using System;
using System.Collections.Generic;
using System.Text;

namespace Visualizer.Core.Entities {
    public class AlbumEntity : BaseEntity {
        public short UserId { get; set; }
        public string Title { get; set; }
    }
}
