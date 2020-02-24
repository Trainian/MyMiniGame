using MyMiniGame.Fighters.Classes;
using MyMiniGame.Fighters.Effects;
using System;
using System.Collections.Generic;
using System.Text;
using MyMiniGame.Fighters;
using static MyMiniGame.Messager;

namespace MyMiniGame.Menus
{
    public class FightMenu
    {
        private BaseFighter _fighter;
        private BaseFighter _enemy;
        private bool battleEnd = false;

        public FightMenu(BaseFighter fighter)
        {
            _fighter = fighter;
            _enemy = EnemyCreater.CreateEnemy(_fighter.Level);
            _enemy.Color = ConsoleColor.Red;
        }

        public void StartAtack()
        {
            Console.Clear();
            FighterInfoHelper.fightersNormalInfo(_fighter, _enemy);

            do
            {
                ChooseAttack();
                if (_fighter.Health <= 0 || _enemy.Health <= 0)
                    battleEnd = true;

                _enemy.Effects();
                EnemyAttack.Attack(_enemy,_fighter);
                if (_fighter.Health <= 0 || _enemy.Health <= 0)
                    battleEnd = true;


                String str = new String('-', 40);
                Console.WriteLine(str);
                FighterInfoHelper.fightersNormalInfo(_fighter, _enemy);
            } while (!battleEnd);


            if(_fighter.Health <= 0 && _enemy.Health <= 0)
                Console.WriteLine("Ничья");
            else if (_fighter.Health <= 0)
                Console.WriteLine("Вы умерли");
            else
            {
                Console.WriteLine("Вы победили !");

                //Опыт за бой
                ExpUp.ExpSet(_fighter, _enemy.Level);
            }

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
                Console.WriteLine($"1 - Обычная атака\n2 - Использовать способность ({_fighter.Ability.Cost} маны)\n3 - Сдаться");
                strCh = Console.ReadLine();
                if (int.TryParse(strCh, out ch))
                {
                    Console.Clear();
                    switch (ch)
                    {
                        case 1:
                            _fighter.StartAttack(_enemy, 1);
                            attackUsed = true;
                            break;
                        case 2:
                            if(_fighter.Mana >= _fighter.Ability.Cost)
                            {
                                _fighter.StartAttack(_enemy, 2);
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
