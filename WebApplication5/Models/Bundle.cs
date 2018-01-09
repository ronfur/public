
using System.Collections.Generic;

namespace WebApplication5.Models
{
    public class Bundle
    {
        /*public Bundle()
        {
            this.Paths = new HashSet<Path>();
        }*/

        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Info { get; set; }
        public virtual List<BundlePath> BundlePaths { get; set; }
    }
}
