using DemoEF.BAL.Enums;

namespace DemoEF.BAL.Dto
{
    public class OutputDto
    {
        public Status Status { get; set; }
        public string Message { get; set; }
        public string Error { get; set; }
    }
    public class OutputDto<T>: OutputDto where T: class
    {
        public List<T> Data { get; set; }   
    }
}
