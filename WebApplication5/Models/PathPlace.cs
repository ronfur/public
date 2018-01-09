using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public class PathPlace
    {
        public int Id { get; set; }
        public int PathId { get; set; }
        //public Path Path { get; set; }
        public int PlaceId { get; set; }
        public Place Place { get; set; }
    }
}
