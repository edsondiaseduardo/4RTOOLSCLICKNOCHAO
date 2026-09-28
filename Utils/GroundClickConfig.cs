using Newtonsoft.Json;
using System.IO;

namespace _4RTools.Utils
{
    // Configuração compartilhada do "clique no chão" (usada por qualquer Skill Timer
    // que tenha a opção "Clicar no chão" marcada). Fica salva num arquivinho local
    // (ground_click_config.json) pra poder ser ajustada pela tela sem recompilar.
    public class GroundClickConfig
    {
        private static readonly string fileName = "ground_click_config.json";
        private static GroundClickConfig _current;

        public int OffsetX { get; set; } = 0;
        public int OffsetY { get; set; } = 50;
        public int DelayMs { get; set; } = 250;

        public static GroundClickConfig GetCurrent()
        {
            if (_current != null) return _current;

            try
            {
                if (File.Exists(fileName))
                {
                    _current = JsonConvert.DeserializeObject<GroundClickConfig>(File.ReadAllText(fileName)) ?? new GroundClickConfig();
                }
                else
                {
                    _current = new GroundClickConfig();
                }
            }
            catch
            {
                _current = new GroundClickConfig();
            }

            return _current;
        }

        public void Save()
        {
            _current = this;
            try
            {
                File.WriteAllText(fileName, JsonConvert.SerializeObject(this, Formatting.Indented));
            }
            catch { }
        }
    }
}
