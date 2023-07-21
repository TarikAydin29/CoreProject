using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PizzaPan.BusinessLayer.Abstract;
using PizzaPan.BusinessLayer.Concrete;
using PizzaPan.DataAccessLayer.Abstract;
using PizzaPan.DataAccessLayer.Concrete;
using PizzaPan.DataAccessLayer.EntityFramework;
using PizzaPan.DataAccessLayer.Repositories;
using PizzaPan.EntityLayer.Concrete;
using PizzaPan.UILayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Google;

using Google.Apis.Auth.AspNetCore3;
using System.Net.Http;
using Google.Apis.Auth.OAuth2;

namespace PizzaPan.UILayer
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
            services.AddDbContext<Context>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDAL, EFCategoryDAL>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDAL, EFProductDAL>();
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactDAL, EFContactDAL>();
            services.AddScoped<IDiscountService, DiscountManager>();
            services.AddScoped<IDiscountDAL, EFDiscountDAL>();
            services.AddScoped<IProductImageService, ProductImageManager>();
            services.AddScoped<IProductImageDAL, EFProductImageDAL>();
            services.AddScoped<ITestimonialService, TestimonialManager>();
            services.AddScoped<ITestimonialDAL, EFTestimonialDAL>();
            services.AddScoped<IOurTeamService, OurTeamManager>();
            services.AddScoped<IOurTeamDAL, EFOurTeamDAL>();


            services.AddHttpContextAccessor();
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>();
            services.AddControllersWithViews();
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            //})
            //    .AddGoogle(options =>
            //    {
            //        options.ClientId = Configuration["107674379567-jjtghh81b33vg3693qr4610kbrlo3sii.apps.googleusercontent.com"];
            //        options.ClientSecret = Configuration["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"];
            //    });


            //services.AddHttpClient();
            //services.AddScoped<DriveService>(provider =>
            //{
            //    var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();

            //    // Replace "your-service-account-key.json" with the path to your Google service account key JSON file
            //    var googleCredential = GoogleCredential.FromFile("a4e67a8b17f5e2506f3134071a430403f28db4ee")
            //                                          .CreateScoped(DriveService.Scope.Drive);

            //    var initializer = new BaseClientService.Initializer()
            //    {
            //        HttpClientInitializer = googleCredential,
            //        ApplicationName = "PizzaPanDriveClient" // Replace with your application's name
            //    };

            //    var service = new DriveService(initializer);

            //    return service;
            //});



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Default}/{action=Index}/{id?}");
            });
        }


    }
}
