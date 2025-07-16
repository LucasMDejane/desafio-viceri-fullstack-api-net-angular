namespace EstudantesNotaApi.Models
{
    public class EstudanteNota
    {
        public int Id { get; set; } 
        public int EstudanteId { get; set; } 
        public string Disciplina { get; set; }
        public decimal Nota { get; set; }
    }
}