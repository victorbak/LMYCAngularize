using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Lmyc.ViewModels
{
    public class LogoutViewModel
    {
        [BindNever]
        public string RequestId { get; set; }
    }
}