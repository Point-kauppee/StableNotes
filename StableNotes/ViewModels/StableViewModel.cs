using StableNotes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StableNotes.ViewModels
{
    public class StableViewModel
    {
        public StableViewModel()
        {
            //this.Address = new HashSet<Address>();
            //this.Horse = new HashSet<Horse>();
            this.TallinTiedot = new HashSet<StableViewModel>();
            // this.Stable = new HashSet<Stable>();//Kokeilu
            //this.Person = new HashSet<Person>();
        }

        public string StableId { get; set; }
        public string Name { get; set; }
        public string Registernumber { get; set; }
        public string Note { get; set; }
        public DateTime Created { get; set; }
        public string UserId { get; set; }

        public string HorseId { get; set; }
        public string Horsename { get; set; }

        public string Horseregisternumber { get; set; }
        public string HorseURL { get; set; }
        public string Horsenote { get; set; }

        public virtual ICollection<StableViewModel> TallinTiedot { get; set; }
        public virtual ICollection<Horse> Horse { get; set; }//Kokeilu
        public virtual ICollection<Stable> Stable { get; set; } 
    }
}