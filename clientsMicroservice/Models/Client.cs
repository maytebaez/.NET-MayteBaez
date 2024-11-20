
namespace ClientsMicroservice.Models {
    public class Client : Person {
        public string? Password { get; set;}

        public bool State { get; set;}
    }
}