using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Tests.Integration.Base
{
    public class AutoAuthorizeMiddleware
    {
        readonly RequestDelegate Next;

        public AutoAuthorizeMiddleware(RequestDelegate next)
        {
            Next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Items["Login"] = "foo";

            await Next(context);
        }
    }
}