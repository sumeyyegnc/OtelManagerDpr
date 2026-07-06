using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OtelManagerDpr;
using OtelManagerDpr.Models;

namespace OtelManagerDpr.Controllers
{
    [Authorize]
    public class RezervasyonController : Controller
    {
        public IActionResult Index()
        {
            return View(Context.Listeleme<RezervasyonModel>("RezervasyonViewAll"));
        }

        public IActionResult EY(int id = 0)
        {
            ViewBag.Musteriler = Context.Listeleme<MusteriModel>("MusteriViewAll");
            ViewBag.Odalar = Context.Listeleme<OdaModel>("OdaViewAll");

            if (id == 0)
            {
                return View();
            }
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@RezervasyonNo", id);
                return View(Context.Listeleme<RezervasyonModel>("RezervasyonViewByNo", param).FirstOrDefault());
            }
        }

        [HttpPost]
        public IActionResult EY(RezervasyonModel rezervasyon)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@RezervasyonNo", rezervasyon.RezervasyonNo);
            param.Add("@MusteriNo", rezervasyon.MusteriNo);
            param.Add("@OdaNo", rezervasyon.OdaNo);
            param.Add("@GirisTarihi", rezervasyon.GirisTarihi);
            param.Add("@CikisTarihi", rezervasyon.CikisTarihi);
            param.Add("@ToplamTutar", rezervasyon.ToplamTutar);
            Context.ExecuteReturn("RezervasyonEY", param);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id = 0, int odaNo = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@RezervasyonNo", id);
            param.Add("@OdaNo", odaNo);
            Context.ExecuteReturn("RezervasyonSil", param);
            return RedirectToAction("Index");
        }
    }
}