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
        /// <value>Значение string</value>
        string Name { get; }

        /// <summary>
        /// Описание эффекта
        /// </summary>
        /// <value>Значение string</value>
        string FullName { get; }
        
        /// <summary>
        /// Эффект используется при атаке или защите
        /// True = Атака
        /// False = Защита
        /// </summary>
        /// <value>Значение bool</value>
        bool IsAttackOrDeffence { get; }

        /// <summary>
        /// Эффект является ли Негативным?
        /// True = Является
        /// False = Не является
        /// </summary>
        /// <value>Значение bool</value>
        bool IsNegative { get; }

        /// <summary>
        /// Колливество использований эффекта
        /// </summary>
        /// <value>Значение sbyte</value>
        sbyte Ticks { get; set; }

        /// <summary>
        /// Действие эффекта
        /// </summary>
        /// <param name="fighter">Боец</param>
        /// <param name="dmg">Урон</param>
        /// <returns>Урон</returns>
        int Run(BaseFighter fighter, int dmg);
    }
}
