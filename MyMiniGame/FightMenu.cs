using MyMiniGame.Fighters.Classes;
using MyMiniGame.Fighters.Effects;
using System;
using System.Collections.Generic;
using System.Text;
using static MyMiniGame.Messager;

namespace MyMiniGame
{
    public class FightMenu
    {
        private BaseFighter _fighter;
        private BaseFighter _enemie;
        private bool battleEnd = false;
        public FightMenu(BaseFighter fighter)
        {
            _fighter = fighter;
            _enemie = new Thief("enemie");
            _enemie.Color = ConsoleColor.Red;
        }
        public void StartAtack()
        {
            Console.Clear();
            FighterInfoHelper.fightersNormalInfo(_fighter, _enemie);
            do
            {
                ChooseAttack();

                if (_fighter.Health <= 0 || _enemie.Health <= 0)
                    battleEnd = true;
                //TODO: Атака противника
                Battle.Effects(_enemie, _fighter);
            } while (!battleEnd);
            if(_fighter.Health <= 0 && _enemie.Health <= 0)
                Console.WriteLine("Ничья");
            else if (_fighter.Health <= 0)
                Console.WriteLine("Вы умерли");
            else
                Console.WriteLine("Вы победили !");
            Console.WriteLine("\n\nДля продолжения, нажмите любую кнопку...");
            Console.ReadKey();
        }
        private void ChooseAttack ()
        {
            string strCh;
            int ch;
            bool attackUsed = false;
            do
            {
                Console.WriteLine("Выбор атаки:");
                Console.WriteLine($"1 - Обычная атака\n2 - Использовать способность ({_fighter.Ability.Cost} маны)\n3 - Сдаться");
                strCh = Console.ReadLine();
                if (int.TryParse(strCh, out ch))
                {
                    Console.Clear();
                    FighterInfoHelper.fightersNormalInfo(_fighter, _enemie);
                    switch (ch)
                    {
                        case 1:
                            _fighter.BaseAttack(_enemie);
                            attackUsed = true;
                            break;
                        case 2:
                            if(_fighter.Mana > _fighter.Ability.Cost)
                            {
                                _fighter.SuperAbility(_enemie);
                                attackUsed = true;
                            }
                            else
                                Console.WriteLine("Не хватает маны.");
                            break;
                        case 3:
                            _fighter.Health = 0;
                            attackUsed = true;
                            break;
                        default:
                            break;
                    }
                }
            } while (attackUsed == false);
        }
    }
}
