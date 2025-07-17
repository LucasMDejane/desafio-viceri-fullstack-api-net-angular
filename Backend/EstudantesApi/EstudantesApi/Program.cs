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

builder.Services.AddScoped<EstudantesService>(); 

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", 
        policyBuilder => policyBuilder.WithOrigins("http://localhost:4200") 
                           .AllowAnyHeader()   
                           .AllowAnyMethod()); 
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