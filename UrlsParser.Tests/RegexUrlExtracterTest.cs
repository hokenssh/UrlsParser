using System.Collections.Generic;
using UrlsParser.UrlsExtracters;
using Xunit;

namespace UrlsParser.Tests;

public class RegexUrlExtracterTest
{
    private IUrlsExtracter extracter = new RegexUrlExtracter();

    [Fact]
    public void ExtractUrls_OneValidUrl_ReturnOneUrl()
    {
        var actual = this.extracter.ExtractUrls("hocine.khen.com");

        Assert.Single(actual);
        Assert.Equal("http://hocine.khen.com", actual[0]);
    }

    [Fact]
    public void ExtractUrls_MultipleValidUrl_ReturnMultipleUrl()
    {
        var actual = this.extracter.ExtractUrls("hocine.khen.com hoken.com");

        var expected = new List<string> { "http://hocine.khen.com", "http://hoken.com" };
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ExtractUrls_InputTextWithoutUrls_ReturnNoUrls()
    {
        var actual = this.extracter.ExtractUrls("this is a normal text that does not include urls.");

        Assert.Empty(actual);
    }

    [Fact]
    public void ExtractUrls_InputTextOnlyFiles_ReturnNoUrls()
    {
        var actual = this.extracter.ExtractUrls("image.name.jpeg, excel.file.csv");

        Assert.Empty(actual);
    }

    [Fact]
    public void ExtractUrls_InputTextUrlsAndFiles_ReturnNoUrls()
    {
        var actual = this.extracter.ExtractUrls("these two websites hocine.khen.com and hoken.com includes two files: image.name.jpeg, excel.file.csv");

        var expected = new List<string> { "http://hocine.khen.com", "http://hoken.com" };
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ExtractUrls_InputTextWithFilesNames_ReturnNoUrls()
    {
        var actual = this.extracter.ExtractUrls("image.test.png testimage.gpg picture.test.jpeg animated.image.gif text.file.txt excelfile.csv wordfile.docx");

        Assert.Empty(actual);
    }

    [Fact]
    public void ExtractUrls_InputUrlWithoutProtocolPrefix_ReturnUrlWithProtocol()
    {
        var actual = this.extracter.ExtractUrls("hocine.khen.com");

        Assert.Equal("http://hocine.khen.com", actual[0]);
    }

    [Fact]
    public void ExtractUrls_InputUrlWithProtocolPrefix_ReturnUrlWithExistingProtocol()
    {
        var actual = this.extracter.ExtractUrls("ftp://hocine.khen.com");

        Assert.Equal("ftp://hocine.khen.com", actual[0]);
    }

    // multiple valid urls
    // full url with query params
    // full url that include image path
    // mixed files and urls
    // url with one letter after the last dot --> invvalid
}