using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static ForumApp.Infrastructure.Constants.ValidationConstants;

namespace ForumApp.Infrastructure.Data.Models
{
    public class Post
    {
        [Key]
        [Comment("Post identifier")]
        public int Id { get; set; }

        [Required]
        [MinLength(TitleMinLength), MaxLength(TitleMaxLength)]
        [Comment("The title of the post")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(ContentMinLength), MaxLength(ContentMaxLength)]
        [Comment("The main content of the post")]
        public string Content { get; set; } = string.Empty;
    }

    //The Post class should have the following properties:
    //Id – an unique integer, primary key
    //Title – a string with min length 10 and max length 50 (required)
    //Content – a string with min length 30 and max length 1500 (required)
}
