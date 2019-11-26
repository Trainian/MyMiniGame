using System;
using System.Collections.Generic;
using System.Text;

namespace MyMiniGame.Fighters.Abilitys.Interfaces
{
    public interface IAbility
    {
        public string Name { get; }
        public string FullInfo { get; }
        void Use(BaseFighter fighter, BaseFighter enemy);
    }
}
