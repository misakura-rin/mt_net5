using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Mapping_Tools_Net5.Updater {

    /// <summary>
    /// Interaktionslogik für Updater.xaml
    /// </summary>
    public partial class UpdaterWindow :Window {
        private readonly IUpdateManager _updateManager;

        public UpdaterWindow(IUpdateManager updateManager) {
            InitializeComponent();

            _updateManager = updateManager;

            _updateManager.IsReadyToUpdate += OnReadyToUpdate;
            _updateManager.Progress.ProgressChanged += OnDownloadProgressChanged;
        }

        private void OnDownloadProgressChanged(object sender, double progress) {
            progressBar.Value = progress;
        }

        private void OnReadyToUpdate(object sender, EventArgs e) {
        }
    }
}