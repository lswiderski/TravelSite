using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Models.ViewModels
{
    public class CreatePlaceViewModel
    {
        public string Name { get; set; }

        public string Content { get; set; }

        public string Photo_URI { get; set; }

        public int CountryId { get; set; }

        public string UserEmail { get; set; }

        public List<CountryModel> Countries { get; set; }
    }
}
