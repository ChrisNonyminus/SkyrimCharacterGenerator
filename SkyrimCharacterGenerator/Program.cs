using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Application
{

    public class Character
    {
        public enum CharacterGender
        {
            Male, Female
        }
        public enum CharacterRace
        {
            Argonian, Breton, Dunmer, Altmer, Imperial, Khajiit, Nord, Orc, Redguard, Bosmer
        }
        public enum DynamicStat
        {
            Health,Stamina,Magicka
        }
        public enum Specialization
        {
            Combat,Magic,Stealth
        }
        public enum Skill
        {
            Archery,Block,HeavyArmor,OneHanded,Smithing,TwoHanded, // combat
            Alteration,Conjuration,Destruction,Enchanting,Illusion,Restoration, // magic
            Alchemy,LightArmor,Lockpicking,Pickpocket,Sneak,Speech // stealth
        }
        public enum StandingStone // aka "Signs"
        {
            TheApprentice,
            TheAtronach,
            TheLady,
            TheLord,
            TheLover,
            TheMage,
            TheSteed,
            TheThief,
            TheWarrior,
            TheTower,
            TheShadow,
            TheRitual,
            TheSerpent
        }
        public enum Faction
        {
            Folk, // the regular villagers throughout Skyrim
            Stormcloaks,
            Imperials,
            Thalmor,
            Forsworn,
            Bandits,
            Warlocks,
            Orcs,
            Dawnguard,
            VolkiharVampires,
            Dwemer,
            Falmer,
            Giants,
            College
        }
        public enum Reputation
        {
            Vilified,
            Shunned,
            Neutral,
            Liked,
            Loved
        }

        public static Dictionary<Faction, Faction[]> FactionsEachFactionHates = new Dictionary<Faction, Faction[]>();

        public CharacterGender Gender;
        public CharacterRace Race;

        public struct CCO
        {
            public bool IsClassCustom;
            public enum CharacterClass
            {
                Archer,Barbarian,Crusader,Knight,Rogue,Scout,Warrior,Battlemage,Healer,Mage,Nightblade,Sorcerer,Spellsword,Witchhunter,Acrobat,Agent,Assassin,Bard,Monk,Pilgrim,Thief
            }
            public CharacterClass PresetClass;
            public struct CustomCharacterClass
            {
                public Specialization Specialization;
                public DynamicStat PrimaryAttribute;
                public Skill[] FocusedSkills; // up to 5
            }
            public CustomCharacterClass CustomClass;
            public StandingStone Sign;
        }
        public CCO CCOStats;
        public struct Lorkhan
        {
            public enum CharacterClass
            {
                Archer, Barbarian, Crusader, Knight, Rogue, Scout, Warrior, Battlemage, Healer, Mage, Nightblade, Sorcerer, Spellsword, Witchhunter, Acrobat, Agent, Assassin, Bard, Monk, Pilgrim, Thief
            }
            public CharacterClass[] Classes; // can take any, as long as there are enough perk shards (gaining a curse can give a perk shard)
            public int PerkShards;
            public enum Curse
            {
                Clumsy,Commoner,DesperateStrikes,Frail,Generous,Lisp,Moralist,Mundane,OpenPalm,Scorned,SunAttuned,Unlucky
            }
            public Curse[] Curses;
            public StandingStone Sign;
            public enum Gem
            {
                NightgateInn,ShorsStone,Solitude,BlackReach,CollegeOfWinterhold,RiftenForest,FalkreathForest,CyrodilBorder,Morthal,WreckOfTheBrineHammer,Riverwood,Ragnfvald,HallOfTheVigilant,HighHrothgar,MorKhazgur,Whiterun,FortDawnguard,SacellumOfBoethia,FortHraggstadPrison,WindhelmDocks,RedDawn,ReachStormcloakCamp,RiftImperialCamp,CrackedTuskKeep,KnifepointMine,BrokenLimbCamp,Kagrenzel,Ivarstead,DeepwoodVale,MeekosShack,Stonehills,RannveigsFast,WinkingSkeever,MovarthsLair
            }
            public Gem StartingLocation;
        }
        public Lorkhan LorkhanStats;
        public Dictionary<Faction, Reputation> DefaultReputations;
        public struct DealingWithBackstories
        {
            public StandingStone Sign;
            public enum ParentsFinancialStatus
            {
                SociallyInvisible,
                WorkingClass,
                MiddleClass,
                UpperClass
            }
            public ParentsFinancialStatus FinancialStatus;
            public enum SiblingsModifiers
            {
                OnlyChild,
                PartnerInCrime,
                RuntOfTheLitter
            }
            public SiblingsModifiers Siblings;
            public enum ChildhoodModifiers
            {
                Stickball,
                HideAndSeek,
                PlayingPretend,
                Swordfighting,
                PlayingHouse,
                PlayingWithFire,
                DressingUp,
                BuildingModels,
                Pranking,
                Sewing,
                BeingBullied,
                Bullying
            }
            public List<ChildhoodModifiers> Childhood; // pick 3
            public enum TalentType
            {
                GirlsOrBoys,
                TheOutdoors,
                Brawling,
                Acquisition,
                Cooking,
                Sculpting,
                TheForbidden,
                Reading,
                Fashion
            }
            public List<TalentType> Adolescence; // pick 3
            public enum CareerModifiers
            {
                Alchemist,
                Antimage,
                Artificer,
                Axeman,
                Bard,
                Bartender,
                Battlemage,
                Berzerker,
                BigGameHunter,
                Blacksmith,
                Bloodmage,
                BountyHunter,
                CodeOfMalacath,
                CorruptedScholar,
                CourtWizard,
                Cultist,
                Darkling,
                DeathKnight,
                FleshCultist,
                Gravelord,
                Healer,
                Heartbreaker,
                Infiltrator,
                Labourer,
                Necromancer,
                Nightblade,
                OrderKnight,
                PettyThief,
                Poisoner,
                Priest,
                Shaman,
                Soldier,
                TravellingPerformer,
                TreasureHunter,
                Warlock,
                Witch,
                Woodsman
            }
            public List<CareerModifiers> PastCareers; // pick 0-3
            public enum AgeModifier
            {
                ComingOfAge, // start at 1
                Adulthood, // start at level 8-12
                MiddleAge, // start at level 13-19
                OldAge, // start at level 18-23
            }
            public AgeModifier Age;
            public enum ParentsJobModifier
            {
                Orphan,Destitutes, // if socially invisible
                Miners,Farmers, // if working class
                Merchants,Artisans, // if middle class
                Priests,Nobles, // if upper class
            }
            public ParentsJobModifier ParentsJob; // must pick 1
            public enum GeneticsType
            {
                Appearance,
                Height,
                MagicalPotential,
                Endurance,
                Fortitude,
                Intelligence,
            }
            public enum QualityType
            {
                Good, Average, Bad
            }

            public Dictionary<GeneticsType, QualityType> Genetics; // must pick 6
            public enum ViceType
            {
                Gambling,SubstanceAbuse,Crime,Sadism,Unprofessional,Adultery, NoneYet
            }
            public ViceType Vice; // N/A if coming of age
            public TalentType Talent; // must pick 1
            public enum FateType
            {
                Injury,
                Illness,
                Cursed,
                HeadTrauma,
                JobShortage,
                EconomicTurmoil,
                Housefire,
                Lycanthropy,
                Undeath
            }
            public List<FateType> Fates; // 0-4 depending on age
            public enum AspirationType
            {
                Family,Career,Piety,Health,Leisure,Wealth
            }
            public List<AspirationType> Focuses; // 0-2
            public List<AspirationType> Neglects; // 0-2
            public enum DesireType
            {
                Wealth,Love,MagicPower,Fame,Immortality,Revenge,RecoverThePast,Adventure,ForbiddenKnowledge,VictoryInBattle
            }
            public List<DesireType> Desires; // must pick 4
        }
        public DealingWithBackstories DWBStats;

        [Serializable]
        public struct Template
        {
            [JsonInclude]
            public CharacterGender Gender;
            [JsonInclude]
            public CharacterRace Race;
            [JsonInclude]
            public Dictionary<Faction, Reputation> DefaultReputations;
        }

        [Serializable]
        public struct Options // what mods to use
        {
            [JsonInclude]
            public bool UsingCCO; // Character Creation Overhaul
            [JsonInclude]
            public bool UsingLorkhan; // Realm of Lorkhan
            [JsonInclude]
            public bool UsingFactionReps; // Faction reputation mods (like Faction Warfare)
            [JsonInclude]
            public bool UsingDWB; // Dealing with Backstories
            [JsonInclude]
            public bool UseTemplate;
            [JsonInclude]
            public Template Template;
        }

        public static Character Generate(Character.Options options)
        {
            FactionsEachFactionHates[Faction.Folk] = new Faction[] { Faction.Forsworn, Faction.Bandits, Faction.Warlocks, Faction.Giants };
            FactionsEachFactionHates[Faction.Bandits] = new Faction[] { Faction.Folk, Faction.Stormcloaks, Faction.Imperials, Faction.Thalmor, Faction.Giants };
            FactionsEachFactionHates[Faction.Forsworn] = new Faction[] { Faction.Folk, Faction.Stormcloaks, Faction.Giants };
            FactionsEachFactionHates[Faction.Stormcloaks] = new Faction[] {Faction.Imperials, Faction.Thalmor, Faction.Bandits, Faction.Warlocks, Faction.Giants };
            FactionsEachFactionHates[Faction.Imperials] = new Faction[] { Faction.Stormcloaks, Faction.Orcs, Faction.Bandits, Faction.Warlocks, Faction.Giants };
            FactionsEachFactionHates[Faction.Thalmor] = new Faction[] { Faction.Stormcloaks, Faction.Orcs, Faction.Bandits, Faction.Warlocks, Faction.Giants };
            FactionsEachFactionHates[Faction.Dawnguard] = new Faction[] { Faction.VolkiharVampires, Faction.Giants };
            FactionsEachFactionHates[Faction.VolkiharVampires] = new Faction[] { Faction.Dawnguard, Faction.Giants };
            FactionsEachFactionHates[Faction.Orcs] = new Faction[] { Faction.Thalmor, Faction.Imperials };
            FactionsEachFactionHates[Faction.Falmer] = new Faction[] { Faction.Dwemer, Faction.Folk };
            FactionsEachFactionHates[Faction.Dwemer] = new Faction[] { Faction.Falmer };
            FactionsEachFactionHates[Faction.Warlocks] = new Faction[] { Faction.Folk, Faction.Stormcloaks, Faction.Imperials, Faction.College, Faction.Giants };
            FactionsEachFactionHates[Faction.College] = new Faction[] { Faction.Warlocks, Faction.Giants };
            FactionsEachFactionHates[Faction.Giants] = new Faction[] { Faction.Folk, Faction.Bandits, Faction.Forsworn, Faction.Imperials, Faction.Thalmor, Faction.Dawnguard, Faction.VolkiharVampires, Faction.Thalmor, Faction.Warlocks, Faction.College };
            Character character = new Character();
            Random random = new Random(new Random().Next());

            // randomize the gender
            if (options.UseTemplate)
            {
                character.Gender = options.Template.Gender;
                character.Race = options.Template.Race;
                character.DefaultReputations = options.Template.DefaultReputations;
            }
            else
            {
                character.Gender = (CharacterGender)random.Next(2);
                character.Race = (CharacterRace)random.Next(10);
                character.DefaultReputations = new Dictionary<Faction, Reputation>();
            }

            if (options.UsingCCO)
            {
                character.CCOStats.Sign = (StandingStone)random.Next(13);
                character.CCOStats.PresetClass = (CCO.CharacterClass)random.Next(21);
            }
            if (options.UsingLorkhan)
            {
                character.LorkhanStats.Sign = (StandingStone)random.Next(13);
                character.LorkhanStats.PerkShards = 2;
                List<Lorkhan.CharacterClass> characterClasses = new List<Lorkhan.CharacterClass>();
                List<Lorkhan.Curse> characterCurses = new List<Lorkhan.Curse>();
                characterClasses.Add((Lorkhan.CharacterClass)random.Next(21));
                character.LorkhanStats.PerkShards -= 2;
                do
                {
                    var curse = (Lorkhan.Curse)random.Next(12);
                    if (!characterCurses.Contains(curse) && random.Next(2) == 1)
                    {
                        characterCurses.Add(curse);
                        character.LorkhanStats.PerkShards += 1;
                    }
                    if (character.LorkhanStats.PerkShards > 1)
                    {
                        var characterClass = (Lorkhan.CharacterClass)random.Next(21);
                        if (!characterClasses.Contains(characterClass) && random.Next(2) == 1)
                        {
                            characterClasses.Add(characterClass);
                            character.LorkhanStats.PerkShards -= 2;
                        }
                    }
                    if (random.Next(2) == 1)
                    {
                        break;
                    }

                } while (character.LorkhanStats.PerkShards > 0);
                if (character.LorkhanStats.PerkShards < 0)
                {
                    throw new Exception("Perk shards was negative!");
                }
                var gem = (Lorkhan.Gem)random.Next(34);
                // todo: filter gems based on generated character class and race
                character.LorkhanStats.StartingLocation = gem;
                character.LorkhanStats.Classes = characterClasses.ToArray();
                character.LorkhanStats.Curses = characterCurses.ToArray();
            }
            Dictionary<Faction, bool> isReputationLocked = new Dictionary<Faction, bool>();
            if (options.UsingDWB)
            {
                character.DWBStats.Sign = (StandingStone)random.Next(13);
                character.DWBStats.FinancialStatus = (DealingWithBackstories.ParentsFinancialStatus)random.Next(4);
                character.DWBStats.Siblings = (DealingWithBackstories.SiblingsModifiers)random.Next(3);
                character.DWBStats.Childhood = new List<DealingWithBackstories.ChildhoodModifiers>();
                for (int i = 0; i < 3; i++)
                {
                    DealingWithBackstories.ChildhoodModifiers mod = (DealingWithBackstories.ChildhoodModifiers)random.Next(12);
                    while (character.DWBStats.Childhood.Contains(mod))
                    {
                        mod = (DealingWithBackstories.ChildhoodModifiers)random.Next(12);
                    }
                    character.DWBStats.Childhood.Add(mod);
                }
                character.DWBStats.Adolescence = new List<DealingWithBackstories.TalentType>();
                for (int i = 0; i < 3; i++)
                {
                    DealingWithBackstories.TalentType talent = (DealingWithBackstories.TalentType)random.Next(9);
                    while (character.DWBStats.Adolescence.Contains(talent))
                    {
                        talent = (DealingWithBackstories.TalentType)random.Next(9);
                    }
                    character.DWBStats.Adolescence.Add(talent);
                }
                character.DWBStats.PastCareers = new List<DealingWithBackstories.CareerModifiers>();
                character.DWBStats.Age = (DealingWithBackstories.AgeModifier)random.Next(4);
                for (int i = 0; i < 3; i++)
                {
                    if (character.DWBStats.Age == DealingWithBackstories.AgeModifier.ComingOfAge)
                    {
                        break;
                    }
                    else if (character.DWBStats.Age == DealingWithBackstories.AgeModifier.Adulthood && i == 1)
                    {
                        break;
                    }
                    else if (character.DWBStats.Age == DealingWithBackstories.AgeModifier.MiddleAge && i == 2)
                    {
                        break;
                    }
                    DealingWithBackstories.CareerModifiers mod = (DealingWithBackstories.CareerModifiers)random.Next(37); // the same career can be added more than once
                    character.DWBStats.PastCareers.Add(mod);
                }
                if (character.DWBStats.FinancialStatus == DealingWithBackstories.ParentsFinancialStatus.SociallyInvisible)
                {
                    character.DWBStats.ParentsJob = (DealingWithBackstories.ParentsJobModifier)random.Next(0, 2);
                }
                else if (character.DWBStats.FinancialStatus == DealingWithBackstories.ParentsFinancialStatus.WorkingClass)
                {
                    character.DWBStats.ParentsJob = (DealingWithBackstories.ParentsJobModifier)random.Next(2, 4);
                }
                else if (character.DWBStats.FinancialStatus == DealingWithBackstories.ParentsFinancialStatus.MiddleClass)
                {
                    character.DWBStats.ParentsJob = (DealingWithBackstories.ParentsJobModifier)random.Next(4, 6);
                }
                else if (character.DWBStats.FinancialStatus == DealingWithBackstories.ParentsFinancialStatus.UpperClass)
                {
                    character.DWBStats.ParentsJob = (DealingWithBackstories.ParentsJobModifier)random.Next(6, 8);
                }
                character.DWBStats.Genetics = new Dictionary<DealingWithBackstories.GeneticsType, DealingWithBackstories.QualityType>();
                for (int i = 0; i < 6; i++)
                {
                    DealingWithBackstories.GeneticsType mod = (DealingWithBackstories.GeneticsType)random.Next(5);
                    while (character.DWBStats.Genetics.ContainsKey(mod))
                    {
                        mod = (DealingWithBackstories.GeneticsType)random.Next(6);
                    }
                    DealingWithBackstories.QualityType qual = (DealingWithBackstories.QualityType)random.Next(3);
                    character.DWBStats.Genetics.Add(mod, qual);
                }
                if ((int)character.DWBStats.Age > 0)
                {
                    character.DWBStats.Vice = (DealingWithBackstories.ViceType)random.Next(6);
                }
                else
                {
                    character.DWBStats.Vice = DealingWithBackstories.ViceType.NoneYet;
                }
                character.DWBStats.Talent = character.DWBStats.Adolescence[random.Next(character.DWBStats.Adolescence.Count)];
                character.DWBStats.Fates = new List<DealingWithBackstories.FateType>();
                for (int i = 0; i < 4; i++)
                {
                    if (random.Next(4) == 1)
                    {
                        break;
                    }
                    if (character.DWBStats.Age == DealingWithBackstories.AgeModifier.ComingOfAge && i == 1)
                    {
                        break;
                    }
                    else if (character.DWBStats.Age == DealingWithBackstories.AgeModifier.Adulthood && i == 2)
                    {
                        break;
                    }
                    else if (character.DWBStats.Age == DealingWithBackstories.AgeModifier.MiddleAge && i == 3)
                    {
                        break;
                    }
                    DealingWithBackstories.FateType fate = (DealingWithBackstories.FateType)random.Next(9);
                    while (character.DWBStats.Fates.Contains(fate))
                    {
                        fate = (DealingWithBackstories.FateType)random.Next(9);
                    }
                    character.DWBStats.Fates.Add(fate);
                }
                character.DWBStats.Focuses = new List<DealingWithBackstories.AspirationType>();
                character.DWBStats.Neglects = new List<DealingWithBackstories.AspirationType>();
                if ((int)character.DWBStats.Age > 1)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        DealingWithBackstories.AspirationType focus = (DealingWithBackstories.AspirationType)random.Next(6);
                        while (character.DWBStats.Focuses.Contains(focus))
                        {
                            focus = (DealingWithBackstories.AspirationType)random.Next(6);
                        }
                        character.DWBStats.Focuses.Add(focus);
                    }
                }
                if (character.DWBStats.Age == DealingWithBackstories.AgeModifier.OldAge)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        DealingWithBackstories.AspirationType neglect = (DealingWithBackstories.AspirationType)random.Next(6);
                        while (character.DWBStats.Neglects.Contains(neglect) || character.DWBStats.Focuses.Contains(neglect))
                        {
                            neglect = (DealingWithBackstories.AspirationType)random.Next(6);
                        }
                        character.DWBStats.Neglects.Add(neglect);
                    }
                }
                character.DWBStats.Desires = new List<DealingWithBackstories.DesireType>();
                for (int i = 0; i < 4; i++)
                {
                    DealingWithBackstories.DesireType desired = (DealingWithBackstories.DesireType)random.Next(10);
                    while (character.DWBStats.Desires.Contains(desired))
                    {
                        desired = (DealingWithBackstories.DesireType)random.Next(10);
                    }
                    character.DWBStats.Desires.Add(desired);
                }
            }
            if (options.UsingFactionReps)
            {
                // todo: filter faction reputations depending on other stats
                for (Faction faction = Faction.Folk; (int)faction < 14; faction++)
                {
                    if (random.Next(3) == 1 && !character.DefaultReputations.ContainsKey(faction))
                    {
                        character.DefaultReputations[faction] = (Character.Reputation)random.Next(5);
                    }
                }
                var baserepuations = character.DefaultReputations.ToArray();
                foreach (var faction in baserepuations)
                {
                    var matches = FactionsEachFactionHates.Where(x => x.Value.Contains(faction.Key));
                    bool factionIsAffiliated = (int)faction.Value > 2;
                    bool factionHatesYou = (int)faction.Value < 2;
                    foreach (var otherfaction in matches)
                    {
                        if (factionIsAffiliated && !isReputationLocked.ContainsKey(otherfaction.Key) && (options.UseTemplate && !options.Template.DefaultReputations.ContainsKey(otherfaction.Key)))
                        {
                            character.DefaultReputations[otherfaction.Key] = faction.Value == Reputation.Liked ? Reputation.Shunned : Reputation.Vilified;
                            isReputationLocked[otherfaction.Key] = true;
                        }
                        else if (factionHatesYou && random.Next(4) == 1 && !isReputationLocked.ContainsKey(otherfaction.Key) && (options.UseTemplate && !options.Template.DefaultReputations.ContainsKey(otherfaction.Key))) // the enemy of my enemy is my friend
                        {
                            character.DefaultReputations[otherfaction.Key] = faction.Value == Reputation.Shunned ? Reputation.Liked : Reputation.Loved;
                            isReputationLocked[otherfaction.Key] = true;
                        }
                    }
                }
            }
            return character;
        }
    }

    class Program
    {
        // todo:
        // filter out various components of the character based on what other components were generated (i.e: autoset faction reputations depending on other faction reputations and how the factions get along, some faction affiliations will depend on character class, DwB adolescence influenced by childhood, etc)
        // Generate DwB stats
        // Sync certain game-wide stuff like standing stones/signs between stat structs
        // more probably
        static void Main(string[] args)
        {
            if (!File.Exists(args[0]))
            {
                Console.WriteLine($"ERROR: {args[0]} does not exist in any known directory");
                return;
            }
            Console.WriteLine($"NOTE: " +
                $"Sometimes the generations in the same category for different 'stat areas' will conflict. (Example: standing stones/signs)\n" +
                $"If that happens, just choose which one you think fits your character best.\n");
            Character.Options options = JsonSerializer.Deserialize<Character.Options>(File.ReadAllText(args[0]));
            Character character = Character.Generate(options);
            Console.WriteLine($"You are a {character.Gender} {character.Race}.");
            if (options.UsingCCO)
            {
                Console.WriteLine("\nCCO Stats:");
                Character.CCO cco = character.CCOStats;
                Console.WriteLine($"\tYour sign is {cco.Sign}.");
                Console.WriteLine($"\tYour primary class is {cco.PresetClass}.");
            }
            if (options.UsingDWB)
            {
                Console.WriteLine($"\nStats for Dealing with Backstories:");
                Character.DealingWithBackstories dwb = character.DWBStats;
                Console.WriteLine($"\tYour sign is {dwb.Sign}.");
                Console.WriteLine($"\tYour parents' financial status was '{dwb.FinancialStatus}'.");
                Console.WriteLine($"\tYour status as a sibling was '{dwb.Siblings}'.");
                Console.WriteLine($"\tChildhood hobbies:");
                foreach (var hobby in dwb.Childhood)
                {
                    Console.WriteLine($"\t\t{hobby}");
                }
                Console.WriteLine($"\tYour interests during adolescence:");
                foreach (var hobby in dwb.Adolescence)
                {
                    Console.WriteLine($"\t\t{hobby}");
                }
                Console.WriteLine($"\tYour past careers:");
                foreach (var career in dwb.PastCareers)
                {
                    Console.WriteLine($"\t\t{career}");
                }
                Console.WriteLine($"\tYour age is {dwb.Age}.");
                Console.WriteLine(dwb.ParentsJob == Character.DealingWithBackstories.ParentsJobModifier.Orphan ? $"\tYou are an orphan." : $"\tYour parents were '{dwb.ParentsJob}'.");
                Console.WriteLine($"\tYour genetics:");
                foreach (var g in dwb.Genetics)
                {
                    Console.WriteLine($"\t\t{g.Key}: {g.Value}");
                }
                Console.WriteLine($"\tYour vice is {dwb.Vice}.");
                Console.WriteLine($"\tYour primary talent is {dwb.Talent}.");

                Console.WriteLine($"\tYour past fate(s), if any:");
                foreach (var fate in dwb.Fates)
                {
                    Console.WriteLine($"\t\t{fate}");
                }

                Console.WriteLine($"\tYour focus(es), if any:");
                foreach (var a in dwb.Focuses)
                {
                    Console.WriteLine($"\t\t{a}");
                }

                Console.WriteLine($"\tYour neglect(s), if any:");
                foreach (var a in dwb.Neglects)
                {
                    Console.WriteLine($"\t\t{a}");
                }

                Console.WriteLine($"\tYour desires:");
                foreach (var a in dwb.Desires)
                {
                    Console.WriteLine($"\t\t{a}");
                }
            }
            if (options.UsingLorkhan)
            {
                Console.WriteLine("\nStats for Realm of Lorkhan:");
                Character.Lorkhan lorkhan = character.LorkhanStats;
                Console.WriteLine($"\tYour standing stone (sign) is {lorkhan.Sign}.");
                Console.WriteLine($"\tClasses (if any):");
                foreach (var taken in lorkhan.Classes)
                {
                    Console.WriteLine($"\t\t{taken}");
                }
                Console.WriteLine($"\tCurses (if any):");
                foreach (var taken in lorkhan.Curses)
                {
                    Console.WriteLine($"\t\t{taken}");
                }
                Console.WriteLine($"\tYou will start the game in {lorkhan.StartingLocation}.");
            }
            if (options.UsingFactionReps)
            {
                Console.WriteLine($"\nHow factions view you:");
                foreach (var faction in character.DefaultReputations)
                {
                    Console.WriteLine($"\t{faction.Key}: {faction.Value}");
                }
            }
        }
    }
}