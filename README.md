Draft
====
[![Build status](https://ci.appveyor.com/api/projects/status/ptna69f3j0vkh35b/branch/master?svg=true)](https://ci.appveyor.com/project/jordansjones/draft/branch/master)

An [etcd](https://github.com/coreos/etcd) client library for .Net

Get it on NuGet:

`PM> Install-Package Draft`

# Basic usage #

**Initialize the Client**
```cs
var client = Draft.Etcd.ClientFor(new Uri("http://localhost:4001"));
```

**Initialize the Client with multiple endpoints**
```cs
var endpointPool = await Draft.Endpoints.EndpointPool.Build()
	.WithRoutingStrategy(Draft.Endpoints.EndpointRoutingStrategy.RoundRobin)
	.WithVerificationStrategy(Draft.Endpoints.EndpointVerificationStrategy.All)
	.VerifyAndBuild(
		new Uri("http://localhost:4001"), 
		new Uri("http://localhost:4002"), 
		new Uri("http://localhost:5002")
	);
var client = Draft.Etcd.ClientFor(endpointPool);
```

## Key based operations ##

**Set a key**
```cs
var keyResult = await client
                .UpsertKey("/somekey")
                .WithValue("The Value!");
```

**Set a key with an expiration**
```cs
var keyResult = await client
                .UpsertKey("/expiringkey")
                .WithValue("I Expire!")
                .WithTimeToLive(300 /* seconds */);
```

**Get a key**
```cs
var keyResult = await client
                .GetKey("/somekey");
```

**Get a key with a fully linearized read**
```cs
var keyResult = await client
                .GetKey("/somekey")
                .WithQuorum(true);
```

**Delete a key**
```cs
await client.DeleteKey("/somekey");
```

**Create a directory**
```cs
var dirResult = await client
                .CreateDirectory("/foo");
```

**Create an expiring directory**
```cs
var dirResult = await client
                .CreateDirectory("/foo")
                .WithTimeToLive(300 /* seconds */);
```

**Watch a key for a single change**
```cs
client.WatchOnce("/somekey")
    .Subscribe(x => { /* do the thing */ });
```

**Monitor a key and child keys for changes**
```cs
client.Watch("/somekey")
    .WithRecursive(true)
    .Subscribe(x => { /* do the thing */ });
```

**Stop monitoring key changes**
```cs
var disposable = client.Watch("/somekey")
                    .WithRecursive(true)
                    .Subscribe(x => { /* do the thing */ });

disposable.Dispose();
```

## Atomic Key based operations ##

**Update a key with an expected value**
```cs
var result = await client
            .Atomic
            .CompareAndSwap("/atomickey")
            .WithExpectedValue("foo")
            .WithNewValue("bar");

```

**Delete a key with an expected modified index**
```cs
var result = await client
            .Atomic
            .CompareAndDelete("/atomickey")
            .WithExpectedIndex(33);

```

## Cluster based operations ##

**Get cluster members**
```cs
var members = await client
                .Cluster
                .GetMembers();
```

**Get cluster leader**
```cs
var leader = await client
                .Cluster
                .GetLeader();
```

**Add a cluster member**
```cs
var memberInfo = await client
                .Cluster
                .CreateMember()
                .WithPeerUri(
					new Uri("http://localhost:4002"), 
					new Uri("http://localhost:5002")
				);
```

**Remove a cluster member**
```cs
await client
    .Cluster
    .DeleteMember()
    .WithMemberId(memberInfo.Id);
```
