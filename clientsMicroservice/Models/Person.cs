using System.ComponentModel.DataAnnotations;

namespace ClientsMicroservice.Models {
    public class Person {

        [Key]
        public int Id { get; set;}

        public string? Name { get; set;}

        public string? Gender { get; set;}

        public int Age { get; set;}

        public string? DocumentNumber { get; set;}

        public string? Address { get; set;}

        public string? PhoneNumber { get; set;}
    }
}
