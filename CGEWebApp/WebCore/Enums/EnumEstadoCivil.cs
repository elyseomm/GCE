using System.ComponentModel;

namespace WebCore.Enums
{
    public enum EnumEstadoCivil
    {
        [Description("Solteiro")]
        SOLTEIRO = 0,
        [Description("Casado")]
        CASADO = 1,
        [Description("Separado")]
        SEPARADO = 2,
        [Description("Divorciado")]
        DIVORCIADO = 3,
        [Description("Viúvo")]
        VIUVO = 5
    }
}