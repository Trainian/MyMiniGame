using System;
using System.Collections.Generic;
using System.Text;

namespace MyMiniGame.Fighters.Abilitys.Interfaces
{
    public interface IAbility
    {
        public List<EnumClasses> IdClass { get; }
        public string FullInfo { get; }
        void Use(BaseFighter fighter, BaseFighter enemy);
    }
}
