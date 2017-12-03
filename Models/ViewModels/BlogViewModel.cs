using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels
{
    public class BlogViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string PreviewText { get; set; }
        public string User { get; set; }
        public string FilePath { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
    }
}
