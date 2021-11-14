using System.Threading.Tasks;

namespace GlasgowAstro.Obsy.Bot.Helpers
{
    public static class TaskExt
    {
        public static async Task<(Task<T0>, Task<T1>)> WhenAll<T0, T1>(Task<T0> task0, Task<T1> task1)
        {
            await Task.WhenAll(task0, task1).ConfigureAwait(false);
            return (task0, task1);
        }
    }
}