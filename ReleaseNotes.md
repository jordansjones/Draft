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
