using MvcRehber1.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcRehber1.Models.Entitites
{

    [Table("Kisiler")]
    public class Kisi
    {
        public int Id { get; set; }

        public string Ad { get; set; }

        public string Soyad { get; set; }

        [DisplayName("Ev Telefonu")]
        public string EvTelefon { get; set; }
        
        [DisplayName("Cep Telefonu")]
        public string CepTelefon { get; set; }

        
        [DisplayName("Is Telefonu")]
        public string IsTelefon { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        public int CurrentId { get; set; }

        public string Adres { get; set; }

        [DisplayName("Şehir")]
        public int SehirId { get; set; }

        public Sehir Sehir { get; set; }

    }
}                    