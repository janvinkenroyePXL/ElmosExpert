using Microsoft.EntityFrameworkCore;
using OutOfTheBox.Infrastructure;
using OutOfTheBox.Infrastructure.Repositories;
using OutOfTheBox.Logic.IRepositories;

namespace OutOfTheBox.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<OutOfTheBoxContext>(dbContextOptions => dbContextOptions.UseSqlServer(
                Configuration.GetConnectionString("OutOfTheBoxDBConnectionString")));
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddScoped<IPrisonRepository, PrisonDbRepository>();
            services.AddScoped<ICellRepository, CellDbRepository>();
            services.AddScoped<IPrisonerRepository, PrisonerDbRepository>();
            services.AddScoped<ISentenceRepository, SentenceDbRepository>();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.MapControllers();
        }
    }
}
