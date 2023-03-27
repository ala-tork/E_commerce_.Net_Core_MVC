using System.ComponentModel.DataAnnotations;

namespace E_commerce.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Full Name")]
        public string FullName { get; set; }
        [Display(Name ="Bio")]
        public string Bio { get; set; }
        [Display(Name = "Profile Picture Url")]
        public string ProfilePictureURL { get; internal set; }
        //Relationships
        public List<Actor_Movie> Actors_Movies { get; set; }

    }
}
