using MyMiniGame.Fighters.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMiniGame.Fighters.Abilitys.Interfaces
{
    public interface IAbility
    {
        List<EnumClasses> IdClass { get; }
        string FullInfo { get; }
        void Use(BaseFighter fighter, BaseFighter enemy);
    }
}
