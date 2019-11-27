using MyMiniGame.Fighters;
using System;
using System.Text;

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
            bool end = false;
            messager += Messager.consoleMessage;

            var Fighter = new Priest("Dima") {Color = ConsoleColor.Cyan};
            var Fighter2 = new Priest("Monster") {Color = ConsoleColor.DarkMagenta};


            while(!end)
            {
                Fighter.fighterFullInfo();
                Console.WriteLine(new String('-', 25));
                Fighter.Attack(Fighter2);
                Fighter.SuperAbility(Fighter2);
                FightHelper.fightersNormalInfo(Fighter, Fighter2);
                FightHelper.Reverse(ref Fighter, ref Fighter2);
                if (Console.ReadLine() == "exit")
                    end = true;
                else
                    Console.Clear();
            }
        }
    }
}
