using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character_Sheet
{
    class ClassImport
    {
        public BarbClass Barbarian
        {
            get;
            set;
        }
        public BardClass Bard
        {
            get;
            set;
        }
        public ClericClass Cleric
        {
            get;
            set;
        }
        public DruidClass Druid
        {
            get;
            set;
        }
        public FightClass Fighter
        {
            get;
            set;
        }
        public MonkClass Monk
        {
            get;
            set;
        }
        public PaladinClass Paladin
        {
            get;
            set;
        }
        public RangerClass Ranger
        {
            get;
            set;
        }
        public RogueClass Rogue
        {
            get;
            set;
        }
        public SorcClass Sorcerer
        {
            get;
            set;
        }
        public WarlockClass Warlock
        {
            get;
            set;
        }
        public WizardClass Wizard
        {
            get;
            set;
        }
        public class Feature
        {
            public string Name
            {
                get;
                set;
            }
            public string[] Description
            {
                get;
                set;
            }
        }
        public class FeatureTable
        {
            public string Title
            {
                get;
                set;
            }
            public string[] Headers
            {
                get;
                set;
            }
            public FeatureRow[] Rows
            {
                get;
                set;
            }
            public class FeatureRow
            {
                public int Level
                {
                    get;
                    set;
                }
                public string[] Features
                {
                    get;
                    set;
                }
            }

        }
        public class SubClass
        {
            public string Name
            {
                get;
                set;
            }
            public string[] Description
            {
                get;
                set;
            }
            public FeatureTable FeaturesTable
            {
                get;
                set;
            }
            public Feature[] SubClassFeatures
            {
                get;
                set;
            }

        }
        public class BarbClass
        {
            public BarbTable Table
            {
                get;
                set;
            }
            public Feature[] ClassFeatures
            {
                get;
                set;
            }
            public SubClass[] PrimalPaths
            {
                get;
                set;
            }
            public string[] Books
            {
                get;
                set;
            }
        }
        public class BarbTable
        {
            public string Title
            {
                get;
                set;
            }
            public string[] Headers
            {
                get;
                set;
            }
            public BarbRow[] Rows
            {
                get;
                set;
            }
            public class BarbRow
            {
                public int Level
                {
                    get;
                    set;
                }
                public int ProficiencyBonus
                {
                    get;
                    set;
                }
                public string[] Features
                {
                    get;
                    set;
                }
                public string Rages
                {
                    get;
                    set;
                }
                public int RageDamage
                {
                    get;
                    set;
                }
            }  
        }
        public class BardClass
        {
            public BardTable Table
            {
                get;
                set;
            }
            public Feature[] ClassFeatures
            {
                get;
                set;
            }
            public SubClass[] BardColleges
            {
                get;
                set;
            }
            public string[] Books
            {
                get;
                set;
            }
        }
        public class BardTable
        {
            public string Title
            {
                get;
                set;
            }
            public string[] Headers
            {
                get;
                set;
            }
            public BardRow[] Rows
            {
                get;
                set;
            }
            public class BardRow
            {
                public int Level
                {
                    get;
                    set;
                }
                public int ProficiencyBonus
                {
                    get;
                    set;
                }
                public string[] Features
                {
                    get;
                    set;
                }
                public int CantripsKnown
                {
                    get;
                    set;
                }
                public int SpellsKnown
                {
                    get;
                    set;
                }
                public int First
                {
                    get;
                    set;
                }
                public int Second
                {
                    get;
                    set;
                }
                public int Third
                {
                    get;
                    set;
                }
                public int Fourth
                {
                    get;
                    set;
                }
                public int Fifth
                {
                    get;
                    set;
                }
                public int Sixth
                {
                    get;
                    set;
                }
                public int Seventh
                {
                    get;
                    set;
                }
                public int Eighth
                {
                    get;
                    set;
                }
                public int Ninth
                {
                    get;
                    set;
                }
            }
        }
        public class ClericClass
        {
             public ClericTable Table
            {
                get;
                set;
            }
            public Feature[] ClassFeatures
            {
                get;
                set;
            }
            public SubClass[] DivineDomains
            {
                get;
                set;
            }
            public string[] Books
            {
                get;
                set;
            }
        }
        public class ClericTable
        {
            public string Title
            {
                get;
                set;
            }
            public string[] Headers
            {
                get;
                set;
            }
            public ClericRow[] Rows
            {
                get;
                set;
            }
            public class ClericRow
            {
                public int Level
                {
                    get;
                    set;
                }
                public int ProficiencyBonus
                {
                    get;
                    set;
                }
                public string[] Features
                {
                    get;
                    set;
                }
                public int CantripsKnown
                {
                    get;
                    set;
                }
                public int SpellsKnown
                {
                    get;
                    set;
                }
                public int First
                {
                    get;
                    set;
                }
                public int Second
                {
                    get;
                    set;
                }
                public int Third
                {
                    get;
                    set;
                }
                public int Fourth
                {
                    get;
                    set;
                }
                public int Fifth
                {
                    get;
                    set;
                }
                public int Sixth
                {
                    get;
                    set;
                }
                public int Seventh
                {
                    get;
                    set;
                }
                public int Eighth
                {
                    get;
                    set;
                }
                public int Ninth
                {
                    get;
                    set;
                }
            }
        }
        public class DruidClass
        {
            public DruidTable Table
            {
                get;
                set;
            }
            public Feature[] ClassFeatures
            {
                get;
                set;
            }
            public SubClass[] DruidCircles
            {
                get;
                set;
            }
            public string[] Books
            {
                get;
                set;
            }
        }
        public class DruidTable
        {
            public string Title
            {
                get;
                set;
            }
            public string[] Headers
            {
                get;
                set;
            }
            public DruidRow[] Rows
            {
                get;
                set;
            }
            public class DruidRow
            {
                public int Level
                {
                    get;
                    set;
                }
                public int ProficiencyBonus
                {
                    get;
                    set;
                }
                public string[] Features
                {
                    get;
                    set;
                }
                public int CantripsKnown
                {
                    get;
                    set;
                }
                public int SpellsKnown
                {
                    get;
                    set;
                }
                public int First
                {
                    get;
                    set;
                }
                public int Second
                {
                    get;
                    set;
                }
                public int Third
                {
                    get;
                    set;
                }
                public int Fourth
                {
                    get;
                    set;
                }
                public int Fifth
                {
                    get;
                    set;
                }
                public int Sixth
                {
                    get;
                    set;
                }
                public int Seventh
                {
                    get;
                    set;
                }
                public int Eighth
                {
                    get;
                    set;
                }
                public int Ninth
                {
                    get;
                    set;
                }
            }
        }
        public class FightClass
        {
            public FightTable Table
            {
                get;
                set;
            }
            public Feature[] ClassFeatures
            {
                get;
                set;
            }
            public SubClass[] MartialArchetypes
            {
                get;
                set;
            }
            public string[] Books
            {
                get;
                set;
            }

        }
        public class FightTable
        {
            public string Title
            {
                get;
                set;
            }
            public string[] Headers
            {
                get;
                set;
            }
            public FightRow[] Rows
            {
                get;
                set;
            }
            public class FightRow
            {
                public int Level
                {
                    get;
                    set;
                }
                public int ProficiencyBonus
                {
                    get;
                    set;
                }
                public string[] Features
                {
                    get;
                    set;
                }
            }
        }
        public class MonkClass
        {
            public MonkTable Table
            {
                get;
                set;
            }
            public Feature[] ClassFeatures
            {
                get;
                set;
            }
            public SubClass[] MonasticTraditions
            {
                get;
                set;
            }
            public string[] Books
            {
                get;
                set;
            }
        }
        public class MonkTable
        {
            public string Title
            {
                get;
                set;
            }
            public string[] Headers
            {
                get;
                set;
            }
            public MonkRow[] Rows
            {
                get;
                set;
            }
            public class MonkRow
            {
                public int Level
                {
                    get;
                    set;
                }
                public int ProficiencyBonus
                {
                    get;
                    set;
                }
                public string MartialArts
                {
                    get;
                    set;
                }
                public int KiPoints
                {
                    get;
                    set;
                }
                public int UnarmoredMovement
                {
                    get;
                    set;
                }
                public string[] Features
                {
                    get;
                    set;
                }
            }
        }
        public class PaladinClass
        {
            public PaladinTable Table
            {
                get;
                set;
            }
            public Feature[] ClassFeatures
            {
                get;
                set;
            }
            public SubClass[] SacredOaths
            {
                get;
                set;
            }
            public string[] Books
            {
                get;
                set;
            }
        }
        public class PaladinTable
        {
            public string Title
            {
                get;
                set;
            }
            public string[] Headers
            {
                get;
                set;
            }
            public PaladinRow[] Rows
            {
                get;
                set;
            }
            public class PaladinRow
            {
                public int Level
                {
                    get;
                    set;
                }
                public int ProficiencyBonus
                {
                    get;
                    set;
                }
                public string[] Features
                {
                    get;
                    set;
                }
                public int First
                {
                    get;
                    set;
                }
                public int Second
                {
                    get;
                    set;
                }
                public int Third
                {
                    get;
                    set;
                }
                public int Fourth
                {
                    get;
                    set;
                }
                public int Fifth
                {
                    get;
                    set;
                }

            }
        }
        public class RangerClass
        {
            public RangerTable Table
            {
                get;
                set;
            }
            public Feature[] ClassFeatures
            {
                get;
                set;
            }
            public SubClass[] RangerArchetypes
            {
                get;
                set;
            }
            public string[] Books
            {
                get;
                set;
            }
        }
        public class RangerTable
        {
            public string Title
            {
                get;
                set;
            }
            public string[] Headers
            {
                get;
                set;
            }
            public RangerRow[] Rows
            {
                get;
                set;
            }
            public class RangerRow
            {
                public int Level
                {
                    get;
                    set;
                }
                public int ProficiencyBonus
                {
                    get;
                    set;
                }
                public string[] Features
                {
                    get;
                    set;
                }
                public int SpellsKnown
                {
                    get;
                    set;
                }
                public int First
                {
                    get;
                    set;
                }
                public int Second
                {
                    get;
                    set;
                }
                public int Third
                {
                    get;
                    set;
                }
                public int Fourth
                {
                    get;
                    set;
                }
                public int Fifth
                {
                    get;
                    set;
                }

            }
        }
        public class RogueClass
        {
            public RogueTable Table
            {
                get;
                set;
            }
            public Feature[] ClassFeatures
            {
                get;
                set;
            }
            public SubClass[] RoguishArchetypes
            {
                get;
                set;
            }
            public string[] Books
            {
                get;
                set;
            }

        }
        public class RogueTable
        {
            public string Title
            {
                get;
                set;
            }
            public string[] Headers
            {
                get;
                set;
            }
            public RogueRow[] Rows
            {
                get;
                set;
            }
            public class RogueRow
            {
                public int Level
                {
                    get;
                    set;
                }
                public int ProficiencyBonus
                {
                    get;
                    set;
                }
                public string SneakAttack
                {
                    get;
                    set;
                }
                public string[] Features
                {
                    get;
                    set;
                }
            }
        }
        public class SorcClass
        {
            public SorcTable Table
            {
                get;
                set;
            }
            public Feature[] ClassFeatures
            {
                get;
                set;
            }
            public SubClass[] SorcerousOrigins
            {
                get;
                set;
            }
            public string[] Books
            {
                get;
                set;
            }
        }
        public class SorcTable
        {
            public string Title
            {
                get;
                set;
            }
            public string[] Headers
            {
                get;
                set;
            }
            public SorcRow[] Rows
            {
                get;
                set;
            }
            public class SorcRow
            {
                public int Level
                {
                    get;
                    set;
                }
                public int ProficiencyBonus
                {
                    get;
                    set;
                }
                public int SorceryPoints
                {
                    get;
                    set;
                }
                public string[] Features
                {
                    get;
                    set;
                }
                public int CantripsKnown
                {
                    get;
                    set;
                }
                public int SpellsKnown
                {
                    get;
                    set;
                }
                public int First
                {
                    get;
                    set;
                }
                public int Second
                {
                    get;
                    set;
                }
                public int Third
                {
                    get;
                    set;
                }
                public int Fourth
                {
                    get;
                    set;
                }
                public int Fifth
                {
                    get;
                    set;
                }
                public int Sixth
                {
                    get;
                    set;
                }
                public int Seventh
                {
                    get;
                    set;
                }
                public int Eighth
                {
                    get;
                    set;
                }
                public int Ninth
                {
                    get;
                    set;
                }
            }
        }
        public class WarlockClass
        {
            public WarlockTable Table
            {
                get;
                set;
            }
            public Feature[] ClassFeatures
            {
                get;
                set;
            }
            public SubClass[] OtherworldlyPatrons
            {
                get;
                set;
            }
            public string[] Books
            {
                get;
                set;
            }

        }
        public class WarlockTable
        {
            public string Title
            {
                get;
                set;
            }
            public string[] Headers
            {
                get;
                set;
            }
            public WarlockRow[] Rows
            {
                get;
                set;
            }
            public class WarlockRow
            {
                public int Level
                {
                    get;
                    set;
                }
                public int ProficiencyBonus
                {
                    get;
                    set;
                }
                public string[] Features
                {
                    get;
                    set;
                }
                public int CantripsKnown
                {
                    get;
                    set;
                }
                public int SpellsKnown
                {
                    get;
                    set;
                }
                public int SpellSlots
                {
                    get;
                    set;
                }
                public int SlotLevel
                {
                    get;
                    set;
                }
                public int InvocationsKnown
                {
                    get;
                    set;
                }
            }
        }
        public class WizardClass
        {
            public WizardTable Table
            {
                get;
                set;
            }
            public Feature[] ClassFeatures
            {
                get;
                set;
            }
            public SubClass[] ArcaneTraditions
            {
                get;
                set;
            }
            public string[] Books
            {
                get;
                set;
            }
        }
        public class WizardTable
        {
            public string Title
            {
                get;
                set;
            }
            public string[] Headers
            {
                get;
                set;
            }
            public WizardRow[] Rows
            {
                get;
                set;
            }
            public class WizardRow
            {
                public int Level
                {
                    get;
                    set;
                }
                public int ProficiencyBonus
                {
                    get;
                    set;
                }
                public string[] Features
                {
                    get;
                    set;
                }
                public int CantripsKnown
                {
                    get;
                    set;
                }
                public int First
                {
                    get;
                    set;
                }
                public int Second
                {
                    get;
                    set;
                }
                public int Third
                {
                    get;
                    set;
                }
                public int Fourth
                {
                    get;
                    set;
                }
                public int Fifth
                {
                    get;
                    set;
                }
                public int Sixth
                {
                    get;
                    set;
                }
                public int Seventh
                {
                    get;
                    set;
                }
                public int Eighth
                {
                    get;
                    set;
                }
                public int Ninth
                {
                    get;
                    set;
                }
            }
        }
    }
}
