using System;

namespace CGE.Core.DTO
{
    interface ISupplierDTO
    {
        int Id { get; set; }
        string CPFCNPJ { get; set; }
        string RazaoSocial { get; set; }
        int TipoPessoa { get; set; }
        int TipoEmpresa { get; set; }
        string Fone1 { get; set; }
        string Fone2 { get; set; }
        string Fone3 { get; set; }
        string Email { get; set; }
        int Nacional { get; set; }
        int Situacao { get; set; }
        DateTime DtAtualizacao { get; set; }
    }
}
