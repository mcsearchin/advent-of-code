using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class AdventOfCodeClient
    {
        private const string BaseUriString = "https://adventofcode.com/2018/";

        private const string DefaultSessionId =
            "53616c7465645f5f5bd14e6affcbcc327445c4b44178804f6d28049f607d3c1acb5d9bb0b288f156a5599cb03937889a";

        private readonly string _sessionId;

        public AdventOfCodeClient(string sessionId = DefaultSessionId)
        {
            _sessionId = sessionId;
        }

        public async Task<string> Get(string Path)
        {
            var baseAddress = new Uri(BaseUriString);
            var cookieContainer = new CookieContainer();
            var cookie = new Cookie("session", _sessionId) {Domain = baseAddress.Host};
            cookieContainer.Add(cookie);
            var handler = new HttpClientHandler {CookieContainer = cookieContainer};
            using (var client = new HttpClient(handler) {BaseAddress = baseAddress})
            {
                var result = await client.GetAsync(Path);
                result.EnsureSuccessStatusCode();
                return await result.Content.ReadAsStringAsync();
            }
        }
    }
}
