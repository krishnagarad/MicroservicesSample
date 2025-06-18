using Microsoft.OpenApi.Models;
using Yarp.ReverseProxy;
namespace AVA.ReverseProxyGateway
{
    public class Startup
    {
        private const string DefaultCorsPolicyName = "localhost";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // Add other services like DbContext, Identity, etc.
            services.AddCors(options =>
            {
                options.AddPolicy(DefaultCorsPolicyName, builder =>
                {
                    //App:CorsOrigins in appsettings.json can contain more than one address with splitted by comma.
                    builder
                        .WithOrigins(Configuration["App:CorsOrigins"].Split(",").Select(o => o.Trim()).ToArray())
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });

            // Add services to the container.

            services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            services.AddOpenApi();
            services.AddEndpointsApiExplorer();
            //services.AddOcelot(Configuration);
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "YARP Reverse Proxy API Gateway",
                    Description = "YARP Reverse Proxy API Gateway"
                });
            });
            services.AddReverseProxy()
    .LoadFromConfig(Configuration.GetSection("ReverseProxy"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(DefaultCorsPolicyName); //Enable CORS!
            app.UseSwagger();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapReverseProxy(); // Use the reverse proxy middleware
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "YARP Reverse Proxy Gateway");
                c.SwaggerEndpoint("https://localhost:44342/swagger/v1/swagger.json", "Vendors Microservice");
                c.SwaggerEndpoint("https://localhost:44368/swagger/v1/swagger.json", "Banks Microservice");
                c.RoutePrefix = String.Empty;
            });
            app.UseAuthorization();
        }
    }
}
