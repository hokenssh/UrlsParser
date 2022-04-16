namespace UrlsParser.UrlsExtracters
{
    public interface IUrlsExtracter
    {
        public List<string> ExtractUrls(string text);
    }
}
