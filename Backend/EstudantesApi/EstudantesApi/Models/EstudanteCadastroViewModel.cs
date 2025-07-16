using EstudantesNotaApi.Models;

namespace EstudantesApi.Models
{
    public class EstudanteCadastroViewModel
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public List<EstudanteNota> Notas { get; set; } = new List<EstudanteNota>(); // A lista de notas
    }
}
