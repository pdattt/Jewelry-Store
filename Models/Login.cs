using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Email không được để trống!!")]
        [StringLength(50)]
        [EmailAddress(ErrorMessage = "Định dạng email không hợp lệ!!")]

        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Mật khẩu không được để trống!!")]
        [StringLength(16)]
        [MinLength(6, ErrorMessage = "Mật khẩu phải có chiều dài tối thiểu là 6 ký tự và tối đa 16 ký tự.")]
        public string Password { get; set; }

        public string Username { get; set; }
    }
}