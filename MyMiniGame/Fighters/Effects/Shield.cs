using MyMiniGame.Fighters.Effects.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyMiniGame.Fighters.Effects
{
    class Shield : IEffect
    {
        public string Name => "Магический Щит";
        public string FullName => "Магический щит, которой даёт небольшую защиту";
        public sbyte Ticks { get; set; } = -1;
        public void Run(BaseFighter fighter)
        {
            throw new NotImplementedException();
        }
    }
}
