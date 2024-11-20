using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountsMicroservice.Models {
    public class Movement {

        [Key]
        public int Id {get; set;}

        public DateTime Date {get; set;}

        public string? Type {get; set;}

        public float Ammount {get; set;}

        public float InitialBalance {get; set;}

        public string AccountNumber {get; set;}

        [ForeignKey("AccountNumber")]
        public virtual Account Account {get; set;}

        public string Description => $"{Type} de {Ammount}";
    }
}