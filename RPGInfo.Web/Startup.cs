using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RPGInfo.Web.Data;
using RPGInfo.Web.Services;
using System;

namespace RPGInfo.Web
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
            services.AddRazorPages();

            services.AddAntiforgery(token => token.HeaderName = "XSRF-TOKEN");

            services.AddSingleton<IDbConnection, DbConnection>();
            services.AddSingleton<ICategoryData, MongoCategoryData>();

            // TODO: May need to change the way Identity works with context
            // due to Mongo
            services.AddIdentity<IdentityUser, IdentityRole>();

            services.Configure<IdentityOptions>(options => 
            {
                // password settings
                options.Password.RequiredLength = 6;

                // lockout settings
                options.Lockout.MaxFailedAccessAttempts = 10;

                // user settings
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;

                // TODO: No Email confirmation enabled for version 1 **
                // If option is enabled, it will let a user log in upon registering however if disconnect/reconnect it will say 'Invalid Login'
                // this is very unhelpful and in order to work in proper email confirmation would need more code added to handle it
                // for now, no email confirmation is required. This will be implemented in future version
                // Ref to implement: https://code-maze.com/email-confirmation-aspnet-core-identity/
                //options.SignIn.RequireConfirmedEmail = true;
            });

            services.ConfigureApplicationCookie(options => 
            {
                // cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
            });

            services.AddScoped<INote, GeneralNote>();
            services.AddScoped<INpc, GeneralNpc>();
            services.Configure<AuthMessageSenderOptions>(Configuration);
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
                app.UseExceptionHandler("/Error");
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
                endpoints.MapRazorPages();
            });
        }
    }
}
