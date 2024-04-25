using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMusic.EntityLayer.Entities
{
    public class Singer
    {
        public int SingerId { get; set; }
        public String Name { get; set; }
        public String ImageUrl { get; set; }

        public List<Album> Albums { get; set; }
    }
}
