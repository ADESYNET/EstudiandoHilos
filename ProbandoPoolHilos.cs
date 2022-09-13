namespace EstudiandoHilos
{
    internal class ProbandoPoolHilos
    {
        
        public void EjecutarProceso(int a)
        {
            Console.WriteLine($"Thread n°: {Thread.CurrentThread.ManagedThreadId} ha comenzado la tarea {a}");

            Thread.Sleep(1000);

            Console.WriteLine($"Thread n°: {Thread.CurrentThread.ManagedThreadId} ha terminado la tarea {a}");

        }
    }


}
