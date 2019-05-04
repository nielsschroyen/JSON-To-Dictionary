using NUnit.Framework;

namespace JSONToDictionary.Tests
{
    [TestFixture]
    public class NewtonsoftExample
    {
        //https://www.newtonsoft.com/json/help/html/SerializingJSONFragments.htm
        [Test]
        public void NewtonsoftExampleTest()
        {
            var json = @"{
                  'responseData': {
                    'results': [
                      {
                        'GsearchResultClass': 'GwebSearch',
                        'unescapedUrl': 'http://en.wikipedia.org/wiki/Paris_Hilton',
                        'url': 'http://en.wikipedia.org/wiki/Paris_Hilton',
                        'visibleUrl': 'en.wikipedia.org',
                        'cacheUrl': 'http://www.google.com/search?q=cache:TwrPfhd22hYJ:en.wikipedia.org',
                        'title': '<b>Paris Hilton</b> - Wikipedia, the free encyclopedia',
                        'titleNoFormatting': 'Paris Hilton - Wikipedia, the free encyclopedia',
                        'content': '[1] In 2006, she released her debut album...'
                      },
                      {
                        'GsearchResultClass': 'GwebSearch',
                        'unescapedUrl': 'http://www.imdb.com/name/nm0385296/',
                        'url': 'http://www.imdb.com/name/nm0385296/',
                        'visibleUrl': 'www.imdb.com',
                        'cacheUrl': 'http://www.google.com/search?q=cache:1i34KkqnsooJ:www.imdb.com',
                        'title': '<b>Paris Hilton</b>',
                        'titleNoFormatting': 'Paris Hilton',
                        'content': 'Self: Zoolander. Socialite <b>Paris Hilton</b>...'
                      }
                    ],
                    'cursor': {
                      'pages': [
                        {
                          'start': '0',
                          'label': 1
                        },
                        {
                          'start': '4',
                          'label': 2
                        },
                        {
                          'start': '8',
                          'label': 3
                        },
                        {
                          'start': '12',
                          'label': 4
                        }
                      ],
                      'estimatedResultCount': '59600000',
                      'currentPageIndex': 0,
                      'moreResultsUrl': 'http://www.google.com/search?oe=utf8&ie=utf8...'
                    }
                  },
                  'responseDetails': null,
                  'responseStatus': 200
                }";

            var dictionary = JSONToDictionary.ToDictionary(json);
            var searchResults = dictionary.GetDictionary("responseData")
                .GetListWithTypedObjects<SearchResults>("results");

            Assert.That(dictionary["responseStatus"], Is.EqualTo(200));
            Assert.That(searchResults[0].url, Is.EqualTo("http://en.wikipedia.org/wiki/Paris_Hilton"));
            Assert.That(searchResults[0].title, Is.EqualTo("<b>Paris Hilton</b> - Wikipedia, the free encyclopedia"));
        }

        public class SearchResults
        {
            public string url { get; set; }
            public string title { get; set; }
        }

    }

}