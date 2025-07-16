using EstudantesApi.Services;
using System.Data; // IDbConnection
using System.Data.SqlClient; // P/ SqlConnection

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "EstudantesApi", Version = "v1" });

});


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddTransient<IDbConnection>(sp => new SqlConnection(connectionString));

builder.Services.AddScoped<EstudantesService>(); // LINHA PARA REGISTRAR SERVI�O

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", // Nome da sua pol�tica de CORS
        policyBuilder => policyBuilder.WithOrigins("http://localhost:4200") // <--- MUITO IMPORTANTE: A URL do seu Angular (padr�o)
                           .AllowAnyHeader()    // Permite qualquer cabe�alho na requisi��o
                           .AllowAnyMethod());  // Permite qualquer m�todo HTTP (POST, GET, etc.)
});

var app = builder.Build(); 

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");
app.UseAuthorization();

app.MapControllers();

app.Run();