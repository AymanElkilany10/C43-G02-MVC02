namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            var app = builder.Build();
            app.UseRouting();

            //app.MapGet("/", () => "Hello World!");
            app.UseStaticFiles();
            app.MapControllerRoute(
                name: "Default",
                pattern: "{controller=Home}/{action=Index}/{Id:int?}"

            );

            app.Run();
        }
    }
}
