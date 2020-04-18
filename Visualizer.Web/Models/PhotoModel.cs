using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Visualizer.Web.Models {
    public class PhotoModel {
        public int PhotoId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}
