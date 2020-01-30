using MyMiniGame.Fighters;
using MyMiniGame.Fighters.Abilitys;
using MyMiniGame.Fighters.Classes;
using MyMiniGame.Fighters.Abilitys.Interfaces;
using System;
using System.Text;
using static MyMiniGame.Messager;
using static MyMiniGame.Fighters.LevelChange;
using MyMiniGame.Fighters.Effects;
using MyMiniGame.Menus;

namespace MyMiniGame
{
    //TODO: Разделить и переделать классы БОЯ, МАГАЗИНА и ПОДНЯТИЯ УРОВНЯ
    //TODO: Переделать отображение информации во время боя
    //TODO: По добавлять информации Summary для классов и интерфесов
    class Program
    {
        static void Main(string[] args)
        {
            messager += consoleMessage; // Подключяем уведомления
            var menu = new MainMenu(); // Создаём Меню
            menu.StartMenu(); // Запускам Меню
        }
    }
}
