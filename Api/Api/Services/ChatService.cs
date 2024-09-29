using RestSharp;
using Newtonsoft.Json.Linq;
namespace Api.Services
{
    public class ChatService
    {
        private const string ApiKey = "";
        public async Task<string> GetChatAnswer(string prompt)
        {
            var client = new RestClient("https://api.openai.com/v1/chat/completions");
            var request = new RestRequest();
            request.Method = Method.Post;

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {ApiKey}");

            var body = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                new { role = "user", content = prompt }
            },
                max_tokens = 100
            };

            request.AddJsonBody(body);
            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                var jsonResponse = JObject.Parse(response.Content);
                return jsonResponse["choices"][0]["message"]["content"].ToString().Trim();
            }
            else
            {
                return $"Błąd: {response.StatusCode} - {response.Content}";
            }
        }
    }
}
