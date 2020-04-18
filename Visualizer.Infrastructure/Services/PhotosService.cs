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
    public class PhotosService : IPhotosService {
        private readonly ServicesEndpoints servicesEndpoints;
        public PhotosService(IOptions<ServicesEndpoints> servicesEndpoints) {
            this.servicesEndpoints = servicesEndpoints.Value;
        }
        public IEnumerable<PhotoEntity> GetAll() {
            string jsonString = HttpRequestHelper.GetJsonFromUri(servicesEndpoints.Photos);
            IEnumerable<PhotoEntity> photos = JsonConvert.DeserializeObject<IEnumerable<PhotoEntity>>(jsonString);
            return photos;
        }

        public PhotoEntity GetById(int id) {
            string jsonString = HttpRequestHelper.GetJsonFromUri(servicesEndpoints.Photos);
            IEnumerable<PhotoEntity> photos = JsonConvert.DeserializeObject<IEnumerable<PhotoEntity>>(jsonString);
            return photos.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<PhotoEntity> GetPhotosByAlbumId(int albumId) {
            string jsonString = HttpRequestHelper.GetJsonFromUri(servicesEndpoints.Photos);
            IEnumerable<PhotoEntity> photos = JsonConvert.DeserializeObject<IEnumerable<PhotoEntity>>(jsonString);
            return photos.Where(p => p.AlbumId == albumId);
        }
    }
}
