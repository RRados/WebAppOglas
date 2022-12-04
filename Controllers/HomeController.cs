using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using WebAppOglas.Models;

namespace WebAppOglas.Controllers
{
    //[Route("api/[Controler]")]
    //[ApiController]
    public class HomeController : Controller
    {
        private IWebHostEnvironment _hostEnv;

        public HomeController(IWebHostEnvironment hostEnv, ILogger<HomeController> logger)
        {
            _hostEnv = hostEnv;
        }

        #region Stranice

        public IActionResult Index() { return View(); }
        public IActionResult Contact() { return View(); }
        public IActionResult About() { return View(); }

        [Authorize]
        [HttpGet]
        public IActionResult Dodaj() { return View(); }

        #endregion



        #region ViewModel stranice
        [HttpPost]
        public ActionResult Dodaj(Automobil automobil)
        {

            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;

                foreach (var Image in files)
                {
                    if (Image != null && Image.Length > 0)
                    {
                        var file = Image;

                        var uploads = Path.Combine(_hostEnv.WebRootPath, "img");

                        if (file.Length > 0)
                        {
                            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('\\');

                            using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                            {
                                file.CopyTo(fileStream);

                                automobil.Fotografija = Path.Combine(file.FileName);
                            }
                            var imageUrl = Path.Combine(file.FileName);
                        }
                    }
                }

                Oglas.DodajOglas(automobil);

                TempData["auto"] = automobil.Marka +
                                   automobil.Godiste +
                                   automobil.ZapreminaMotora +
                                   automobil.Snaga +
                                   automobil.Gorivo +
                                   automobil.Karoserija +
                                   automobil.Fotografija +
                                   automobil.Opis +
                                   automobil.Cena +
                                   automobil.Kontakt;

                return RedirectToAction("Detalji", new { id = automobil.Id });
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Detalji(int id)
        {
            MvcOglasContext db = new MvcOglasContext();

            Automobil automobil = db.Automobil.Where(p => p.Id == id).FirstOrDefault();

            if (automobil == null)
            {
                return NotFound();
            }

            return View(automobil);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Obrisi(int id)
        {
            if (ModelState.IsValid)
            {
                MvcOglasContext db = new MvcOglasContext();

                Automobil automobil = db.Automobil.Where(m => m.Id == id).FirstOrDefault();

                return View(automobil);
            }
            else
            {
                return View();
            }
        }


        [HttpPost]
        public IActionResult Obrisi(Automobil automobil)
        {

            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;

                foreach (var Image in files)
                {
                    if (Image != null && Image.Length > 0)
                    {
                        var file = Image;

                        var uploads = Path.Combine(_hostEnv.WebRootPath, "img");

                        if (file.Length > 0)
                        {
                            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('\\');

                            using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                            {
                                file.CopyTo(fileStream);

                                automobil.Fotografija = Path.Combine(file.FileName);
                            }
                            var imageUrl = Path.Combine(file.FileName);
                        }
                    }
                }

                Oglas.Obrisi(automobil);

                TempData["obrisanAuto"] = automobil.Marka +
                                          automobil.Godiste +
                                          automobil.ZapreminaMotora +
                                          automobil.Snaga +
                                          automobil.Gorivo +
                                          automobil.Karoserija +
                                          automobil.Fotografija +
                                          automobil.Opis +
                                          automobil.Cena +
                                          automobil.Kontakt;

                return RedirectToAction("Index");
            }
            else
            {
                return View("Obrisi");
            }
        }


        [HttpGet]
        public IActionResult Izmeni(int id)
        {
            if (ModelState.IsValid)
            {
                MvcOglasContext db = new MvcOglasContext();

                Automobil automobil = db.Automobil.Where(m => m.Id == id).FirstOrDefault();

                return View(automobil);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Izmeni(Automobil automobil)
        {

            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;

                foreach (var Image in files)
                {
                    if (Image != null && Image.Length > 0)
                    {
                        var file = Image;

                        var uploads = Path.Combine(_hostEnv.WebRootPath, "img");

                        if (file.Length > 0)
                        {
                            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('\\');

                            using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                            {
                                file.CopyTo(fileStream);

                                automobil.Fotografija = Path.Combine(file.FileName);
                            }
                            var imageUrl = Path.Combine(file.FileName);
                        }
                    }
                }
                Oglas.Izmeni(automobil);

                TempData["izmenjenAuto"] = automobil.Marka +
                                           automobil.Godiste +
                                           automobil.ZapreminaMotora +
                                           automobil.Snaga +
                                           automobil.Gorivo +
                                           automobil.Karoserija +
                                           automobil.Fotografija +
                                           automobil.Opis +
                                           automobil.Cena +
                                           automobil.Kontakt;

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
