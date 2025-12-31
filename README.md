# 1. Knowledge notebook

## 1.1. Struct clean architecture

## 1.2. Transaction isolation levels

https://www.geeksforgeeks.org/dbms/transaction-isolation-levels-dbms/

## 1.3. DateTimeProvider, DateTimeOffset

https://www.linkedin.com/pulse/s%25E1%25BB%25AD-d%25E1%25BB%25A5ng-datetimenow-l%25E1%25BB%2597i-ti%25E1%25BB%2581m-%25E1%25BA%25A9n-c%25E1%25BB%25A7a-h%25E1%25BB%2587-th%25E1%25BB%2591ng-son-do-fl09c/?trackingId=II4yYX17S9i5t562GID9lg%3D%3D

## 1.4. ABP DDD best practices

https://abp.io/docs/latest/framework/architecture/best-practices

## 1.5. Controller vs ControllerBase, ApiController Attributes

https://learn.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-10.0

## 1.6. Handling Concurrency Conflicts => RowVersion

https://learn.microsoft.com/en-us/ef/core/saving/concurrency?tabs=data-annotations

## 1.6. Disposabale

https://www.facebook.com/share/p/1AJ7kJkCua/

## 1.7. EF Core

https://learn.microsoft.com/en-us/ef/core/

### 1.7.1. DbContext Lifetime, Configuration, and Initialization

https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/

### 1.7.1. Query data

- Loading:
    + Eager loading
    + Explicit loading
    + Lazy loading

- AsNoTracking, AsSplitQuery

- Dynamically-constructed queries
    + Expression API with constant
    + Expression API with parameter
    + Simple with parameter
    +
- EF.Constants()
-

### 1.7.2. Multi tenant
https://learn.microsoft.com/en-us/ef/core/miscellaneous/multitenancy
#### Multi-Tenant Data Isolation Approaches

| Approach               | Column for Tenant? | Schema per Tenant? | Multiple Databases? | EF Core Support     |
|------------------------|--------------------|--------------------|---------------------|---------------------|
| Discriminator (column) | Yes                | No                 | No                  | Global query filter |
| Database per tenant    | No                 | No                 | Yes                 | Configuration       |
| Schema per tenant      | No                 | Yes                | No                  | Not supported       |

## 1.8. Circuit Breaker Pattern
https://www.geeksforgeeks.org/system-design/what-is-circuit-breaker-pattern-in-microservices/

# 2. Usecase project

## 2.1. Audit log

## 2.2. Message bus, background service

## 2.3. Rate limit

## 2.4. File management, chunks, encryption (EncryptionKey, EncryptionIV)


