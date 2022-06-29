using CentOps.Api.Services;
using CentOps.Api.Services.ModelStore.Interfaces;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;


namespace CentOps.Api
{
    [ExcludeFromCodeCoverage] // This is not solution code, no need for unit tests
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            _ = builder.Services.AddControllers().AddJsonOptions(jo =>
            {
                jo.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            _ = builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            _ = builder.Services.AddEndpointsApiExplorer();
            _ = builder.Services.AddSwaggerGen();

            // var inMemoryStore = new InMemoryStore();
            // _ = builder.Services.AddSingleton<IInstitutionStore>(provider => inMemoryStore);
            // _ = builder.Services.AddSingleton<IParticipantStore>(provider => inMemoryStore);

            var section = builder.Configuration.GetSection("CosmosDb");
            var cosmosDb = CosmosDbService.CreateCosmosDbService(section);
            _ = builder.Services.AddSingleton<IInstitutionStore>(provider => cosmosDb);
            _ = builder.Services.AddSingleton<IParticipantStore>(provider => cosmosDb);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                _ = app.UseSwagger();
                _ = app.UseSwaggerUI();
            }

            _ = app.UseHttpsRedirection();

            _ = app.UseAuthorization();

            _ = app.MapControllers();

            app.Run();
        }
    }
}