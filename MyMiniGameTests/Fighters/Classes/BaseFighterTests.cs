using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMiniGame.Fighters.Classes;
using MyMiniGame.Fighters.Effects;
using MyMiniGame.Fighters.Effects.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMiniGame.Fighters.Classes.Tests
{
    [TestClass]
    public class BaseFighterTests
    {
        BaseFighter fighter, fighterTest;
        [TestInitialize]
        public void Setup ()
        {
            fighter = new Thief("Class");
            fighterTest = new Thief("TestClass");
        }

        [TestMethod]
        public void Effects_ReNewEffect_OneEffect()
        {
            fighter.AddEffect(new Bleeding());
            fighterTest.AddEffect(new Bleeding());

            fighterTest.Ability.Use(fighterTest,fighter);
            fighterTest.AddEffect(new Bleeding());

            Assert.AreEqual(fighter.GetEffects().Count, fighter.GetEffects().Count);
            Assert.AreEqual(fighter.GetEffects()[0].FullName, fighterTest.GetEffects()[0].FullName);
            Assert.AreEqual(fighter.GetEffects()[0].Ticks, fighterTest.GetEffects()[0].Ticks);
        }
    }
}