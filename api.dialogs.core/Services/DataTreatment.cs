using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace api.dialogs.core.Services
{
    public class DataTreatment
    {
        private readonly RGDialogsClients _dialogsClients;

        public DataTreatment(RGDialogsClients dialogsClients)
        {
            _dialogsClients = dialogsClients;
        }
        public async Task<Response> GetDialog(List<Guid> guids)
        {
            var dialog = await _dialogsClients.Init();
            var DialogIdList = new List<string>(); var dialogId = String.Empty;

            foreach (var guid in guids)
            {
                var findDialog = dialog.FirstOrDefault(x => x.IDClient == guid);
                if (findDialog == null)
                    return new Response { StatusCode = System.Net.HttpStatusCode.BadRequest, ReturnGuid = new Guid { } };
                DialogIdList.Add(findDialog.IDRGDialog.ToString());
            }
            foreach (var item in DialogIdList)
            {       
                if (!item.ToString().Equals(DialogIdList.First().ToString()))
                    return new Response { StatusCode = System.Net.HttpStatusCode.BadRequest, ReturnGuid = new Guid { } };
                else
                    dialogId = DialogIdList.First();
            }
            return new Response { StatusCode = System.Net.HttpStatusCode.OK, ReturnGuid = Guid.Parse(dialogId) };
        }
    }
}
