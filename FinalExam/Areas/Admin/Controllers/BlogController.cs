using FinalExam.Areas.Admin.ViewModels.Blog;
using FinalExam.DAL;
using FinalExam.Models;
using FinalExam.Utulities.Extentions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.ContentModel;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace FinalExam.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public BlogController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<Blog> blogs = await _context.Blogs.ToListAsync();
            return View(blogs);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogVM create)
        {
            if (!ModelState.IsValid) return BadRequest();
            bool result = await _context.Blogs.AnyAsync(x => x.Name.Trim().ToLower() == create.Name.Trim().ToLower());

            if (result)
            {
                ModelState.AddModelError("Name", "This Name Does Exist");
                return View(create);
            }
            if (!create.Photo.ValidateType())
            {

                ModelState.AddModelError("Photo", "Not Valid Type");
                return View(create);
            }
            if (!create.Photo.ValidateSize(10))
            {

                ModelState.AddModelError("Photo", "Max 10mb");
                return View(create);
            }
            Blog blog = new()
            {
                Name = create.Name,
                Description = create.Description,
                Title = create.Title,
                Image = await create.Photo.CreateFile(_env.WebRootPath, "assets", "images","blog")
            };
            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            if (id <= 0) return BadRequest();
            Blog blog = await _context.Blogs.FirstOrDefaultAsync(x => x.Id == id);

            UpdateBlogVM updateBlogVM = new UpdateBlogVM()
            {
                Name = blog.Name,
                Description = blog.Description,
                Title = blog.Title,
                Image = blog.Image,
            };

            return View(updateBlogVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateBlogVM update)
        {
            if (!ModelState.IsValid) return BadRequest();
            Blog blogs = _context.Blogs.FirstOrDefault(s => s.Id == id);
            if (blogs is null)
            {
                return NotFound();
            }
            if (update.Photo is not null)
            {
                if (!update.Photo.ValidateType())
                {
                    ModelState.AddModelError("Photo", "Type not valid");
                    return View(update);
                }
                if (!update.Photo.ValidateSize(10))
                {
                    ModelState.AddModelError("Photo", "max 10mb");
                    return View(update);
                }
                blogs.Image.DeleteFile(_env.WebRootPath, "assets", "images", "blog");
                blogs.Image = await update.Photo.CreateFile(_env.WebRootPath, "assets", "images", "blog");

            }
            blogs.Name = update.Name;
            blogs.Description = update.Description;
            blogs.Title = update.Title;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest();
            Blog blogs = _context.Blogs.FirstOrDefault(s => s.Id == id);
            if (blogs is null) return NotFound();

            _context.Remove(blogs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
