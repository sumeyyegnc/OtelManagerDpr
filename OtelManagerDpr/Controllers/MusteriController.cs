using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OtelManagerDpr;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using OtelManagerDpr.Models;

namespace OtelManagerDpr.Controllers
{
    [Authorize]
    public class MusteriController : Controller
    {
        public IActionResult Index()
        {
            return View(Context.Listeleme<MusteriModel>("MusteriViewAll"));
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
                param.Add("@MusteriNo", id);
                return View(Context.Listeleme<MusteriModel>("MusteriViewByNo", param).FirstOrDefault());
            }
        }

        [HttpPost]
        public IActionResult EY(MusteriModel musteri)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@MusteriNo", musteri.MusteriNo);
            param.Add("@AdSoyad", musteri.AdSoyad);
            param.Add("@TcNo", musteri.TcNo);
            param.Add("@Telefon", musteri.Telefon);
            param.Add("@Eposta", musteri.Eposta);
            param.Add("@Adres", musteri.Adres);
            Context.ExecuteReturn("MusteriEY", param);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@MusteriNo", id);
            Context.ExecuteReturn("MusteriSil", param);
            return RedirectToAction("Index");
        }

        public IActionResult ExportToPdf()
        {
            var musteriler = Context.Listeleme<MusteriModel>("MusteriViewAll");

            var pdf = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(20);

                    page.Header()
                        .Text("Müşteri Raporu")
                        .FontSize(20)
                        .Bold();

                    page.Content()
                        .Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(50);
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            table.Header(header =>
                            {
                                header.Cell().Text("No").Bold();
                                header.Cell().Text("Ad Soyad").Bold();
                                header.Cell().Text("TC No").Bold();
                                header.Cell().Text("Telefon").Bold();
                            });

                            foreach (var item in musteriler)
                            {
                                table.Cell().Text(item.MusteriNo.ToString());
                                table.Cell().Text(item.AdSoyad);
                                table.Cell().Text(item.TcNo);
                                table.Cell().Text(item.Telefon);
                            }
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Sayfa ");
                            x.CurrentPageNumber();
                        });
                });
            });

            var pdfBytes = pdf.GeneratePdf();

            return File(
                pdfBytes,
                "application/pdf",
                $"MusteriRapor_{DateTime.Now:yyyyMMdd}.pdf");
        }
        public IActionResult ExportToExcel()
        {
            ExcelPackage.License.SetNonCommercialPersonal("OtelManager");

            var musteriler = Context.Listeleme<MusteriModel>("MusteriViewAll");

            using (var package = new ExcelPackage())
            {
                var sheet = package.Workbook.Worksheets.Add("Musteriler");

                sheet.Cells[1, 1].Value = "No";
                sheet.Cells[1, 2].Value = "Ad Soyad";
                sheet.Cells[1, 3].Value = "TC No";
                sheet.Cells[1, 4].Value = "Telefon";
                sheet.Cells[1, 5].Value = "Eposta";

                using (var range = sheet.Cells[1, 1, 1, 5])
                {
                    range.Style.Font.Bold = true;
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

                int row = 2;

                foreach (var item in musteriler)
                {
                    sheet.Cells[row, 1].Value = item.MusteriNo;
                    sheet.Cells[row, 2].Value = item.AdSoyad;
                    sheet.Cells[row, 3].Value = item.TcNo;
                    sheet.Cells[row, 4].Value = item.Telefon;
                    sheet.Cells[row, 5].Value = item.Eposta;

                    row++;
                }

                sheet.Cells.AutoFitColumns();

                byte[] fileBytes = package.GetAsByteArray();

                return File(
                    fileBytes,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    $"MusteriRapor_{DateTime.Now:yyyyMMdd}.xlsx");
            }
        }
    }
}