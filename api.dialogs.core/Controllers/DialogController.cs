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
        private readonly DataTreatment _dataTreatment;

        public DialogController(DataTreatment dataTreatment)
        {
            _dataTreatment = dataTreatment;
        }

        [HttpPost]
        public async Task<IActionResult> DialogCheckout(List<Guid> guids)
        {
            var data = await _dataTreatment.GetDialog(guids);
            return data.StatusCode == System.Net.HttpStatusCode.OK ? Ok(data) : BadRequest(data);
        }
    }
}
