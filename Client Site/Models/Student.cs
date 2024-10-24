using System.ComponentModel.DataAnnotations;

namespace CRUDAppUsingAPI.Models
{
    public class Student
    {
        public int id { get; set; }
        [Required]
        public string fullname { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public int age { get; set; }
        [Required]
        public int _class { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string pass { get; set; }
    }
}
