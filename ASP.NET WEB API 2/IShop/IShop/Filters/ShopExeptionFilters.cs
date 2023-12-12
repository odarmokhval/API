using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace IShop.Filters
{
    public class ShopExeptionFilters : Attribute, IExceptionFilter
    {
        public bool AllowMultiple
        {
            get
            {
                return false;
            }
        }

        public async Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext, 
            CancellationToken cancellationToken)
        {
            if(actionExecutedContext != null && actionExecutedContext.Exception is IndexOutOfRangeException) 
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(
                    System.Net.HttpStatusCode.BadRequest, "Unknown exeption");
            }
        }
    }
}