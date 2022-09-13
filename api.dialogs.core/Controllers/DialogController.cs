using api.dialogs.core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace api.dialogs.core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DialogController : ControllerBase
    {
        private readonly RGDialogsClients _dialogsClients;

        public DialogController(RGDialogsClients dialogsClients)
        {
            _dialogsClients = dialogsClients;
        }
        [HttpPost]
        public async Task<IActionResult> GetDialog(List<Guid> guids)
        {
            var dialog = await _dialogsClients.Init();
            var DialogIdList = new List<string>();
            var dialogId = String.Empty;
            foreach (var guid in guids)
            {
                var findDialog = dialog.FirstOrDefault(x => x.IDClient == guid);
                if (findDialog == null)
                    return BadRequest(new Guid { });
                DialogIdList.Add(findDialog.IDRGDialog.ToString());
            }
            foreach (var item in DialogIdList)
            {
                if (!item.ToString().Equals(DialogIdList.First().ToString()))
                    return BadRequest(new Guid { });
                else
                    dialogId = DialogIdList.First();
            }

            return Ok("DialogId => " + dialogId);
        }
    }
}
