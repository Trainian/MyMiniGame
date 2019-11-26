using MyMiniGame.Fighters;
using System;

namespace MyMiniGame
{
    enum FightersNames
    {
        Warrior = 1,
        Paladin = 2,
        Mag = 3,
        Cleric = 4,
        Archer = 5,
        Thief = 6
    }
    class Program
    {
        public static Action<string> messager;
        static void Main(string[] args)
        {
            messager += Messager.consoleMessage;

            var Fighter = new Priest("Dima") {Ability = new Health() };

            var Fighter2 = new Priest("Monster");
            Fighter.Ability = new Health();

            Fighter.fighterFullInfo();
            Console.WriteLine();

            Console.WriteLine("Fighter {0} Health: {1}",Fighter.Name, Fighter.Health);
            Console.WriteLine("Fighter {0} Health: {1}", Fighter2.Name, Fighter2.Health);
            Fighter.SuperAbility(Fighter2);
            Fighter.Attack(Fighter2);
            Console.WriteLine("----------After Fight---------");
            Console.WriteLine("Fighter {0} Health: {1}", Fighter.Name, Fighter.Health);
            Console.WriteLine("Fighter {0} Health: {1}", Fighter2.Name, Fighter2.Health);
        }
    }
}
