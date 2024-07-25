using MvcRehber1.Models.Entities;
using MvcRehber1.Models.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcRehber1.Models.KisiModel
{
    public class KisiGuncelleViewModel
    {
        public Kisi Kisi { get; set; }  
        public List<Sehir> Sehirler  { get; set; }

        public List<Kullanici> Kullanicilar { get; set; }

    }
}