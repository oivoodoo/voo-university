namespace Voo.Migration
{
    internal class Program
    {
        private static void Main()
        {
            var manager = new TaskManager();
            manager.RunTasks();
        }
    }
}