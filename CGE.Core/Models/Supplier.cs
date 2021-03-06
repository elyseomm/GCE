using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CGE.Core.Models
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

        [DataType(DataType.Date)]
        public DateTime DtAtualizacao { get; set; }        

        #region Atributos Pessoa Juridica
        
        public string NomeFantasia { get; set; }

        [DataType(DataType.Date)]
        public Nullable<DateTime> DtConstituicao { get; set; }
        public Nullable<int> Porte { get; set; }
        public string WebSite { get; set; }
        public Nullable<int> CaracterizacaoCapital { get; set; }
        public Nullable<decimal> QtdQuota { get; set; }
        public Nullable<decimal> VlrQuota { get; set; }
        public decimal? CapitalSocial { get; set; }

        #endregion

        #region Atributos Pessoa Física

        public Nullable<int> EstadoCivil { get; set; }
        public string Profissao { get; set; }

        [DataType(DataType.Date)]
        public Nullable<DateTime> DtNascimento { get; set; }
        public Nullable<int> Genero { get; set; }
        public string Nacionalidade { get; set; }

        #endregion
    }
}
