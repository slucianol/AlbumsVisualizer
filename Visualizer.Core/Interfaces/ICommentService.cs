using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visualizer.Core.Entities;

namespace Visualizer.Core.Interfaces {
    public interface ICommentsService : IGenericService<CommentEntity> {
        IEnumerable<CommentEntity> GetCommentsByPhotoId(int photoId);
    }
}
