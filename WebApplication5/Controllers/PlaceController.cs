
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [Route("api/Place")]
    [Produces("application/json")]
    public class PlaceController : Controller
    {
        [HttpGet]
        public List<Place> GetAllPlaces()
        {
            using (ModelContext ModelContext = new ModelContext())
            {
                return ModelContext.Places.ToList();
            }
        }

        [HttpGet("{id}", Name = "GetPlaceById")]
        public Place GetPlaceById(int id)
        {
            using (ModelContext ModelContext = new ModelContext())
            {
                Place item = (from p in ModelContext.Places where p.Id == id select p).SingleOrDefault();
                return item;
            }
        }

        [HttpPost]
        public void PostPlace([FromBody]Place value)
        {
            using (ModelContext ModelContext = new ModelContext())
            {
                int? maxid = ModelContext.Places.Max(x => (int?)x.Id);

                if (!maxid.HasValue) value.Id = 1;
                else value.Id = maxid.Value + 1;

                ModelContext.Places.Add(value);

                ModelContext.SaveChanges();
            }
        }

        [HttpPut("{id}")]
        public void PutPlace(int id, [FromBody]Place value)
        {
            using (ModelContext ModelContext = new ModelContext())
            {
                Place item = (from p in ModelContext.Places where p.Id == id select p).SingleOrDefault();

                item.Image = value.Image;
                item.Info = value.Info;
                item.Name = value.Name;
                item.Radius = value.Radius;

                ModelContext.SaveChanges();
            }
        }
        
        [HttpDelete("{id}")]
        public void DeletePlace(int id)
        {
            using (ModelContext ModelContext = new ModelContext())
            {
                Place item = (from p in ModelContext.Places where p.Id == id select p).SingleOrDefault();

                ModelContext.Places.Remove(item);

                ModelContext.SaveChanges();
            }
        }
    }
}
