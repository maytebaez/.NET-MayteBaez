using System.ComponentModel.DataAnnotations;

namespace AccountsMicroservice.Models {
    public class Account {

        [Key]
        public string Number {get; set;}

        public string? Type {get; set;}

        public bool State {get; set;}

        public float Balance {get; set;}

        public int ClientId {get; set;}
    }
}