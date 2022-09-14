using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using StepChange.Blogger.DAL.Persistence;
using StepChange.Blogger.DAL.Services;
using StepChange.Blogger.Web.Security.Services;

namespace StepChange.Blogger.Web
{
    public class Startup
    {
        readonly string _dbDefaultConnection;

        public Startup(IConfiguration configuration)
        {
            string dbDefaultConnection = configuration
                .GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(dbDefaultConnection))
            {
                throw new ArgumentNullException(
                    nameof(IConfiguration),
                    @"'DefaultConnection' can not be null");
            }

            _dbDefaultConnection = dbDefaultConnection;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            services.AddDbContext<ApiDbContext>(options =>
                options.UseSqlServer(
                    _dbDefaultConnection,
                    b =>
                    {
                        // Its need as DAL project is separated from migration assembly project
                        b.MigrationsAssembly("StepChange.Blogger.Web");
                    }));

            // Dependency services
            services.AddTransient<IBlogPostService, BlogPostService>();
            services.AddTransient<IBlogPublisherService, BlogPublisherService>();
            services.AddTransient<ITokenService, TokenService>();

            // Session for JWT tokens
            services.AddSession();

            // JWT token based authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters =
                        Utils.GetDefaultTokenValidationParameters(
                            Configuration.GetJwtSigningKey());
                });

            // Role based authorization
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseSession();
            app.Use(async (context, next) =>
            {
                var token = context.Session.GetString("JwtToken");
                if (!string.IsNullOrEmpty(token))
                {
                    context.Request.Headers.Add("Authorization", "Bearer " + token);
                }
                await next();
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
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
