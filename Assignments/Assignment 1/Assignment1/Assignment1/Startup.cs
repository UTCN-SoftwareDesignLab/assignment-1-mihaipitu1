using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Database;
using Assignment1.Repository.Accounts;
using Assignment1.Repository.Clients;
using Assignment1.Repository.Users;
using Assignment1.Service.Accounts;
using Assignment1.Service.Clients;
using Assignment1.Service.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Assignment1
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
            services.AddMvc();
            services.AddTransient<DBConnectionWrapper>(_ => new DBConnectionFactory().GetConnectionWrapper(false));

            services.AddScoped<ISavingAccountRepository,SavingAccountRepositoryMySQL>();
            services.AddScoped<ISpendingAccountRepository, SpendingAccountRepositoryMySQL>();
            services.AddScoped<IAccountService, SavingAccountService>();
            services.AddScoped<IAccountService, SpendingAccountService>();
            services.AddScoped<IUserRepository, UserRepositoryMySQL > ();
            services.AddScoped<IAdminService,AdminServiceMySQL>();
            services.AddScoped<IClientRepository, ClientRepositoryMySQL>();
            services.AddScoped<IClientService, ClientServiceMySQL>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Client}/{action=Index}/{id?}");
            });
        }
    }
}
