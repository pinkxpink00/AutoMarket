using System.ComponentModel.DataAnnotations;

namespace AutoMarket.Domain.Enum
{
    public enum TypeCar
    {
        [Display(Name="Легковой автомобиль")]
        PassengerCar = 0,
        [Display(Name = "Седан")]
        Sedan = 1,
        [Display(Name = "Хэтчбэк")]
        Hatchback = 2,
        [Display(Name = "Минивэн")]
        Minivan = 3,
        [Display(Name = "Спортивный автомобиль")]
        SportCar = 4,
        [Display(Name = "Внедорожный автомобиль")]
        Suv = 5,
    }
}
