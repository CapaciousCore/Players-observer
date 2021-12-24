using System.Collections.Generic;
using System.Linq;

namespace Players_observer
{
    public class Map
    {
        public int ZoneID { get; set; }
        public string ZoneName { get; set; }
        public int MapSize { get; set; }

        public Map(int ZoneID, string ZoneName, int MapSize)
        {
            this.ZoneID = ZoneID;
            this.ZoneName = ZoneName;
            this.MapSize = MapSize;
        }
    }

    class Player
    {
        public string UserID { get; set; }
        public int ZoneID { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Player(string UserID, int ZoneID, float X, float Y, float Z)
        {
            this.UserID = UserID;
            this.ZoneID = ZoneID;
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }
    }

    class Observer
    {
        private List<Map> Maps = new List<Map>();
        private List<Player> Players = new List<Player>();
        public int CurrentZoneID { get; set; } = 21;
        public string ObservedUserID { get; set; }

        public Observer()
        {
            // Maps
            Maps.Add(new Map(1, "Karus", 2048));
            Maps.Add(new Map(2, "Elmorad", 2048));
            Maps.Add(new Map(11, "Karus Eslant", 1024));
            Maps.Add(new Map(12, "Elmorad Eslant", 1024));
            Maps.Add(new Map(21, "Moradon", 512));
            Maps.Add(new Map(30, "Delos", 1024));
            Maps.Add(new Map(32, "Desperation Abyss", 512));
            Maps.Add(new Map(33, "Hell Abyss", 512));
            Maps.Add(new Map(48, "Battle Arena", 256));
            Maps.Add(new Map(51, "Orc Prisoner Arena", 256));
            Maps.Add(new Map(52, "Blood Don Arena", 256));
            Maps.Add(new Map(53, "Goblin Arena", 256));
            Maps.Add(new Map(54, "Caitharos Arena", 256)); // Cape Quest
            Maps.Add(new Map(55, "Kellino Temple", 256)); // Forgotten Temple
            // Maps.Add(new Map(91, "Monster Storage", 256));
            Maps.Add(new Map(101, "Napies Gorge", 1024)); // Lunar War
            Maps.Add(new Map(102, "Alseids Prairie", 1024)); // Dark Lunar War
            Maps.Add(new Map(103, "Neids Triangle", 1024)); // New Lunar War
            Maps.Add(new Map(111, "Snow War", 1024));
            Maps.Add(new Map(201, "Colony Zone", 2048));
        }

        public void AddPlayer(string UserID, int ZoneID, float X, float Z, float Y)
        {
            Players.Add(new Player(UserID, ZoneID, X, Z, Y));
        }

        public void UpdatePlayer(string UserID, int ZoneID, float X, float Z, float Y)
        {
            var Player = Players.FirstOrDefault(p => p.UserID == UserID);

            if (Player != null)
            {
                Player.ZoneID = ZoneID;
                Player.X = X;
                Player.Z = Z;
                Player.Y = Y;
            }
        }

        public void RemovePlayer(string UserID)
        {
            Players.RemoveAll(p => p.UserID == UserID);
        }

        public void ClearPlayersList()
        {
            Players.Clear();
        }

        public Player GetPlayerInfo(string UserID)
        {
            return Players.Where(p => p.UserID == UserID).FirstOrDefault();
        }

        public List<Player> GetPlayers(int ZoneID)
        {
            return Players.Where(p => p.ZoneID == ZoneID).ToList();
        }

        public List<Map> GetMapsList()
        {
            return Maps.ToList();
        }

        public int GetMapSize(int ZoneID)
        {
            return Maps.Where(m => m.ZoneID == ZoneID).FirstOrDefault().MapSize;
        }
    }
}