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
            fighterOne.fighterFullInfo();
            messager?.Invoke(new String('-', 25));
            fighterOne.Attack(fighterTwo);
            fighterOne.SuperAbility(fighterTwo);
            FightHelper.fightersNormalInfo(fighterOne, fighterTwo);
            if (fighterTwo.Health <= 0)
                return true;
            else
                return false;
        }
    }
}
