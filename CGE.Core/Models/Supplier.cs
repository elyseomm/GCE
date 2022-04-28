using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CGE.Api.Models
{
    [Table("Suppliers")]
    public class Supplier
    {
        public int Id { get; set; }        
        public string CPFCNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public int TipoPessoa { get; set; }
        public int TipoEmpresa { get; set; }
        public string Fone1 { get; set; }
        public string Fone2 { get; set; }
        public string Fone3 { get; set; }        
        public string Email { get; set; }
        public int Nacional { get; set; }
        public int Situacao { get; set; }
        public DateTime DtAtualizacao { get; set; }        

        #region Atributos Pessoa Juridica

        public string NomeFantasia { get; set; }        
        public DateTime DtConstituicao { get; set; }
        public int Porte { get; set; }
        public string WebSite { get; set; }
        public int CaracterizacaoCapital { get; set; }
        public decimal QtdQuota { get; set; }
        public decimal VlrQuota { get; set; }
        public decimal CapitalSocial { get; set; }

        #endregion

        #region Atributos Pessoa Física

        public int EstadoCivil { get; set; }
        public string Profissao { get; set; }
        public DateTime DtNascimento { get; set; }
        public int Genero { get; set; }
        public string Nacionalidade { get; set; }

        #endregion
    }
}
