using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visualizer.Core.Entities;

namespace Visualizer.Core.Interfaces {
    public interface IAlbumsService : IGenericService<AlbumEntity> {
        IEnumerable<AlbumEntity> GetAlbumsByUserId(int userId);
    }
}
