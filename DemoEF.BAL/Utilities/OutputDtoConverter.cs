using DemoEF.BAL.Constants;
using DemoEF.BAL.Dto;
using DemoEF.BAL.Enums;

namespace DemoEF.BAL.Utilities
{
    public static class OutputDtoConverter
    {

        public static OutputDto SetSuccess()
        {
            return new OutputDto
            {
                Status = Status.Success,
                Message = Message.Success,
            };
        }
        public static OutputDto SetSuccess(string message)
        {
            return new OutputDto
            {
                Status = Status.Success,
                Message = message,
            };
        }
        public static OutputDto<T> SetSuccess<T>(List<T> data) where T : class
        {
            return new OutputDto<T>
            {
                Status = Status.Success,
                Message = Message.Success,
                Data = data
            };
        }
        public static OutputDto<T> SetSuccess<T>(T data) where T : class
        {
            return new OutputDto<T>
            {
                Status = Status.Success,
                Message = Message.Success,
                Data = data is null ? [] : new List<T> { data }
            };
        }


        public static OutputDto<T> SetFailed<T>(string error) where T : class
        {
            return new OutputDto<T>
            {
                Status = Status.Failed,
                Message = Message.Failed,
                Data = [],
                Error=error
            };
        }

        public static OutputDto SetFailed(string error)
        {
            return new OutputDto
            {
                Status = Status.Failed,
                Message = Message.Failed,
                Error = error
            };
        }
    }
}
