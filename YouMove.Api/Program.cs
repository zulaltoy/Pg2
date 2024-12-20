
using Microsoft.EntityFrameworkCore;
using YouMove.Data.Repositories;
using YouMove.Business.Interfaces;
using YouMove.Business.Managers;
using YouMove.Data.Context;

namespace YouMove.Data {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

          

            builder.Services.AddDbContext<GymTestContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("GymTest")));


            builder.Services.AddControllers().AddXmlDataContractSerializerFormatters();
            builder .Services.AddScoped<IEquipmentManager, EquipmentManager>();
            builder.Services.AddScoped<IMemberManager, MemberManager>();
            builder.Services.AddScoped<IProgramManager, ProgramManager>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
