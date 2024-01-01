﻿using System.ComponentModel.DataAnnotations;
using AutoMarket.Domain.Enum;
using Microsoft.AspNetCore.Http;

namespace AutoMarket.Domain.ViewModels.Car
{
    public class CarViewModel
    {
        public long Id { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Введите Имя")]
        [MinLength(2,ErrorMessage = "Минимальная длина должна быть больше двух символов")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        [MinLength(90,ErrorMessage = "Минимальна длина должна быть больше 90 символов")]
        public string Description { get; set; }

        [Display(Name = "Модель")]
        [Required(ErrorMessage = "Укажите модель")]
        [MinLength(2, ErrorMessage = "Минимальная длина должна быть больше двух символов")]
        public string Model { get; set; }

        [Display(Name = "Скорость")]
        [Required(ErrorMessage = "Укажите скорость")]
        [Range(0, 600, ErrorMessage = "Длина должна быть в диапазоне от 0 до 600")]
        public double Speed { get; set; }

        [Display(Name = "Стоимость")]
        [Required(ErrorMessage = "Укажите стоимость")]
        public decimal Price { get; set; }

        public DateTime DateCreate { get; set; }

        [Display(Name = "Тип автомобиля")]
        [Required(ErrorMessage = "Выберите тип")]
        public string TypeCar { get; set; }

        public IFormFile Avatar { get; set; }
    }
}
