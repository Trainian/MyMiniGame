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
        bool IsActiveOrPassive { get;  }
        /// <summary>
        /// Тики, сколько длится действие, в ходах
        /// -1 - Постоянно, 0+ - Длится опередлённое кол-во ходов
        /// </summary>
        sbyte Ticks { get; set; }
        /// <summary>
        /// Установить/Обновить эффект и кол-во Тиков
        /// </summary>
        public void SetTicks();
        /// <summary>
        /// Действие эффекта
        /// </summary>
        int Run(int dmg);
    }
}
