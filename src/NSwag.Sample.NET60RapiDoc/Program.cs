using NJsonSchema.Generation;
using System.Text.Json.Serialization;

namespace NSwag.Sample.NET60RapiDoc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services
                .AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            builder.Services.AddOpenApiDocument(document =>
            {
                document.Description = "Hello world!";
                document.DefaultReferenceTypeNullHandling = ReferenceTypeNullHandling.NotNull;
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseOpenApi(p => p.Path = "/swagger/{documentName}/swagger.yaml");
            app.UseRapiDoc(p => {
                p.DocumentPath = "/swagger/{documentName}/swagger.yaml";
                p.Theme = AspNetCore.RapiDocTheme.Light;
            });
            //app.UseApimundo();
            //app.UseApimundo(settings =>
            //{
            //    //settings.CompareTo = "a:a:27:25:15:latest";
            //    settings.DocumentPath = "/swagger/v1/swagger.yaml";
            //    settings.ApimundoUrl = "https://localhost:5001";
            //});

            app.Run();
        }
    }
}