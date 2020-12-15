using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

using LandonApi.Filters;
using LandonApi.Models;
using LandonApi.Services;

using AutoMapper;
using LandonApi.Infrastructure;

namespace LandonApi
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

            // Use in-memory database for quick dev and testing
            // TODO: Swap out for a real database in production
            services.AddDbContext<HotelApiDbContext>(options => options.UseInMemoryDatabase("landondb"));

            // Pull data from appsettings.json
            services.Configure<HotelInfo>(
                Configuration.GetSection("Info"));

            // Add service for rooms
            services.AddScoped<IRoomService, DefaultRoomService>();

            // Adds automapper dependency to reduce boilerplate code in controller
            services.AddAutoMapper(options => options.AddProfile<MappingProfile>());

            services.AddMvc(options =>
            {
                // Filter exceptions so production only gets simplified exception errors
                options.Filters.Add<JsonExceptionFilter>();
                
                // Rewrite links
                options.Filters.Add<LinkRewritingFilter>();

                // Require https
                options.Filters.Add<RequireHttpsOrCloseAttribute>();
            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddControllers();

            // Configure API docs
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LandonApi", Version = "v1" });
            });

            services.AddRouting(options => options.LowercaseUrls = true);

            // API versioning (instead of /api/v1/... and /api/v2/...), versioning in header 
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ApiVersionReader = new MediaTypeApiVersionReader();
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionSelector
                    = new CurrentImplementationApiVersionSelector(options);
            });

            // CORS, remove for production
            services.AddCors(options =>
            {
                options.AddPolicy("AllowMyApp", policy => policy.AllowAnyOrigin());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LandonApi v1"));
            }
            else
            {
                // HTTP Strict Transport Protocol
                app.UseHsts();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // CORS, remove before production
            app.UseCors("AllowMyApp");
        }
    }
}
