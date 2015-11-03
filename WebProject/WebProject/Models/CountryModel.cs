using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Models
{
    public class CountryModel
    {
        [Key]
        public int CountryId { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public void Create(CountryModel model)
        {
            using (var db = new webprojectDBEntities())
            {
                db.Country.Add(new Country()
                {
                    Name = model.Name,
                    Code = model.Code,
                });
                db.SaveChanges();
            }
        }
        public List<CountryModel> GetCountries()
        {
            var db = new webprojectDBEntities();
            return db.Country.Select(x => new CountryModel { Code = x.Code, CountryId = x.CountryId, Name = x.Name }).ToList();
        }
    }
}
