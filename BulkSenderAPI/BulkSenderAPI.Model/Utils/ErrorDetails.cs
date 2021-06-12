using BulkSenderAPI.Model.Enums;
using Newtonsoft.Json;

namespace BulkSenderAPI.Model.Utils
{
    public class ErrorDetails
    {
        public string Message { get; set; }
        public object Data { get; set; }
        public ResponseStatus Status { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
