using System.ComponentModel.DataAnnotations;

namespace MotivoSuporte.Model
{
    public class AddMotivoSuporte
    {
        [Required]
        public string Num_Cnpj { get; set; }
        [Required]
        public string Motivo {  get; set; }
        [Required]
        public string Des_Motivo { get; set; }
    }
}
