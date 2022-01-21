using CodeHero.Wordle.Domain.Model;
using CodeHero.Wordle.Domain.Services;
using HtmlAgilityPack;
using System.Net;

namespace CodeHero.Wordle.WordFetcher.Services
{
    public class BestWordlListWordFetcher : IWordFetcher
    {
        private readonly string StartUrl = "https://www.bestwordlist.com/5letterwords.htm";
        private readonly string CurrentPageUrl = "https://www.bestwordlist.com/5letterwordspage{index}.htm";
        private readonly string NextPageRelativeUrl = "/5letterwordspage{index}.htm";

        public Task<IEnumerable<Word>> FetchWordsAsync()
        {
            var htmlWeb = GetHtmlWeb();
            var document = htmlWeb.Load(StartUrl);
            var words = GetWords(document);

            for (var i = 2; ; ++i)
            {
                var currentUrl = GetPageUrl(CurrentPageUrl, i);
                document = htmlWeb.Load(currentUrl);

                var newWords = GetWords(document);
                words = words.Concat(newWords);

                var nextUrl = GetPageUrl(NextPageRelativeUrl, i + 1);
                if (!HasNextPage(document, nextUrl))
                {
                    break;
                }
            }

            return Task.FromResult(words);
        }

        private HtmlWeb GetHtmlWeb() => new HtmlWeb()
        {
            PreRequest = request =>
            {
                request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                return true;
            }
        };

        private IEnumerable<Word> GetWords(HtmlDocument document) => document
            .DocumentNode
            .Descendants("span")
            .Where(span => span.HasClass("mot") || span.HasClass("mot2"))
            .SelectMany(span => span.InnerText.Split(" "))
            .Where(word => word.Length > 0)
            .Select(word => new Word() { Characters = word });

        private bool HasNextPage(HtmlDocument document, string nextPageUrl) => document
            .DocumentNode
            .Descendants("a")
            .Where(a => a.HasClass("f2"))
            .Select(a => a.GetAttributeValue("href", string.Empty))
            .Any(href => href.Equals(nextPageUrl));

        private string GetPageUrl(string url, int index) => url.Replace("{index}", index.ToString());
    }
}
