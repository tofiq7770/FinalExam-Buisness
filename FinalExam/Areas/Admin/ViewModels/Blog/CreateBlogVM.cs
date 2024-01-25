namespace FinalExam.Areas.Admin.ViewModels.Blog
{
    public class CreateBlogVM
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
