namespace MotivoSuporte.Entities
{
    public class Motivo_Suporte
    {
        public int Id { get; set; }
        public int Idf_Empresa { get; set; }
        public string Motivo { get; set; }
        public string Des_Motivo { get; set; }
        public decimal Num_CNPJ { get; set; }
        public string Raz_Social { get; set; }
        public string Email { get; set; }
        public int Telefone { get; set; }
        public string Situacao { get; set; }
        public int Qtde_Admissoes { get; set; }
        public int Qtde_Funcionarios { get; set; }
        public string Origem { get; set; }
    }
}
