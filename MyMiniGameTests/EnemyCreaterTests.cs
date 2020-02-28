using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMiniGame;
using MyMiniGame.Fighters.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using MyMiniGame.Fighters.Enemys;

namespace MyMiniGame.Tests
{
    [TestClass()]
    public class EnemyCreaterTests
    {
        [TestMethod()]
        public void CreateEnemy_NewFighter_NotNull()
        {
            BaseFighter fighter = EnemyCreater.CreateEnemy(1);

            Assert.IsNotNull(fighter);
        }
    }
}