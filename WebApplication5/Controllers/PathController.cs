
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication5.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication5.Controllers
{
    [Route("api/Path")]
    [Produces("application/json")]
    public class PathController : Controller
    {
        [HttpGet]
        public List<Path> GetAllPaths()
        {
            using (ModelContext ModelContext = new ModelContext())
            {
                List<Path> list = ModelContext.Paths.Include(path => path.PathPlaces).ThenInclude(pathplace => pathplace.Place).ToList();

                //List<Bundle> list = (from x in ModelContext.Bundles.Include(bundle => bundle.BundlePaths) select x).ToList();

                return list;
            }
        }

        [HttpGet("{id}", Name = "GetPathById")]
        public Path GetPathById(int id)
        {
            using (ModelContext ModelContext = new ModelContext())
            {
                Path item = (from p in ModelContext.Paths where p.Id == id select p).SingleOrDefault();
                return item;
            }
        }

        [HttpPost]
        public void PostPlace([FromBody]Path value)
        {
            using (ModelContext ModelContext = new ModelContext())
            {
                int? maxid = ModelContext.Paths.Max(x => (int?)x.Id);

                if (!maxid.HasValue) value.Id = 1;
                else value.Id = maxid.Value + 1;

                ModelContext.Paths.Add(value);

                ModelContext.SaveChanges();
            }
        }

        [HttpPut("{id}")]
        public void PutPath(int id, [FromBody]Path value)
        {
            foreach (PathPlace item in value.PathPlaces)
                item.Place = null;

            using (ModelContext ModelContext = new ModelContext())
            {
                Path item = (from p in ModelContext.Paths.Include(path => path.PathPlaces) where p.Id == id select p).SingleOrDefault();

                item.Image = value.Image;
                item.Info = value.Info;
                item.Name = value.Name;
                item.Length = value.Length;
                item.Duration = value.Duration;
                item.PathPlaces = new List<PathPlace>();
                ModelContext.SaveChanges();

                item.PathPlaces = value.PathPlaces;
                ModelContext.SaveChanges();
            }
        }
        
        [HttpDelete("{id}")]
        public void DeletePath(int id)
        {
            using (ModelContext ModelContext = new ModelContext())
            {
                Path item = (from p in ModelContext.Paths where p.Id == id select p).SingleOrDefault();

                ModelContext.Paths.Remove(item);

                ModelContext.SaveChanges();
            }
        }
    }
}
