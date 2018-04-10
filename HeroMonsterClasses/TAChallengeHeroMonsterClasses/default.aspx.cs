using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TAChallengeHeroMonsterClasses
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //  Characters
            Character hero = new Character();
            hero.Name = "Paladin";
            hero.MaxHealth = 20;
            hero.CurrentHealth = hero.MaxHealth;
            hero.DamageMaximum = 12;
            hero.AttackBonus = false;

            Character monster = new Character();
            monster.Name = "Orc";
            monster.MaxHealth = 25;
            monster.CurrentHealth = monster.MaxHealth;
            monster.DamageMaximum = 10;
            monster.AttackBonus = false;

            Dice heroDice = new Dice();
            heroDice.Sides = hero.DamageMaximum;

            Dice monsterDice = new Dice();
            monsterDice.Sides = monster.DamageMaximum;

            //  Battle
            statLabel.Text = "CHARACTER STATS:<br/><br/>" + hero.Stats() + monster.Stats();

            battle(hero, monster, heroDice, monsterDice);
            
        }

        private void battle(Character hero, Character monster, Dice heroDice, Dice monsterDice)
        {
            int roundNum = 1;
            while (hero.CurrentHealth > 0
                && monster.CurrentHealth > 0)
            {
                round(hero, monster, roundNum, heroDice, monsterDice);
                roundNum++;
            }
            endPrint(hero, monster);
        }

        private void endPrint(Character hero, Character monster)
        {
            string endString = "";
            if (hero.CurrentHealth > 0)
            {
                endString = String.Format(
                    "{0} bested {1} in battle!",
                    hero.Name, monster.Name);
            }
            else if (monster.CurrentHealth > 0)
            {
                endString = String.Format(
                    "{0} bested {1} in battle!",
                    monster.Name, hero.Name);
            }
            else
            {
                endString = String.Format(
                    "{0} killed {1} and died from his injuries.",
                    hero.Name, monster.Name);
            }

            resultLabel.Text += endString;
        }

        private void round(Character hero, Character monster, int roundNum, Dice heroDice, Dice monsterDice)
        {
            hero.AttackBonus = false;
            monster.AttackBonus = false;

            int heroDamage = 0;
            int rollValue = heroDice.roll();
            heroDamage = hero.Attack(rollValue);
            monster.Defend(heroDamage);

            int monsterDamage = 0;
            rollValue = monsterDice.roll();
            monsterDamage = monster.Attack(rollValue);
            hero.Defend(monsterDamage);

            roundPrint(hero, monster, heroDamage, monsterDamage, roundNum);
        }

        private void roundPrint(Character hero, Character monster, int heroDamage, int monsterDamage, int roundNum)
        {
            string heroBonus = "";

            if (hero.AttackBonus == true)
            {
                heroBonus = hero.Name + " attacked twice!!<br/>";
            }

            string monsterBonus = "";

            if (monster.AttackBonus == true)
            {
                monsterBonus = monster.Name + " attacked twice!!<br/>";
            }

            string heroMove = String.Format(
                "{0} inflicted {1} damage on {2}<br/>",
                hero.Name, heroDamage, monster.Name);

            string monsterMove = String.Format(
                "{0} inflicted {1} damage on {2}<br/>",
                monster.Name, monsterDamage, hero.Name);

            string characterStats = String.Format(
                "<strong>{0} Health: {1}<br/>"+
                "{2} Health: {3}<br/><br/></strong>",
                hero.Name, hero.CurrentHealth, monster.Name, monster.CurrentHealth);

            resultLabel.Text += "ROUND: " + roundNum + "<br/>" + heroBonus + heroMove + monsterBonus + monsterMove + characterStats;
        }
    }

    class Character
    {
        public string Name { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int DamageMaximum { get; set; }
        public bool AttackBonus { get; set; }

        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static int rnd(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }

        public int Attack(int rollValue)
        {
            int rollDamage = rollValue;
            int attackDamage = rollDamage;
            bonusAttackCheck();
            if (this.AttackBonus == true)
            {
                attackDamage = bonusAttack(attackDamage);
            }
            return attackDamage;
        }

        public void bonusAttackCheck()
        {
            int bonusCheck = rnd(1, 6);
            if (bonusCheck == 1) this.AttackBonus = true;
            
        }

        public int bonusAttack(int attackDamage)
        {
            int bonusAttackDamage = rnd(1, this.DamageMaximum);
            attackDamage += bonusAttackDamage;
            return attackDamage;
        }

        public void Defend(int attackDamage)
        {
            this.CurrentHealth = this.CurrentHealth - attackDamage;
        }

        public string Stats()
        {
            string stats = String.Format(
                "<strong>Character: {0}<br/>"+
                "Maximum Health: {1} hit points<br/>"+
                "Maximum Damage: {2}<br/><br/></strong>",
                this.Name, this.MaxHealth, this.DamageMaximum);
            return stats;
        }
    }

    class Dice
    {
        public int Sides { get; set; }

        //  generate random number
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static int rnd(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }

        public int roll()
        {
            int diceRoll = rnd(1, this.Sides);
            return diceRoll;
        }
    }
}