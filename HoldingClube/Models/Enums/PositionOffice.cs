
using System.ComponentModel.DataAnnotations;

namespace HoldingClube.Models.Enums
{
    public enum PositionOffice : int
    {
        [Display(Name = "Outros")]
        Others        = 0,

        [Display(Name = "Analista")]
        Analyst       = 1,

        [Display(Name = "Assistente")]
        Assistant     = 2,

        [Display(Name = "CEO")]
        CEO           = 3,

        [Display(Name = "Coordenador")]
        Coordinator   = 4,

        [Display(Name = "Diretor")]
        Director      = 5,

        [Display(Name = "Estagiário")]
        Intern        = 6,

        [Display(Name = "Estudante")]
        Student       = 7,

        [Display(Name = "Freelancer")]
        Freelancer    = 8,

        [Display(Name = "Gerente")]
        Manager       = 9,

        [Display(Name = "Proprietário / Sócio")]
        OwnerPartner  = 10,

        [Display(Name = "Vice Presidente")]
        VicePresident = 11
    }
}
