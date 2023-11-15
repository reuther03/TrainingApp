```
dotnet ef migrations add Init -s <PathToStartup> -c <DbContext> -o <PathToMigrationsFolder>
```

```
dotnet ef migrations add Init -s ..\Api -c TrainingDbContext -o Database/Migrations
```
ToDo:
    show user training plans created by himself and admin / same for exercises
    try to plan Trainigns