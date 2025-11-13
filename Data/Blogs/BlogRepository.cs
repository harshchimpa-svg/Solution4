using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Blogs
{
    public class BlogRepository : IBlogRepository
    {
        private readonly ProjectContext _context;

        public BlogRepository(ProjectContext context)
        {
            _context = context;
        }



        public Task<Blog> CreateBlog(Blog blog)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteBlog(int id)
        {
            var blog = await _context.Blogs.FirstAsync();
            _context.Blogs.Remove(blog);
        }

        public async Task<List<Blog>> GetAllBlog()
        {
            return await _context.Blogs.ToListAsync();
        }

        public async Task<Blog> GetById(int id)
        {
            return await _context.Blogs.FindAsync();
        }

        Task<List<Blog>> IBlogRepository.GetAllBlog()
        {
            throw new NotImplementedException();
        }

        Task<Blog> IBlogRepository.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
