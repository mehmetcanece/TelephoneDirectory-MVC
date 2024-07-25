﻿using MvcRehber1.Models.Context;
using MvcRehber1.Models.Entities;
using MvcRehber1.Models.Entitites;
using MvcRehber1.Models.KullaniciModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rehber.Controllers
{
    public class KullaniciController : Controller
    {

        MvcRehber1Context db = new MvcRehber1Context();

        public ActionResult Index()
        {

            return View(db.Kullanicilar.ToList());
        }
        public ActionResult Kaydol()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kaydol(Kullanici kullanici)
        {
            var model = new KullaniciIndexViewModel
            {
                Kullanicilar = db.Kullanicilar.ToList(),
            };
            if (db.Kullanicilar.Any(x => x.Username == kullanici.Username))
            {

                ViewBag.Notification = "Bu kullanıcı mevcut.";
                return View();

            }
            if (kullanici.Username == null || kullanici.Password ==null )
            {
                ViewBag.Notification = "Kullanıcı adı veya şifre boş olamaz.";
                return View();
            }
            else
            {
                db.Kullanicilar.Add(kullanici);
                db.SaveChanges();

                Session["IdSS"] = kullanici.Id.ToString();
                Session["UsernameSS"] = kullanici.Username.ToString();
                return RedirectToAction("Index");
            }
        }

        public ActionResult CikisYap(Kisi kisi)
        {
            kisi.CurrentId = 0;
            Session.Clear();
            return RedirectToAction("GirisYap", "Kullanici");
        }

        [HttpGet]
        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GirisYap(Kullanici kullanici)
        {
            var checkLogin = db.Kullanicilar.Where(x => x.Username.Equals(kullanici.Username) && x.Password.Equals(kullanici.Password)).FirstOrDefault();
            if (checkLogin != null)
            {
                Session["IdSS"] = checkLogin.Id.ToString();
                Session["UsernameSS"] = checkLogin.Username.ToString();

                return RedirectToAction("Index","Kisi");
            }
            else
            {
                ViewBag.Notification = "Yanlış kullanıcı adı ya da şifre";
            }
            return View();
        }




    }
}