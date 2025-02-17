using System;
namespace HeroBook
{
    public static class HazardTable
    {
        private const int MAXIMUM = 10;

        public static Random rnd = new();

        public static int GetRandom()
        {
            return rnd.Next() * MAXIMUM;
        }
    }
}
