using CGE.Core.DTO;
using CGE.Core.Enums;
using System;

namespace CGE.Core.Models
{
    public class SupplierPJDTO : ISupplierDTO
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
        public Nullable<DateTime> DtConstituicao { get; set; }
        public Nullable<int> Porte { get; set; }
        public string WebSite { get; set; }
        public Nullable<int> CaracterizacaoCapital { get; set; }
        public Nullable<decimal> QtdQuota { get; set; }
        public Nullable<decimal> VlrQuota { get; set; }
        public decimal? CapitalSocial { get; set; }

        #endregion

        public SupplierPJDTO()
        {
            TipoPessoa = (int)SupplierSituation.EmElaboracao;
        }
    }
}
