using System;

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
            public ChildhoodModifiers[] Childhood; // pick 3
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
            public TalentType[] Adolescence; // pick 3
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
                TravellingPerforming,
                TreasureHunter,
                Warlock,
                Witch,
                Woodsman
            }
            public CareerModifiers[] PastCareers; // pick 0-3
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
                Orphan,Destitute, // if socially invisible
                Miners,Farmers, // if working class
                Merchants,Artisans, // if middle class
                Priests,Nobles, // if upper class
            }
            public ParentsJobModifier ParentsJob; // must pick 1
            public enum GeneticsType
            {
                BadAppearance, GoodAppearance,
                BadHeight, GoodHeight,
                BadMagicalPotential, GoodMagicalPotential,
                BadEndurance, GoodEndurance,
                BadFortitude, GoodFortitude,
                BadIntelligence, GoodIntelligence,
            }
            public GeneticsType[] Genetics; // must pick 6
            public enum ViceType
            {
                Gambling,SubstanceAbuse,Crime,Sadism,Unprofessional,Adultery
            }
            public ViceType Vice; // optional if coming of age
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
            public FateType[] Fates; // 0-4 depending on age
            public enum AspirationType
            {
                Family,Career,Piety,Health,Leisure,Wealth
            }
            public AspirationType[] Focuses; // 0-2
            public AspirationType[] Neglects; // 0-2
            public enum DesireType
            {
                Wealth,Love,MagicPower,Fame,Immortality,Revenge,RecoverThePast,Adventure,ForbiddenKnowledge,VictoryInBattle
            }
            public DesireType[] Desires; // must pick 4
        }
        public DealingWithBackstories DWBStats;
        
        public struct Options // what mods to use
        {
            public bool UsingCCO; // Character Creation Overhaul
            public bool UsingLorkhan; // Realm of Lorkhan
            public bool UsingFactionReps; // Faction reputation mods (like Faction Warfare)
            public bool UsingDWB; // Dealing with Backstories
        }

        public static Character Generate(Character.Options options)
        {
            Character character = new Character();
            Random random = new Random(new Random().Next());

            // randomize the gender
            character.Gender = (CharacterGender)random.Next(2);
            character.Race = (CharacterRace)random.Next(10);
            character.DefaultReputations = new Dictionary<Faction, Reputation>();

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
            // todo: DwB
            if (options.UsingFactionReps)
            {
                // todo: filter faction reputations depending on other stats
                for (Faction faction = Faction.Folk; (int)faction < 14; faction++)
                {
                    if (random.Next(2) == 1 && !character.DefaultReputations.ContainsKey(faction))
                    {
                        character.DefaultReputations[faction] = (Character.Reputation)random.Next(5);
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
            Character.Options options;
            options.UsingLorkhan = false;
            options.UsingCCO = false;
            options.UsingDWB = false;
            options.UsingFactionReps = false;
            if (args.Contains("cco"))
            {
                options.UsingCCO = true;
            }
            if (args.Contains("dwb"))
            {
                options.UsingDWB = true;
            }
            if (args.Contains("lorkhan"))
            {
                options.UsingLorkhan = true;
            }
            if (args.Contains("factions"))
            {
                options.UsingFactionReps = true;
            }
            Character character = Character.Generate(options);
            Console.WriteLine($"You are a {character.Gender} {character.Race}.");
            if (args.Contains("cco"))
            {
                Console.WriteLine("\nCCO Stats:");
                Character.CCO cco = character.CCOStats;
                Console.WriteLine($"\tYour sign is {cco.Sign}.");
                Console.WriteLine($"\tYour primary class is {cco.PresetClass}.");
            }
            if (args.Contains("dwb"))
            {
                // todo
            }
            if (args.Contains("lorkhan"))
            {
                Console.WriteLine("\nStats for Realm of Lorkhan:");
                Character.Lorkhan lorkhan = character.LorkhanStats;
                Console.WriteLine($"\tYour standing stone is {lorkhan.Sign}.");
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
            if (args.Contains("factions"))
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