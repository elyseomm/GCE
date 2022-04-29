using CGE.Core.Enums;
using System;

namespace CGE.Core.DTO
{
    public class SupplierPFDTO : ISupplierDTO
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

        #region Atributos Pessoa Física

        public Nullable<int> EstadoCivil { get; set; }
        public string Profissao { get; set; }
        public Nullable<DateTime> DtNascimento { get; set; }
        public Nullable<int> Genero { get; set; }
        public string Nacionalidade { get; set; }

        #endregion

        public SupplierPFDTO()
        {
            TipoPessoa = (int)SupplierSituation.EmElaboracao; 
        }
    }
}
