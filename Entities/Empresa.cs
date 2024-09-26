using System.ComponentModel.DataAnnotations;

namespace MotivoSuporte.Entities
{
    public class Empresa
    {
        public Empresa(int idfEmpresa, decimal cnpj, string raz_social)
        {
            Idf_Empresa = idfEmpresa;
            Num_CNPJ = cnpj;
            Raz_Social = raz_social;
        }

        public Empresa() { }

        [Key]
        public int Idf_Empresa { get; set; }
        public decimal Num_CNPJ { get; set; }
        public string Raz_Social { get; set; }
    }
}
