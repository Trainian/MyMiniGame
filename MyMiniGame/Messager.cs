using System;
using System.Collections.Generic;
using System.Text;

namespace MyMiniGame
{
    //TODO: сохранять ЛОГ боя, для просмотра во время или после БОЯ
    internal static class Messager
    {
        internal static Action<string> messager;
        /// <summary>
        /// Вывод сообщений в Консоле
        /// </summary>
        /// <param name="message">сообщение</param>        
        public static void consoleMessage (string message)
        {
            Console.WriteLine(message);
        }
        /// <summary>
        /// Запись сообщения в ЛОГ
        /// </summary>
        /// <param name="message">текст</param>
        public static void consoleMessage1(string message)
        {
            // TODO: Реализовать запись в файл
        }
    }
}
