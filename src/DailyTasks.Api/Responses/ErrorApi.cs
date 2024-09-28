using AgrotoolsMaps.Application.UseCases.Shared;
using System;
using System.Collections.Generic;

namespace AgrotoolsMaps.Api.Responses
{
    public class ErrorApi
    {
        public ErrorApi(string traceId, IEnumerable<ErrorResponse> erros)
        {
            Errors = erros;
            TraceId = traceId;
        }

        public string TraceId { get; }

        public DateTime IssueDate => DateTime.UtcNow;
        
        public IEnumerable<ErrorResponse> Errors { get; }
    }
}