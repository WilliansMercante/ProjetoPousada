using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using ProjetoPousada.Dominio.Entidades.Proxy;
using ProjetoPousada.Infra.Contexts;
using ProjetoPousada.IoC;
using System.Configuration;
using System.Text;
using Microsoft.AspNetCore.Antiforgery;
using ProjetoPousada.Dominio.Entidades.Helpers;

namespace ProjetoPousada.IU.Web
{
	public class Startup
	{
		public IConfiguration configRoot
		{
			get;
		}
		public Startup(IConfiguration configuration)
		{
			configRoot = configuration;
		}
		public void ConfigureServices(IServiceCollection services)
		{
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

			services.AddDbContext<ConfiguracaoContext>(options => options.UseSqlServer(configRoot.GetConnectionString("PROJETO_POUSADA")), ServiceLifetime.Scoped);
			services.AddDbContext<ProjetoPousadaContext>(options => options.UseSqlServer(configRoot.GetConnectionString("PROJETO_POUSADA")), ServiceLifetime.Scoped);

			services.Configure<ProxyEntity>(configRoot.GetSection("Proxy"));
			InjectionDependencyCore.ConfigureServices(services);

			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddSingleton(configRoot);

			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(x =>
			{
				x.RequireHttpsMetadata = false;
				x.SaveToken = true;
				x.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					ValidateIssuer = false,
					ValidateAudience = false
				};
			});

			services.AddCors(options =>
			{
				options.AddPolicy("EnableCORS", builder =>
				{
					builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build();
				});
			});

			services.Configure<CookieTempDataProviderOptions>(options => {
				options.Cookie.IsEssential = true;
			});

			services.AddSession(options =>
			{
				options.Cookie.Name = ".Pousada.Session";
				options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
				options.IdleTimeout = TimeSpan.FromMinutes(20);
				options.Cookie.IsEssential = true;
			});

			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
					.AddCookie(options =>
					{
						options.LoginPath = "/Autenticar/Index";
						options.LogoutPath = "/Autenticar/Logout";
					});


			services.AddAuthentication(options =>
			{
				options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
				options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
			});


			services.AddDataProtection()
					//.PersistKeysToFileSystem(new DirectoryInfo(Path.GetTempPath()))
					.UseCryptographicAlgorithms(new AuthenticatedEncryptorConfiguration
					{
						EncryptionAlgorithm = EncryptionAlgorithm.AES_256_CBC,
						ValidationAlgorithm = ValidationAlgorithm.HMACSHA256
					})
					.SetApplicationName("ProjetoPousada");

			services.ConfigureApplicationCookie(options =>
			{
				options.Cookie.Name = ".AspNet.SharedCookie";
				options.Cookie.Path = "/";
			});			

			services.AddRazorPages();
		}
		public void Configure(IApplicationBuilder app, IWebHostEnvironment webHostingEnvironment)
		{
			if (webHostingEnvironment.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();

			app.UseStaticFiles();

			//// This will add "Libs" as another valid static content location
			app.UseStaticFiles();

			app.UseCookiePolicy();

			app.UseCors(x => x
				.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader());

			AppHttpContextHelper.Services = app.ApplicationServices;

			app.UseSession();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
				   name: "default",
				   pattern: "{controller=Autenticar}/{action=Index}/{id?}"
			   );				
			});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller}/{action}/{id?}"
                );
            });
        }
	}
}
