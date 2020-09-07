using System;
using System.Collections.Generic;
using System.Linq;

namespace Teht2
{

    public class Player : IPlayer
    {
        public Guid Id { get; set; }
        public int Score { get; set; }
        public List<Item> Items { get; set; }

        public Player(Guid Id, List<Item> itemList)
        {
            this.Id = Id;
            this.Items = itemList;
        }

        public void CreatePlayers(int Amount)
        {
            List<Player> PlayerList = new List<Player>();

            for (int i = 0; i < Amount; i++)
            {
                Guid g1 = Guid.NewGuid();
                Random rnd = new Random();
                int ItemCount = rnd.Next(3, 11);

                List<Item> itemList = new List<Item>();
                for (int h = 0; h < ItemCount; h++)
                {
                    Guid g2 = Guid.NewGuid();
                    int RandomLevel = rnd.Next(1, 100000);
                    itemList.Add(new Item(g2, RandomLevel));
                }
                PlayerList.Add(new Player(g1, itemList));
            }

            // Tulostaminen

            foreach (var Player in PlayerList)
            {
                Console.WriteLine(Player.Id);
                for (int k = 0; k < Player.Items.Count; k++)
                {
                    Console.WriteLine(Player.Items[k].Id);
                    Console.WriteLine(Player.Items[k].Level);
                }
                Console.WriteLine("\n");
            }

            // int maxLevel = Player.Items.Levels.Max();

            CheckDuplicates(PlayerList);
            Console.WriteLine("Finished!");
        }

        public void CheckDuplicates(List<Player> playerList)
        {

            if (playerList.Count != playerList.Distinct().Count())
            {
                // Duplicates exist
                Console.WriteLine("Dupes found");
            }
        }
    }
}