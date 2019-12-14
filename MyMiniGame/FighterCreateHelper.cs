using MyMiniGame.Fighters.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMiniGame
{
    public static class FighterCreateHelper
    {
        public static BaseFighter FighterCreate ()
        {
            Console.WriteLine("Выберите Класс");
            return;
        }
        public static void FighterCreateRandom(this BaseFighter fighter, int lvl)
        {
            //TODO: Реализовать создание случайного Бойца
            throw new NotImplementedException("Необходимо реализовать");
        }
    }
}
