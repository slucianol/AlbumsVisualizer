using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visualizer.Core.Entities;
using Visualizer.Core.Interfaces;
using Visualizer.Infrastructure.DTO;
using Visualizer.Infrastructure.Helpers;

namespace Visualizer.Infrastructure.Services {
    public class CommentsService : ICommentsService {
        private readonly ServicesEndpoints servicesEndpoints;
        public CommentsService(IOptions<ServicesEndpoints> servicesEndpoints) {
            this.servicesEndpoints = servicesEndpoints.Value;
        }
        public IEnumerable<CommentEntity> GetAll() {
            string jsonString = HttpRequestHelper.GetJsonFromUri(servicesEndpoints.Comments);
            IEnumerable<CommentEntity> comments = JsonConvert.DeserializeObject<IEnumerable<CommentEntity>>(jsonString);
            return comments;
        }

        public CommentEntity GetById(int id) {
            string jsonString = HttpRequestHelper.GetJsonFromUri(servicesEndpoints.Comments);
            IEnumerable<CommentEntity> comments = JsonConvert.DeserializeObject<IEnumerable<CommentEntity>>(jsonString);
            return comments.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<CommentEntity> GetCommentsByPhotoId(int photoId) {
            string jsonString = HttpRequestHelper.GetJsonFromUri(servicesEndpoints.Comments);
            IEnumerable<CommentEntity> comments = JsonConvert.DeserializeObject<IEnumerable<CommentEntity>>(jsonString);
            return comments.Where(c => c.PostId == photoId);
        }
    }
}
