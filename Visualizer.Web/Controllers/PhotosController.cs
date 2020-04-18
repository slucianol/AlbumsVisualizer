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
    public class PhotosController : Controller {
        private readonly IPhotosService photosService;
        private readonly ICommentsService commentsService;
        private readonly IMapper mapper;
        public PhotosController(IPhotosService photosService, ICommentsService commentsService, IMapper mapper) {
            this.photosService = photosService;
            this.commentsService = commentsService;
            this.mapper = mapper;
        }
        // GET: Photos/{albumId}
        [HttpGet("[controller]/{albumId}", Name = nameof(Index))]
        public async Task<ActionResult> Index([FromRoute]int albumId) {
            IEnumerable<PhotoEntity> photoEntities = photosService.GetPhotosByAlbumId(albumId);
            IEnumerable<PhotoModel> photos = mapper.Map<IEnumerable<PhotoModel>>(photoEntities);
            return View(photos);
        }

        // GET: Photos/Details/5
        [HttpGet("[controller]/Comments/{postId}", Name = nameof(GetCommentsByPostID))]
        public JsonResult GetCommentsByPostID([FromRoute]int postId) {
            IEnumerable<CommentEntity> commentEntities = commentsService.GetCommentsByPhotoId(postId);
            IEnumerable<CommentModel> comments = mapper.Map<IEnumerable<CommentModel>>(commentEntities);
            return new JsonResult(comments);
        }
    }
}