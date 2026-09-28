namespace _4RTools.Utils
{
    // Trava compartilhada entre os Skill Timers: garante que a tecla (+ clique, quando
    // marcado) de um timer termine antes de outro timer começar a apertar a tecla dele.
    // Sem isso, um timer rápido (ex: 5s) pode "cortar" no meio da ação de um timer lento
    // (ex: 4min com clique no chão) e embaralhar tecla/clique dos dois.
    public static class ActionLock
    {
        public static readonly object Sync = new object();
    }
}
