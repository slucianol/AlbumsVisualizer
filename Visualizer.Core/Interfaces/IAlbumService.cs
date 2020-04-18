﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Visualizer.Core.Entities;

namespace Visualizer.Core.Interfaces {
    public interface IAlbumService : IGenericService<AlbumEntity> {
        IQueryable<AlbumEntity> GetAlbumsByUserId(short userId);
    }
}
