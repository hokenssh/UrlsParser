using System.Text.RegularExpressions;

namespace UrlsParser.UrlsExtracters
{
    public class RegexUrlExtracter : IUrlsExtracter
    {
        // if needed add other file extensions to the expression here
        private const string FileNameExpression = @"(?i)^(\w+[\w.\-]*)(\.png|\.gpg|\.jpeg|\.gif|\.txt|\.csv|\.docx)$";

        // this expression accepts file names
        private const string UrlExpression = @"(?i)\b([(http(s)?)://(www.)?a-z0-9@:%._+\-~#=]|[^\x00-\x7F]){2,}\.([a-z0-9]|[^\x00-\x7F]){2,}\b(([-a-z0-9@:%_+\-.~#?&//=]|[^\x00-\x7F])*)";

        private const string ProtocolPrefixExpression = @"^([\w]+://)";

        public List<string> ExtractUrls(string text)
        {
            List<string> urls = new List<string>();

            MatchCollection urlMatches = Regex.Matches(text, UrlExpression);

            // go through all the found matches and check if it is not a file name
            // and make sure to include the protocol prefix
            foreach (Match match in urlMatches)
            {
                string urlCandidate = match.Groups[0].Value;
                
                // urlCandidate can be something like random.name.png which is a file name
                // don't add it to returned Urls
                if (!this.IsFileName(urlCandidate))
                {
                    urls.Add(this.AddProtocolPrefix(urlCandidate));
                }
                
            }

            return urls;
        }

        private bool IsFileName(string url)
        {
            Match matchFileName = Regex.Match(url, FileNameExpression);
            return matchFileName.Success;
        }

        private string AddProtocolPrefix(string url)
        {
            // check if url contains the protocol prefix
            var matchProtocol = Regex.Match(url, ProtocolPrefixExpression);
            var hasProtocolPrefix = matchProtocol.Success;
            var protocolPrefix = hasProtocolPrefix ? string.Empty : "http://";

            return protocolPrefix + url;
        }
    }
}