using System;
using System.Collections.Generic;
using MyMiniGame.Fighters.Abilitys.Interfaces;
using MyMiniGame.Fighters.Classes;

namespace MyMiniGame.Fighters.Abilitys.LowGrade
{
    public struct SwordSlash : IAbility
    {
        public List<EnumClasses> IdClass => new List<EnumClasses>(new EnumClasses[] {EnumClasses.Warrior});
        public string FullInfo => "Рассекающий удар, способный пробить броню";

        public int Cost => 8;

        public string Name => "Лёгкий рубящий удар мечом";

        public bool IsAttack => true;

        public int Use(BaseFighter fighter, BaseFighter enemy)
        {
            //TODO: Реализовать абилку для SwordSlash
            throw new NotImplementedException();
        }
    }
}
