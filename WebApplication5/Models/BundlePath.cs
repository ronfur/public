
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public class BundlePath
    {
        public int Id { get; set; }
        public int BundleId { get; set; }
        public int PathId { get; set; }
        public Path Path { get; set; }
    }
}
