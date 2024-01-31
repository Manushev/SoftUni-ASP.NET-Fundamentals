using ForumApp.Core.Contracts;
using ForumApp.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService postService;

        public PostController(IPostService _postService)
        {
            postService = _postService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var allPosts = await postService.GetAllAsync();

            return View(allPosts);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostFormViewModel model)
        {
            await postService.AddAsync(model);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await postService.GetByIdAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostFormViewModel model)
        {
            await postService.UpdateAsync(model);
            return RedirectToAction(nameof(All));
        }
    }
}
