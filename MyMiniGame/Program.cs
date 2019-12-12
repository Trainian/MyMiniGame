using MyMiniGame.Fighters;
using MyMiniGame.Fighters.Abilitys;
using MyMiniGame.Fighters.Classes;
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
    //TODO: Добавить Класс проверяющего и повышающего Уровень
    class Program
    {
        static void Main(string[] args)
        {
            messager += consoleMessage;
            bool _endFight = false;

            BaseFighter Fighter = new Priest("Dima") {Color = ConsoleColor.Cyan};
            BaseFighter Fighter2 = new Thief("Monster") {Color = ConsoleColor.DarkMagenta};

            while(!_endFight)
            {
                Console.Clear();
                Fighter.fighterFullInfo();
                messager?.Invoke(new String('-', 25));
                FightHelper.changeFighters<BaseFighter>(ref Fighter,ref Fighter2);
                _endFight = Battle.Fight(Fighter, Fighter2);
                Console.ReadLine();
            }
            Console.WriteLine("Конец !");
        }
    }
}
