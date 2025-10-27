using DemoEF.BAL.Dto;
using Message = DemoEF.BAL.Constants.Message;
namespace DemoEF.Desktop.Utilities
{
    public static class DialogMessage
    {
        public static DialogResult FailedAlert(OutputDto result)
        {
            return MessageBox.Show(result.Error,result.Message,MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
        public static DialogResult FailedAlert(string error)
        {
            return MessageBox.Show(error, Message.Failed, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult SuccessAlert(OutputDto result)
        {
            return MessageBox.Show(result.Message, Message.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
