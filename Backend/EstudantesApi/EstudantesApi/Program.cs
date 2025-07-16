using EstudantesApi.Services;
using System.Data; // IDbConnection
using System.Data.SqlClient; // P/ SqlConnection

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
    

builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();          


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddTransient<IDbConnection>(sp => new SqlConnection(connectionString));

builder.Services.AddScoped<EstudantesService>(); // LINHA PARA REGISTRAR SERVIÇO

var app = builder.Build(); 

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();