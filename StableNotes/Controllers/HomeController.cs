using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StableNotes.ViewModels;
using StableNotes.Models;

namespace StableNotes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<StableViewModel> model = new List<StableViewModel>();

            kauppeedbEntities entities = new kauppeedbEntities();

            try
            {
                List<Horse> horses = entities.Horse.OrderBy(Horse => Horse.Horsename).ToList();
                foreach (Horse horse in horses)
                {
                    StableViewModel view = new StableViewModel();
                    view.StableId = horse.StableId;
                    //view.Name = Name;
                    view.Horsename = horse.Horsename;
                    view.Horseregisternumber = horse.Horseregisternumber;
                    view.HorseURL = horse.HorseURL;
                    view.Horsenote = horse.Horsenote;

                    model.Add(view);
                }
            }

            finally
            {
                entities.Dispose();
            }

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Tämä on kuvaus järjestelmästä.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Tämä on järjestelmän kehittäjän ja markkinoijan yhteystietosivu.";

            return View();
        }
    }
}