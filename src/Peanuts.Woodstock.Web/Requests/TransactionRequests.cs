namespace Peanuts.Woodstock.Web.Requests;

public record CreateTransactionRequest(string Description, DateTime Date, decimal Value);