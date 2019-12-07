using Funcionality.Interface;
using Plugin.DownloadManager;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Funcionality.ViewModels
{
    public class QrCodeViewModel : INotifyPropertyChanged
    {
        private string qrCodeScanResult;
        private bool isDownloadButtonEnabled;

        public QrCodeViewModel()
        {
            ScanQrCodeCommand = new Command(ScanQrCodeCommandHandler);
            DownloadBookCommand = new Command(DownloadBookHandler);
        }

        #region Command

        public ICommand ScanQrCodeCommand { get; set; }

        public ICommand DownloadBookCommand { get; set; }

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
                OnPropertyChanged(nameof(QrCodeScanResult));
            }
        }

        public bool IsDownloadButtonEnabled
        {
            get
            {
                return isDownloadButtonEnabled;
            }

            set
            {
                isDownloadButtonEnabled = value;
                OnPropertyChanged(nameof(IsDownloadButtonEnabled));
            }
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
                IsDownloadButtonEnabled = isResultValid;
                QrCodeScanResult = isResultValid ? result : string.Empty;
            }
            catch (Exception ex)
            {
                //Log exception
                throw;
            }
        }

        private void DownloadBookHandler()
        {
            try
            {
                Plugin.DownloadManager.Abstractions.IDownloadManager downloadManager = CrossDownloadManager.Current;
                Plugin.DownloadManager.Abstractions.IDownloadFile file = downloadManager.CreateDownloadFile(QrCodeScanResult);
                downloadManager.Start(file);
            }
            catch
            {
                //Log exception
                throw;
            }
        }

        #endregion
    }
}
