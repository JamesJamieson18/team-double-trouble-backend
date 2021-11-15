using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using team_double_trouble_backend.Helpers;
using team_double_trouble_backend.Models;
using team_double_trouble_backend.Services;
using team_double_trouble_backend.Authorization;

namespace team_double_trouble_backend.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private IPostService _postService;
        private IMapper _mapper;

        public PostController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        // GET: api/Post
        [HttpGet]
        public IActionResult GetAll()
        {
            var posts = _postService.GetAll();
            return Ok(posts);
        }

        // GET: api/Post/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var post = _postService.GetById(id);
            return Ok(post);
        }

        //GET: /api/Post/UserPosts/18
        [HttpGet("UserPosts/{UserId}")]
        public IActionResult GetByUserId(int UserId)
        {
            var post = _postService.GetByUserId(UserId);
            return Ok(post);
        }

        // PUT: api/Post/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, PostUpdateRequest model)
        {
            _postService.Update(id, model);
            return Ok(new { message = "Post updated successfully" });
        }

        // POST: api/Post
        [HttpPost]
        public IActionResult Create(MakePostRequest model)
        {
            _postService.Create(model);
            return Ok(new { message = "Post created successfully" });
        }

        // DELETE: api/Post/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _postService.Delete(id);
            return Ok(new { message = "Post deleted successfully" });
        }
    }
}
