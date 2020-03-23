using MyMiniGame.Fighters.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMiniGame
{
    /// <summary>
    /// Приходит информация об атаках в готово STRING значение, после чего отображается и сохраняется, если есть такая необходимость.
    /// </summary>
    //TODO: сохранять ЛОГ боя, для просмотра во время или после БОЯ
    internal static class Messager
    {
        internal static Action<BaseFighter> messager;
        
        /// <summary>
        /// Вывод сообщений в Консоле
        /// </summary>  
        public static void ConsoleMessage(BaseFighter fighter)
        {
            Console.ForegroundColor = fighter.Color;
            for (int i = 0; i < fighter.Messages.Count;)
            Console.WriteLine(fighter.Messages.Dequeue());
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Запись сообщения в ЛОГ
        /// </summary>
        /// <param name="message">текст</param>
        public static void ConsoleMessage1(string message)
        {
            // TODO: Реализовать запись в файл
        }
    }
}
