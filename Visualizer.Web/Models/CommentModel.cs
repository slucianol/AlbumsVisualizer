using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Visualizer.Web.Models {
    public class CommentModel {
        public int CommentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
    }
}
