using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Visualizer.Core.Entities;
using Visualizer.Web.Models;

namespace Visualizer.Web.MappingProfiles {
    public class DefaultMappingProfile : Profile {
        public DefaultMappingProfile() {
            CreateMap<AlbumEntity, AlbumModel>().ForMember(destination => destination.AlbumId, options => options.MapFrom(source => source.Id));
            CreateMap<PhotoEntity, PhotoModel>().ForMember(destination => destination.PhotoId, options => options.MapFrom(source => source.Id));
            CreateMap<CommentEntity, CommentModel>().ForMember(destination => destination.CommentId, options => options.MapFrom(source => source.Id));
        }
    }
}
