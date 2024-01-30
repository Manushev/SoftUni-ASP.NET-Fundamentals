using ForumApp.Core.Contracts;
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

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> All()
        {
            var allPosts = await postService.GetAllAsync();

            return View(allPosts);
        }
    }
}
