namespace Peanuts.Woodstock.Web.Endpoints;

public interface IEndpointDefinitions
{
    void DefineEndpoints(WebApplication app);
    void DefineServices(IServiceCollection services) { }
}