using System;
using System.Collections.Generic;
using System.Text;

namespace MyMiniGame
{
    internal static class Messager
    {
        /// <summary>
        /// Вывод сообщений в Консоле
        /// </summary>
        /// <param name="message">сообщение</param>
        internal static void consoleMessage (string message)
        {
            Console.WriteLine(message);
        }
        /// <summary>
        /// Запись сообщения в ЛОГ
        /// </summary>
        /// <param name="message">текст</param>
        internal static void consoleMessage1(string message)
        {
            // TODO: Реализовать запись в файл
        }
    }
}
