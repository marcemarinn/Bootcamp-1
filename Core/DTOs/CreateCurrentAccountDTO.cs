using System.ComponentModel.DataAnnotations;

namespace Core.DTOs;

public class CreateCurrentAccountDTO
{

    [Required(ErrorMessage = "El campo OperationalLimit es obligatorio.")]
    public decimal? OperationalLimit { get; set; }

    [Required(ErrorMessage = "El campo MonthAverage es obligatorio.")]
    public decimal? MonthAverage { get; set; }

    [Required(ErrorMessage = "El campo Interest es obligatorio.")]
    public decimal? Interest { get; set; }

}



    
    //public Account Account { get; set; } = null!;


