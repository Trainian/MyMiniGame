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
        private List<BaseFighter> _enemies { get; set; }
        public FightMenu(BaseFighter fighter)

        {
            _fighter = fighter;
            _enemies.Add(new Thief("enemie"));
        }
        public void StartAtack(BaseFighter enemy)
        {
            do
            {
                ChooseAttack();

            } while (_fighter.Health > 0 || enemy.Health > 0);
        }
        private void ChooseAttack ()
        {
            FighterInfoHelper.fighterSmallInfo(_fighter);
            messager?.Invoke("Выбор атаки:");
            messager?.Invoke($"1 - Обычная атака\n2 - Использовать способность ({_fighter.Ability.Cost} маны)");
        }
    }
}
