using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FavBooks.Core;
using FavBooks.Core.Entities;
using Newtonsoft.Json.Linq;

namespace FavBooks.DataAccess.ExternalDataProviders
{
    public class BookDataProvider : IExternalDataProvider<Book>
    {
        public async Task<Book> GetItem(params object[] keys)
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(string.Format("https://www.booknomads.com/api/v0/isbn/{0}", keys)))
            {
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    try
                    {
                        dynamic json = JValue.Parse(data);
                        Book book = new Book()
                        {
                            ISBN = json.ISBN,
                            CoverThumb = json.CoverThumb,
                            Description = json.Description,
                            Title = json.Title,
                            Subtitle = json.Subtitle,
                            Subjects = string.Join(", ", json.Subjects),
                            Authors = string.Join(", ", ((JArray)json.Authors).Select(a => a["Name"].ToString()).ToArray())
                        };
                        return book;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Couldn't parse json");
                    }
                }
                return null;
            }
        }
    }
}
