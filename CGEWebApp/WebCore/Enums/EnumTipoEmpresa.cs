using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace WebCore.Enums
{
    public enum EnumTipoEmpresa
    {
        [Description("Microempreendedor Individual (MEI)")]
        MEI = 0,
        [Description("Empresa Individual de Responsabilidade Limitada (EIRELI)")]
        EIRELI = 1,
        [Description("Empresário Individual (EI)")]
        EI = 2,
        [Description("Sociedade Empresária Limitada (LTDA) ")]
        LTDA = 3,
        [Description("Sociedade Simples (SS)")]
        SS = 4,
        [Description("Sociedade Anônima (SA)")]
        SA = 5,
        [Description("Sociedade Limitada Unipessoal (SLU)")]
        SLU = 6
    }

}
