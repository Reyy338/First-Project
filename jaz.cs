using System;

class Story
{
    static void Main()
    {
        Console.WriteLine("You stand before the entrance of the Dungeon of the under world.");
        Console.WriteLine("You need to choose abilities wisely to defeat the demons.");

        string abilityChoice = "";
        bool success = false;

        while (true)
        {
            Console.WriteLine("\nChoose your ability:");
            Console.WriteLine("1. Super Saiyan");
            Console.WriteLine("2. Death Note");
            Console.WriteLine("3. Time travel");
            Console.WriteLine("4. Stop time");
            Console.WriteLine("5. elemental powers");
            Console.WriteLine("6. manipulator's eye");
            Console.WriteLine("7. Light Saber");
            Console.WriteLine("8. holy abilities");
            Console.WriteLine("9. Summoning");
            Console.WriteLine("10. infinite void");
            Console.WriteLine("11. sharingan");
            Console.WriteLine("12. atomic blast");
            Console.WriteLine("13. dark magic");

            abilityChoice = Console.ReadLine();

            // Use switch statements to control the story flow
            switch (abilityChoice)
            {
                case "1":
                    Console.WriteLine("You obtain super saiyan.");
                    Console.WriteLine("You still didn't know the true power of being a super saiyan so you Died.");
                    break;
                case "2":
                    Console.WriteLine("You don't know the Name of the demons.");
                    Console.WriteLine("You got killed.");
                    break;
                case "3":
                    Console.WriteLine("Time travel is useless if you are in the under world.");
                    Console.WriteLine("You suffered infinitely");
                    break;
                case "4":
                    Console.WriteLine("Stop time is usefull");
                    Console.WriteLine("you stopped the time and you take advantage to the demons.");
                    success = true;
                    break;
                case "5":
                    Console.WriteLine("elemental abilities is an orb effect to the demons");
                    Console.WriteLine("You died.");
                    break;
                case "6":
                    Console.WriteLine("You cant manipulate a demon.");
                    Console.WriteLine("you died .");
                    break;
                case "7":
                    Console.WriteLine("you obtained light saber.");
                    Console.WriteLine("but the demons carry an demonic armor so its useless and you.");
                    break;
                case "8":
                    Console.WriteLine("holy abilities is the greatest counter for demons.");
                    Console.WriteLine("you smashed all the demons.");
                    success = true;
                    break;
                case "9":
                    Console.WriteLine("You summoned God to help you in the battle.");
                    Console.WriteLine("God demolished all the demons.");
                    success = true;
                    break;
                case "10":
                    Console.WriteLine("you have infinity void abilities");
                    Console.WriteLine("you locked all the demons in the void.");
                    
                    break;
                case "11":
                    Console.WriteLine("you have sharigan eyes that can paralize enemies.");
                    Console.WriteLine("but demons have also a demons eyes that is a perfect counter to sharingan.");
                    break;
                case "12":
                    Console.WriteLine("You Tried using atomic blast");
                    Console.WriteLine("but they have regeneration and your out of mana");
                    break;
                case "13":
                    Console.WriteLine("You attempted to use dark magic .");
                    Console.WriteLine("but it is an orb effect to the demons.");
                    break;
 
            }

            // Break the loop if the agent succeeds or if they have tried 3 times
            if (success || Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                break;
            }
        }

        if (success)
        {
            Console.WriteLine("Congratulations, You successfully defeated the demons.");
        }
        else
        {
            Console.WriteLine("Mission failed. The demons overpowered you.");
        }
    }
}