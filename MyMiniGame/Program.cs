using MyMiniGame.Menus;
using static MyMiniGame.Messager;

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
