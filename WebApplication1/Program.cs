
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositorypattern.core.Models;
using Repositorypattern.core.UnitofWork;
using Repositorypattern.ef;
using RepositoryPattern.ef;
using RepositoryPattern.ef.Repositories;


namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbContext>(
                   options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                   b=>b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                   ) );

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
         .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddScoped<UserManager<ApplicationUser>>();
            builder.Services.AddScoped<SignInManager<ApplicationUser>>();

            builder.Services.AddScoped<IUnitOFWork, UnitOFWork>();
            builder.Services.AddScoped<IAccountRepository, AccountRespository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
