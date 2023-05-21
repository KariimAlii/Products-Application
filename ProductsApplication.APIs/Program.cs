using Microsoft.AspNetCore.Http.Features;
using AutoMapper;
namespace ProductsApplication.APIs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Default Services
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #endregion

            builder.Services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = 52428800; // 50 MB
            });
            #region Cors Service
            var PolicyName = "_PolicyName";
            builder.Services.AddCorsServices(PolicyName);
            #endregion

            #region AutoMapper Service
            builder.Services.AddAutoMapperServices(); 
            #endregion

            #region Identity Service
            builder.Services.AddIdentityServices();
            #endregion

            #region Authentication Service
            builder.Services.AddAuthenticationServices();
            #endregion

            #region Authorization Service
            builder.Services.AddAuthorizationServices();
            #endregion

            #region Context Service
            builder.Services.AddApplicationServices();
            #endregion

            #region Tokens Service
            builder.Services.AddTokenServices();
            #endregion

            #region Managers Service
            builder.Services.AddManagerServices();
            #endregion

            #region Repos Service
            builder.Services.AddRepoServices();
            #endregion

            var app = builder.Build();

            #region HTTP request Pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                context.Response.Headers.Add("Access-Control-Allow-Methods", "*");
                context.Response.Headers.Add("Access-Control-Allow-Headers", "*");
                context.Response.Headers.Add("Access-Control-Max-Age", "86400");
                await next();
            });
            app.UseHttpsRedirection();
            app.UseCors(PolicyName);

            app.UseAuthentication(); // First
            app.UseAuthorization(); // Second


            app.MapControllers();

            app.Run(); 
            #endregion
        }
    }
}