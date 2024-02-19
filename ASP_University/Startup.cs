public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<CalcService>();
        services.AddTransient<ITimeOfDayService, TimeOfDayService>();
        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}