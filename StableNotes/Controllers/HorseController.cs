using Newtonsoft.Json;
using StableNotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace StableNotes.Controllers
{
    public class HorseController : Controller
    {
        // GET: Horse
        public ActionResult List()
        {
            ViewBag.Tallinnimi = "Tillin talli";

            kauppeedbEntities entities = new kauppeedbEntities();
            List<Horse> model = entities.Horse.ToList();
            entities.Dispose();

            return View(model);
        }

        public ActionResult Index()
        {
            kauppeedbEntities entities = new kauppeedbEntities();
            List<Horse> model = entities.Horse.ToList();

            entities.Dispose();

            return View(model);
        }



        public ActionResult DownloadViewPDF()
        {

            kauppeedbEntities entities = new kauppeedbEntities();
            List<Horse> model = entities.Horse.ToList();
            entities.Dispose();

            return new Rotativa.MVC.ViewAsPdf("PdfList", model) { FileName = "PdfList.pdf" };
        }

        public ActionResult PdfList()
        {
            kauppeedbEntities entities = new kauppeedbEntities();
            List<Horse> model = entities.Horse.ToList();
            entities.Dispose();
            return View(model);
        }
        public JsonResult GetList()
        {
            kauppeedbEntities entities = new kauppeedbEntities();
            var model = (from c in entities.Horse
                         select new
                         {
                             HorseId = c.HorseId,
                             Name = c.Name,
                             Registernumber = c.Registernumber,
                             URL = c.URL,
                             Note = c.Note,
                             Created = c.Created,
                             StableId = c.StableId,
                             PersonId = c.PersonId,
                             UserId = c.UserId
                            }).ToList();
            string json = JsonConvert.SerializeObject(model);
            entities.Dispose();

            Response.Expires = -1;
            Response.CacheControl = "no-cache";

            return Json(json, JsonRequestBehavior.AllowGet);


        }
        public JsonResult GetSingleHorse(string id)
        {
            kauppeedbEntities entities = new kauppeedbEntities();
            var model = (from c in entities.Horse
                         where c.HorseId == id
                         select new
                         {
                             HorseId = c.HorseId,
                             Name = c.Name,
                             Registernumber = c.Registernumber,
                             URL = c.URL,
                             Note = c.Note,
                             Created = c.Created,
                             StableId = c.StableId,
                             PersonId = c.PersonId,
                             UserId = c.UserId

                         }).FirstOrDefault();

            string json = JsonConvert.SerializeObject(model);
            entities.Dispose();

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(Horse hors)
        {
            kauppeedbEntities entities = new kauppeedbEntities();
            string id = hors.HorseId;

            bool OK = false;

            //onko muokkaus vai lisääminen

            if (id == "(uusi)")
            {
                // uuden lisäys, kopioidaan kentät -- uusi StableId tulee tietueelle automaattisesti kantaan
                Horse dbItem = new Horse()
                {
                    HorseId = hors.Name.Substring(0, 5).Trim().ToUpper(),
                    //HorseId = "testi",
                    Name = hors.Name,
                    Registernumber = hors.Registernumber,
                    URL = hors.URL,
                    Note = hors.Note,
                    Created = hors.Created,
                    StableId = hors.StableId,
                    PersonId = hors.PersonId,
                    UserId =  hors.UserId

                };
                //tallennus tietokantaan
                entities.Horse.Add(dbItem);
                entities.SaveChanges();
                OK = true;

            }
            else
            {
                //muokkaus, haetaan id:n perusteella

                Horse dbItem = (from c in entities.Horse
                                 where c.HorseId == id
                                 select c).FirstOrDefault();
                if (dbItem != null)
                {
                    dbItem.HorseId = hors.HorseId;
                    dbItem.Name = hors.Name;
                    dbItem.Registernumber = hors.Registernumber;
                    dbItem.URL = hors.URL;
                    dbItem.Note = hors.Note;
                    dbItem.Created = hors.Created;
                    dbItem.StableId = hors.StableId;
                    dbItem.PersonId = hors.PersonId;
                    dbItem.UserId = hors.UserId;

                    //tallennus tietokantaan
                    entities.SaveChanges();
                    OK = true;
                }
                //entities.SaveChanges();
                }
            //entities.SaveChanges();

            entities.Dispose();

            return Json(OK, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Delete(string id)
        {

            kauppeedbEntities entities = new kauppeedbEntities();

            //etsitään id:n perusteella
            bool OK = false;
            //muokkaus, haetaan id:n perusteella

            Horse dbItem = (from c in entities.Horse
                             where c.HorseId == id
                             select c).FirstOrDefault();
            if (dbItem != null)
            {
                // tietokannasta poisto
                entities.Horse.Remove(dbItem);
                entities.SaveChanges();
                OK = true;
            }

            entities.Dispose();

            return Json(OK, JsonRequestBehavior.AllowGet);
        }
    }
}