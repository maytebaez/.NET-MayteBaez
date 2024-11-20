
namespace ClientsMicroservice.Models.Dtos
{
    public class ReportDto{
        public string NumeroDeCuenta {get; set;}
        public string TipoDeCuenta {get; set;}
        public List<MovementDto> Movimientos {get; set;} 
    }

    public class MovementDto {
        public DateTime Fecha {get; set;}
        public string Tipo {get; set;}
        public float Monto {get; set;}
    }
}