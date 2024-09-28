using System.Net;
using AgrotoolsMaps.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AgrotoolsMaps.Api.Interfaces
{
    public interface IPresenter : IOutputPort
    {
        ActionResult ResultForPost(HttpStatusCode successStatus);

        ActionResult ResultForPut(HttpStatusCode successStatus);

        ActionResult ResultForGet();
    }
}