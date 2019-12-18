using MyMiniGame.Fighters.Classes;
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
        private List<BaseFighter> _enemies { get; set; } = new List<BaseFighter>();
        public FightMenu(BaseFighter fighter)

        {
            _fighter = fighter;
            _enemie = new Thief("enemie");
        }
        public void StartAtack()
        {
            do
            {
                int attack = ChooseAttack();
                _enemie.Health -= attack;
                FighterInfoHelper.fightersNormalInfo(_fighter, _enemie);
                Console.ForegroundColor = _fighter.Color;
                messager($"{_fighter.Name} нанёс {attack} урона {_fighter.Name}");
                messager($"Оставшееся здоровье противника: {_fighter.Health}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
            } while (_fighter.Health > 0 && _enemie.Health > 0);
        }
        private int ChooseAttack ()
        {
            string strCh;
            int ch;
            do
            {
                Console.Clear();
                FighterInfoHelper.fighterSmallInfo(_fighter);
                messager?.Invoke("Выбор атаки:");
                messager?.Invoke($"1 - Обычная атака\n2 - Использовать способность ({_fighter.Ability.Cost} маны)\n3 - Сдаться и проиграть");
                strCh = Console.ReadLine();
                if (int.TryParse(strCh, out ch))
                {
                    switch (ch)
                    {
                        case 1:
                            return _fighter.Attack(_enemie);
                        case 2:
                            return _fighter.SuperAbility(_enemie);
                        case 3:
                            return int.MinValue;
                        default:
                            break;
                    }
                }
            } while (ch != 3);
            return -1;
        }
    }
}
