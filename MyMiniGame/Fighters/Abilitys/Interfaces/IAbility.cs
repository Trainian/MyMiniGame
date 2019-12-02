using System;
using System.Collections.Generic;
using System.Text;

namespace MyMiniGame.Fighters.Abilitys.Interfaces
{
    //TODO: Добавить возможность реализации Абилки несколькими Классами
    public interface IAbility
    {
        public Classes IdClass { get; }
        public string FullInfo { get; }
        void Use(BaseFighter fighter, BaseFighter enemy);
    }
}
