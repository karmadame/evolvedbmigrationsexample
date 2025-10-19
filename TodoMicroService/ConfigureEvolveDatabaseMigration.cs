using EvolveDb;
using Npgsql;

namespace TodoMicroService;

public static class ConfigureEvolveDatabaseMigration
{
    public static void ConfigureEvolveMigration(this IServiceCollection builder, IConfiguration configuration)
    {
        var logger = builder.BuildServiceProvider().GetRequiredService<ILogger<Program>>(); 
        try
        {
            var cnx = new NpgsqlConnection(configuration["npsqlconnection"]);
            var evolve = new Evolve(cnx, msg => logger.LogInformation(msg))
            {
                Locations = ["db/migrations"],
                IsEraseDisabled = true,
                MetadataTableSchema = "public"
            };

            evolve.Migrate();
        }
        catch (Exception ex)
        {
            logger.LogCritical(ex.Message);
            throw;
        }
    }
}