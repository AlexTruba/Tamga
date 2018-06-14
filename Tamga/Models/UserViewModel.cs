

namespace Tamga.Models
{
    using AutoMapper;
    using DB.Model;
    using System;
    using System.ComponentModel.DataAnnotations;
    using Tamga.Validation;
    
    public class UserViewModel
    {
        public static UserViewModel GetUserViewModel(User user)
        {
            return Mapper.Map<User, UserViewModel>(user);
        }
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Поле \"Фамилия\" обязательно для заполнения.")]
        public string Surname { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Поле \"Имя\" обязательно для заполнения.")]
        public string Name { get; set; }

        [Display(Name = "Отчество")]
        [Required(ErrorMessage = "Поле \"Отчество\" обязательно для заполнения.")]
        public string Patronymic { get; set; }

        [Display(Name = "Мобильный телефон")]
        [Required(ErrorMessage = "Необходимо указать телефон.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Трудоустроен")]
        public bool Employed { get; set; }

        [Display(Name = "Название компании")]
        [RequiredIfOtherFieldTrueAttribute("Employed", ErrorMessage = "Необходимо указать компанию.")]
        public string OrganizationName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата приема на работу")]
        [RequiredIfOtherFieldTrueAttribute("Employed", ErrorMessage = "Необходимо указать дату начали карьеры.")]
        public DateTime? StartOnUtc { get; set; }
    }
}