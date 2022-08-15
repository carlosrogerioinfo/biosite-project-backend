using System.ComponentModel;

namespace Biosite.Core.Enums
{
    public enum Gender
    {
        M = 1,
        F = 0
    }

    public enum BodyImageType
    {
        [Description("Padrão")]
        Default = 0,

        [Description("Circulatorio")]
        Circulatory = 1,

        [Description("Digestivo")]
        Digestive = 2,

        [Description("Endócrino")]
        Endocrine = 3,

        [Description("Ósseo")]
        Bone = 4,

        [Description("Linfatico")]
        Lymphatic = 5,

        [Description("Muscular")]
        Muscular = 6,

        [Description("Nervoso")]
        Nervous = 7,

        [Description("Reprodutor Feminino")]
        ReproductiveFemale = 8,

        [Description("Reprodutor Masculino")]
        ReproductiveMale = 9,

        [Description("Respiratório")]
        Resporatory = 10,

        [Description("Urinário")]
        Urinary = 11
    }

}