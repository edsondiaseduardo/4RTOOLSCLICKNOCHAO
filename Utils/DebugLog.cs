using System;
using System.IO;

namespace _4RTools.Utils
{
    // Log temporário só pra diagnosticar o "Clicar no chão" (grava em
    // ground_click_debug.log, na pasta onde o 4RTools.exe está rodando).
    public static class DebugLog
    {
        private const string fileName = "ground_click_debug.log";
        private static readonly object sync = new object();

        public static void Write(string message)
        {
            try
            {
                lock (sync)
                {
                    File.AppendAllText(fileName, $"{DateTime.Now:HH:mm:ss.fff} - {message}{Environment.NewLine}");
                }
            }
            catch
            {
                // não deixa o log derrubar nada
            }
        }
    }
}
