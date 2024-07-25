using MvcRehber1.Models.Entities;
using MvcRehber1.Models.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcRehber1.Models.KullaniciModel
{
    public class KullaniciIndexViewModel
    {
        public List<Kullanici> Kullanicilar { get; set; }

        public Kisi Kisiler { get; set; }
    }
}