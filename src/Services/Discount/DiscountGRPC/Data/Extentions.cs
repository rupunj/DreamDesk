using Microsoft.EntityFrameworkCore;

namespace DiscountGRPC.Data;

public static class Extentions
{
    public static IApplicationBuilder UseMigration(this IApplicationBuilder application)
    {
        using var scope = application.ApplicationServices.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<DiscountContext>();
        dbContext.Database.MigrateAsync();
        return application;
    }

}
