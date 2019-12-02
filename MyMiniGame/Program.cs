using MyMiniGame.Fighters;
using MyMiniGame.Fighters.Abilitys;
using MyMiniGame.Fighters.Abilitys.Interfaces;
using System;
using System.Text;
using static MyMiniGame.Messager;

namespace MyMiniGame
{
    //TODO: Добавить МЕНЮ
    //TODO: Разделить и переделать классы БОЯ, МАГАЗИНА и ПОДНЯТИЯ УРОВНЯ
    //TODO: Переделать отображение информации во время боя
    //TODO: По добавлять информации Summary для классов и интерфесов
    class Program
    {
        static void Main(string[] args)
        {
            messager += consoleMessage;

            bool end = false;

            var Fighter = new Priest("Dima") {Color = ConsoleColor.Cyan};
            var Fighter2 = new Thief("Monster") {Color = ConsoleColor.DarkMagenta};

            while(!end)
            {
                Fighter.fighterFullInfo();
                messager?.Invoke(new String('-', 25));
                Fighter.Attack(Fighter2);
                Fighter.SuperAbility(Fighter2);
                FightHelper.fightersNormalInfo(Fighter, Fighter2);
                if (Console.ReadLine() == "exit")
                    end = true;
                else
                    Console.Clear();

                Fighter2.fighterFullInfo();
                messager?.Invoke(new String('-', 25));
                Fighter2.Attack(Fighter);
                Fighter2.SuperAbility(Fighter);
                FightHelper.fightersNormalInfo(Fighter2, Fighter);
                if (Console.ReadLine() == "exit")
                    end = true;
                else
                    Console.Clear();
            }
        }
    }
}
