using MyMiniGame.Fighters;
using MyMiniGame.Fighters.Abilitys;
using MyMiniGame.Fighters.Classes;
using MyMiniGame.Fighters.Abilitys.Interfaces;
using System;
using System.Text;
using static MyMiniGame.Messager;
using static MyMiniGame.Fighters.LevelChange;
using MyMiniGame.Fighters.Effects;

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
            Fighter2.Effects.Add(new Bleeding());
            Fighter2.Effects.Add(new Shield());

            while(!_endFight)
            {
                Console.Clear();
                Fighter.fighterFullInfo();
                messager?.Invoke(new String('-', 25));
                _endFight = Battle.Fight(Fighter, Fighter2);
                FighterInfoHelper.changeFighters<BaseFighter>(ref Fighter,ref Fighter2);
                //Console.ReadLine();
            }
            ExpSet(Fighter2, Fighter.Level, true);
            Fighter2.fighterFullInfo();
            Console.WriteLine("Конец !");
        }
    }
}
