using Newtonsoft.Json;
using StableNotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace StableNotes.Controllers
{
    public class TrainingController : Controller
    {
        // GET: Training
        public ActionResult List()
        {
            ViewBag.Tallinnimi = "Tillin talli";

            kauppeedbEntities entities = new kauppeedbEntities();
            List<Training> model = entities.Training.ToList();
            entities.Dispose();

            return View(model);
        }

        public ActionResult Index()
        {
            kauppeedbEntities entities = new kauppeedbEntities();
            List<Training> model = entities.Training.ToList();

            entities.Dispose();

            return View(model);
        }



        public ActionResult DownloadViewPDF()
        {

            kauppeedbEntities entities = new kauppeedbEntities();
            List<Training> model = entities.Training.ToList();
            entities.Dispose();

            return new Rotativa.MVC.ViewAsPdf("PdfList", model) { FileName = "PdfList.pdf" };
        }

        public ActionResult PdfList()
        {
            kauppeedbEntities entities = new kauppeedbEntities();
            List<Training> model = entities.Training.ToList();
            entities.Dispose();
            return View(model);
        }
        public JsonResult GetList()
        {
            kauppeedbEntities entities = new kauppeedbEntities();
            var model = (from c in entities.Training
                         select new
                         {
                             TrainingId = c.TrainingId,
                             Type = c.Type,
                             Quantity = c.Quantity,
                             Note = c.Note
                            }).ToList();
            string json = JsonConvert.SerializeObject(model);
            entities.Dispose();

            Response.Expires = -1;
            Response.CacheControl = "no-cache";

            return Json(json, JsonRequestBehavior.AllowGet);


        }
        public JsonResult GetSingleTraining(string id)
        {
            kauppeedbEntities entities = new kauppeedbEntities();
            var model = (from c in entities.Training
                         where c.TrainingId == id
                         select new
                         {
                             TrainingId = c.TrainingId,
                             Type = c.Type,
                             Quantity = c.Quantity,
                             Note = c.Note
                         }).FirstOrDefault();

            string json = JsonConvert.SerializeObject(model);
            entities.Dispose();

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(Training train)
        {
            kauppeedbEntities entities = new kauppeedbEntities();
            string id = train.TrainingId;

            bool OK = false;

            //onko muokkaus vai lisääminen

            if (id == "(uusi)")
            {
                // uuden lisäys, kopioidaan kentät -- uusi StableId tulee tietueelle automaattisesti kantaan
                Training dbItem = new Training()
                {
                    TrainingId = train.Type.Substring(0, 5).Trim().ToUpper(),
                    //TrainingId = "testi",
                    Type = train.Type,
                    Quantity = train.Quantity,
                    Note = train.Note

                };
                //tallennus tietokantaan
                entities.Training.Add(dbItem);
                entities.SaveChanges();
                OK = true;

            }
            else
            {
                //muokkaus, haetaan id:n perusteella

                Training dbItem = (from c in entities.Training
                                 where c.TrainingId == id
                                 select c).FirstOrDefault();
                if (dbItem != null)
                {
                    dbItem.TrainingId = train.TrainingId;
                    dbItem.Type = train.Type;
                    dbItem.Quantity = train.Quantity;
                    dbItem.Note = train.Note;

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

            Training dbItem = (from c in entities.Training
                             where c.TrainingId == id
                             select c).FirstOrDefault();
            if (dbItem != null)
            {
                // tietokannasta poisto
                entities.Training.Remove(dbItem);
                entities.SaveChanges();
                OK = true;
            }

            entities.Dispose();

            return Json(OK, JsonRequestBehavior.AllowGet);
        }
    }
}