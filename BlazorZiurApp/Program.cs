using BlazorZiur.Application.Interfaces;
using BlazorZiur.Application.Services;
using BlazorZiurApp.Components;
using BlazorZiur.Infrastructure.Services;
using System.Net.Http.Headers;

namespace BlazorZiurApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Obtener la sección de configuración
            var ziurApiConfig = builder.Configuration.GetSection("ZiurApiSettings");
            var baseUrl = ziurApiConfig["BaseUrl"];
            var token = ziurApiConfig["Token"];
            // Add services to the container.
            
            builder.Services.AddHttpClient("ZiurClient", client =>
            {
                client.BaseAddress = new Uri(baseUrl ?? string.Empty);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            });
            builder.Services.AddScoped<IZiurApiService, ZiurApiService>();
            builder.Services.AddScoped<DocumentoAppService>();

            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
