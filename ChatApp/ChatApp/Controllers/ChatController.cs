using ChatApp.Models.Message;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    public class ChatController : Controller
    {
        //A collection of messages, which has the message sender as key and the message text as value
        private static List<KeyValuePair<string, string>> messeges = 
            new List<KeyValuePair<string, string>>();

        //A "GET" method Show(), which returns a view with model (the model may hold the messages)
        public IActionResult Show()
        {
            //If the messages collection of the class is empty,
            //the controller action should return a view with an empty ChatViewModel. 
            if (messeges.Count < 1)
            {
                return View(new ChatViewModel());
            }
            var chatModel = new ChatViewModel()
            {
                Messages = messeges.Select(m => new MessageViewModel()
                {
                    Sender = m.Key,
                    MessageText = m.Value,
                })
                .ToList()
            };
            return View(chatModel);  
        }

        //A "POST" method Send(), which accepts a model from the view and adds a message to the collection.
        [HttpPost]
        public IActionResult Send(ChatViewModel chat)
        {
            var newMessage = chat.CurrentMessage;

            messeges.Add(new KeyValuePair<string, string>(newMessage.Sender, newMessage.MessageText));
            //Then, it redirects to the Show() action.
            return RedirectToAction("Show");
        }
    }
}
