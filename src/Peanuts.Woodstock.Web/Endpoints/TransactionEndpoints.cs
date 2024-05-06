using Microsoft.AspNetCore.Mvc;
using Peanuts.Woodstock.Web.Requests;

namespace Peanuts.Woodstock.Web.Endpoints;

public class TransactionEndpoints : IEndpointDefinitions
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapPut("/transactions/create", ([FromBody] CreateTransactionRequest request) => { 
            
        });
    }
}
