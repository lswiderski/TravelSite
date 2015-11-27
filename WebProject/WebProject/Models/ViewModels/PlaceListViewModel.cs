using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Models.ViewModels
{
    public class PlaceListViewModel
    {
        public List<CountryModel> Countries { get; set; }
        public int CountryId { get; set; }
        public List<PlaceViewModel> Places { get; set; }
    }
}
