using MvcRehber1.Models.Entities;
using MvcRehber1.Models.Entitites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcRehber1.Models.Context
{
    public class MvcRehber1Context : DbContext
    {
        public MvcRehber1Context() : base("Server=(localdb)\\MSSQLLocalDB;Database=MvcRehberDB;Trusted_Connection=true")
        {

        }
        public DbSet<Kisi> Kisiler { get; set; }
        public DbSet<Sehir> Sehirler { get; set; }

        public DbSet<Kullanici> Kullanicilar { get; set; }

    }
}