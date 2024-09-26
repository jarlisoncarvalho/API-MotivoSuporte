using System.ComponentModel.DataAnnotations;

namespace MotivoSuporte.Entities
{
    public class Motivos
    {
        [Key]
        public int Id { get; set; }
        public string Motivo { get; set; }
    }
}
