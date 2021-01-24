using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character_Sheet
{
    public class PlayerCharacter
    {
        public string CharacterName
        {
            get;
            set;
        }
        public string PlayerName
        {
            get;
            set;
        }
        public string Background
        {
            get;
            set;
        }
        public string Alignment
        {
            get;
            set;
        }
        public string Religion
        {
            get;
            set;
        }
        public int Experience
        {
            get;
            set;
        }
        public int Copper
        {
            get;
            set;
        }
        public int Silver
        {
            get;
            set;
        }
        public int Elisium
        {
            get;
            set;
        }
        public int Gold
        {
            get;
            set;
        }
        public int Platinum
        {
            get;
            set;
        }
        public List<KeyValuePair<int, int>> HitDice
        {
            get;
            set;
        }
        public StatBlock CharacterStats
        {
            get;
            set;
        }
        public List<PlayerClass> PlayerClassList
        {
            get;
            set;
        }
        public List<Feature> FeatsNtraits
        {
            get;
            set;
        }
        public List<Equipment> EquipmentList
        {
            get;
            set;

        }
        public List<Attack> AttackList
        {
            get;
            set;
        }
        public PlayerCharacter ()
        {
            CharacterName = "";
            PlayerName = "";
            Background = "";
            Alignment = "";
            Religion = "";
            Experience = 0;
            Copper = 0;
            Silver = 0;
            Elisium = 0;
            Gold = 0;
            Platinum = 0;
            HitDice = new List<KeyValuePair<int, int>>();
            CharacterStats = new StatBlock();
            PlayerClassList = new List<PlayerClass>();
            FeatsNtraits = new List<Feature>();
            EquipmentList = new List<Equipment>();
            AttackList = new List<Attack>();

        }
        public string SaveCharacter()
        {
            IECharacter newChar = new IECharacter();
            newChar.CharacterName = CharacterName;
            newChar.PlayerName = PlayerName;
            newChar.Background = Background;
            newChar.Alignment = Alignment;
            newChar.Religion = Religion;
            newChar.Experience = Experience;
            newChar.Copper = Copper;
            newChar.Silver = Silver;
            newChar.Elisium = Elisium;
            newChar.Gold = Gold;
            newChar.Platinum = Platinum;
            newChar.HitDice = HitDice;
            newChar.PlayerClassList = PlayerClassList;
            newChar.FeatsNtraits = FeatsNtraits;
            newChar.EquipmentList = EquipmentList;
            newChar.AttackList = AttackList;
            newChar.AllStats = CharacterStats.AllStats;
            newChar.Proficiencies = CharacterStats.Proficiencies;
            newChar.Speed = CharacterStats.Speed;
            newChar.Age = CharacterStats.Age;
            newChar.Height = CharacterStats.Height;
            newChar.Weight = CharacterStats.Weight;
            string json = JsonConvert.SerializeObject(newChar);
            return json;
        }
        public void LoadCharacter (string json)
        {
            IECharacter newChar = JsonConvert.DeserializeObject<IECharacter>(json);
            CharacterName = newChar.CharacterName;
            PlayerName = newChar.PlayerName;
            Background = newChar.Background;
            Alignment = newChar.Alignment;
            Religion = newChar.Religion;
            Experience = newChar.Experience;
            Copper = newChar.Copper;
            Silver = newChar.Silver;
            Elisium = newChar.Elisium;
            Gold = newChar.Gold;
            Platinum = newChar.Platinum;
            HitDice = newChar.HitDice;
            PlayerClassList = newChar.PlayerClassList;
            FeatsNtraits = newChar.FeatsNtraits;
            EquipmentList = newChar.EquipmentList;
            AttackList = newChar.AttackList;
            foreach(Stat pStat in CharacterStats.AllStats)
                foreach(Stat ieStat in newChar.AllStats)
                    if(pStat.Name.Equals(ieStat.Name))
                    {
                        pStat.StatBase = ieStat.StatBase;
                        break;
                    }
            CharacterStats.Proficiencies = newChar.Proficiencies;
            CharacterStats.Speed = newChar.Speed;
            CharacterStats.Age = newChar.Age;
            CharacterStats.Height = newChar.Height;
            CharacterStats.Weight = newChar.Weight;
        }
        public void newCharacter()
        {
            CharacterName = "";
            PlayerName = "";
            Background = "";
            Alignment = "";
            Religion = "";
            Experience = 0;
            Copper = 0;
            Silver = 0;
            Elisium = 0;
            Gold = 0;
            Platinum = 0;
            HitDice = new List<KeyValuePair<int, int>>();
            PlayerClassList = new List<PlayerClass>();
            FeatsNtraits = new List<Feature>();
            EquipmentList = new List<Equipment>();
            AttackList = new List<Attack>();
            foreach (Stat pStat in CharacterStats.AllStats)
                pStat.StatBase = 0;
            CharacterStats.Proficiencies = new List<Stat>();
            CharacterStats.Age = "";
            CharacterStats.Height = "";
            CharacterStats.Weight = "";
            CharacterStats.Speed = new List<Stat>();
        }

    }
    public class StatBlock
    {
        public List<Stat> AllStats
        {
            get;
            set;
        }

        public string Age
        {
            get;
            set;
        }
        public string Height
        {
            get;
            set;
        }
        public string Weight
        {
            get;
            set;
        }

        public CoreAttribute Strength
        {
            get;
            set;
        }
        public CoreAttribute Dexterity
        {
            get;
            set;
        }
        public CoreAttribute Constitution
        {
            get;
            set;
        }
        public CoreAttribute Intelligence
        {
            get;
            set;
        }
        public CoreAttribute Wisdom
        {
            get;
            set;
        }
        public CoreAttribute Charisma
        {
            get;
            set;
        }
        public List<CoreAttribute> CoreAttributes
        {
            get;
            set;
        }

        public Stat MaxHitPoints
        {
            get;
            set;
        }
        public int CurrentHitPoints
        {
            get;
            set;
        }
        public int TemporaryHitPoints
        {
            get;
            set;
        }

        public Stat Initiative
        {
            get;
            set;
        }
        public Stat ArmorClass
        {
            get;
            set;
        }
        public List<Stat> Speed
        {
            get;
            set;
        }
        public Stat PassivePerception
        {
            get;
            set;
        }

        public List<Stat> Vision
        {
            get;
            set;
        }
        public Stat Size
        {
            get;
            set;
        }

        public Stat ProficiencyBonus
        {
            get;
            set;
        }

        public Stat StrengthSave
        {
            get;
            set;
        }
        public Stat DexteritySave
        {
            get;
            set;
        }
        public Stat ConstitutionSave
        {
            get;
            set;
        }
        public Stat IntelligenceSave
        {
            get;
            set;
        }
        public Stat WisdomSave
        {
            get;
            set;
        }
        public Stat CharismaSave
        {
            get;
            set;
        }
        public List<Stat> Saves
        {
            get;
            set;
        }

        public Stat Acrobatics
        {
            get;
            set;
        }
        public Stat AnimalHandling
        {
            get;
            set;
        }
        public Stat Arcana
        {
            get;
            set;
        }
        public Stat Athletics
        {
            get;
            set;
        }
        public Stat Deception
        {
            get;
            set;
        }
        public Stat History
        {
            get;
            set;
        }
        public Stat Insight
        {
            get;
            set;
        }
        public Stat Intimidate
        {
            get;
            set;
        }
        public Stat Investigate
        {
            get;
            set;
        }
        public Stat Medicine
        {
            get;
            set;
        }
        public Stat Nature
        {
            get;
            set;
        }
        public Stat Perception
        {
            get;
            set;
        }
        public Stat Performance
        {
            get;
            set;
        }
        public Stat Persuasion
        {
            get;
            set;
        }
        public Stat Religion
        {
            get;
            set;
        }
        public Stat SleightOfHand
        {
            get;
            set;
        }
        public Stat Stealth
        {
            get;
            set;
        }
        public Stat Survival
        {
            get;
            set;
        }
        public List<Stat> Skills
        {
            get;
            set;
        }

        public List<Stat> Proficiencies
        {
            get;
            set;
        }

        public StatBlock()
        {
            AllStats = new List<Stat>();

            Age = "";
            Height = "";
            Weight = "";

            CoreAttributes = new List<CoreAttribute>();
            Strength = new CoreAttribute();
            Strength.Name = "Strength";
            Strength.Type = "Core";
            Strength.SubType = "Physical";
            CoreAttributes.Add(Strength);
            AllStats.Add(Strength);
            Dexterity = new CoreAttribute();
            Dexterity.Name = "Dexterity";
            Dexterity.Type = "Core";
            Dexterity.SubType = "Physical";
            CoreAttributes.Add(Dexterity);
            AllStats.Add(Dexterity);
            Constitution = new CoreAttribute();
            Constitution.Name = "Constitution";
            Constitution.Type = "Core";
            Constitution.SubType = "Physical";
            CoreAttributes.Add(Constitution);
            AllStats.Add(Constitution);
            Intelligence = new CoreAttribute();
            Intelligence.Name = "Intelligence";
            Intelligence.Type = "Core";
            Intelligence.SubType = "Mental";
            CoreAttributes.Add(Intelligence);
            AllStats.Add(Intelligence);
            Wisdom = new CoreAttribute();
            Wisdom.Name = "Wisdom";
            Wisdom.Type = "Core";
            Wisdom.SubType = "Mental";
            CoreAttributes.Add(Wisdom);
            AllStats.Add(Wisdom);
            Charisma = new CoreAttribute();
            Charisma.Name = "Charisma";
            Charisma.Type = "Core";
            Charisma.SubType = "Mental";
            CoreAttributes.Add(Charisma);
            AllStats.Add(Charisma);

            MaxHitPoints = new Stat();
            MaxHitPoints.Name = "Max Hit Points";
            MaxHitPoints.Type = "Base";
            AllStats.Add(MaxHitPoints);
            CurrentHitPoints = 0;
            TemporaryHitPoints = 0;

            Initiative = new Stat();
            Initiative.Name = "Initiative";
            Initiative.Type = "Base";
            AllStats.Add(Initiative);
            ArmorClass = new Stat();
            ArmorClass.Name = "Armor Class";
            ArmorClass.Type = "Base";
            AllStats.Add(ArmorClass);

            Speed = new List<Stat>();

            PassivePerception = new Stat();
            PassivePerception.Name = "Passive Perception";
            PassivePerception.Type = "Base";
            AllStats.Add(PassivePerception);

            Vision = new List<Stat>();
            Size = new Stat();
            Size.Name = "Size";
            Size.Type = "Base";
            AllStats.Add(Size);

            ProficiencyBonus = new Stat();
            ProficiencyBonus.Name = "Proficiency Bonus";
            ProficiencyBonus.Type = "Base";
            AllStats.Add(ProficiencyBonus);

            Saves = new List<Stat>();
            StrengthSave = new Stat();
            StrengthSave.Name = "Strength Save";
            StrengthSave.Type = "Save";
            StrengthSave.SubType = "Physical";
            Saves.Add(StrengthSave);
            AllStats.Add(StrengthSave);
            DexteritySave = new Stat();
            DexteritySave.Name = "Dexterity Save";
            DexteritySave.Type = "Save";
            DexteritySave.SubType = "Physical";
            Saves.Add(DexteritySave);
            AllStats.Add(DexteritySave);
            ConstitutionSave = new Stat();
            ConstitutionSave.Name = "Constitution Save";
            ConstitutionSave.Type = "Save";
            ConstitutionSave.SubType = "Physical";
            Saves.Add(ConstitutionSave);
            AllStats.Add(ConstitutionSave);
            IntelligenceSave = new Stat();
            IntelligenceSave.Name = "Intelligence Save";
            IntelligenceSave.Type = "Save";
            IntelligenceSave.SubType = "Mental";
            Saves.Add(IntelligenceSave);
            AllStats.Add(IntelligenceSave);
            WisdomSave = new Stat();
            WisdomSave.Name = "Wisdom Save";
            WisdomSave.Type = "Save";
            WisdomSave.SubType = "Mental";
            Saves.Add(WisdomSave);
            AllStats.Add(WisdomSave);
            CharismaSave = new Stat();
            CharismaSave.Name = "Charisma Save";
            CharismaSave.Type = "Save";
            CharismaSave.SubType = "Mental";
            Saves.Add(CharismaSave);
            AllStats.Add(CharismaSave);

            Skills = new List<Stat>();
            Acrobatics = new Stat();
            Acrobatics.Name = "Acrobatics";
            Acrobatics.Type = "Skill";
            Acrobatics.SubType = "Dexterity";
            Skills.Add(Acrobatics);
            AllStats.Add(Acrobatics);
            AnimalHandling = new Stat();
            AnimalHandling.Name = "Animal Handling";
            AnimalHandling.Type = "Skill";
            AnimalHandling.SubType = "Wisdom";
            Skills.Add(AnimalHandling);
            AllStats.Add(AnimalHandling);
            Arcana = new Stat();
            Arcana.Name = "Arcana";
            Arcana.Type = "Skill";
            Arcana.SubType = "Intelligence";
            Skills.Add(Arcana);
            AllStats.Add(Arcana);
            Athletics = new Stat();
            Athletics.Name = "Athletics";
            Athletics.Type = "Skill";
            Athletics.SubType = "Strength";
            Skills.Add(Athletics);
            AllStats.Add(Athletics);
            Deception = new Stat();
            Deception.Name = "Deception";
            Deception.Type = "Skill";
            Deception.SubType = "Charisma";
            Skills.Add(Deception);
            AllStats.Add(Deception);
            History = new Stat();
            History.Name = "History";
            History.Type = "Skill";
            History.SubType = "Intelligence";
            Skills.Add(History);
            AllStats.Add(History);
            Insight = new Stat();
            Insight.Name = "Insight";
            Insight.Type = "Skill";
            Insight.SubType = "Wisdom";
            Skills.Add(Insight);
            AllStats.Add(Insight);
            Investigate = new Stat();
            Investigate.Name = "Investigate";
            Investigate.Type = "Skill";
            Investigate.SubType = "Intelligence";
            Skills.Add(Investigate);
            AllStats.Add(Investigate);
            Medicine = new Stat();
            Medicine.Name = "Medicine";
            Medicine.Type = "Skill";
            Medicine.SubType = "Wisdom";
            Skills.Add(Medicine);
            AllStats.Add(Medicine);
            Nature = new Stat();
            Nature.Name = "Nature";
            Nature.Type = "Skill";
            Nature.SubType = "Intelligence";
            Skills.Add(Nature);
            AllStats.Add(Nature);
            Perception = new Stat();
            Perception.Name = "Perception";
            Perception.Type = "Skill";
            Perception.SubType = "Wisdom";
            Skills.Add(Perception);
            AllStats.Add(Perception);
            Performance = new Stat();
            Performance.Name = "Performance";
            Performance.Type = "Skill";
            Performance.SubType = "Charisma";
            Skills.Add(Performance);
            AllStats.Add(Performance);
            Persuasion = new Stat();
            Persuasion.Name = "Persuasion";
            Persuasion.Type = "Skill";
            Persuasion.SubType = "Charisma";
            Skills.Add(Persuasion);
            AllStats.Add(Persuasion);
            Religion = new Stat();
            Religion.Name = "Religion";
            Religion.Type = "Skill";
            Religion.SubType = "Intelligence";
            Skills.Add(Religion);
            AllStats.Add(Religion);
            SleightOfHand = new Stat();
            SleightOfHand.Name = "Sleight Of Hand";
            SleightOfHand.Type = "Skill";
            SleightOfHand.SubType = "Dexterity";
            Skills.Add(SleightOfHand);
            AllStats.Add(SleightOfHand);
            Stealth = new Stat();
            Stealth.Name = "Stealth";
            Stealth.Type = "Skill";
            Stealth.SubType = "Dexterity";
            Skills.Add(Stealth);
            AllStats.Add(Stealth);
            Survival = new Stat();
            Survival.Name = "Survival";
            Survival.Type = "Skill";
            Survival.SubType = "Wisdom";
            Skills.Add(Survival);
            AllStats.Add(Survival);

            Proficiencies = new List<Stat>();
        }
    }
    public class CoreAttribute : Stat
    {
        public int AbilityModifier
        {
            get;
            private set;
        }
        public int Calculate()
        {
            int retVal = base.Calculate();
            AbilityModifier = (Value - 10) / 2;
            if (Value < 10)
                if (Value % 2 > 0)
                    AbilityModifier = AbilityModifier - 1;
            return retVal;
        }
    }
    public class Stat
    {
        public string Name
        {
            get;
            set;
        }
        public string Type
        {
            get;
            set;
        }
        public string SubType
        {
            get;
            set;
        }
        public int StatBase
        {
            get;
            set;
        }
        public int Value
        {
            get;
            private set;
        }
        public int TotalModifier
        {
            get;
            private set;
        }
        public KeyValuePair<string, int> TempBase
        {
            get;
            set;
        }
        public List<KeyValuePair<string, int>> Modifiers
        {
            get;
            set;
        }
        public Stat()
        {
            Name = "";
            Type = "";
            SubType = "";
            StatBase = 0;
            TempBase = new KeyValuePair<string, int>("", 0);
            Modifiers = new List<KeyValuePair<string, int>>();
            TotalModifier = 0;
            Value = 0;
        }
        public int Calculate()
        {
            int calcbase = StatBase;
            TotalModifier = 0;
            if (!string.IsNullOrWhiteSpace(TempBase.Key))
                calcbase = TempBase.Value;
            foreach (KeyValuePair<string, int> modifier in Modifiers)
                TotalModifier += modifier.Value;
            Value = calcbase + TotalModifier;
            return Value;
        }
        public void Reset()
        {
            TempBase = new KeyValuePair<string, int>("", 0);
            Modifiers = new List<KeyValuePair<string, int>>();
            TotalModifier = 0;
            Value = 0;
        }
        public void AddModifiers(List<KeyValuePair<string, int>> newModifiers)
        {
            foreach (KeyValuePair<string, int> modifier in newModifiers)
                Modifiers.Add(new KeyValuePair<string, int>(modifier.Key, modifier.Value));
        }
        public void AddModifiers(KeyValuePair<string, int> newModifier)
        {
            Modifiers.Add(new KeyValuePair<string, int>(newModifier.Key, newModifier.Value));
        }
        public void AddModifiers(string source, int value)
        {
            Modifiers.Add(new KeyValuePair<string, int>(source, value));
        }
        public void SetTempBase(KeyValuePair<string, int> newBase)
        {
            TempBase = new KeyValuePair<string, int>(newBase.Key, newBase.Value);
        }
        public void SetTempBase(string source, int value)
        {
            TempBase = new KeyValuePair<string, int>(source, value);
        }
    }
    public class PlayerClass
    {
        public string Name
        {
            get;
            set;
        }
        public int Level
        {
            get;
            set;
        }
        public string SubClass
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
        public string[] Description
        {
            get;
            set;
        }
    }
    public class Equipment
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
    public class Attack
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
        public int BonusAttack
        {
            get;
            set;
        }
        public int BonusDamage
        {
            get;
            set;
        }
        public bool Proficient
        {
            get;
            set;
        }
        public CoreAttribute baseStat
        {
            get;
            set;
        }
        public List<string> DamageTypes
        {
            get;
            set;
        }
        public List<KeyValuePair<int,int>> DamageDice
        {
            get;
            set;
        }
    }
    public class IECharacter
    {
        public string CharacterName
        {
            get;
            set;
        }
        public string PlayerName
        {
            get;
            set;
        }
        public string Background
        {
            get;
            set;
        }
        public string Alignment
        {
            get;
            set;
        }
        public string Religion
        {
            get;
            set;
        }
        public int Experience
        {
            get;
            set;
        }
        public int Copper
        {
            get;
            set;
        }
        public int Silver
        {
            get;
            set;
        }
        public int Elisium
        {
            get;
            set;
        }
        public int Gold
        {
            get;
            set;
        }
        public int Platinum
        {
            get;
            set;
        }
        public List<KeyValuePair<int, int>> HitDice
        {
            get;
            set;
        }
        public List<PlayerClass> PlayerClassList
        {
            get;
            set;
        }
        public List<Feature> FeatsNtraits
        {
            get;
            set;
        }
        public List<Equipment> EquipmentList
        {
            get;
            set;

        }
        public List<Attack> AttackList
        {
            get;
            set;
        }
        public List<Stat> AllStats
        {
            get;
            set;
        }
        public List<Stat> Proficiencies
        {
            get;
            set;
        }
        public List<Stat> Speed
        {
            get;
            set;
        }
        public string Age
        {
            get;
            set;
        }
        public string Height
        {
            get;
            set;
        }
        public string Weight
        {
            get;
            set;
        }
    }
    public class Spell
    {
        public string Name
        {
            get;
            set;
        }
        public string School
        {
            get;
            set;
        }
        public bool Cantrip
        {
            get;
            set;
        }
        public bool Ritual
        {
            get;
            set;
        }
        public int Level
        {
            get;
            set;
        }
        public string CastingTime
        {
            get;
            set;
        }
        public string Range
        {
            get;
            set;
        }
        public string Components
        {
            get;
            set;
        }
        public string Duration
        {
            get;
            set;
        }
        public string[] Description
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
        public CasterType Classes
        {
            get;
            set;
        }
    }
    public class CasterType
    {
        public bool Bard
        {
            get;
            set;
        }
        public bool Cleric
        {
            get;
            set;
        }
        public bool Druid
        {
            get;
            set;
        }
        public bool Paladin
        {
            get;
            set;
        }
        public bool Ranger
        {
            get;
            set;
        }
        public bool Sorcerer
        {
            get;
            set;
        }
        public bool Warlock
        {
            get;
            set;
        }
        public bool Wizard
        {
            get;
            set;
        }
    }
}
