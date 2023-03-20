using Chat_app2.dtos;
using Microsoft.AspNetCore.Mvc;
using PusherServer;
using System.Threading.Tasks;

namespace Chat_app2.Controllers
{
    [Route("api")]
    [ApiController]
    public class ChatController : Controller
    {
        [HttpPost("messages")]
        public async Task<ActionResult> Message(MessageDTO dto)
        {
            var options = new PusherOptions
            {
                Cluster = "eu",
                Encrypted = true
            };

            var pusher = new Pusher(
              "1565118",
              "3cf6710fe0762cade304",
              "72e04164755a97b21e76",
              options);

            await pusher.TriggerAsync(
              "chat",
              "message",
              new { 
                  username = dto.Username,
                  message = dto.Message 
              });
            return Ok(new string[] { });


        }
    }
}
