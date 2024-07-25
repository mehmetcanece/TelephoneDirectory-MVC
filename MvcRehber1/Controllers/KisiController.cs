﻿using MvcRehber1.Models.Context;
using MvcRehber1.Models.Entitites;
using MvcRehber1.Models.KisiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace rehber.Controllers
{
    public class KisiController : Controller
    {
        MvcRehber1Context db = new MvcRehber1Context();
        // GET: Kisi
        public ActionResult Index()
        {
            var simdikiKullanici = Convert.ToInt32(Session["IdSS"]);

            var model = new KisiIndexViewModel
            {
                Kisiler = db.Kisiler.Where(x=>x.CurrentId == simdikiKullanici).ToList(),
                Sehirler = db.Sehirler.ToList(),
                Kullanicilar = db.Kullanicilar.ToList()
            };
            return View(model);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            var model = new KisiEkleViewModel
            {
                Kisi = new Kisi(),
                Sehirler = db.Sehirler.ToList(),
                Kullanicilar = db.Kullanicilar.ToList()

            };
            return View(model);

        }
        [HttpPost]
        public ActionResult Ekle(Kisi kisi)
        {
            try
            {
                kisi.CurrentId = Convert.ToInt32(Session["IdSS"]);
                db.Kisiler.Add(kisi);
                db.SaveChanges();

                TempData["BasariliMesaj"] = "Ekleme İşlemi Başarıyla Gerçekleşti.";

            }
            catch (Exception)
            {
                TempData["HataliMesaj"] = "Hata Oluştu! Lütfen Yeniden Deneyiniz.";

            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            var kisi = db.Kisiler.Find(id);

            if (kisi == null)
            {
                TempData["HataliMesaj"] = "Güncellenmek istenen kayıt bulunamadı!";
                return RedirectToAction("Index");

            }
            var model = new KisiGuncelleViewModel
            {
                Kisi = kisi,
                Sehirler = db.Sehirler.ToList(),
                Kullanicilar = db.Kullanicilar.ToList()

            };

            ViewBag.Sehirler = new SelectList(db.Sehirler.ToList(), "Id", "SehirAdi");
            return View(model);

        }
        [HttpPost]
        public ActionResult Guncelle(Kisi kisi)
        {
            var eskiKisi = db.Kisiler.Find(kisi.Id);

            if (eskiKisi == null)
            {
                TempData["HataliMesaj"] = "Güncellenmek istenen kayıt bulunamadı!";
                return RedirectToAction("Index");

            }
            eskiKisi.Ad = kisi.Ad;
            eskiKisi.Soyad = kisi.Soyad;
            eskiKisi.CepTelefon = kisi.CepTelefon;
            eskiKisi.Email = kisi.Email;
            eskiKisi.Adres = kisi.Adres;
            eskiKisi.SehirId = kisi.SehirId;

            db.SaveChanges();

            TempData["BasariliMesaj"] = "Kişi Bilgeleri Başarıyla Güncellendi.";


            return RedirectToAction("Index");

        }

        [HttpGet]

        public ActionResult Detay(int id)
        {

            var kisi = db.Kisiler.Find(id);

            if (kisi == null)
            {
                TempData["HataliMesaj"] = "Kişi Bulunamadı!";
                return RedirectToAction("Index");

            }
            var model = new KisiDetayViewModel
            {
                Kisi = kisi,
                Sehirler = db.Sehirler.ToList()
            };
            return View(model);
        }

        public ActionResult Sil(int id)
        {
            var kisi = db.Kisiler.Find(id);

            if (kisi == null)
            {
                TempData["HataliMesaj"] = "Kişi Bulunamadı!";
                return RedirectToAction("Index");
            }
            db.Kisiler.Remove(kisi);
            db.SaveChanges();

            TempData["BasariliMesaj"] = "Kişi Veritabanından Silinmiştir";


            return RedirectToAction("Index");
        }


    }
}