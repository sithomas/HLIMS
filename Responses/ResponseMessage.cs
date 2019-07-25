using System;
using System.Collections.Generic;

namespace HLIMS_API_MicroServices.Responses
{
    public interface IResponseMessage<T>
    {
        MessageHeader Header { get; set; }
        T MessageBody { get; set; }
        List<string> Errors { get; set; }
        List<ValidationErrors> ValidationErrors { get; set; }
    }
    public class ResponseMessage<T> : IResponseMessage<T>
    {

        public ResponseMessage(int count, T messageBody, Exception exception, List<ValidationErrors> validationErrors = null)
        {
            MessageBody = messageBody;
            Header = new MessageHeader
            {
                RecordCount = count
            };
            Errors = new List<string>();
            if (exception != null)
                Errors.Add(exception.Message);
            ValidationErrors = validationErrors ?? new List<ValidationErrors>();
        }

        public ResponseMessage() : this(0, default(T), null) { }
        public ResponseMessage(int count, T MessageBody) : this(count, MessageBody, null) { }
        public ResponseMessage(Exception exception) : this(0, default(T), exception) { }
        public ResponseMessage(int count, T MessageBody, List<ValidationErrors> ValidationErrors) : this(count, MessageBody, null, ValidationErrors) { }
        public MessageHeader Header { get; set; }
        public T MessageBody { get; set; }
        public List<string> Errors { get; set; }
        public List<ValidationErrors> ValidationErrors { get; set; }
    }
}