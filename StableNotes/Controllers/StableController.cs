using Newtonsoft.Json;
using StableNotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StableNotes.Controllers
{
    public class StableController : Controller
    {
        // GET: Stable
        public ActionResult Index()
        {
            ViewBag.Tallinnimi = "Tillin talli";

            kauppeedbEntities entities = new kauppeedbEntities();
            List<Stable> model = entities.Stable.ToList();
            entities.Dispose();

            return View(model);
        }

        public ActionResult Index2()
        {


            return View();
        }
        public ActionResult Index3()
        {


            return View();
        }
        public JsonResult GetList()
        {
            kauppeedbEntities entities = new kauppeedbEntities();
            //List<Stable> model = entities.Stable.ToList();
            var model = (from c in entities.Stable
                         select new
                         {
                             StableId = c.StableId,
                             Name = c.Name,
                             Registernumber = c.Registernumber,
                             Note = c.Note,
                             Created = c.Created

                         }).ToList();
            string json = JsonConvert.SerializeObject(model);
            entities.Dispose();

            Response.Expires = -1;
            Response.CacheControl ="no-cache";

            return Json(json, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetSingleStable(string id)
        {
            kauppeedbEntities entities = new kauppeedbEntities();
            //List<Stable> model = entities.Stable.ToList();
            var model = (from c in entities.Stable
                         where c.StableId == id
                         select new
                         {
                             StableId = c.StableId,
                             Name = c.Name,
                             Registernumber = c.Registernumber,
                             Note = c.Note,
                             Created = c.Created

                         }).FirstOrDefault();

            string json = JsonConvert.SerializeObject(model);
            entities.Dispose();

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(Stable stab)
        {
            kauppeedbEntities entities = new kauppeedbEntities();
            string id = stab.StableId;

            bool OK = false;

            //onko muokkaus vai lisääminen

            if (id == "(uusi)")
            {
                // uuden lisäys, kopioidaan kentät -- uusi StableId tulee tietueelle automaattisesti kantaan
                Stable dbItem = new Stable()
                {
                    StableId = stab.Name.Substring(0, 5).Trim().ToUpper(),
                    Name = stab.Name,
                    Registernumber = stab.Registernumber,
                    Note = stab.Note,
                    Created = stab.Created
                };
                //tallennus tietokantaan
                entities.Stable.Add(dbItem);
                entities.SaveChanges();
                OK = true;

            }
            else
            {
                //muokkaus, haetaan id:n perusteella

                Stable dbItem = (from c in entities.Stable
                                 where c.StableId == id
                                 select c).FirstOrDefault();
                if (dbItem != null)
                {
                    dbItem.StableId = stab.StableId;
                    dbItem.Name = stab.Name;
                    dbItem.Registernumber = stab.Registernumber;
                    dbItem.Note = stab.Note;
                    dbItem.Created = stab.Created;

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

            Stable dbItem = (from c in entities.Stable
                             where c.StableId == id
                             select c).FirstOrDefault();
            if (dbItem != null)
            {
                // tietokannasta poisto
                entities.Stable.Remove(dbItem);
                entities.SaveChanges();
                OK = true;
            }

            entities.Dispose();

            return Json(OK,JsonRequestBehavior.AllowGet);
        }

    }
}