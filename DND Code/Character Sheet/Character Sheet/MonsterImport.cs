using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character_Sheet
{
    class MonsterImport
    {
        public string Size
        {
            get;
            set;
        }
        public string Type
        {
            get;
            set;
        }
        public string Subtype
        {
            get;
            set;
        }
        public string Alignment
        {
            get;
            set;
        }
        public int ArmorClass
        {
            get;
            set;
        }
        public string HitDice
        {
            get;
            set;
        }
        public Movement Speed
        {
            get;
            set;
        }
        public StatBlock AbilityScores
        {
            get;
            set;
        }
        public Saves SavingThrows
        {
            get;
            set;
        }
        public SkillBlock Skills
        {
            get;
            set;
        }
        public string[] DamageVulnerabilities
        {
            get;
            set;
        }
        public string[] DamageResistances
        {
            get;
            set;
        }
        public string[] DamageImmunities
        {
            get;
            set;
        }
        public string[] ConditionImmunities
        {
            get;
            set;
        }
        public SenseTypes Senses
        {
            get;
            set;
        }
        public string[] Languages
        {
            get;
            set;
        }
        public string Challenge
        {
            get;
            set;
        }
        public int Experience
        {
            get;
            set;
        }
        public Feature[] Features
        {
            get;
            set;
        }
        public Feature[] Actions
        {
            get;
            set;
        }
        public string Book
        {
            get;
            set;
        }
        public int Page
        {
            get;
            set;
        }
        public class Movement
        {
            public int Walk
            {
                get;
                set;
            }
            public int Burrow
            {
                get;
                set;
            }
            public int Climb
            {
                get;
                set;
            }
            public int Fly
            {
                get;
                set;
            }
            public int Swim
            {
                get;
                set;
            }
            public bool Hover
            {
                get;
                set;
            }
        }
        public class StatBlock
        {
            public int Strength
            {
                get;
                set;
            }
            public int Dexterity
            {
                get;
                set;
            }
            public int Constitution
            {
                get;
                set;
            }
            public int Intelligence
            {
                get;
                set;
            }
            public int Wisdom
            {
                get;
                set;
            }
            public int Charisma
            {
                get;
                set;
            }
        }
        public class Saves
        {
            public bool Strength
            {
                get;
                set;
            }
            public bool Dexterity
            {
                get;
                set;
            }
            public bool Constitution
            {
                get;
                set;
            }
            public bool Intelligence
            {
                get;
                set;
            }
            public bool Wisdom
            {
                get;
                set;
            }
            public bool Charisma
            {
                get;
                set;
            }
        }
        public class SkillBlock
        {
            public bool Acrobatics
            {
                get;
                set;
            }
            public bool AnimalHandling
            {
                get;
                set;
            }
            public bool Arcana
            {
                get;
                set;
            }
            public bool Athletics
            {
                get;
                set;
            }
            public bool Deception
            {
                get;
                set;
            }
            public bool History
            {
                get;
                set;
            }
            public bool Insight
            {
                get;
                set;
            }
            public bool Intimidation
            {
                get;
                set;
            }
            public bool Investigation
            {
                get;
                set;
            }
            public bool Medicine
            {
                get;
                set;
            }
            public bool Nature
            {
                get;
                set;
            }
            public bool Perception
            {
                get;
                set;
            }
            public bool Persuasion
            {
                get;
                set;
            }
            public bool Religion
            {
                get;
                set;
            }
            public bool SleightOfHand
            {
                get;
                set;
            }
            public bool Stealth
            {
                get;
                set;
            }
            public bool Survival
            {
                get;
                set;
            }
        }
        public class SenseTypes
        {
            public int Blindsight
            {
                get;
                set;
            }
            public int Darkvision
            {
                get;
                set;
            }
            public int Tremorsense
            {
                get;
                set;
            }
            public int Truesight
            {
                get;
                set;
            }
            public bool Blind
            {
                get;
                set;
            }
        }
        public class Feature
        {
            public string Name
            {
                get;
                set;
            }
            public string Description
            {
                get;
                set;
            }
        }
    }
}
