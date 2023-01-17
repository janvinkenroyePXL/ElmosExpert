using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OutOfTheBox.Infrastructure;
using OutOfTheBox.Infrastructure.Repositories;
using OutOfTheBox.Logic.IRepositories;
using OutOfTheBox.Logic.IServices;
using OutOfTheBox.Logic.Services;
using System.Text.Json.Serialization;

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
            services.AddControllers()
                .AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            services.AddDbContext<OutOfTheBoxContext>(dbContextOptions => dbContextOptions.UseSqlServer(
                Configuration.GetConnectionString("OutOfTheBoxDBConnectionString")));
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // Repositories
            services.AddScoped<IPrisonRepository, PrisonDbRepository>();
            services.AddScoped<ICellRepository, CellDbRepository>();
            services.AddScoped<IPrisonerRepository, PrisonerDbRepository>();
            services.AddScoped<ISentenceRepository, SentenceDbRepository>();
            services.AddScoped<IRivalryRepository, RivalryDbRepository>();

            // Crud-Services
            services.AddScoped<IWritePrisonService, WritePrisonService>();
            services.AddScoped<IReadPrisonService, ReadPrisonService>();
            services.AddScoped<IWriteCellService, WriteCellService>();
            services.AddScoped<IReadCellService, ReadCellService>();
            services.AddScoped<IWritePrisonerService, WritePrisonerService>();
            services.AddScoped<IReadPrisonerService, ReadPrisonerService>();

            // Services
            services.AddScoped<ICellAssignmentService, CellAssignmentService>();

            // AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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
