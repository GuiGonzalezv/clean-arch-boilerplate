using Microsoft.AspNetCore.Mvc;
using System.Net;
using AgrotoolsMaps.Api.Interfaces;
using AgrotoolsMaps.Application.UseCases;

namespace AgrotoolsMaps.Api.Responses
{
    public class Presenter : IPresenter
    {
        private readonly ContentResult _contentResult;
        private bool _hasErrors;

        public Presenter()
        {
            _contentResult = new JsonContentResult();
        }

        public void Handle<T>(UseCaseOutput<T> output) where T : class
        {
            _hasErrors = output.HasErrors;
            var noContent = output.Data == null && !_hasErrors;

            if (noContent)
                return;

            SetContentResult(output);
        }

        private void SetContentResult<T>(UseCaseOutput<T> output) where T : class
        {
            _contentResult.Content = _hasErrors
                ? JsonSerializer.SerializeObject(new ErrorApi(string.Empty, output.Errors))
                : JsonSerializer.SerializeObject(output.Data);
        }

        private ContentResult SetStatusCode(HttpStatusCode successStatus, HttpStatusCode invalidStatus)
        {
            var status = _hasErrors ? invalidStatus : successStatus;
            if (!_hasErrors && _contentResult.Content == null)
                _contentResult.StatusCode = (int)HttpStatusCode.NoContent;
            else
                _contentResult.StatusCode = (int)status;
            return _contentResult;
        }

        public virtual ActionResult ResultForPost(HttpStatusCode successStatus)
        {
            return SetStatusCode(successStatus, HttpStatusCode.BadRequest);
        }

        public virtual ActionResult ResultForPut(HttpStatusCode successStatus)
        {
            return SetStatusCode(successStatus, HttpStatusCode.BadRequest);
        }

        public virtual ActionResult ResultForGet()
        {
            if (_contentResult.Content == null)
                return new NotFoundResult();

            _contentResult.StatusCode = (int)HttpStatusCode.OK;
            return _contentResult;
        }
    }
}