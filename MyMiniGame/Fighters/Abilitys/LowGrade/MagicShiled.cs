using MyMiniGame.Fighters.Abilitys.Interfaces;
using MyMiniGame.Fighters.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMiniGame.Fighters.Abilitys
{
    class MagicShiled : IAbility
    {
        public List<EnumClasses> IdClass => new List<EnumClasses>(new EnumClasses[] {EnumClasses.Paladin});
        public string FullInfo => "Магический щит, дающий защиту при следующем ударе";

        public void Use(BaseFighter fighter, BaseFighter enemy)
        {
            //TODO: Реализовать Абилку для MagicShiled
            throw new NotImplementedException();
        }
    }
}
