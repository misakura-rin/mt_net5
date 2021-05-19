using Onova;
using Onova.Models;
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
        CheckForUpdatesResult UpdatesResult { get; }

        event EventHandler IsReadyToUpdate;

        Task<bool> FetchUpdateAsync();

        Task StartUpdateAsync();
    }

    public class UpdateManager :IUpdateManager {
        public Progress<double> Progress { get; } = new Progress<double>();
        public IPackageResolver PackageResolver { get; set; }
        public EventWaitHandle Lock { get; } = new EventWaitHandle(false, EventResetMode.AutoReset);
        public bool RestartAfterUpdate { get; set; }
        public CheckForUpdatesResult UpdatesResult { get; private set; }

        public event EventHandler<bool> HasFetchedUpdates;

        public event EventHandler IsReadyToUpdate;

        public UpdateManager(IPackageResolver packageResolver) {
            PackageResolver = packageResolver;
        }

        public UpdateManager(string repoOwner, string repoName, string assetNamePattern) {
            PackageResolver = new GithubPackageResolver(repoOwner, repoName, assetNamePattern);
        }

        /// <exception cref="LockFileNotAcquiredException"></exception>
        /// <exception cref="UpdaterAlreadyLaunchedException "></exception>
        public async Task<bool> FetchUpdateAsync() {
            using var manager = new Onova.UpdateManager(PackageResolver, new ZipPackageExtractor());

            UpdatesResult = await manager.CheckForUpdatesAsync();

            return UpdatesResult.CanUpdate;
        }

        /// <exception cref="Onova.Exceptions.LockFileNotAcquiredException"></exception>
        /// <exception cref="Onova.Exceptions.UpdaterAlreadyLaunchedException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task StartUpdateAsync() {
            if( UpdatesResult == null ) {
                throw new InvalidOperationException("Do not call this method before fetching updates!");
            }

            if( !UpdatesResult.CanUpdate ) {
                throw new InvalidOperationException("Do not call this method if there are no updates!");
            }

            using var manager = new Onova.UpdateManager(PackageResolver, new ZipPackageExtractor());

            await manager.PrepareUpdateAsync(UpdatesResult.LastVersion, Progress);

            IsReadyToUpdate?.Invoke(this, null);

            Lock.WaitOne();

            manager.LaunchUpdater(UpdatesResult.LastVersion, RestartAfterUpdate);
        }
    }
}