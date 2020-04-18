using System;
using System.Collections.Generic;
using System.Text;

namespace Visualizer.Core.Entities {
    public class CommentEntity : BaseEntity {
        public short PostId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
    }
}
