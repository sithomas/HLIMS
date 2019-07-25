namespace HLIMS_API_MicroServices.Responses
{
    public class GenericResponse
    {
        private readonly string _errorMessage;
        private readonly bool _isSuccessful;
        public GenericResponse(string errorMessage)
        {
           _errorMessage = errorMessage;
            _isSuccessful = false;
        }

        public GenericResponse(bool requestIsSuccessful)
        {
            _isSuccessful = requestIsSuccessful;
        }

        public bool RequestSuccessful
        {
            get { return _isSuccessful;}
        }
        public string ErrorMessage
        {
            get { return _errorMessage; }
        }

    }
}