using System.ComponentModel.DataAnnotations;

namespace E_commerce.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Full Name")]
        public string FullName { get; set; }
        [Display(Name ="Picture")]
        public string ProfilePictureURL { get; set; }
        [Display(Name ="Bio")]
        public string Bio { get; set; }
        //Relation shipq
        public List<Movie> Movies { get; set; }
    }
}
