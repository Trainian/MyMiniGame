﻿using System;
using MyMiniGame.Fighters.Classes;

namespace MyMiniGame.Fighters
{
    public static class FighterCreateHelper
    {
        public static BaseFighter FighterCreate ()
        {
            BaseFighter fighter;
            string name;
            int ch;
            string str;

            Console.Write("Назовите своего Героя: ");
            name = Console.ReadLine().Trim();

            do
            {
                Console.WriteLine("Выберите Класс");
                Console.WriteLine("1 = Warrior\n2 = Paladin\n3 = Mag\n4 = Priest\n5 = Archer\n6 = Thief");
                str = Console.ReadLine();
            } while(!Int32.TryParse(str, out ch) || ch > 6 || ch < 1);
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
            fighter.Color = ConsoleColor.Green;
            fighter.LvlUp = 5;
            return fighter;
        }
    }
}
