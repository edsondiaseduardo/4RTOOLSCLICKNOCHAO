using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace _4RTools.Utils
{
    // Encontra o monitor virtual (o "VDD by MTT" que aparece em Configurações > Tela)
    // pra que a gente possa mover a janela do client que recebe clique automático pra lá.
    //
    // Um monitor virtual não existe fisicamente — nenhuma tela de verdade mostra ele —
    // então qualquer pulo de cursor/clique que a gente faça "nele" nunca aparece pro
    // usuário nem interfere com o mouse real ou com qualquer outro programa que ele
    // esteja usando (Discord, navegador, outro client que ele esteja jogando ativamente
    // de verdade etc). É a diferença entre "o clique acontece numa tela que ninguém
    // olha" e "o clique acontece na tela de verdade e volta rápido".
    public static class VirtualDisplayHelper
    {
        private static Rectangle? _cachedVirtualBounds;
        private static DateTime _lastCheck = DateTime.MinValue;
        private static readonly TimeSpan CacheDuration = TimeSpan.FromSeconds(10);

        // Retorna os limites (Bounds) do monitor virtual, ou null se não encontrar
        // nenhum monitor secundário (ex: driver desligado ou não instalado — nesse caso
        // o comportamento cai pro antigo, clicando na tela real mesmo).
        public static Rectangle? GetVirtualDisplayBounds()
        {
            if (_cachedVirtualBounds.HasValue && (DateTime.Now - _lastCheck) < CacheDuration)
                return _cachedVirtualBounds;

            try
            {
                Screen[] screens = Screen.AllScreens;

                // O .NET não expõe o nome amigável do monitor ("VDD by MTT") por aqui,
                // só o DeviceName tipo "\\.\DISPLAY2". Por isso usamos a heurística mais
                // simples e robusta: qualquer tela que NÃO seja a primária é o monitor
                // virtual, já que o usuário só tem 1 monitor físico real (o AW2521HF).
                Screen virtualScreen = screens.FirstOrDefault(s => !s.Primary);

                if (virtualScreen == null)
                {
                    DebugLog.Write("VirtualDisplayHelper: nenhum monitor secundario encontrado (driver VDD desligado ou nao instalado?)");
                    _cachedVirtualBounds = null;
                }
                else
                {
                    _cachedVirtualBounds = virtualScreen.Bounds;
                    DebugLog.Write($"VirtualDisplayHelper: monitor virtual encontrado deviceName={virtualScreen.DeviceName} bounds=({virtualScreen.Bounds.X},{virtualScreen.Bounds.Y},{virtualScreen.Bounds.Width}x{virtualScreen.Bounds.Height})");
                }

                _lastCheck = DateTime.Now;
                return _cachedVirtualBounds;
            }
            catch (Exception ex)
            {
                DebugLog.Write($"VirtualDisplayHelper: EXCEPTION {ex}");
                return null;
            }
        }

        // Diz se o canto (Left,Top) de uma janela já está dentro do monitor virtual.
        // Usado tanto pra decidir se precisa mover a janela pra lá, quanto pra saber (na
        // volta) se ela realmente estava na tela real antes — e por isso é seguro
        // devolver ela pro lugar de onde veio.
        public static bool IsInsideVirtualDisplay(RECT rect)
        {
            Rectangle? virtualBounds = GetVirtualDisplayBounds();
            if (virtualBounds == null) return false;

            Rectangle vb = virtualBounds.Value;
            return rect.Left >= vb.Left && rect.Top >= vb.Top
                && rect.Left < vb.Right && rect.Top < vb.Bottom;
        }
    }
}
