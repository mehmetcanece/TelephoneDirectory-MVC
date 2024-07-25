using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcRehber1.Models.Entities
{
    public class Kullanici
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Kullanıcı Adı Girilmesi Gereklidir!")]
        [DisplayName("Kullanıcı Adı")]
        public string Username { get; set; }


        
        [Required(ErrorMessage = "Şifre Girilmesi Gereklidir!")]
        [DisplayName("Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}