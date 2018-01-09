
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication5.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication5.Controllers
{
    [Route("api/Bundle")]
    [Produces("application/json")]
    public class BundleController : Controller
    {
        [HttpGet]
        public List<Bundle> GetAllBundles()
        {
            using (ModelContext ModelContext = new ModelContext())
            {
                List<Bundle> list = ModelContext.Bundles.Include(bundle => bundle.BundlePaths).ThenInclude(bundlepath => bundlepath.Path).ToList();
                
                //List<Bundle> list = (from x in ModelContext.Bundles.Include(bundle => bundle.BundlePaths) select x).ToList();

                return list;
            }
        }

        [HttpGet("{id}", Name = "GetBundleById")]
        public Bundle GetBundleById(int id)
        {
            using (ModelContext ModelContext = new ModelContext())
            {
                Bundle item = (from x in ModelContext.Bundles where x.Id == id select x).FirstOrDefault<Bundle>();

                return item;
            }
        }
        
        [HttpPost]
        public void PostBundle([FromBody]Bundle value)
        {
            using (ModelContext ModelContext = new ModelContext())
            {
                int? maxid = ModelContext.Bundles.Max(x => (int?)x.Id);

                if (!maxid.HasValue) value.Id = 1;
                else value.Id = maxid.Value + 1;

                ModelContext.Bundles.Add(value);
                ModelContext.SaveChanges();
            }
        }
        
        [HttpPut("{id}")]
        public void PutBundle(int id, [FromBody]Bundle value)
        {
            foreach (BundlePath item in value.BundlePaths)
                item.Path = null;
            
            using (ModelContext ModelContext = new ModelContext())
            {
                Bundle item = (from p in ModelContext.Bundles.Include(bundle => bundle.BundlePaths) where p.Id == id select p).SingleOrDefault();
                    
                item.Image = value.Image;
                item.Info = value.Info;
                item.Name = value.Name;
                item.BundlePaths = new List<BundlePath>();
                ModelContext.SaveChanges();

                item.BundlePaths = value.BundlePaths;
                ModelContext.SaveChanges();

                /*foreach(BundlePath b in value.BundlePaths)
                {
                    item.BundlePaths.Add(b);
                    ModelContext.SaveChanges();
                }*/
            }
        }

        [HttpDelete("{id}")]
        public void DeleteBundle(int id)
        {
            using (ModelContext ModelContext = new ModelContext())
            {
                Bundle item = (from p in ModelContext.Bundles where p.Id == id select p).SingleOrDefault();

                ModelContext.Bundles.Remove(item);
                ModelContext.SaveChanges();
            }
        }
    }
}
