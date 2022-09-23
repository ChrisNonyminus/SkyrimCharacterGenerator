using System;
using System.Text.Json;
using System.Text.Json.Serialization;

using SkyrimCharacterGenerator.Common;

namespace SkyrimCharacterGenerator.ConsoleApp
{

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