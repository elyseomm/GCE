using System;
using WebCore.DTO;
using WebCore.Enums;
using WebCore.Extensions;

namespace WebCore.DTO
{
    public class SupplierDTO : ISupplierDTO
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

        #region Atributos Pessoa Física

        public Nullable<int> EstadoCivil { get; set; }
        public string Profissao { get; set; }
        public Nullable<DateTime> DtNascimento { get; set; }
        public Nullable<int> Genero { get; set; }
        public string Nacionalidade { get; set; }

        #endregion

        public string GetTipoPessoa => TipoPessoa == 0 ? "Pessoa Física" : "Pessoa Jurídica";

        public string GetNacional => Nacional == 1 ? "Sim" : "Não"; 

        public string GetSituacao { 
            get { 
                return Situacao == (int)EnumSupplierSituation.Ativado ? "Ativado" :
                    Situacao == (int)EnumSupplierSituation.Desativado ? "Desativado" :
                    "Em Elaboração"; 
            } }

        public string GetTipoEmpresa 
        {
            get
            {
                return TipoEmpresa == (int)EnumSupplierSituation.Ativado ? "Ativado" :
                    Situacao == (int)EnumSupplierSituation.Desativado ? "Desativado" :
                    "Em Elaboração";
            }
        }

        public string GetPorte
        {
            get
            {
                return Porte.Value.ToEnum<EnumPorteEmpresa>().GetDescription();
            }
        }

    }
}
