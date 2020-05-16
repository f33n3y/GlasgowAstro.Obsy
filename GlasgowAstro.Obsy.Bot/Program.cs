using System.Threading.Tasks;

namespace GlasgowAstro.Obsy.Bot
{
    public class Program
    {
        public static async Task Main(string[] args) =>
            await Startup.RunAsync(args);
    }
}
