using System.ComponentModel.DataAnnotations;

namespace MotivoSuporte.Model
{
    public class Empresa
    {
        
        public int Idf_Empresa { get; set; }
        public decimal Num_CNPJ { get; set; }
        public string Raz_Social { get; set; }
        public DateTime Dta_cadastro { get; set; }
        public DateTime Dta_alteracao { get; set; }

    }
}
