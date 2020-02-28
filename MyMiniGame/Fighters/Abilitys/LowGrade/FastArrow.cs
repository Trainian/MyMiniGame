using System;
using System.Collections.Generic;
using MyMiniGame.Fighters.Abilitys.Interfaces;
using MyMiniGame.Fighters.Classes;

namespace MyMiniGame.Fighters.Abilitys.LowGrade
{
    public struct FastArrow : IAbility
    {
        public List<EnumClasses> IdClass => new List<EnumClasses>(new EnumClasses[] {EnumClasses.Archer });
        public string FullInfo => "Быстрая и сильная стрела, наносящий большой урон";

        public int Cost => 8;

        public string Name => "Слабые но быстрые стрелы";

        public bool IsAttack => true;

        public void Use(BaseFighter fighter, BaseFighter enemy)
        {
            //TODO: Реализовать АБилку для FastArrow
            throw new NotImplementedException();
        }
    }
}
