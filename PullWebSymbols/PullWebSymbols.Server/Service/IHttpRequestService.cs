namespace PullWebSymbols.Server.Service;

public interface IHttpRequestService
{
    Task<Dictionary<string, int>> ExecuteSearch(string search);
}