using MyMiniGame.Fighters.Classes;
using MyMiniGame.Fighters.Effects;
using System;
using System.Collections.Generic;
using System.Text;
using MyMiniGame.Fighters;
using MyMiniGame.Fighters.Enemys;
using static MyMiniGame.Battle;
using static MyMiniGame.Messager;

namespace MyMiniGame.Menus
{
    public class FightMenu
    {
        String strInf = new String('-', 40);
        private BaseFighter _fighter;
        private BaseFighter _enemy;

        public FightMenu(BaseFighter fighter)
        {
            _fighter = fighter;
            _enemy = EnemyCreater.CreateEnemy(_fighter.Level);
            _enemy.Color = ConsoleColor.Red;
        }

        public void StartAttack()
        {
            do
            {
                Console.Clear();
                FighterInfoHelper.fightersNormalInfo(_fighter, _enemy);

                ConsoleMessage(_fighter);
                ConsoleMessage(_enemy);
                Console.WriteLine(strInf);

                ChooseAttack();
                if (_fighter.Health <= 0 || _enemy.Health <= 0)
                    break;

                EnemyAttack.Attack(_enemy,_fighter);
                if (_fighter.Health <= 0 || _enemy.Health <= 0)
                    break; 
            } while (true);
            
            WhoWinner(_fighter, _enemy);

            Console.WriteLine("\n\nДля продолжения, нажмите любую кнопку...");
            Console.ReadKey();
            //Возвращаем Жизни и Ману в норму
            _fighter.SetParametersToNormalize();
        }

        private void ChooseAttack ()
        {
            string strCh;
            int ch;
            bool attackUsed = false;
            do
            {
                Console.WriteLine("Выбор атаки:");
                Console.WriteLine($"1 - Обычная атака\n2 - Использовать способность ({_fighter.Mana} \\ {_fighter.Ability.Cost})\n3 - Сдаться");
                strCh = Console.ReadLine();
                if (int.TryParse(strCh, out ch))
                {
                    Console.Clear();
                    switch (ch)
                    {
                        case 1:
                            _fighter.StartAttack(_enemy, EnumAttackChoise.BaseAttack);
                            attackUsed = true;
                            break;
                        case 2:
                            if(_fighter.Mana >= _fighter.Ability.Cost)
                            {
                                _fighter.StartAttack(_enemy, EnumAttackChoise.MagicAttack);
                                attackUsed = true;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Не хватает маны.");
                                continue;
                            }

                        case 3:
                            _fighter.Health = 0;
                            attackUsed = true;
                            break;
                        default:
                            continue;
                    }
                }
            } while (attackUsed == false);
        }
    }
}
