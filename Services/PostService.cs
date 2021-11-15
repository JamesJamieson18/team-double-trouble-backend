using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using team_double_trouble_backend.Authorization;
using team_double_trouble_backend.Entities;
using team_double_trouble_backend.Helpers;
using team_double_trouble_backend.Models;

namespace team_double_trouble_backend.Services
{
    public interface IPostService
    {
        IEnumerable<Post> GetAll();
        Post GetById(int id);
        IQueryable<Post> GetByUserId(int UserId);
        void Create(MakePostRequest model);
        void Update(int id, PostUpdateRequest model);
        void Delete(int id);
    }
    public class PostService : IPostService
    {
        private SqliteDataContext _context;
        private readonly IMapper _mapper;

        public PostService(
            SqliteDataContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Post> GetAll()
        {
            return _context.Posts.OrderByDescending(p => p.PostId);
        }

        public Post GetById(int id)
        {
            return getPost(id);
        }
        public  IQueryable<Post> GetByUserId(int UserId)
        {
            var Posts = _context.Posts.Where(post => post.UserId == UserId).OrderByDescending(p => p.PostId);
            if (Posts == null) throw new KeyNotFoundException("No posts found for this user");
            return Posts;
        }
        public void Create(MakePostRequest model)
        {
            // check for any posts with the same text
            if (_context.Posts.Any(x => x.Text == model.Text))
                throw new AppException("Post has already been made");

            // map model to new post object
            var post = _mapper.Map<Post>(model);

            // set the Date to current UTC time
            post.Date = DateTime.Now;


            // save post
            _context.Posts.Add(post);
            _context.SaveChanges();
        }
        
        public void Update(int id, PostUpdateRequest model)
        {
            var post = getPost(id);
            // copy model to post and save
            _mapper.Map(model, post);
            _context.Posts.Update(post);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var post = getPost(id);
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }

        //helper method
        private Post getPost(int id)
        {
            var post = _context.Posts.Find(id);
            if (post == null) throw new KeyNotFoundException("Post not found");
            return post;
        }
    }
}