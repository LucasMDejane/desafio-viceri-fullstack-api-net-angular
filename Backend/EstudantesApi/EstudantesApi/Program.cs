using System.Data; // Para IDbConnection
using System.Data.SqlClient; // Para SqlConnection do pacote System.Data.SqlClient

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
    
// --- ESTAS DUAS LINHAS DEVEM ESTAR AQUI, ANTES DE builder.Build() ---
builder.Services.AddEndpointsApiExplorer(); // Necessário para o Swagger
builder.Services.AddSwaggerGen();           // Configura o gerador do Swagger
// --- FIM DA POSIÇÃO CORRETA ---

// --- Conexão com o Banco de Dados (já adicionado por você) ---
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddTransient<IDbConnection>(sp => new SqlConnection(connectionString));
// --- Fim da Conexão com o Banco de Dados ---

var app = builder.Build(); // A partir daqui, você configura o pipeline de requisições

// Configure the HTTP request pipeline.
// O Swagger UI (interface visual) só deve aparecer em ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();