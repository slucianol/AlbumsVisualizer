using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Visualizer.Core.Entities;
using Visualizer.Core.Interfaces;
using Visualizer.Web.Models;

namespace Visualizer.Web.Controllers {
    public class AlbumsController : Controller {
        private readonly IAlbumsService albumsService;
        private readonly IMapper mapper;

        public AlbumsController(IAlbumsService albumsService, IMapper mapper) {
            this.albumsService = albumsService;
            this.mapper = mapper;
        }
        // GET: Albums
        [HttpGet(Name = nameof(Index))]
        public ActionResult Index() {
            IEnumerable<AlbumEntity> albumEntities = albumsService.GetAll();
            IEnumerable<AlbumModel> albums = mapper.Map<IEnumerable<AlbumModel>>(albumEntities);
            return View(albums);
        }

        // GET: Albums/Details/5
        [HttpGet("[controller]/ByUserId/{userId}", Name = nameof(GetAlbumsByUserId))]
        public ActionResult GetAlbumsByUserId([FromRoute]int userId) {
            IEnumerable<AlbumEntity> albumEntities = albumsService.GetAlbumsByUserId(userId);
            IEnumerable<AlbumModel> albums = mapper.Map<IEnumerable<AlbumModel>>(albumEntities);
            return View(albums);
        }
    }
}