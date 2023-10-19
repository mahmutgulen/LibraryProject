using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.User
{
    public class UserUpdateDto : IDto
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserSurname { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Telefon numarası 10 hane olmalıdır.")]
        public string UserPhoneNumber { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 20, ErrorMessage = "Adres minimum 20 karakter olmalıdır.")]
        public string UserAddress { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Tc kimlik numarası 11 hane olmalıdır.")]
        public string UserIdentityNumber { get; set; }
    }
}
