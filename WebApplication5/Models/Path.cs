
using System.Collections.Generic;

namespace WebApplication5.Models
{
    public class Path
    {
        /*public Path()
        {
            this.Places = new HashSet<Place>();
        }*/

        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public string Length { get; set; }
        public string Duration { get; set; }
        public string Image { get; set; }
        public virtual ICollection<PathPlace> PathPlaces { get; set; }
        //public virtual List<BundlePath> BundlePaths { get; set; }
    }
}
