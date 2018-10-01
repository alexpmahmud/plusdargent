using System.ComponentModel.DataAnnotations;


namespace PlusArgent_v1._0.Utils
{
    public static class Enums
    {

        public enum AccountTypes
        {
            [System.ComponentModel.Description("Portefeuille")]
            [Display(Name = "Portefeuille")]
            Default = 1,
            [System.ComponentModel.Description("Carte de crédit")]
            [Display(Name = "Carte de crédit")]
            CreditCard = 2,
            [System.ComponentModel.Description("Prêt")]
            [Display(Name = "Prêt")]
            Loan = 3,
            [System.ComponentModel.Description("Compte bancaire")]
            [Display(Name = "Compte bancaire")]
            Bank = 4
        }


    }
}