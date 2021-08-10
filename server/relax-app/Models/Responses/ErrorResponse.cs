using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relax_app.Models.Responses
{
    public class ErrorResponse
    {
        public ErrorResponse()
        {

        }
        public ErrorResponse(string title, int status)
        {
            Title = title;
            Status = status;
        }
        public int Status { get; set; }
        public string Title { get; set; }
        public List<ErrorField> Errors { get; set; }
    }

    public class ErrorField
    {
        public string Field { get; set; }
        public List<string> Messages { get; set; }
    }
}
