```
dotnet ef migrations add Init -s <PathToStartup> -c <DbContext> -o <PathToMigrationsFolder>
```

```
dotnet ef migrations add Init -s ..\Api -c TrainingDbContext -o Database/Migrations
```
ToDo:
- User
  Add GetCurrentUser ()
  Add UpdateUser ()
  Add change password
  Add Edit User