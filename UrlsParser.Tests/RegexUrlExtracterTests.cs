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
        var text = @"Lorem Ipsum is simply dummy text of the printing test.website.com and typesetting industry. Lorem Ipsum has been the industry's\n"
        + " standard dummy text ever since the 1500s, when an unknown";
        var expected = new List<string> { "http://test.website.com" };

        var actual = this.extracter.ExtractUrls(text);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ExtractUrls_MultipleValidUrl_ReturnMultipleUrl()
    {
        var text = @"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's\n"
        + " standard dummy text ever since the 1500s, someserver.website1.net and otherserver.com when an unknown";
        var expected = new List<string> { "http://someserver.website1.net", "http://otherserver.com" };

        var actual = this.extracter.ExtractUrls(text);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ExtractUrls_InputTextWithoutUrls_ReturnNoUrls()
    {
        var text = @"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's\n"
        + " standard dummy text ever since the 1500s, when an unknown...";

        var actual = this.extracter.ExtractUrls(text);

        Assert.Empty(actual);
    }

    [Fact]
    public void ExtractUrls_InputTextOnlyFiles_ReturnNoUrls()
    {
        var text = @"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's\n"
        + " standard dummy text image.name.jpeg, excel.file.csv ever since the 1500s, when an unknown...";

        var actual = this.extracter.ExtractUrls(text);

        Assert.Empty(actual);
    }

    [Fact]
    public void ExtractUrls_InputTextUrlsAndFiles_ReturnNoUrls()
    {
        var text = "these two websites wow.website.fi nope.server.net includes two files: image.name.jpeg, excel.file.csv";
        var expected = new List<string> { "http://wow.website.fi", "http://nope.server.net" };

        var actual = this.extracter.ExtractUrls(text);

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
        var text = @"Lorem Ipsum lorem.ipsum.com is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's\n"
        + " standard dummy text ever since the 1500s, when an unknown...";
        var expected = new List<string> { "http://lorem.ipsum.com" };

        var actual = this.extracter.ExtractUrls(text);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ExtractUrls_InputUrlWithProtocolPrefix_ReturnUrlWithExistingProtocol()
    {
        var text = @"Lorem Ipsum ftp://lorem.ipsum.com is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's\n"
        + " standard dummy text ever since the 1500s, when an unknown...";
        var expected = new List<string> { "ftp://lorem.ipsum.com" };

        var actual = this.extracter.ExtractUrls(text);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ExtractUrls_InputValidUrlForFileLocation_ReturnUrlWithExistingProtocol()
    {
        var text = @"Lorem Ipsum https://lorem.ipsum.com/public/files/filename.csv is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's\n"
        + " standard dummy text ever since the 1500s, when an unknown...";
        var expected = new List<string> { "https://lorem.ipsum.com/public/files/filename.csv" };

        var actual = this.extracter.ExtractUrls(text);


        Assert.Equal(expected, actual);
    }
}