using MyMiniGame.Fighters.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using static MyMiniGame.Messager;

namespace MyMiniGame
{
    static class Battle
    {
        public static bool Fight (BaseFighter fighterOne, BaseFighter fighterTwo)
        {
            int attack = 0;
            attack += fighterOne.Attack(fighterTwo);
            fighterOne.SuperAbility(fighterTwo);
            FightHelper.fightersNormalInfo(fighterOne, fighterTwo);

            Console.ForegroundColor = fighterOne.Color;
            messager($"{fighterOne.Name} нанёс {attack} урона {fighterTwo.Name}");
            messager($"Оставшееся здоровье противника: {fighterTwo.Health}");
            Console.ForegroundColor = ConsoleColor.White;

            return Death(fighterTwo);
        }
        private static bool Death (BaseFighter fighter)
        {
            if (fighter.Health <= 0)
                return true;
            else
                return false;
        }
        private static int SuperAbility(this BaseFighter fighterOne, BaseFighter fighterTwo)
        {
            int attack = 0;
            if(fighterOne.Mana >= fighterOne.Ability.Cost)
            {
                Console.ForegroundColor = fighterOne.Color;

                fighterOne.Mana =- fighterOne.Ability.Cost;
                fighterOne.Ability.Use(fighterOne, fighterTwo);

                Console.ForegroundColor = ConsoleColor.White;
            }
            return attack;
        }
        private static int Attack(this BaseFighter fighterOne, BaseFighter fighterTwo)
        {
            return fighterOne.Strength;
        }
    }
}
//-> Выбор Действия
//1) Обычная атака / Магическая атака

//    а) Получаем обычныую атаку и добавляем эффекты

//        i) Подсчитываем ману, если это магия

//        ii) Если нет маны, то пропускам, если есть то добавляем эффекты

//    б) Плюсуем атаку с эффектами

//    в) Выводим атаку