using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LakewoodScoopNoAds.Data
{
    public class Article
    {
        public string Title { get; set; }
        public string ArticleLink { get; set; }
        public string Image { get; set; }
        public string Excerpt { get; set; }
        public string Comments { get; set; }
    }

    public class Scraper
    {
        public List<Article> GetArticles()
        {
            var url = "https://thelakewoodscoop.com/";
            var client = new HttpClient();
            var html = client.GetStringAsync(url).Result;
            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);

            IHtmlCollection<IElement> allArticles = document.QuerySelectorAll(".td_block_inner.td-mc1-wrap");
            List<Article> articles = new List<Article>();

            foreach (var article in allArticles)
            {
                Article tempArticle = new Article();
                var title = article.QuerySelector(".entry-title");
                if (title != null)
                {
                    tempArticle.Title = title.TextContent;
                    var articleLink = title.QuerySelector("a");
                    if (articleLink != null)
                    {
                        tempArticle.ArticleLink = articleLink.Attributes["href"].Value;
                    }
                }

                var image = article.QuerySelector("span.entry-thumb");
                if (image != null)
                {
                    tempArticle.Image = image.Attributes["data-img-url"].Value;
                }

                var excerpt = article.QuerySelector(".td-excerpt");
                if (excerpt != null)
                {
                    tempArticle.Excerpt = excerpt.TextContent;
                }

                var comments = article.QuerySelector(".td-module-comments");
                if (comments != null)
                {
                    tempArticle.Comments = comments.TextContent;
                }

                articles.Add(tempArticle);
            };

            return articles;
        }

    }
}
