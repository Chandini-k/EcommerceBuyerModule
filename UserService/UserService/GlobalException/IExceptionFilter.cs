using Microsoft.AspNetCore.Mvc.Filters;

namespace UserService.GlobalException
{
    public interface IExceptionFilter : IFilterMetadata
    {
        void OnException(ExceptionContext context);
    }
}
