using System.ComponentModel;

namespace CGE.Core.Enums
{
    public enum SupplierSituation
    {
        [Description("Em Elaboração")]
        EmElaboracao = 0,

        [Description("Ativado")]
        Ativado = 1,

        [Description("Desativado")]
        Desativado = 2
    }
}
