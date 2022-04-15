namespace UrlsParser.Helpers
{
    public interface IUrlsExtracter
    {
        public List<string> ExtractUrls(string text);
    }
}
