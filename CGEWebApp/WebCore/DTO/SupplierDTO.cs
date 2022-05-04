using System;
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
        
        [NoMap]
        //public string GetTipoPessoa => 
        public string GetTipoPessoa { get { return _GetTipoPessoa(); } }

        private string _GetTipoPessoa()
        {
            return TipoPessoa == 0 ? "Pessoa Física" : "Pessoa Jurídica";
        }

        [NoMap]
        //public string GetNacional => Nacional == 1 ? "Sim" : "Não";
        public string GetNacional { get { return _GetNacional(); } }

        private string _GetNacional()
        {
            return Nacional == 1 ? "Sim" : "Não";
        }

        [NoMap]
        //public string GetSituacao => Situacao.ToEnum<EnumSupplierSituation>().GetDescription();
        public string GetSituacao { get { return _GetSituacao(); } }

        private string _GetSituacao()
        {
            return Situacao.ToEnum<EnumSupplierSituation>().GetDescription();
        }

        [NoMap]
        //public string GetTipoEmpresa => TipoEmpresa.ToEnum<EnumPorteEmpresa>().GetDescription();
        public string GetTipoEmpresa { get { return _GetTipoEmpresa(); } }

        private string _GetTipoEmpresa()
        {
            return TipoEmpresa.ToEnum<EnumPorteEmpresa>().GetDescription();
        }        
        
        [NoMap]
        //public string GetPorte => Porte?.ToEnum<EnumPorteEmpresa>().GetDescription();
        public string GetPorte { get { return _GetPorte(); } }
        private string _GetPorte()
        {
            return Porte?.ToEnum<EnumPorteEmpresa>().GetDescription();
        }

        public SupplierPFDTO ParsePF()
        {
            return ParsePF(this);
        }

        public SupplierPJDTO ParsePJ()
        {
            return ParsePJ(this);
        }

        public static SupplierPFDTO ParsePF(SupplierDTO dto)
        {
            return new SupplierPFDTO()
            {
                Id = dto.Id,
                CPFCNPJ = dto.CPFCNPJ,
                RazaoSocial = dto.RazaoSocial,
                TipoPessoa = dto.TipoPessoa,
                TipoEmpresa = dto.TipoEmpresa,
                Fone1 = dto.Fone1,
                Fone2 = dto.Fone2,
                Fone3 = dto.Fone3,
                Email = dto.Email,
                Nacional = dto.Nacional,
                Situacao = dto.Situacao,
                DtAtualizacao = dto.DtAtualizacao,

                EstadoCivil = dto.EstadoCivil,
                Profissao = dto.Profissao,
                DtNascimento = dto.DtNascimento,
                Genero = dto.Genero,
                Nacionalidade = dto.Nacionalidade,
            };
        }

        public static SupplierPJDTO ParsePJ(SupplierDTO dto)
        {
            return new SupplierPJDTO()
            {
                Id = dto.Id,
                CPFCNPJ = dto.CPFCNPJ,
                RazaoSocial = dto.RazaoSocial,
                TipoPessoa = dto.TipoPessoa,
                TipoEmpresa = dto.TipoEmpresa,
                Fone1 = dto.Fone1,
                Fone2 = dto.Fone2,
                Fone3 = dto.Fone3,
                Email = dto.Email,
                Nacional = dto.Nacional,
                Situacao = dto.Situacao,
                DtAtualizacao = dto.DtAtualizacao,

                NomeFantasia = dto.NomeFantasia,
                DtConstituicao = dto.DtConstituicao,
                Porte = dto.Porte,
                WebSite = dto.WebSite,
                CaracterizacaoCapital = dto.CaracterizacaoCapital,
                QtdQuota = dto.QtdQuota,
                VlrQuota = dto.VlrQuota,
                CapitalSocial = dto.CapitalSocial,
            };
        }
    }
}
