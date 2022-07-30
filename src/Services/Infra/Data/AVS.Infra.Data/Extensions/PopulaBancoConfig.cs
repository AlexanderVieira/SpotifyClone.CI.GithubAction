using AVS.Infra.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace AVS.Core.Extensions
{
    public static class PopulaBancoConfig
    {
        public static IApplicationBuilder UseItToSeedSqlServer(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app, nameof(app));
            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var ctx = services.GetRequiredService<SpotifyCloneContext>();
                PopulaBanco.Popular(ctx);
            }
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
                throw;
            }

            return app;
        }
    }
}
