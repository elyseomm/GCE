using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace WebCore.Enums
{
    public enum EnumTipoCapital
    {
        [Description("Capital Social")]
        SOCIAL = 0,
        [Description("Capital Nominal")]
        NOMINAL = 1,
        [Description("Capital Próprio")]
        PROIPRIO = 2,
        [Description("Capital de Giro")]
        GIRO = 3,
        [Description("Capital de Terceiros")]
        TERCEIROS = 4,
        [Description("Capital Total à Disposição da Entidade")]
        TDE = 5,
        [Description("Capital Integralizado")]
        INTEGRALIZADO = 6,
        [Description("Capital a Integralizar")]
        AINTEGRALIZAR = 7,
        [Description("Capital Subscrito")]
        SUBSCRITO = 8,
        [Description("Capital Humano")]
        HUMANO = 9,
        [Description("Capital Autorizado")]
        AUTORIZADO = 10
    }

}
