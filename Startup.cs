using System;
using ComicsScraper.Constants;
using ComicsScraper.Data;
using ComicsScraper.Providers;
using ComicsScraper.Providers.Parsers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ComicsScraper
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IComicProvider, ComicProvider>();
            services.AddSingleton<IComicParserFactory, ComicParserFactory>();
            services.AddSingleton<IComicDefinitions, ComicDefinitions>();
            services.AddSingleton<INetworkComicReader, NetworkComicReader>();
            services.AddSingleton<IFileComicReader, FileComicReader>();
            services.AddTransient<GoComicsParser>();
            services.AddTransient<DilbertParser>();

            services.AddHttpClient(ComicGroups.GoComics, client =>
            {
                client.BaseAddress = new Uri("https://gocomics.com/");
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko");
                client.DefaultRequestHeaders.Add("Accept", "text/html");
            });
            services.AddHttpClient(ComicGroups.Dilbert, client =>
            {
                client.BaseAddress = new Uri("https://dilbert.com/");
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko");
                client.DefaultRequestHeaders.Add("Accept", "text/html");
            });

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
	        app.UsePathBase("/comics");
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
