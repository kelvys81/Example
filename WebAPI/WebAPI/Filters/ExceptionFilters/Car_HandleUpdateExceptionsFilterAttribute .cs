using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebAPI.Models.Repositories;

namespace WebAPI.Filters.ExceptionFilters
{
    public class Car_HandleUpdateExceptionsFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            var strCarId =  context.RouteData.Values["id"] as string;
            if (int.TryParse(strCarId, out int carId))
            {
                if (!CarRepository.CarExists(carId))
                {
                    context.ModelState.AddModelError("CarId", "Car don't exist");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(problemDetails);
                }
            }
        }
    }
}
