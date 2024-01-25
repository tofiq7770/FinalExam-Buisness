using System.ComponentModel.DataAnnotations;

namespace FinalExam.Areas.Admin.ViewModels.Settings
{
    public class UpdateSettingsVM
    {

        [Required]
        public string Key { get; set; }
        [Required]
        public string Value { get; set; }
    }
}
