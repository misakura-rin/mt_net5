using System;
using System.Windows;
using System.Windows.Threading;

namespace Mapping_Tools_Net5.Updater {

    public partial class UpdaterWindow :Window {
        private readonly IUpdateManager _updateManager;

        public UpdaterWindow(IUpdateManager updateManager) {
            InitializeComponent();

            _updateManager = updateManager;

            _updateManager.Progress.ProgressChanged += OnDownloadProgressChanged;
            _updateManager.IsReadyToUpdate += OnReadyToUpdate;
        }

        public async void StartUpdateProcess() {
            try {
                await _updateManager.StartUpdateAsync();
            }
            catch( Exception e ) {
                MessageBox.Show(e.Message);
            }
        }

        private void OnDownloadProgressChanged(object sender, double progress) {
            Dispatcher.Invoke(() => ProgressBar.Value = progress);
        }

        private void OnReadyToUpdate(object sender, EventArgs e) {
            Dispatcher.Invoke(() => {
                ReadyPanel.Visibility = Visibility.Visible;
                DownloadText.Visibility = Visibility.Hidden;
                ProgressBar.Visibility = Visibility.Hidden;
            });
        }

        private void RestartBtn_Click(object sender, RoutedEventArgs e) {
            _updateManager.RestartAfterUpdate = true;
            _updateManager.Lock.Set();
            Dispatcher.Invoke(() => Close());
        }

        private void WaitBtn_Click(object sender, RoutedEventArgs e) {
            _updateManager.Lock.Set();
            Dispatcher.Invoke(() => Close());
        }

        private void SkipBtn_Click(object sender, RoutedEventArgs e) {
            Dispatcher.Invoke(() => Close());
        }
    }
}