using Onova;
using Onova.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mapping_Tools_Net5.Updater {

    public interface IUpdateManager {
        Progress<double> Progress { get; }
        IPackageResolver PackageResolver { get; set; }
        EventWaitHandle Lock { get; }
        bool RestartAfterUpdate { get; set; }

        event EventHandler<bool> HasFetchedUpdates;

        event EventHandler IsReadyToUpdate;

        Task InitUpdateAsync();
    }

    public class UpdateManager :IUpdateManager {
        public Progress<double> Progress { get; } = new Progress<double>();
        public IPackageResolver PackageResolver { get; set; }
        public EventWaitHandle Lock { get; } = new EventWaitHandle(false, EventResetMode.AutoReset);
        public bool RestartAfterUpdate { get; set; }

        public event EventHandler<bool> HasFetchedUpdates;

        public event EventHandler IsReadyToUpdate;

        public UpdateManager(IPackageResolver packageResolver) {
            PackageResolver = packageResolver;
        }

        public UpdateManager(string repoOwner, string repoName, string assetNamePattern) {
            PackageResolver = new GithubPackageResolver(repoOwner, repoName, assetNamePattern);
        }

        /// <summary>
        /// Initializes updater
        /// </summary>
        /// <exception cref="LockFileNotAcquiredException"></exception>
        /// <exception cref="UpdaterAlreadyLaunchedException "></exception>
        /// <returns>True if there are new updates and the updater could successfully launch itself and false if there are no new updates.</returns>
        public async Task InitUpdateAsync() {
            using var manager = new Onova.UpdateManager(PackageResolver, new ZipPackageExtractor());

            var result = await manager.CheckForUpdatesAsync();

            if( result.CanUpdate ) {
                HasFetchedUpdates?.Invoke(this, true);

                await manager.PrepareUpdateAsync(result.LastVersion, Progress);

                IsReadyToUpdate?.Invoke(this, null);

                Lock.WaitOne();

                manager.LaunchUpdater(result.LastVersion, RestartAfterUpdate);

                return;
            }

            HasFetchedUpdates?.Invoke(this, false);
        }
    }
}