using ETAppApi.Persistence;
namespace ETAppApi.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContextSpecial();
            builder.Services.AddPersistenceServices();
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //builder.Services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowSpecificOrigin",
            //        builder =>
            //        {
            //            builder.WithOrigins("http://localhost:4200")
            //                   .AllowAnyHeader()
            //                   .AllowAnyMethod();
            //        });
            //});

      


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors(x => x
                       .AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader());

            app.MapControllers();

            app.Run();
        }
    }
}
