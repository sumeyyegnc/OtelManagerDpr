using Dapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using OtelManagerDpr.Models;
using System.Security.Claims;

namespace OtelManagerDpr.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(string kullaniciAdi, string sifre)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@KullaniciAdi", kullaniciAdi);
            var kullanici = Context.Listeleme<KullaniciModel>("KullaniciViewByAdi", param).FirstOrDefault();

            if (kullanici == null || !PasswordHelper.VerifyPassword(sifre, kullanici.SifreHash))
            {
                ViewBag.Hata = "Kullanıcı adı veya şifre hatalı.";
                return View();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, kullanici.KullaniciAdi),
                new Claim(ClaimTypes.Role, kullanici.Rol),
                new Claim("AdSoyad", kullanici.AdSoyad)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                new AuthenticationProperties { IsPersistent = true, ExpiresUtc = DateTime.UtcNow.AddHours(8) });

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(KullaniciModel kullanici, string sifre)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@KullaniciNo", 0);
            param.Add("@KullaniciAdi", kullanici.KullaniciAdi);
            param.Add("@SifreHash", PasswordHelper.HashPassword(sifre));
            param.Add("@AdSoyad", kullanici.AdSoyad);
            param.Add("@Rol", "Personel");
            Context.ExecuteReturn("KullaniciEY", param);
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        public IActionResult AccessDenied() => View();
    }
}