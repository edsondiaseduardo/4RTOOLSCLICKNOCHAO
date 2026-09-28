using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using _4RTools.Model;

namespace _4RTools.Utils
{
    // Clica no chão (centro da janela do jogo + offset configurável em GroundClickConfig),
    // usando a mesma técnica do AHK Spammer: move o cursor real e dispara
    // WM_LBUTTONDOWN/UP pra janela do jogo, sem precisar estar em foco.
    public static class GroundClickHelper
    {
        public static bool ClickGroundInFrontOfWindow(Client roClient)
        {
            try
            {
                if (roClient == null) { DebugLog.Write("ClickGround: roClient == null"); return false; }

                IntPtr hWnd = roClient.process.MainWindowHandle;
                if (hWnd == IntPtr.Zero) { DebugLog.Write("ClickGround: hWnd == Zero"); return false; }

                // Guarda onde a janela estava ANTES de mexer em qualquer coisa. Isso é o
                // que permite ela ficar "normal" (visível, no lugar que o usuário deixou)
                // o tempo todo — só vamos mandar ela pro monitor virtual, clicar, e trazer
                // ela de volta pra esse exato lugar logo em seguida. Se ela já estava no
                // monitor virtual (ex: um ciclo anterior não conseguiu devolver por algum
                // motivo), não arriscamos "inventar" uma posição errada pra devolver.
                bool windowRectOk = Interop.GetWindowRect(hWnd, out RECT rectBeforeMove);
                bool wasAlreadyOnVirtual = windowRectOk && VirtualDisplayHelper.IsInsideVirtualDisplay(rectBeforeMove);

                // Antes de clicar, garante que essa janela está dentro do monitor virtual
                // (se o driver estiver instalado/ligado). Se não estiver, move ela pra lá
                // — assim TODO o resto (GetClientRect, ClientToScreen, o pulo de cursor e
                // o clique) acontece num pedaço de tela que não existe fisicamente, e
                // nunca toca na tela de verdade nem em nenhum outro programa que o
                // usuário esteja usando naquele instante.
                EnsureWindowOnVirtualDisplay(hWnd);

                if (!Interop.GetClientRect(hWnd, out RECT rect))
                {
                    DebugLog.Write($"ClickGround: GetClientRect FALHOU (erro Win32={Marshal.GetLastWin32Error()})");
                    return false;
                }

                GroundClickConfig cfg = GroundClickConfig.GetCurrent();

                Point center = new Point(
                    (rect.Right - rect.Left) / 2 + cfg.OffsetX,
                    (rect.Bottom - rect.Top) / 2 + cfg.OffsetY
                );

                Point screenPoint = center;
                if (!Interop.ClientToScreen(hWnd, ref screenPoint))
                {
                    DebugLog.Write($"ClickGround: ClientToScreen FALHOU (erro Win32={Marshal.GetLastWin32Error()})");
                    return false;
                }

                // O jogo tem proteção anti-cheat (Gepard Shield) que ignora clique mandado
                // por PostMessage (não é um clique "de verdade" do ponto de vista do Windows).
                // Por isso usamos mouse_event, que injeta o clique no mesmo nível de um mouse
                // físico de verdade.
                //
                // Ativar a janela (SetForegroundWindow) pra clicar nela sempre vai causar uma
                // troca de tela de verdade (tipo alt+tab), mesmo que rápida — não é o que o
                // usuário quer. Em vez disso, usamos WS_EX_NOACTIVATE: uma "flag" de janela do
                // próprio Windows (não é hack nem injeção, é só mudar um estilo via API
                // pública) que diz "essa janela pode receber clique, mas nunca vira a janela
                // ativa por causa disso" — é a mesma técnica de janelas tipo conta-gotas de
                // cor, que recebem clique sem roubar o foco/teclado de quem tá usando outro
                // programa. Com essa flag ligada, só trazemos a janela pra cima da pilha
                // (SetWindowPos sem ativar) pra ela não ficar escondida atrás da outra no
                // ponto exato do clique, clicamos, e devolvemos a janela anterior pra cima de
                // novo — SEM nunca mexer em qual janela está com o foco/teclado.
                IntPtr previousForeground = Interop.GetForegroundWindow();

                // O WS_EX_NOACTIVATE resolve o foco/teclado, mas o CURSOR do mouse é um só
                // (compartilhado por toda a área de trabalho) — pra clicar num ponto específico
                // com mouse_event, o cursor PRECISA passar por aquele ponto, não tem jeito de
                // "clicar sem mover o cursor de verdade". Por isso guardamos onde o mouse estava
                // antes e devolvemos ele pro lugar certinho logo depois do clique, pra não ficar
                // "preso" na tela do F3 — só um pulo rápido de ida e volta, igual fazemos com a
                // janela.
                Point previousCursorPos = Cursor.Position;

                Interop.SetNoActivateStyle(hWnd, true);
                bool broughtToTopOk = Interop.BringToTopWithoutStealingFocus(hWnd);

                Cursor.Position = screenPoint;
                Thread.Sleep(30);
                Interop.mouse_event(Constants.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                Thread.Sleep(15);
                Interop.mouse_event(Constants.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                Thread.Sleep(20);

                Cursor.Position = previousCursorPos;
                Interop.SetNoActivateStyle(hWnd, false);

                // Se o foco realmente não mudou (é o que a gente espera com WS_EX_NOACTIVATE),
                // isso aqui só traz a janela anterior de volta pra cima visualmente — sem
                // "ativar" nada, porque ela nunca deixou de estar ativa.
                if (previousForeground != IntPtr.Zero && previousForeground != hWnd)
                {
                    Interop.BringToTopWithoutStealingFocus(previousForeground);
                }

                // Confere se a teoria realmente funcionou: se foregroundDepoisDoClique for
                // igual ao previousForeground, quer dizer que o clique NÃO roubou o foco.
                IntPtr foregroundDepoisDoClique = Interop.GetForegroundWindow();
                bool focoFoiPreservado = foregroundDepoisDoClique == previousForeground;

                // Devolve a janela pro lugar de onde ela veio na tela real — assim ela
                // volta a ficar "normal" (visível, clicável, dá pra ver item no chão etc)
                // o resto do tempo, e só ficou fora dali pela fração de segundo do clique.
                if (windowRectOk && !wasAlreadyOnVirtual)
                {
                    Interop.MoveWindowToPosition(hWnd, rectBeforeMove.Left, rectBeforeMove.Top);
                }

                DebugLog.Write($"ClickGround: OK rect=({rect.Left},{rect.Top},{rect.Right},{rect.Bottom}) offset=({cfg.OffsetX},{cfg.OffsetY}) clientPt=({center.X},{center.Y}) screenPt=({screenPoint.X},{screenPoint.Y}) broughtToTopOk={broughtToTopOk} focoFoiPreservado={focoFoiPreservado} previousForeground={previousForeground} foregroundDepois={foregroundDepoisDoClique} cursorDevolvidoPara=({previousCursorPos.X},{previousCursorPos.Y}) janelaDevolvidaPara=({(windowRectOk && !wasAlreadyOnVirtual ? rectBeforeMove.Left : -1)},{(windowRectOk && !wasAlreadyOnVirtual ? rectBeforeMove.Top : -1)}) metodo=WS_EX_NOACTIVATE_com_restauro_de_cursor_e_janela");
                return true;
            }
            catch (Exception ex)
            {
                DebugLog.Write($"ClickGround: EXCEPTION {ex}");
                return false;
            }
        }

        // Garante que a janela do client que recebe o clique automático está posicionada
        // dentro do monitor virtual — fora da área de qualquer tela física. Se o driver
        // do monitor virtual não estiver instalado/ligado, não faz nada (cai pro
        // comportamento antigo, clicando normalmente na tela real).
        private static void EnsureWindowOnVirtualDisplay(IntPtr hWnd)
        {
            try
            {
                Rectangle? virtualBounds = VirtualDisplayHelper.GetVirtualDisplayBounds();
                if (virtualBounds == null) return;

                if (!Interop.GetWindowRect(hWnd, out RECT current))
                {
                    DebugLog.Write($"ClickGround: GetWindowRect FALHOU (erro Win32={Marshal.GetLastWin32Error()})");
                    return;
                }

                Rectangle vb = virtualBounds.Value;
                bool alreadyInside = current.Left >= vb.Left && current.Top >= vb.Top
                    && current.Left < vb.Right && current.Top < vb.Bottom;

                if (alreadyInside) return;

                int targetX = vb.Left;
                int targetY = vb.Top;

                Interop.MoveWindowToPosition(hWnd, targetX, targetY);
                DebugLog.Write($"ClickGround: janela movida pro monitor virtual, novo canto=({targetX},{targetY})");
            }
            catch (Exception ex)
            {
                DebugLog.Write($"ClickGround: EXCEPTION ao mover janela pro monitor virtual {ex}");
            }
        }

        // Devolve o foco pra janela que estava na frente antes do clique (evita que a tela
        // fique "presa" no cliente que acabou de usar a skill).
        public static void RestoreFocus(IntPtr previousForeground, IntPtr justClickedHWnd)
        {
            try
            {
                if (previousForeground == IntPtr.Zero || previousForeground == justClickedHWnd) return;
                Thread.Sleep(30);
                Interop.ForceForegroundWindow(previousForeground);
                DebugLog.Write($"ClickGround: foco devolvido pra hWnd={previousForeground}");
            }
            catch (Exception ex)
            {
                DebugLog.Write($"ClickGround: EXCEPTION ao devolver foco {ex}");
            }
        }
    }
}
