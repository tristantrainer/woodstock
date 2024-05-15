Initial Plan: Based on Prototype (project structure based on https://github.com/jasontaylordev/CleanArchitecture)
- CQRS structure
- GraphQL Interface for most web requests, REST for admin related requests
- Query side reading from a NoSQL document database of for cached queries for speed of reads
- Command side writing to a PostgreSQL relational database, then updating cache and notifying listeners via subscriptions (SignalR) when cache is updated

Possible ideas:
- Seperate DI of "external" dependencies to allow for internal integration tests, using the same DI setup for internal services, that are environment agnostic. IDbCollection overlay for DbSet to allow mocking of external database dependency while retaining repository logic (queries) within "internal" scope.


