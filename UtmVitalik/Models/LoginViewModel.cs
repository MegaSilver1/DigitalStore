using System.ComponentModel.DataAnnotations;

namespace UtmVitalik.BusinessLogic.DB
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Имя пользователя")]
        public string Name { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}