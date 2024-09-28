using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace AgrotoolsMaps.Api.Responses
{
    public class JsonContentResult : ContentResult
    {
        public JsonContentResult()
        {
            ContentType = MediaTypeNames.Application.Json;
        }
    }
}