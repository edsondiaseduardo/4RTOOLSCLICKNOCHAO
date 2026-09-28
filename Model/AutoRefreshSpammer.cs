using System;
using System.Threading;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Newtonsoft.Json;
using _4RTools.Utils;

namespace _4RTools.Model
{
    public class AutoRefreshSpammer : Action
    {
        private _4RThread thread;
        public string ActionName { get; set; }
        public int RefreshDelay { get; set; } = 5;
        public Key RefreshKey { get; set; }

        // Quando true, depois de apertar a tecla o timer também clica no chão
        // (centro da janela do jogo + offset), sem precisar segurar nenhuma tecla.
        public bool ClickOnGround { get; set; } = false;

        public AutoRefreshSpammer(string actionName)
        {
            this.ActionName = actionName;
        }

        public void Start()
        {
            Client roClient = ClientSingleton.GetClient();
            if (roClient != null)
            {
                const int defaultDelayInSeconds = 1000;
                int delayInSeconds = this.RefreshDelay * 1000;
                int delay = delayInSeconds == 0 ? defaultDelayInSeconds : delayInSeconds;
                this.thread = new _4RThread(_ => AutorefreshThreadExecution(roClient, delay));
                _4RThread.Start(this.thread);
            }
        }

        // Quantas vezes tenta repetir tecla+clique seguidas antes de desistir desse ciclo
        // (protege contra a skill não ter "pegado" no primeiro clique).
        private const int GROUND_CLICK_RETRY_ATTEMPTS = 3;
        private const int GROUND_CLICK_RETRY_INTERVAL_MS = 400;

        private int AutorefreshThreadExecution(Client roClient, int delay)
        {
            if (this.RefreshKey != Key.None)
            {
                // A trava garante que outro Skill Timer (ex: uma skill de 5s) não aperte a
                // tecla dele bem no meio da tecla+clique desse timer, embaralhando os dois.
                lock (ActionLock.Sync)
                {
                    if (this.ClickOnGround)
                    {
                        IntPtr hWnd = roClient.process.MainWindowHandle;

                        DebugLog.Write($"[{this.ActionName}] entrou no ciclo ClickOnGround, tecla={this.RefreshKey}, hWnd={hWnd}");
                        for (int attempt = 1; attempt <= GROUND_CLICK_RETRY_ATTEMPTS; attempt++)
                        {
                            bool keyOk = Interop.PostMessage(hWnd, Constants.WM_KEYDOWN_MSG_ID, (Keys)Enum.Parse(typeof(Keys), this.RefreshKey.ToString()), 0);
                            DebugLog.Write($"[{this.ActionName}] tentativa {attempt}: PostMessage tecla {this.RefreshKey} retornou {keyOk}");
                            Thread.Sleep(GroundClickConfig.GetCurrent().DelayMs);
                            GroundClickHelper.ClickGroundInFrontOfWindow(roClient);

                            if (attempt < GROUND_CLICK_RETRY_ATTEMPTS)
                            {
                                Thread.Sleep(GROUND_CLICK_RETRY_INTERVAL_MS);
                            }
                        }
                    }
                    else
                    {
                        Interop.PostMessage(roClient.process.MainWindowHandle, Constants.WM_KEYDOWN_MSG_ID, (Keys)Enum.Parse(typeof(Keys), this.RefreshKey.ToString()), 0);
                    }
                }
            }
            Thread.Sleep(delay);
            return 0;
        }

        public void Stop()
        {
            _4RThread.Stop(this.thread);
        }

        public string GetConfiguration()
        {
            return JsonConvert.SerializeObject(this);
        }

        public string GetActionName()
        {
            return this.ActionName;
        }
    }
}
