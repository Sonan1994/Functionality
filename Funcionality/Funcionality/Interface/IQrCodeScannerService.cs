using System.Threading.Tasks;

namespace Funcionality.Interface
{
    public interface IQrCodeScannerService
    {
        Task<string> ScanAsync();
    }
}
