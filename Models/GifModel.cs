using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GifAPI.Models
{
    public class GifModel
    {
        public GifModel(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        internal void Update(string name, string address)
        {
            Name = name;
            Address = address;
        }
    }
}
