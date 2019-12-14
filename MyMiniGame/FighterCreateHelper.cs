﻿using MyMiniGame.Fighters.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMiniGame
{
    public static class FighterCreateHelper
    {
        public static BaseFighter FighterCreate ()
        {
            BaseFighter fighter;
            string name;
            int ch;
            string str;

            Console.WriteLine("Назовите своего Героя: ");
            name = Console.ReadLine().Trim();

            do
            {
                Console.WriteLine("Выберите Класс");
                Console.WriteLine("Warrior = 1, Paladin = 2, Mag = 3, Priest = 4, Archer = 5, Thief = 6");
                str = Console.ReadLine();
            } while(Int32.TryParse(str, out ch) && ch < 7 && ch > 0);
            fighter = ch switch
            {
                1 =>  new Warrior(name),
                2 =>  new Paladin(name),
                3 =>  new Mag(name),
                4 =>  new Priest(name),
                5 =>  new Archer(name),
                6 =>  new Thief(name),
                _ => throw new Exception("Хакер, что ли ?"),
            };
            return fighter;
        }
        public static void FighterCreateRandom(this BaseFighter fighter, int lvl)
        {
            //TODO: Реализовать создание случайного Бойца
            throw new NotImplementedException("Необходимо реализовать перед использованием");
        }
    }
}