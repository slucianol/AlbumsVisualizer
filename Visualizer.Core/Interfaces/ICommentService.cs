using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Visualizer.Core.Entities;

namespace Visualizer.Core.Interfaces {
    public interface ICommentService : IGenericService<CommentEntity> {
        IQueryable<CommentEntity> GetCommentsByPhotoId(short photoId);
    }
}
