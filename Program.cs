using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


class Program
{
    private static readonly HttpClient httpClient = new HttpClient();

    private const string BotToken = "MTI0MzMwMTExNDExMjM4MTE2OA.GpQoNc.hC5mLNv5FeNRctM_feMBdc7K180BICuBRbeYYY";

    private const string ChannelId = "876126506240335902";
    private const string MessageId = "1244963506797809675";

    private const string Emoji = "%F0%9F%91%8D";

    static async Task Main(string[] args)
    {
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bot {BotToken}");

        string url = $"https://discord.com/api/v9/channels/{ChannelId}/messages/{MessageId}/reactions/{Emoji}/@me";

        var response = await httpClient.PutAsync(url, null);

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Реакция успешно поставлена!");
        }
        else
        {
            string responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Ошибка: {response.StatusCode}\n{responseContent}");
        }
    }
}