using System;
using System.Threading.Tasks;
using System.Net.Http;



namespace Teht1
{

    public interface ICityBikeDataFetcher
    {
       Task<int> GetBikeCountInStation(string stationName);
    }

}