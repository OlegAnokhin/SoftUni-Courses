namespace FightingArena.Tests
{
    using System;
    using NUnit.Framework;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void TestIfConstructorWorcsCorrectly()
        {
            string expectedName = "Pesho";
            int expectedDamage = 55;
            int expectedHp = 55;

            Warrior warrior = new Warrior(expectedName, expectedDamage, expectedHp);
            FieldInfo nameField = GetField("name");
            string actualName = (string)nameField.GetValue(warrior);
            FieldInfo damageField = GetField("damage");
            int actualDamage = (int)damageField.GetValue(warrior);
            FieldInfo hpField = GetField("hp");
            int acttualHp = (int)hpField.GetValue(warrior);
            Assert.AreEqual(expectedName, actualName,
                "Constructor should initialize the Name of the Warrior!");
            Assert.AreEqual(expectedDamage, actualDamage,
                "Constructor should initialize the Damage of the Warrior!");
            Assert.AreEqual(expectedHp, acttualHp,
                "Constructor should initialize the HP of the Warrior!");
        }
        [Test]
        public void TestNameGetter()
        {
            string expectedName = "Pesho";
            int expectedDamage = 55;
            int expectedHp = 55;
            Warrior warrior = new Warrior(expectedName, expectedDamage, expectedHp);
            string actualName = warrior.Name;
            Assert.AreEqual(expectedName, actualName,
                "Getter og the property Name should retur the value of name!");
        }
        [TestCase(null)]
        [TestCase("")]
        [TestCase("      ")]
        public void TestNameSetterValidation(string name)
        {

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, 55, 55);
            }, "Name should not be empty or whitespace!");
        }
        [Test]
        public void TestDamegeGetter()
        {
            int expectedDamage = 55;
            Warrior warrior = new Warrior("Pesho", expectedDamage, 55);
            int actualDamage = warrior.Damage;
            Assert.AreEqual(expectedDamage, actualDamage,
                "Getter og the property Damage should retur the value of damage!");
        }
        [TestCase(-5)]
        [TestCase(-1)]
        [TestCase(0)]
        public void TestDamageSetterValidation(int damage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", damage, 55);
            }, "Damage value should be positive!");
        }
        [Test]
        public void TestHPGetter()
        {
            int expectedHp = 55;
            Warrior warrior = new Warrior("Pesho", 33, expectedHp);
            int actualHp = warrior.HP;
            Assert.AreEqual(expectedHp, actualHp,
                "Getter of the property HP should return the value of the Hp!");
        }
        [TestCase(-5)]
        [TestCase(-1)]
        public void TestHPSetterValidation(int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", 55, hp);
            }, "HP should not be negative!");
        }
        [TestCase(0)]
        [TestCase(10)]
        [TestCase(25)]
        [TestCase(30)]
        public void AttackShouldThrowErrorWhenAttackingWarriorIsLow(int startHP)
        {
            Warrior warrior_att = new Warrior("Pesho", 70, startHP);
            Warrior warrior_def = new Warrior("Gosho", 55, 45);
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior_att.Attack(warrior_def);
            }, "Your HP is too low in order to attack other warriors!");
        }
        [TestCase(0)]
        [TestCase(10)]
        [TestCase(25)]
        [TestCase(30)]
        public void AttackShouldThrowErrorWhenDefendingWarriorIsLow(int startHP)
        {
            Warrior warrior_att = new Warrior("Pesho", 45, 65);
            Warrior warrior_def = new Warrior("Gosho", 35, startHP);
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior_att.Attack(warrior_def);
            }, "Enemy HP must be greater than 30 in order to attack him!");
        }
        [TestCase(50,60)]
        [TestCase(50,51)]
        public void AttackShouldThrowErrorWhenDefendingWarriorIsStronger(int attackerHp, int defenderDamage)
        {
            Warrior warrior_att = new Warrior("Pesho", 50, attackerHp);
            Warrior warrior_def = new Warrior("Gosho", defenderDamage, 50);
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior_att.Attack(warrior_def);
            }, "You are trying to attack too strong enemy");
        }
        [TestCase(70,50)]
        [TestCase(60,55)]
        [TestCase(60,60)]
        public void SucsessAttackShouldDecreaseHp(int attackerHp, int defenderDamage)
        {
            Warrior warrior_att = new Warrior("Pesho", 50, attackerHp);
            Warrior warrior_def = new Warrior("Gosho", defenderDamage, 55);
            warrior_att.Attack(warrior_def);
            int actualHp = warrior_att.HP;
            int expectedHp = attackerHp - defenderDamage;
            Assert.AreEqual(expectedHp, actualHp,
                "Successful attack should decrease attacker HP!");
        }
        [TestCase(70,40)]
        [TestCase(60,55)]
        [TestCase(60,59)]
        public void SuccessAttackShoudKillEnemyIfMyDamageIsOverTherHp(int attackerDamage, int defenderHp)
        {
            Warrior warrior_att = new Warrior("Pesho", attackerDamage, 100);
            Warrior warrior_def = new Warrior("Gosho", 40, defenderHp);
            warrior_att.Attack(warrior_def);
            int actualDefenderHp = warrior_def.HP;
            int expectedDefenderHp = 0;
            Assert.AreEqual(expectedDefenderHp, actualDefenderHp,
                "Attacking enemy with lower HP than attacker Damage should leave them with zero HP!");
        }
        [TestCase(50, 100)]
        [TestCase(50, 60)]
        [TestCase(50, 51)]
        [TestCase(50, 50)]
        public void SuccessAttackShoudDecreaseEnemyHPIfWeDoNotKillThem(int attackerDamage, int defenderHp)
        {
            Warrior warrior_att = new Warrior("Pesho", attackerDamage, 100);
            Warrior warrior_def = new Warrior("Gosho", 30, defenderHp);
            warrior_att.Attack(warrior_def);
            int actualDefenderHp = warrior_def.HP;
            int expectedDefenderHp = defenderHp - attackerDamage;
            Assert.AreEqual(expectedDefenderHp, actualDefenderHp,
                "Attacking enemy with higher HP than attacker Damage should leave them with corract HP value!");
        }
        private FieldInfo GetField(string fieldName)
            => typeof(Warrior)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.Name == fieldName);
    }
}