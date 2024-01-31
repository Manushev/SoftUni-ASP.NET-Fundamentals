using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static ForumApp.Infrastructure.Constants.ValidationConstants;

namespace ForumApp.Core.Models
{
    public class PostFormViewModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(TitleMinLength, ErrorMessage = TitleMinLengthErrorMessage), 
            MaxLength(TitleMaxLength, ErrorMessage = TitleMaxLengthErrorMessage)]
        [Comment("The title of the post")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(ContentMinLength, ErrorMessage = ContentMinLengthErrorMessage), 
            MaxLength(ContentMaxLength, ErrorMessage = ContentMaxLengthErrorMessage)]
        [Comment("The main content of the post")]
        public string Content { get; set; } = string.Empty;
    }
}
