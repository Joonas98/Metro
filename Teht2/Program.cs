using System;
using System.Collections.Generic;
using System.Linq;


namespace Teht2
{
    class Program
    {
        static void Main(string[] args)
        {

            Player host = new Player(Guid.NewGuid(), null);
            host.CreatePlayers(10);

        }
    }
}
