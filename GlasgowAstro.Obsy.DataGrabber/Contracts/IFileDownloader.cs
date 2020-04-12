using System.Threading.Tasks;

namespace GlasgowAstro.Obsy.DataGrabber.Contracts
{
    public interface IFileDownloader
    {
        Task<string> DownloadAsync();
    }
}
