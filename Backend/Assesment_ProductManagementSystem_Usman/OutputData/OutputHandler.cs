using System.Net;

namespace Assesment_ProductManagementSystem_Usman.OutputData
{
    public class OutputHandler
    {
        public static OutputDTO<T> Handler<T>(int responseCode, T dto, string name = "Record", int totalCount = 0)
        {
            var obj = new OutputDTO<T>()
            {
                Data = dto,
                TotalCounts = totalCount,
            };

            switch (responseCode)
            {
                case (int)ResponseType.SAVE:
                    obj.HttpStatusCode = ResponseCode.SAVE;
                    obj.Message = string.Format(ResponseMessage.SAVE, name);
                    break;

                case (int)ResponseType.CREATE:
                    obj.HttpStatusCode = ResponseCode.CREATE;
                    obj.Message = string.Format(ResponseMessage.CREATE, name);
                    break;

                case (int)ResponseType.UPDATE:
                    obj.HttpStatusCode = ResponseCode.UPDATE;
                    obj.Message = string.Format(ResponseMessage.UPDATE, name);
                    break;

                case (int)ResponseType.DELETE:
                    obj.HttpStatusCode = ResponseCode.DELETE;
                    obj.Message = string.Format(ResponseMessage.DELETE, name);
                    break;

                case (int)ResponseType.GET:
                    obj.HttpStatusCode = ResponseCode.GET;
                    obj.Message = string.Format(ResponseMessage.GET, name);
                    break;

                case (int)ResponseType.GET_ALL:
                    obj.Succeeded = true;
                    obj.HttpStatusCode = ResponseCode.GET_ALL;
                    obj.Message = string.Format(ResponseMessage.GET_ALL, name);
                    break;

                case (int)ResponseType.EXIST:
                    obj.Succeeded = false;
                    obj.HttpStatusCode = ResponseCode.EXIST;
                    obj.Message = string.Format(ResponseMessage.EXIST, name);
                    break;

                case (int)ResponseType.NOT_EXIST:
                    obj.Succeeded = false;
                    obj.HttpStatusCode = ResponseCode.NOT_EXIST;
                    obj.Message = string.Format(ResponseMessage.NOT_EXIST, name);
                    break;

                case (int)ResponseType.INVALID_REQUEST:
                    obj.Succeeded = false;
                    obj.HttpStatusCode = ResponseCode.INVALID_REQUEST;
                    obj.Message = ResponseMessage.INVALID_REQUEST;
                    break;
            }

            return obj;
        }
    }
}
