using ComicsScraper.Constants;
using ComicsScraper.Data;
using ComicsScraper.Providers;
using ComicsScraper.Providers.Parsers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<IComicProvider, ComicProvider>();
            services.AddSingleton<IComicParserFactory, ComicParserFactory>();
            services.AddSingleton<IComicDefinitions, ComicDefinitions>();
            services.AddSingleton<INetworkComicReader, NetworkComicReader>();
            services.AddSingleton<IFileComicReader, FileComicReader>();
            services.AddTransient<GoComicsParser>();
            services.AddTransient<DilbertParser>();

            services.AddHttpClient(ComicGroups.GoComics, client =>
            {
                client.BaseAddress = new Uri("http://www.gocomics.com/");
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko");
                client.DefaultRequestHeaders.Add("Accept", "text/html");
            });
            services.AddHttpClient(ComicGroups.Dilbert, client =>
            {
                client.BaseAddress = new Uri("https://dilbert.com/");
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko");
                client.DefaultRequestHeaders.Add("Accept", "text/html");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
