namespace PlusArgent_v1._0.Utils
{
    public static class TextMessages
    {

        //data annotation 
        public const string MsgEmailError       = "L'e corriel n'est pas un courriel valide.";
        public const string MsgRequired         = "Ce champ {0} est obligatoire.";
        public const string MsgPasswordConfirm  = "Confirmer que le mot de passe ne correspond pas.";
        public const string MsgLengthMinMax     = "Le {0} doit comporter entre {2} et {1} caractères";
        public const string MsgLengthMax        = "Le {0} doit comporter au maximum {1} caractères";
        public const string MsgRange            = "Le {0} doit comporter entre {1} et {2} caractères";


        //ModelState Error
        public const string MseFileError        = "Le Type de fichier n'est pas autorísé.Envoyer uniquement des fichiers JPG.";
        public const string MseLogin            = "Utilisateur ou mot de passe invalide.";
        public const string MseEmailNotFound    = "Votre courriel n'existe pas dans notre système.";
        public const string MseEmailFound       = "Votre courriel dejá existe dans notre système.";
        public const string MseError            = "Une erreur est survenue dans l'opération, veuillez réessayer.";
    }
}