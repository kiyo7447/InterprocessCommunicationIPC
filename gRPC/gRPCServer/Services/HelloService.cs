using Grpc.Core;
using gRPCServer;

namespace gRPCServer.Services;

public class HelloService : Hello.HelloBase
{
    private readonly ILogger<HelloService> _logger;
    public HelloService(ILogger<HelloService> logger)
    {
        _logger = logger;
    }

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + request.Name
        });
    }
}
