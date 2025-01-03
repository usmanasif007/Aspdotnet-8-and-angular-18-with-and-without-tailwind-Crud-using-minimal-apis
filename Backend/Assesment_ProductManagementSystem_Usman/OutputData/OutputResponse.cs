namespace Assesment_ProductManagementSystem_Usman.OutputData
{
    public static class ResponseCode
    {
        public const int SAVE = 200;
        public const int CREATE = 200;
        public const int UPDATE = 200;
        public const int DELETE = 200;
        public const int GET = 200;
        public const int GET_ALL = 200;
        public const int EXIST = 400;
        public const int NOT_EXIST = 400;
        public const int INVALID_REQUEST = 400;
    }
    public static class ResponseMessage
    {
        public const string SAVE = "{0} is Save Successfully.";
        public const string CREATE = "{0} is Created Successfully.";
        public const string UPDATE = "{0} is Updated Successfully.";
        public const string DELETE = "{0} is Deleted Successfully.";
        public const string GET = "{0} Get Successfully.";
        public const string GET_ALL = "{0}s Get all Successfully.";
        public const string EXIST = "{0} Already Exist.";
        public const string NOT_EXIST = "{0} does not Exist.";
        public const string INVALID_REQUEST = "Invalid Request";
    }

    public enum ResponseType
    {
        SAVE,
        CREATE,
        UPDATE,
        DELETE,
        GET,
        GET_ALL,
        EXIST,
        NOT_EXIST,
        INVALID_REQUEST
    }
}
