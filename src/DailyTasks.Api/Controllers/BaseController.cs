using System.Net;
using System.Net.Mime;
using AgrotoolsMaps.Api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CentralAlertasBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [Produces(MediaTypeNames.Application.Json)]
    public class BaseController : ControllerBase
    {
        private readonly IPresenter _presenter;

        public BaseController(IPresenter presenter)
        {
            _presenter = presenter;
        }
        
        protected ActionResult ResultForPost(HttpStatusCode successStatus)
        {
            return _presenter.ResultForPost(successStatus);
        }

        protected ActionResult ResultForPut(HttpStatusCode successStatus)
        {
            return _presenter.ResultForPut(successStatus);
        }

        protected ActionResult ResultForGet()
        {
            return _presenter.ResultForGet();
        }

    }
}