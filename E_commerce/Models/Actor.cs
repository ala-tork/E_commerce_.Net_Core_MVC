using E_commerce.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace E_commerce.Models
{
    public class Actor: IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Profile Picture Url")]
        [Required(ErrorMessage = "Picture URL is required")]
        public string ProfilePictureURL { get; set; }

        [Display(Name ="Full Name")]
        [Required(ErrorMessage ="Full name is required")]
        [MinLength(8,ErrorMessage ="lenth should be more than 8")]

        public string FullName { get; set; }

        [Display(Name ="Bio")]
        [Required(ErrorMessage = "Bio is required")]
        [StringLength(50,MinimumLength =7,ErrorMessage ="length should be between 7 and 50 chars")]
        public string Bio { get; set; }

        //Relationships
        public List<Actor_Movie>? Actors_Movies { get; set; }

    }
}
