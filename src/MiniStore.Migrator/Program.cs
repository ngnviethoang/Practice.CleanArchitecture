using Microsoft.EntityFrameworkCore;
using MiniStore.Migrator.ConfigurationOptions;
using MiniStore.Persistence;
using AssemblyReference = MiniStore.Migrator.AssemblyReference;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

AppSettings appSettings = new();
builder.Configuration.Bind(appSettings);

builder.Services.AddDbContext<MiniStoreDbContext>(options => options.UseSqlServer(appSettings.ConnectionStrings["Default"], sql => { sql.MigrationsAssembly(AssemblyReference.Assembly); }));

IHost app = builder.Build();
await app.RunAsync();

/*

bool hasError = false;
foreach ((string tenantName, string connectionString) in appSettings.ConnectionStrings)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"===== Migrating tenant: {tenantName} =====");
    Console.ResetColor();

    UpgradeEngine upgrader = DeployChanges.To
        .SqlDatabase(connectionString)
        .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
        .LogToConsole()
        .Build();

    DatabaseUpgradeResult result = upgrader.PerformUpgrade();

    if (!result.Successful)
    {
        hasError = true;

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"❌ Migration FAILED for tenant: {tenantName}");
        Console.WriteLine(result.Error);
        Console.ResetColor();
        continue;
    }

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"✅ Migration SUCCESS for tenant: {tenantName}");
    Console.ResetColor();
}

if (hasError)
{
    Environment.ExitCode = -1;
}

Console.WriteLine("All migrations completed.");
*/