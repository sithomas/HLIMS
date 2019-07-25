namespace HLIMS_API_MicroServices.Responses
{
    public class BaseResponse<T> where T : class
    {
        private readonly T _responseObject;

        private readonly GenericResponse _response;

        public BaseResponse(T responseObject)
        {
            _responseObject = responseObject;
            _response = new GenericResponse(true);
        }

        public BaseResponse(GenericResponse response)
        {
            _response = response;
        }

        public BaseResponse(T responseObject, GenericResponse response)
        {
            _responseObject = responseObject;
            _response = response;
        }

        public T ResponseObject
        {
            get
            {
                return _responseObject;
            }
        }

        public GenericResponse Response
        {
            get
            {
                return _response;
            }
        }
    }
}