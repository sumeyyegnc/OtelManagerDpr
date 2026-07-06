using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OtelManagerDpr.Models;

namespace OtelManagerDpr.Controllers
{
    [Authorize]
    public class OdaController : Controller
    {
        public IActionResult Index()
        {
            return View(Context.Listeleme<OdaModel>("OdaViewAll"));
        }

        public IActionResult EY(int id = 0)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@OdaNo", id);
                return View(Context.Listeleme<OdaModel>("OdaViewByNo", param).FirstOrDefault());
            }
        }

        [HttpPost]
        public IActionResult EY(OdaModel oda)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@OdaNo", oda.OdaNo);
            param.Add("@OdaKodu", oda.OdaKodu);
            param.Add("@OdaTipi", oda.OdaTipi);
            param.Add("@Fiyat", oda.Fiyat);
            param.Add("@Kapasite", oda.Kapasite);
            param.Add("@Durum", oda.Durum);
            Context.ExecuteReturn("OdaEY", param);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@OdaNo", id);
            Context.ExecuteReturn("OdaSil", param);
            return RedirectToAction("Index");
        }
    }
}