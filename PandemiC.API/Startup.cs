using DCODatabase.ToolBox.Database;
using DCOToolBox.Cryptography;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PandemiC.API.Infrastructure.Security;
using PandemiC.Client.Models;
using PandemiC.Client.Services;
using PandemiC.Repo;
using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using GCtry = PandemiC.Global.Models.Country;
using GCtryService = PandemiC.Global.Services.CountryService;
using GResto = PandemiC.Global.Models.Restaurant;
using GRestoService = PandemiC.Global.Services.RestaurantService;
using GTL = PandemiC.Global.Models.TimeLine;
using GTLService = PandemiC.Global.Services.TimeLineService;
using GUser = PandemiC.Global.Models.User;
using GUserService = PandemiC.Global.Services.UserService;

namespace PandemiC.API
{
    public class Startup
    {
        private IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) // Directory where the json files are located
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers()
                .AddXmlDataContractSerializerFormatters();

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PandemiC.API", Version = "v1" });
            //});

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "PandemiC API",
                    Description = "Pandemic Web API",
                    //TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Coppens Dominique",
                        Email = string.Empty,
                        Url = new Uri("http://www.linkedin.com/in/dominique-coppens77"),
                    }
                });


                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);


                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            services.AddSingleton<DbProviderFactory, SqlClientFactory>((sp) => SqlClientFactory.Instance);
            services.AddSingleton<IConnectionInfo, DBConnectionInfo>((sp) => new DBConnectionInfo(_configuration.GetSection("ConnectionStrings").GetSection("DBCONN").Value));
            services.AddSingleton<IConnection, DBConnection>();

            services.AddTransient<IUserService<GUser>, GUserService>();
            services.AddTransient<IUserService<User>, UserService>();

            services.AddTransient<IRestaurantService<GResto>, GRestoService>();
            services.AddTransient<IRestaurantService<Restaurant>, RestaurantService>();

            services.AddScoped<ICountryService<GCtry>, GCtryService>();
            services.AddScoped<ICountryService<Country>, CountryService>();

            services.AddScoped<ITimeLineService<GTL>, GTLService>();
            services.AddScoped<ITimeLineService<TimeLine>, TimeLineService>();

            services.AddSingleton<ITokenService, TokenService>();

            services.AddSingleton<ICryptoRSA, CryptoRSA>(o => new CryptoRSA(Properties.Resource.Keys));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PandemiC.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
