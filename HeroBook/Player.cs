using System;
namespace HeroBook
{
    public class Player
    {
        public string PlayerName;

        public int Gold = 0; // Max 50
        public int Food = 5;

        public int Hability = 10 + HazardTable.GetRandom();
        public int Endurance = 20 + HazardTable.GetRandom();

        public Class Class;
        public Race Race;
        public Bag Bag = new();

        public Discipline Discipline;
    }
}
