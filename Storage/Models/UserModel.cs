using Storage.Core;
using Storage.Core.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Storage.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Введите логин")]
        [Display(Name = "Логин*")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [Display(Name = "Пароль*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class RegisterModel
    {
        public RegisterModel() { }
        [Required(ErrorMessage = "Введите логин")]
        [Display(Name = "Логин*")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [Display(Name = "Пароль*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [Display(Name = "Повторите пароль*")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
    public class ListUser
    {
        public ListUser(IUserRepository _userRepository)
        {
            Users = _userRepository.GetUserList();
        }
        public IList<User> Users { get; private set; }
    }
}