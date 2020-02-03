using MyMiniGame.Fighters;
using MyMiniGame.Fighters.Abilitys;
using MyMiniGame.Fighters.Classes;
using MyMiniGame.Fighters.Abilitys.Interfaces;
using System;
using System.Text;
using static MyMiniGame.Messager;
using MyMiniGame.Fighters.Effects;
using MyMiniGame.Menus;

namespace MyMiniGame
{
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
