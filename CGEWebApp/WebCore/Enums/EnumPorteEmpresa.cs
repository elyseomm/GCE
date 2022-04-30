using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCore.Enums
{
    public enum EnumPorteEmpresa
    {
        [Description("Microempreendedor Individual (MEI)")]
        MEI = 0,
        [Description("Microempresa (ME)")]
        ME = 1,
        [Description("Empresa de Pequeno Porte (EPP)")]
        EPP = 2,
        [Description("Empresa de Médio Porte")]
        EMP = 3,
        [Description("Grande Empresa")]
        GE = 4,
        [Description("Outros")]
        OUTROS = 5
    }
}
