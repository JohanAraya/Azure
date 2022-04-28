using System.ComponentModel.DataAnnotations;

namespace ComponentesMVC.ViewModels
{
    public class AccountViewModel
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]        
        public string ConfirmPassword { get; set; }
        [Required]
        //Raza que busca el usuario
        public string PetBreed{ get; set; }
        [Required]
        //Tipo que busca el usuario
        public string PetKind { get; set; }
        

        //Datos de la mascota
        [Required]
        public string PetName { get; set; }
        [Required]
        public string Breed { get; set; }
        [Required]
        public string Kind { get; set; }
        [Required]
        public string Sex { get; set; } 

    }
}
