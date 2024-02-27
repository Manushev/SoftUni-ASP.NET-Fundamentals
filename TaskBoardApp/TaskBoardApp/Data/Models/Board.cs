using MessagePack;
using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.Constants.ConstantsValidation.Board;

namespace TaskBoardApp.Data.Models
{
    public class Board
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }

        [MinLength(NameMinimumLength)]
        [MaxLength(NameMaximumLength)]
        [Required]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<Task> Tasks { get; set; } = new List<Task>();
    }

//•	Id – a unique integer, Primary Key
//•	Name – a string with min length 3 and max length 30 (required)
//•	Tasks – a collection of Task
}