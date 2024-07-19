using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BuildingBlocks.Behaviours;

public class LoggingBehavior<TRequest, TResponse>(ILogger<LoggingBehavior<TRequest, TResponse>> logger) : IPipelineBehavior<TRequest, TResponse>
where TRequest:notnull,IRequest<TResponse>
where TResponse:notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        logger.LogInformation("[START] Handle -Request={Resquest} -Response = {Response} -RequestData={RequestData} ",typeof(TRequest).Name,typeof(TResponse).Name,request);

        var timer = new Stopwatch();
        timer.Start();

        var response = await next();
        timer.Stop();

        var timeTaken = timer.Elapsed.Seconds;
        if (timeTaken> 3)
        {
          logger.LogWarning("[PERFORMANCE] the request {Request} took {TimeTaken}",typeof(TRequest).Name,timeTaken);
        }

        logger.LogInformation("[END] Handle -Request={Request} -Response = {Response} -RequestData={RequestData} - TimeTaken={TimeTaken} seconds", typeof(TRequest).Name, typeof(TResponse).Name, request, timeTaken);
        return response;
    }
}
