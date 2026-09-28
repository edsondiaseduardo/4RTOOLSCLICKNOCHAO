using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace _4RTools.Utils
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }

    internal class Interop
    {
        // PINVOKES
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool PostMessage(IntPtr hWnd, int Msg, Keys wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, int dwExtraInfo);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool ClientToScreen(IntPtr hWnd, ref System.Drawing.Point lpPoint);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        // Usados só pra "forçar" o SetForegroundWindow a funcionar (o Windows bloqueia
        // um programa em segundo plano de roubar o foco na maioria das vezes, a não ser
        // que a gente "empreste" a fila de input da janela que está em foco no momento).
        [DllImport("user32.dll")]
        public static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);

        [DllImport("kernel32.dll")]
        public static extern uint GetCurrentThreadId();

        [DllImport("user32.dll")]
        public static extern bool BringWindowToTop(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        // GetWindowLongPtr/SetWindowLongPtr só existem de verdade em user32 de 64 bits;
        // em 32 bits usamos GetWindowLong/SetWindowLong mesmo (mesmo nome de API antiga).
        // Isso deixa o código funcionando tanto compilado como x86 quanto x64.
        [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr", SetLastError = true)]
        private static extern IntPtr GetWindowLongPtr64(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "GetWindowLong", SetLastError = true)]
        private static extern int GetWindowLong32(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr", SetLastError = true)]
        private static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong", SetLastError = true)]
        private static extern int SetWindowLong32(IntPtr hWnd, int nIndex, int dwNewLong);

        private static IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex)
        {
            return IntPtr.Size == 8 ? GetWindowLongPtr64(hWnd, nIndex) : new IntPtr(GetWindowLong32(hWnd, nIndex));
        }

        private static IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong)
        {
            return IntPtr.Size == 8 ? SetWindowLongPtr64(hWnd, nIndex, dwNewLong) : new IntPtr(SetWindowLong32(hWnd, nIndex, dwNewLong.ToInt32()));
        }

        private const int GWL_EXSTYLE = -20;
        private const long WS_EX_NOACTIVATE = 0x08000000L;

        // Liga/desliga a "flag" de janela WS_EX_NOACTIVATE. Com ela ligada, o Windows NÃO
        // ativa essa janela mesmo que ela receba um clique de verdade (mouse_event) — é a
        // mesma técnica que janelinhas de overlay (ex: conta-gotas de cor) usam pra
        // receberem clique sem tirar o foco/teclado de quem está usando outro programa.
        // Isso NÃO é hack/injeção: é só mudar um estilo da janela via API pública do
        // Windows, de fora do processo do jogo (igual GetClientRect, mouse_event etc.).
        public static bool SetNoActivateStyle(IntPtr hWnd, bool enable)
        {
            IntPtr current = GetWindowLongPtr(hWnd, GWL_EXSTYLE);
            long currentValue = current.ToInt64();
            long newValue = enable ? (currentValue | WS_EX_NOACTIVATE) : (currentValue & ~WS_EX_NOACTIVATE);
            SetWindowLongPtr(hWnd, GWL_EXSTYLE, new IntPtr(newValue));
            return true;
        }

        public const int SW_RESTORE = 9;
        public const int SW_SHOWNA = 8; // mostra a janela (tira de minimizada) sem ativar/roubar o foco
        private static readonly IntPtr HWND_TOP = IntPtr.Zero;
        private const uint SWP_NOMOVE = 0x0002;
        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOACTIVATE = 0x0010; // essa é a chave: traz a janela pra cima visualmente, sem ativar ela (sem roubar o teclado/foco de quem está jogando em outra janela)

        // Traz a janela pra cima da pilha (visualmente, pra não ficar escondida atrás de
        // outro client) SEM ativar ela e SEM roubar o foco/teclado de quem está jogando
        // em outra janela ao mesmo tempo.
        public static bool BringToTopWithoutStealingFocus(IntPtr hWnd)
        {
            ShowWindow(hWnd, SW_SHOWNA);
            return SetWindowPos(hWnd, HWND_TOP, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE);
        }

        // Move a janela pra uma posição específica da área de trabalho virtual do Windows
        // (que agora inclui o monitor virtual), SEM mudar o tamanho dela e SEM ativar
        // ela/roubar foco — usado pra levar o client que recebe clique automático pra
        // dentro do monitor virtual, que não existe fisicamente em lugar nenhum.
        public static bool MoveWindowToPosition(IntPtr hWnd, int x, int y)
        {
            return SetWindowPos(hWnd, HWND_TOP, x, y, 0, 0, SWP_NOSIZE | SWP_NOACTIVATE);
        }

        // Tenta forçar a janela do jogo pra frente, driblando o bloqueio padrão do Windows.
        public static bool ForceForegroundWindow(IntPtr hWnd)
        {
            IntPtr foreground = GetForegroundWindow();
            uint foregroundThreadId = GetWindowThreadProcessId(foreground, IntPtr.Zero);
            uint targetThreadId = GetWindowThreadProcessId(hWnd, IntPtr.Zero);
            uint currentThreadId = GetCurrentThreadId();

            bool attachedToForeground = foregroundThreadId != currentThreadId && AttachThreadInput(currentThreadId, foregroundThreadId, true);
            bool attachedToTarget = targetThreadId != currentThreadId && AttachThreadInput(currentThreadId, targetThreadId, true);

            ShowWindow(hWnd, SW_RESTORE);
            BringWindowToTop(hWnd);
            bool ok = SetForegroundWindow(hWnd);

            if (attachedToForeground) AttachThreadInput(currentThreadId, foregroundThreadId, false);
            if (attachedToTarget) AttachThreadInput(currentThreadId, targetThreadId, false);

            return ok;
        }
    }
}
