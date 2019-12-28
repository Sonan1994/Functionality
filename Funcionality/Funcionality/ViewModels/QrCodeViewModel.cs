using Funcionality.Interface;
using System;
using System.Windows.Input;
using Funcionality.ViewModels.Base;
using Xamarin.Forms;

namespace Funcionality.ViewModels
{
    public class QrCodeViewModel : ViewModelBase
    {
        private string qrCodeScanResult;

        public QrCodeViewModel()
        {
            ScanQrCodeCommand = new Command(ScanQrCodeCommandHandler);
        }

        #region Command

        public ICommand ScanQrCodeCommand { get; set; }

        #endregion

        #region Properties

        public string QrCodeScanResult
        {
            get
            {
                return qrCodeScanResult;
            }

            set
            {
                qrCodeScanResult = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Command handlers

        private async void ScanQrCodeCommandHandler()
        {
            try
            {
                var scanner = DependencyService.Get<IQrCodeScannerService>();
                string result = await scanner.ScanAsync();

                bool isResultValid = result != null;
                QrCodeScanResult = isResultValid ? result : string.Empty;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion
    }
}
