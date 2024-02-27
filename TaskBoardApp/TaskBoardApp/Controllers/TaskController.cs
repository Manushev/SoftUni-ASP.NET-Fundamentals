using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models;
using Task = TaskBoardApp.Data.Models.Task;

namespace TaskBoardApp.Controllers
{
    
    public class TaskController : Controller
    {
        private readonly ApplicationDbContext context;

        public TaskController(ApplicationDbContext _context)
        {
            context = _context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var taskModel = new TaskFormViewModel()
            {
                Boards = GetBoards()
            };

            return View(taskModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormViewModel taskModel)
        {
            if (!GetBoards().Any(b => b.Id == taskModel.BoardId))
            {
                ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist");
            }

            var currentUserId = GetUserId();

            if (!ModelState.IsValid) 
            { 
                taskModel.Boards = GetBoards();
                return View(taskModel);
            }


            Task task = new Task()
            {
                Title = taskModel.Title,
                Description = taskModel.Description,
                CreatedOn = DateTime.Now,
                BoardId = taskModel.BoardId,
                OwnerId = currentUserId
            };

            await context.Tasks.AddAsync(task);
            await context.SaveChangesAsync();

            var boards = context.Boards;

            return RedirectToAction("All", "Board");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var task = await context.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUser = GetUserId();
            if(currentUser != task.OwnerId)
            {
                return Unauthorized();
            }

            var taskModel = new TaskFormViewModel()
            {
                Title = task.Title,
                Description = task.Description,
                BoardId = (int)task.BoardId,
                Boards = GetBoards()
            };

            return View(taskModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TaskFormViewModel model)
        {
            var task = await context.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUser = GetUserId();
            if (currentUser != task.OwnerId)
            {
                return Unauthorized();
            }

            if (!GetBoards().Any(b => b.Id == model.BoardId))
            {
                ModelState.AddModelError(nameof(model.BoardId), "Board does not exist");
            }

            if (!ModelState.IsValid)
            {
                model.Boards = GetBoards();
                return View(model);
            }

            task.Title = model.Title;
            task.Description = model.Description;
            task.BoardId = model.BoardId;
            
            await context.SaveChangesAsync();
            return RedirectToAction("All", "Board");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await context.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUser = GetUserId();
            if (currentUser != task.OwnerId)
            {
                return Unauthorized();
            }

            var model = new TaskViewModel()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TaskViewModel model)
        {
            var task = await context.Tasks.FindAsync(model.Id);
            if (task == null)
            {
                return BadRequest();
            }

            string currentUser = GetUserId();
            if (currentUser != task.OwnerId)
            {
                return Unauthorized();
            }

            context.Tasks.Remove(task);
            await context.SaveChangesAsync();

            return RedirectToAction("All", "Board");
        }

            public async Task<IActionResult> Details(int id)
        {
            var task = await context
                .Tasks
                .Where(b => b.Id == id)
                .Select(d => new TaskDetailsViewModel()
                {
                    Id= d.Id,
                    Title = d.Title,
                    Description = d.Description,
                    CreatedOn = d.CreatedOn.ToString(),
                    Board = d.Board.Name,
                    Owner = d.Owner.UserName

                })
                .FirstOrDefaultAsync();

            if (task == null)
            {
                return BadRequest();
            }

            return View(task);
        }

        private string GetUserId()
            => User.FindFirstValue(ClaimTypes.NameIdentifier);

        private IEnumerable<TaskBoardViewModel> GetBoards()
            => context
                .Boards
                .Select(b => new TaskBoardViewModel
                {
                    Id = b.Id,
                    Name = b.Name,
                });
    }
}
