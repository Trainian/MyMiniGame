using System;
using System.Collections.Generic;
using MyMiniGame.Fighters.Abilitys.Interfaces;
using MyMiniGame.Fighters.Classes;

namespace MyMiniGame.Fighters.Abilitys.LowGrade
{
    public struct FireBall : IAbility
    {
        public List<EnumClasses> IdClass => new List<EnumClasses>(new EnumClasses[] { EnumClasses.Mag });
        public string FullInfo => "Огненный шар, наносящий ожоги и увечья противнику";

        public int Cost => 20;

        public string Name => "Малый огенный шар";

        public bool IsAttack => true;

        public void Use(BaseFighter fighter, BaseFighter enemy)
        {
            //TODO: Реализовать абилку для FireBall
            throw new NotImplementedException();
        }
    }
}
