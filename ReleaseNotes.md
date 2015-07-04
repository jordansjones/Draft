### New in 1.0.0 (Release 2015/07/03)
* New: `EndpointVerificationStrategy.ClusterMembers` - Similar verification as `EndpointVerificationStrategy.Any` but also adds verified cluster members to the `EndpointPool`.
* New: `IEtcdClient.Statistics`
	* `GetLeaderStatistics` - Retrieve the statistical information for leader of the etcd cluster
	* `GetServerStatistics` - Retrieve the statistical information for the server (Which server depends on how the `EndpointPool` was built)
	* `GetStoreStatistics` - Retrieve the etcd backing store statistics (For which server depends on how the `EndpointPool` was built)
* Breaking Change: `IEtcdClient.Enqueue` has been moved to `IEtcdClient.Atomic.Enqueue`
* Breaking Change: `IKeyDataValueConverter` overhaul
	* `object ReadString(string value)` has been refactored into `T Read<T>(string value)`
	* `string WriteString(object value)` has been refactored into `string Write<T>(T value)`
* Change: The following have been annotated with `[Serializable]`
	* `Endpoint`
	* `EndpointPool`
	* `EndpointRoutingStrategy`
	* `EndpointVerificationStrategy`

### New in 0.2.1 (Released 2015/05/07)
* Fixed: `NullReferenceException` thrown when a `WebException` occurs due to a client connection problem.

### New in 0.2.0 (Released 2015/04/26)
* New: Support for multiple etcd endpoints
	* Includes verifying endpoint availability
	* Includes mechanisms for calling different endpoints 

### New in 0.1.1 (Released 2015/03/15)
* Fixed: Passing `false` into `WithExisting` is no longer ignored and results in `prevExist=false` being passed in the call.
* Fixed: Misuse of the `waitIndex` parameter during `Watch`/`WatchOnce` calls. Now will increment value passed to `WithModifiedIndex` until the value matches what is returned in the `X-Etcd-Index` header.

### New in 0.1.0 (Released 2015/02/20)
* Initial release
