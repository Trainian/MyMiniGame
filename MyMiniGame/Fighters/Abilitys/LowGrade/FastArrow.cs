using MyMiniGame.Fighters.Abilitys.Interfaces;
using MyMiniGame.Fighters.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMiniGame.Fighters.Abilitys
{
    class FastArrow : IAbility
    {
        public List<EnumClasses> IdClass => new List<EnumClasses>(new EnumClasses[] {EnumClasses.Archer });
        public string FullInfo => "Быстрая и сильная стрела, наносящий большой урон";

        public int Cost => 8;

        public void Use(BaseFighter fighter, BaseFighter enemy)
        {
            //TODO: Реализовать АБилку для FastArrow
            throw new NotImplementedException();
        }
    }
}
