using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Collections.Generic;

public class Ratkaisija
{
    public Player[] PlayerList { get; set; }
    public Ratkaisija(Player[] PelaajaLista)
    {
        PlayerList = PelaajaLista;
    }
}
public class FileRepository : IRepository
{
    string path = @"C:\Users\jsuur\OneDrive\Työpöytä\Taustajärjs\GameWebApi\game-dev.txt";
    public Task<Player> Get(Guid id)
    {
        string jsonToBeDeserialized = System.IO.File.ReadAllText(path);
        List<Player> players = JsonConvert.DeserializeObject<List<Player>>(jsonToBeDeserialized);
        Player foundPlayer = new Player();
        foreach (Player player in players)
        {
            if (player.Id == id)
            {
                foundPlayer = player;
                return Task.FromResult<Player>(foundPlayer);
            }
        }
        foundPlayer.Name = "not found";
        return Task.FromResult<Player>(foundPlayer);
    }

    public Task<Player[]> GetAll()
    {
        string jsonToBeDeserialized = System.IO.File.ReadAllText(path);
        Ratkaisija players = JsonConvert.DeserializeObject<Ratkaisija>(jsonToBeDeserialized);
        Player[] players1 = players.PlayerList;
        return Task.FromResult<Player[]>(players1);
    }
    public Task<Player> Create(Player player)
    {
        Player[] players1;
        string jsonToBeDeserialized = System.IO.File.ReadAllText(path);
        if (jsonToBeDeserialized.Length > 0)
        {
            Ratkaisija players = JsonConvert.DeserializeObject<Ratkaisija>(jsonToBeDeserialized);
            players1 = new Player[players.PlayerList.Length + 2];
            var newlycreatedPlayer = new Player
            {
                Id = player.Id,
                Name = player.Name,
                Score = 0,
                Level = 0,
                IsBanned = false,
                CreationTime = DateTime.Now
            };
            players1 = players.PlayerList;
            players1[players.PlayerList.Length] = newlycreatedPlayer;
            Ratkaisija newplayers = new Ratkaisija(players1);
            string output = JsonConvert.SerializeObject(newplayers);
            File.WriteAllText(path, output);
            return Task.FromResult<Player>(newlycreatedPlayer);
        }
        else
        {
            players1 = new Player[500];
            var newlycreatedPlayer = new Player
            {
                Id = player.Id,
                Name = player.Name,
                Score = 0,
                Level = 0,
                IsBanned = false,
                CreationTime = DateTime.Now
            };

            players1[0] = newlycreatedPlayer;
            Ratkaisija newplayers = new Ratkaisija(players1);
            string output = JsonConvert.SerializeObject(newplayers);
            File.WriteAllText(path, output);
            return Task.FromResult<Player>(newlycreatedPlayer);
        }

    }
    public Task<Player> Modify(Guid id, ModifiedPlayer player)
    {
        string jsonToBeDeserialized = System.IO.File.ReadAllText(path);
        List<Player> players = JsonConvert.DeserializeObject<List<Player>>(jsonToBeDeserialized);
        Player foundPlayer = new Player();
        foreach (Player playeri in players)
        {
            if (playeri.Id == id)
            {
                playeri.Score = player.Score;
                string output = JsonConvert.SerializeObject(players);
                File.WriteAllText(path, output);
                return Task.FromResult<Player>(playeri);
            }
        }
        foundPlayer.Name = "not found";
        return Task.FromResult<Player>(foundPlayer);
    }
    public Task<Player> Delete(Guid id)
    {
        string jsonToBeDeserialized = System.IO.File.ReadAllText(path);
        List<Player> players = JsonConvert.DeserializeObject<List<Player>>(jsonToBeDeserialized);
        Player foundPlayer = new Player();
        foreach (Player playeri in players)
        {
            if (playeri.Id == id)
            {
                foundPlayer = playeri;
                players.Remove(playeri);
                string output = JsonConvert.SerializeObject(players);
                File.WriteAllText(path, output);
                return Task.FromResult<Player>(foundPlayer);
            }
        }
        foundPlayer.Name = "not found";
        return Task.FromResult<Player>(foundPlayer);
    }
}