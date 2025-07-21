using back_end.Errors;
using System.Net;
using System.Net.WebSockets;
using System.Text.Json;

namespace back_end.Middlewares
{
    public class ExceptionMiddleware
    {
        public ExceptionMiddleware(RequestDelegate next,
            ILogger<ExceptionMiddleware> logger,IHostEnvironment env)
        {
            Next = next;
            Logger = logger;
            Env = env;
        }

        public RequestDelegate Next { get; }
        public ILogger<ExceptionMiddleware> Logger { get; }
        public IHostEnvironment Env { get; }


        public async Task InvokeAsync(HttpContext context)
        {
            //kiểm tra context có đi qua middleware tiếp theo được không
            try
            {
                await Next(context);
            }

            catch (Exception ex)
            {
                this.Logger.LogError(ex,ex.Message);

                context.Response.ContentType = "application/json"; // gán kiêu dữ liệu cho respone
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; // gán status cho respone


                //kiểm tra có phải là môi trường development không
                //nêu phải thì tạo ra 1 class ApiException với thông báo lỗi chi tiết
                var respone = this.Env.IsDevelopment()
                    ? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString())
                    : new ApiException(context.Response.StatusCode, ex.Message, "Internal server error");


                //thêm options cho respone json
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                //tạo json
                var json = JsonSerializer.Serialize(respone, options);

                // trả về respone có dạng json 
                await context.Response.WriteAsync(json);
            }
        }
    }
}
