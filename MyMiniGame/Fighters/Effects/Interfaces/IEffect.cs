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
        string Name { get; }
        /// <summary>
        /// Описание эффекта
        /// </summary>
        string FullName { get; }
        /// <summary>
        /// Эффект является атакующим или защитным
        /// True = Атакующий
        /// False = Защитный
        /// </summary>
        bool IsAttackOrDeffence { get; }
        /// <summary>
        /// Эффект имеет значение как позитивный или негативный
        /// True = Позитивный
        /// False = Негативный
        /// </summary>
        bool IsPositiveOrNegative { get; }
        /// <summary>
        /// Эффект является активным или пассивынм
        /// True = Активный
        /// False = Пассивный
        /// </summary>
        bool IsActiveOrPassive { get; }
        /// <summary>
        /// Тики, сколько длится действие, в ходах
        /// </summary>
        sbyte Ticks { get; set; }
        /// <summary>
        /// Действие эффекта
        /// </summary>
        int Run(BaseFighter fighter, int dmg);
    }
}
