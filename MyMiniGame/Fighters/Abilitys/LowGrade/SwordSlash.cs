using MyMiniGame.Fighters.Abilitys.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMiniGame.Fighters.Abilitys
{
    class SwordSlash : IAbility
    {
        public Classes IdClass => Classes.Warrior;

        public string FullInfo => "Рассекающий удар, способный пробить броню";

        public void Use(BaseFighter fighter, BaseFighter enemy)
        {
            //TODO: Реализовать абилку для SwordSlash
            throw new NotImplementedException();
        }
    }
}
