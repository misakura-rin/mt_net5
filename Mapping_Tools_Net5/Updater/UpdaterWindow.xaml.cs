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
            Dispatcher.Invoke(() => progressBar.Value = progress);
        }

        private void OnReadyToUpdate(object sender, EventArgs e) {
        }
    }
}