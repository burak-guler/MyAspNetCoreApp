using Microsoft.AspNetCore.Mvc;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class OrnekController : Controller
    {
        public IActionResult Index()
        {
            //View tarafa data taşımak için;
            //ViewBag, ViewData, TempData, ViewModel Kullanılır.

            //VİEWBAG
            //controllerdan view tarafa daha küçük hacimli datalar
            // taşımak için viewbag kullanılır.
            ViewBag.name = "Asp.Net Core";
            //foreach ile yazdırılır.
            ViewBag.list = new List<string>() {"burak","ahmet","mehmet"};

            //VİEWDATA
            ViewData["age"] = 30;
            ViewData["names"] = new List<string>() { "Burak", "Talha", "Bertuğ", "Bahadır", "Umut" };

            //TEMPDATA
            //TempData ile bu actiondan ve viewden başka action ve view e data taşıyabiliriz.
            TempData["id"] = 2;
            TempData["name"] = "Burak";
            TempData["surname"] = "Güler";

            return View();
        }

        public IActionResult Index2()
        {
            //başka bir actiondan gelen datalar (index den )
            var Name = TempData["name"];    
            var surname = TempData["surname"];
            var id = TempData["id"];    
            return View();
        }

        //başka sayfaya gönderme action'u
        public IActionResult Index3()
        {
            return RedirectToAction("Index","Ornek");  
        }
        
        public IActionResult ParametreView(int id)
        {
            return RedirectToAction("JsonResultParametre", new {id=id});  
        }

        public IActionResult JsonResultParametre(int id)
        {
            return Json(new { Id = id});
        }

        //String bir ifade döndürmek için Content geri dönüşü kullanılır.
        //url'de /controller/action ismi çağırılırsa boş sayfada string ifade yazar.
        public IActionResult ContentResult()
        {
            return Content("ContentResult");
        }

        //Json bir ifade döndürmek için json geri dönüşü kullanılır.
        //url'de /controller/action ismi çağırılırsa boş sayfada json ifade yazar.
        public IActionResult JsonResult()
        {
            return Json(new { Id = 1, name = "Burak", Price = 100 });
        }
                
        //url'de /controller/action ismi çağırılırsa boş sayfa karşımıza gelir
        public IActionResult EmptyResult()
        {
            return new EmptyResult();
        }

    }
}
