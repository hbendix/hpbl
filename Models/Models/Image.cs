using System;
using System.Text;
using System.Collections.Generic;

namespace Models
{
    public class Image
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