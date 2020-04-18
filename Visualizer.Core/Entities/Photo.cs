using System;
using System.Collections.Generic;
using System.Text;

namespace Visualizer.Core.Entities {
    public class PhotoEntity : BaseEntity {
        public short AlbumId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}
