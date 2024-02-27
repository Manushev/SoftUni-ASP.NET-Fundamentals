using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TaskBoardApp.Data.Constants.ConstantsValidation.Task;

namespace TaskBoardApp.Data.Models
{
    public class Task //Задача
    {
        [Key]
        public int Id { get; set; }

        [MinLength(TitleMinimumLength)]
        [MaxLength(TitleMaximumLength)]
        [Required]
        public string Title { get; set; } = string.Empty;

        [MinLength(DescriptionMinimumLength)]
        [MaxLength(DescriptionMaximumLength)]
        [Required]
        public string Description { get; set; } = string.Empty;

        public DateTime? CreatedOn { get; set; }

        public int? BoardId { get; set; }

        [ForeignKey(nameof(BoardId))]
        public Board? Board { get; set; }

        [Required]
        public string OwnerId { get; set; } = string.Empty;

        [ForeignKey(nameof(OwnerId))]
        public IdentityUser Owner { get; set; } = null!;
    }

//•	Id – a unique integer, Primary Key
//•	Title – a string with min length 5 and max length 70 (required)
//•	Description – a string with min length 10 and max length 1000 (required)
//•	CreatedOn – date and time
//•	BoardId – an integer
//•	Board – a Board object
//•	OwnerId – an integer(required)
//•	Owner – an IdentityUser object
}
