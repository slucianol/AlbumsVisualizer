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
    public class AlbumsService : IAlbumsService {
        private readonly ServicesEndpoints servicesEndpoints;
        public AlbumsService(IOptions<ServicesEndpoints> servicesEndpoints) {
            this.servicesEndpoints = servicesEndpoints.Value;
        }
        public IEnumerable<AlbumEntity> GetAlbumsByUserId(int userId) {
            string jsonString = HttpRequestHelper.GetJsonFromUri(servicesEndpoints.Albums);
            IEnumerable<AlbumEntity> albums = JsonConvert.DeserializeObject<IEnumerable<AlbumEntity>>(jsonString);
            return albums.Where(a => a.UserId == userId);
        }

        public IEnumerable<AlbumEntity> GetAll() {
            string jsonString = HttpRequestHelper.GetJsonFromUri(servicesEndpoints.Albums);
            IEnumerable<AlbumEntity> albums = JsonConvert.DeserializeObject<IEnumerable<AlbumEntity>>(jsonString);
            return albums;
        }

        public AlbumEntity GetById(int id) {
            string jsonString = HttpRequestHelper.GetJsonFromUri(servicesEndpoints.Albums);
            IEnumerable<AlbumEntity> albums = JsonConvert.DeserializeObject<IEnumerable<AlbumEntity>>(jsonString);
            return albums.FirstOrDefault(a => a.Id == id);
        }
    }
}
