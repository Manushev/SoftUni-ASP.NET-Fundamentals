using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.Constants.ConstantsValidation.Task;

namespace TaskBoardApp.Models
{
    public class TaskFormViewModel
    {
        public int Id { get; set; }

        [MinLength(TitleMinimumLength, ErrorMessage = "The Title field must be at least 5 characters long.")]
        [MaxLength(TitleMaximumLength, ErrorMessage = "The Title field cannot exceed 70 characters in length.")]
        [Required(ErrorMessage = "The Title field is required.")]
        public string Title { get; set; } = string.Empty;

        [MinLength(DescriptionMinimumLength, ErrorMessage = "The Description field must be at least 10 characters long.")]
        [MaxLength(DescriptionMaximumLength, ErrorMessage = "The Description field cannot exceed 1000 characters in length.")]
        [Required(ErrorMessage = "The Description field is required.")]
        public string Description { get; set; } = string.Empty;

        [DisplayName("Board")]
        public int BoardId { get; set; }

        public IEnumerable<TaskBoardViewModel> Boards { get; set; } = new List<TaskBoardViewModel>();
    }
}
