using System;
using System.Threading.Tasks;
using System.Net.Http;


namespace Teht1
{

    class Program
    {
        static async Task Main(string[] args)
        {
            RealTimeCityBikeDataFetcher fetcher = new RealTimeCityBikeDataFetcher();
            int arvo = 0;
            arvo = await fetcher.GetBikeCountInStation("Lammasrinne");
            Console.WriteLine(arvo);
        }
    }
}
