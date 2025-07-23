namespace Tech_Inventory.Application.Common.Exceptions;

public class ResponseHandler
{
    public static ApiResponse GetExceptionResponse(Exception ex)
    {
        var message = ex.Message;
        if (ex.InnerException != null)
        {
            message = ex.InnerException.Message;
        }

        ApiResponse response = new ApiResponse();
        response.IsSuccess = false;
        response.IsError = true;
        response.Data = message;
        return response;
    }

    public static ApiResponse GetAppResponse(ResponseType type, object? contract)
    {

        ApiResponse apiResponse;
        apiResponse = new ApiResponse { Data = contract };

        switch (type)
        {
            case ResponseType.Success:
                apiResponse.IsSuccess = true;
                apiResponse.IsError = false;
                break;
            case ResponseType.Failed:
                apiResponse.IsSuccess = false;
                apiResponse.IsError = true;
                break;
        }

        return apiResponse;
    }
}
