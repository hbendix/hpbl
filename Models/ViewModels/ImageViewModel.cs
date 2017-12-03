using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class ImageViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FilePath { get; set; }
        public string Country { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public DateTime Taken { get; set; }
    }
}
