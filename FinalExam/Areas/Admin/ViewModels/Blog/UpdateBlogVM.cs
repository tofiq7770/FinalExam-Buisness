namespace FinalExam.Areas.Admin.ViewModels.Blog
{
    public class UpdateBlogVM
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
