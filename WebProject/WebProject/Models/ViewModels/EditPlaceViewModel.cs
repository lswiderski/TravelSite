using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.Models.ViewModels
{
    public class EditPlaceViewModel
    {
        public int PlaceId { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public string Photo_URI { get; set; }

        public int CountryId { get; set; }

        public string UserEmail { get; set; }

        public List<CountryModel> Countries { get; set; }
        public string ContentPT { get; set; }
        public string ContentPL { get; set; }
    }
}