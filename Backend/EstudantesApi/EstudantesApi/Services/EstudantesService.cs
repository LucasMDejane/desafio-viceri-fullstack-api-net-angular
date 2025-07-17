using System.Data; 
using Dapper;
using System.Data.SqlClient;
using EstudantesApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EstudantesApi.Services
{
    public class EstudantesService
    {
        private readonly IDbConnection _dbConnection; // Campo para armazenar a conexão

        public EstudantesService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection; // armazena a conexão injetada
        }

        public async Task<(bool Success, string Message)> CadastrarEstudanteComNotas(EstudanteCadastroViewModel model)
        {
            // regras de Negócio

            if (string.IsNullOrWhiteSpace(model.Nome))
            {
                return (false, "Nome do estudante não pode ser vazio.");
            }
            if (model.Idade <= 0)
            {
                return (false, "Idade do estudante deve ser maior que 0.");
            }
            foreach (var nota in model.Notas)
            {
                if (nota.Nota < 0 || nota.Nota > 10)
                {
                    return (false, $"A nota para a disciplina '{nota.Disciplina}' deve estar entre 0 e 10.");
                }
            }

            try
            {
                // inserrt
              
                var sqlInsertEstudante = "INSERT INTO Estudantes (Nome, Idade) VALUES (@Nome, @Idade); SELECT SCOPE_IDENTITY();";
                //executa e retorna o primeiro valor da primeira linha, o ID 
                //  "model" - porque Dapper mapeia propriedades

                var estudanteId = await _dbConnection.ExecuteScalarAsync<int>(sqlInsertEstudante, model);

                // notas no bd (loop para cada nota)

                var sqlInsertNota = "INSERT INTO EstudanteNotas (EstudanteId, Disciplina, Nota) VALUES (@EstudanteId, @Disciplina, @Nota);";
                foreach (var nota in model.Notas)
                {
                    nota.EstudanteId = estudanteId; // nota do estudante que acabou de ser criado
                    await _dbConnection.ExecuteAsync(sqlInsertNota, nota); 
                }

                return (true, "Estudante e notas cadastrados com sucesso!");
            }
            catch (Exception ex) 
            {
                return (false, $"Ocorreu um erro interno ao cadastrar: {ex.Message}");
            }
        }

    }
}
