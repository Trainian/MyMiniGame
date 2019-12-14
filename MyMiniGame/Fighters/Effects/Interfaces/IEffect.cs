using MyMiniGame.Fighters.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMiniGame.Fighters.Effects.Interfaces
{
    public interface IEffect
    {
        /// <summary>
        /// Название эффекта
        /// </summary>
        string Name { get;}
        /// <summary>
        /// Описание эффекта
        /// </summary>
        string FullName { get;}
        /// <summary>
        /// Эффект имеет значение как позитивный или негативный
        /// True = Позитивный
        /// False = Негативный
        /// </summary>
        public bool IsPositive { get; }
        /// <summary>
        /// Тики, сколько длится действие, в ходах
        /// -1 - Постоянно, 0+ - Длится опередлённое кол-во ходов
        /// </summary>
        sbyte Ticks { get; set; }
        /// <summary>
        /// Действие эффекта
        /// </summary>
        int Run(BaseFighter fighter);
    }
}
