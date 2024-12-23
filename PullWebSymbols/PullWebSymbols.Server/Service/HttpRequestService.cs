using HtmlAgilityPack;

namespace PullWebSymbols.Server.Service;

public class HttpRequestService(IHttpClientFactory httpClientFactory) : IHttpRequestService
{
    public async Task<Dictionary<string, int>> ExecuteSearch(string search = "https://www.google.com")
    {
        var client = httpClientFactory.CreateClient();

        HttpResponseMessage response = await client.GetAsync(search);
        var htmlResp = await response.Content.ReadAsStringAsync();

        var htmlDoc = new HtmlDocument();
        htmlDoc.LoadHtml(htmlResp);
        var allNodes = htmlDoc.DocumentNode.Descendants();
        var res = allNodes.Where(n => n.NodeType == HtmlNodeType.Element).GroupBy(n => n.Name).ToDictionary(n => n.Key, n => n.Count());

        return res;
    }
}
