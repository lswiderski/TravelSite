using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.Models.ViewModels
{
    public class CreateTravelViewModel
    {

        public string UserEmail { get; set; }
        public int PlaceId { get; set; }
        public DateTime Date { get; set; }
    }
}