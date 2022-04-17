namespace UrlsParser.UrlsExtracters
{
    public interface IUrlsExtracter
    {
        List<string> ExtractUrls(string text);
    }
}
