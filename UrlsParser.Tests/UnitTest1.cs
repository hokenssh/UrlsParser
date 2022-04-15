using UrlsParser.Helpers;
using Xunit;

namespace UrlsParser.Tests;

public class UnitTest1
{
    [Fact]
    public void ExtractUrls_OneValidUrl_ReturnOneUrl()
    {
        IUrlsExtracter extracter = new RegexUrlExtracter();

        var actual = extracter.ExtractUrls("hocine.khen.com");

        Assert.Single(actual);
        Assert.Equal("http://hocine.khen.com", actual[0]);
    }

    [Fact]
    public void ExtractUrls_InputTextWithoutUrls_ReturnNoUrls()
    {
        IUrlsExtracter extracter = new RegexUrlExtracter();
        var actual = extracter.ExtractUrls("this is a normal text that does not include urls.");

        Assert.Empty(actual);
    }

    [Fact]
    public void ExtractUrls_InputTextWithFilesNames_ReturnNoUrls()
    {
        IUrlsExtracter extracter = new RegexUrlExtracter();
        var actual = extracter.ExtractUrls("image.test.png testimage.gpg picture.test.jpeg animated.image.gif text.file.txt excelfile.csv wordfile.docx");

        Assert.Empty(actual);
    }

    [Fact]
    public void ExtractUrls_InputUrlWithoutProtocolPrefix_ReturnUrlWithProtocol()
    {
        IUrlsExtracter extracter = new RegexUrlExtracter();
        var actual = extracter.ExtractUrls("hocine.khen.com");

        Assert.Equal("http://hocine.khen.com", actual[0]);
    }

    [Fact]
    public void ExtractUrls_InputUrlWithProtocolPrefix_ReturnUrlWithExistingProtocol()
    {
        IUrlsExtracter extracter = new RegexUrlExtracter();
        var actual = extracter.ExtractUrls("ftp://hocine.khen.com");

        Assert.Equal("ftp://hocine.khen.com", actual[0]);
    }

    //multiple valid urls
    // full url with query params
    //full url that include image path
    //mixed files and urls
    //url with one letter after the last dot --> invvalid
}