using MyMiniGame.Fighters.Abilitys.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMiniGame.Fighters.Abilitys
{
    class FireBall : IAbility
    {
        public List<EnumClasses> IdClass => new List<EnumClasses>(new EnumClasses[] { EnumClasses.Mag });
        public string FullInfo => "Огненный шар, наносящий ожоги и увечья противнику";
        public void Use(BaseFighter fighter, BaseFighter enemy)
        {
            //TODO: Реализовать абилку для FireBall
            throw new NotImplementedException();
        }
    }
}
