using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberi.API.Dtos
{
    public class CityForListDto
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String PhotoUrl { get; set; }
        public String Description { get; set; }
    }
}
