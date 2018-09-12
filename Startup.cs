namespace www.gokhan_gokalp.com
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.HttpsPolicy;
    using Microsoft.AspNetCore.Mvc;

    using Microsoft.EntityFrameworkCore;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    using GraphQL;
    using GraphQL.Types;

    using eu.cdab.GraphQL_Gokhan.Data;
    using eu.cdab.GraphQL_Gokhan.Models;

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

            services.AddEntityFrameworkInMemoryDatabase().AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("TestDatabase"));

            // services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));

            services.AddScoped<IDocumentExecuter, DocumentExecuter>();

            // services.AddTransient<EasyStoreQuery>();
            services.AddScoped<EasyStoreQuery>();

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<CategoryType>();
            services.AddTransient<ProductType>();

            services.AddScoped<ISchema>(s => new EasyStoreSchema(new FuncDependencyResolver(type => (IGraphType) s.GetRequiredService(type))));
            
            // services.AddScoped<ISchema, EasyStoreSchema>();
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
                app.UseHsts();
            }

            new ApplicationDatabaseInitialiser().SeedAsync(app).GetAwaiter();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
