using Newtonsoft.Json;
using StableNotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace StableNotes.Controllers
{
    public class MedicineController : Controller
    {
        // GET: Medicine
        public ActionResult List()
        {
            ViewBag.Tallinnimi = "Tillin talli";

            kauppeedbEntities entities = new kauppeedbEntities();
            List<Medicine> model = entities.Medicine.ToList();
            entities.Dispose();

            return View(model);
        }

        public ActionResult Index()
        {


            return View();
        }
        public JsonResult GetList()
        {
            kauppeedbEntities entities = new kauppeedbEntities();
            //List<Medicine> model = entities.Medicine.ToList();
            var model = (from c in entities.Medicine
                         select new
                         {
                             MedicineId = c.MedicineId,
                             Type = c.Type,
                             Quantity = c.Quantity,
                             Note = c.Note,
                             URL = c.URL,
                             Withdrawalperiod = c.Withdrawalperiod,
                             Purchaced = c.Purchaced
                         }).ToList();
            string json = JsonConvert.SerializeObject(model);
            entities.Dispose();

            Response.Expires = -1;
            Response.CacheControl = "no-cache";

            return Json(json, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetSingleMedicine(string id)
        {
            kauppeedbEntities entities = new kauppeedbEntities();
            //List<Medicine> model = entities.Medicine.ToList();
            var model = (from c in entities.Medicine
                         where c.MedicineId == id
                         select new
                         {
                             MedicineId = c.MedicineId,
                             Type = c.Type,
                             Quantity = c.Quantity,
                             Note = c.Note,
                             URL = c.URL,
                             Withdrawalperiod = c.Withdrawalperiod,
                             Purchaced = c.Purchaced
                         }).FirstOrDefault();

            string json = JsonConvert.SerializeObject(model);
            entities.Dispose();

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(Medicine medi)
        {
            kauppeedbEntities entities = new kauppeedbEntities();
            string id = medi.MedicineId;

            bool OK = false;

            //onko muokkaus vai lisääminen

            if (id == "(uusi)")
            {
                // uuden lisäys, kopioidaan kentät -- uusi MedicineId tulee tietueelle automaattisesti kantaan
                Medicine dbItem = new Medicine()
                {
                    MedicineId = medi.Type.Substring(0, 5).Trim().ToUpper(),
                    Type = medi.Type,
                    Quantity = medi.Quantity,
                    Note = medi.Note,
                    URL = medi.URL,
                    Withdrawalperiod = medi.Withdrawalperiod,
                    Purchaced = medi.Purchaced
                };
                //tallennus tietokantaan
                entities.Medicine.Add(dbItem);
                entities.SaveChanges();
                OK = true;

            }
            else
            {
                //muokkaus, haetaan id:n perusteella

                Medicine dbItem = (from c in entities.Medicine
                                 where c.MedicineId == id
                                 select c).FirstOrDefault();
                if (dbItem != null)
                {
                    dbItem.MedicineId = medi.MedicineId;
                    dbItem.Type = medi.Type;
                    dbItem.Quantity = medi.Quantity;
                    dbItem.Note = medi.Note;
                    dbItem.URL = medi.URL;
                    dbItem.Withdrawalperiod = medi.Withdrawalperiod;
                    dbItem.Purchaced = medi.Purchaced;
                    //tallennus tietokantaan
                    entities.SaveChanges();
                    OK = true;
                }
            }

            entities.Dispose();

            return Json(OK, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Delete(string id)
        {

            kauppeedbEntities entities = new kauppeedbEntities();

            //etsitään id:n perusteella
            bool OK = false;
            //muokkaus, haetaan id:n perusteella

            Medicine dbItem = (from c in entities.Medicine
                             where c.MedicineId == id
                             select c).FirstOrDefault();
            if (dbItem != null)
            {
                // tietokannasta poisto
                entities.Medicine.Remove(dbItem);
                entities.SaveChanges();
                OK = true;
            }

            entities.Dispose();

            return Json(OK, JsonRequestBehavior.AllowGet);
        }

    }
}