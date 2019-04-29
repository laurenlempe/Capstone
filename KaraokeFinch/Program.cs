using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinchAPI;
using HidSharp;

namespace KaraokeFinch
{
    class Program
    {
        //**************************************
        // Title: Karaoke Finch
        // Application Type: Console
        // Description: Make the Finch robot sing and dance
        // Author: Lauren Lempe
        // Date Created: 4/24/2019
        // Last Modified: 4/28/2019
        //***************************************

        //
        // Declare Finch
        //
        static Finch gloria = new Finch();

        static void Main(string[] args)
        {
            DisplayWelcomeScreen();
            DisplayMenu();
            DisplayClosingScreen();
        }

        static void DisplayMenu()
        {
            //
            // variables
            //        
            string karaokeSong;
            gloria.connect();
            double paparazziLightThreshold = 0;


            //
            // Display instructions message
            //
            Console.WriteLine("Gloria, a Finch robot, is a terrible singer but she loves karaoke!");
            Console.WriteLine();
            Console.WriteLine("Also when the song is over, flashing lights or 'paparazzi' flash photography make her dance!");
            Console.WriteLine("Have fun!");
            Console.WriteLine();

            //
            // Get song choice from user
            //
            Console.WriteLine("Please enter your song choice for Karaoke legend Gloria:");
            karaokeSong = Console.ReadLine();

            switch (karaokeSong)
            {
                case "1":
                    KaraokeSongOne(paparazziLightThreshold);
                    break;
                case "2":
                    KaraokeSongTwo(paparazziLightThreshold);
                    break;
                case "3":
                    KaraokeSongThree(paparazziLightThreshold);
                    break;
                default:
                    Console.WriteLine("Sorry, invalid song choice. Unable to continue.");
                    Console.WriteLine("Music time is over!");
                    break;
            }
        }

        static double SetupPapparazziLightThreshold()
        {
            //
            // Get starting light level and establish paparazzi light threshold
            //
            double paparazziLightThreshold;
            double startLight;

            startLight = gloria.getLeftLightSensor();

            paparazziLightThreshold = startLight + 20;

            return paparazziLightThreshold;
        }

        static bool LightAboveThreshold(double paparazziLightThreshold)
        {
            //
            // Loop to check if current light level has gone above the paparazzi light threshold
            //
            if (gloria.getLeftLightSensor() >= paparazziLightThreshold)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void KaraokeSongOne(double paparazziLightThreshold)
        {
            //
            // Karaoke Song 1 - during this song, Gloria can go into Diva mode with a single camera flash 
            //
            Console.WriteLine();
            Console.WriteLine("Here's Gloria Row, Row, Rowing that Boat!");

            paparazziLightThreshold = SetupPapparazziLightThreshold();

            PlaySongOne();

            while (!LightAboveThreshold(paparazziLightThreshold))
            {
                gloria.setLED(100, 100, 0);
                gloria.wait(1000);
                gloria.setLED(100, 0, 100);
                gloria.wait(1000);
            }

            DanceOne();

        }

        static void KaraokeSongTwo(double paparazziLightThreshold)
        {
            //
            // Karaoke Song 2 - not to be confused with Huey Lewis, this Heart and Soul makes her do the cha cha
            //
            Console.WriteLine();
            Console.WriteLine("Here's Gloria with Heart and Soul!");

            paparazziLightThreshold = SetupPapparazziLightThreshold();

            PlaySongTwo();

            while (!LightAboveThreshold(paparazziLightThreshold))
            {
                gloria.setLED(100, 200, 50);
                gloria.wait(1000);
                gloria.setLED(50, 100, 100);
                gloria.wait(1000);
            }

            DanceTwo();

        }

        static void KaraokeSongThree(double paparazziLightThreshold)
        {
            //
            // Karaoke Song 3 - Twinkle Twinkle puts Gloris in the best mood for her best dance moves
            //
            Console.WriteLine();
            Console.WriteLine("Here's Gloria with her favorite jam, Twinkle Twinkle Little Star!");
            Console.WriteLine();

            paparazziLightThreshold = SetupPapparazziLightThreshold();

            PlaySongThree();

            while (!LightAboveThreshold(paparazziLightThreshold))
            {
                gloria.setLED(100, 50, 200);
                gloria.wait(1000);
                gloria.setLED(100, 200, 100);
                gloria.wait(1000);
            }

            DanceThree();

        }

        static void DanceOne()
        {
            //
            // Diva Dance scene 1 - Gloria shows off a few dance moves
            //
            gloria.noteOff();

            Console.WriteLine();
            Console.WriteLine("Gloria says: That was fun!");

            for (int i = 0; i < 3; i++)
            {
                gloria.setLED(255, 0, 0);
                gloria.setMotors(-50, 100);
                gloria.wait(500);
                gloria.setLED(0, 255, 0);
                gloria.wait(500);
                gloria.setLED(0, 0, 255);
                gloria.wait(250);
                gloria.setLED(0, 0, 0);
                gloria.setMotors(0, 0);
            }

            Console.WriteLine();
            Console.WriteLine("Song Over!");
            Console.WriteLine();
        }

        static void DanceTwo()
        {
            //
            // Diva Dance scene 2 - Gloria is strutting her stuff
            //
            gloria.noteOff();


            Console.WriteLine();
            Console.WriteLine("Gloria says: Now we're groovin'!");

            for (int i = 0; i < 5; i++)
            {
                gloria.setLED(0, 255, 0);
                gloria.setMotors(75, 75);
                gloria.wait(500);
                gloria.setLED(255, 0, 0);
                gloria.setMotors(-75, -75);
                gloria.wait(500);
                gloria.setLED(0, 0, 0);
                gloria.setMotors(0, 0);
            }

            Console.WriteLine();
            Console.WriteLine("Song Over!");
            Console.WriteLine();
        }

        static void DanceThree()
        {
            //
            // Diva Dance scene 3 - Gloria pulls out all the stops and tears up the dance floor!
            //
            gloria.noteOff();

            Console.WriteLine();
            Console.WriteLine("Gloria says: Nobody gets Jiggy with it like me!");

            for (int i = 0; i < 5; i++)
            {
                gloria.setLED(255, 255, 0);
                gloria.setMotors(-100, 150);
                gloria.wait(500);
                gloria.setLED(0, 255, 255);
                gloria.setMotors(100, -150);
                gloria.wait(500);
                gloria.setLED(255, 0, 255);
                gloria.wait(250);
                gloria.setLED(0, 0, 0);
                gloria.setMotors(0, 0);
            }

            Console.WriteLine();
            Console.WriteLine("Song Over!");
            Console.WriteLine();
        }

        static void PlaySongTwo()
        {
            //
            // Heart and Soul
            //
            gloria.noteOn(262);
            gloria.wait(500);
            gloria.noteOff();
            gloria.noteOn(262);
            gloria.wait(500);
            gloria.noteOff();
            gloria.noteOn(262);
            gloria.wait(650);
            gloria.noteOff();
            gloria.noteOn(262);
            gloria.wait(250);
            gloria.noteOn(247);
            gloria.wait(350);
            gloria.noteOn(220);
            gloria.wait(250);
            gloria.noteOn(247);
            gloria.wait(350);
            gloria.noteOn(262);
            gloria.wait(250);
            gloria.noteOn(294);
            gloria.wait(750);

            gloria.noteOn(330);
            gloria.wait(500);
            gloria.noteOff();
            gloria.noteOn(330);
            gloria.wait(500);
            gloria.noteOff();
            gloria.noteOn(330);
            gloria.wait(650);
            gloria.noteOff();
            gloria.noteOn(330);
            gloria.wait(250);
            gloria.noteOn(294);
            gloria.wait(350);
            gloria.noteOn(262);
            gloria.wait(250);
            gloria.noteOn(294);
            gloria.wait(350);
            gloria.noteOn(330);
            gloria.wait(250);
            gloria.noteOn(349);
            gloria.wait(350);

            gloria.noteOn(392);
            gloria.wait(1000);
            gloria.noteOn(262);
            gloria.wait(1000);
            gloria.noteOn(440);
            gloria.wait(250);
            gloria.noteOn(392);
            gloria.wait(350);
            gloria.noteOn(349);
            gloria.wait(250);
            gloria.noteOn(330);
            gloria.wait(350);
            gloria.noteOn(294);
            gloria.wait(1000);
            gloria.noteOn(262);
            gloria.wait(1000);


            gloria.noteOn(247);
            gloria.wait(300);
            gloria.noteOn(220);
            gloria.wait(650);
            gloria.noteOn(196);
            gloria.wait(300);
            gloria.noteOn(175);
            gloria.wait(650);
            gloria.noteOn(165);
            gloria.wait(300);
            gloria.noteOn(147);
            gloria.wait(650);
            gloria.noteOn(196);
            gloria.wait(750);
            gloria.noteOn(262);
            gloria.wait(1000);
            gloria.noteOff();
        }

        static void PlaySongThree()
        {
            //
            // Twinkle Twinkle Little Star
            //
            gloria.noteOn(262);
            gloria.wait(250);
            gloria.noteOff();
            gloria.noteOn(262);
            gloria.wait(250);
            gloria.noteOn(392);
            gloria.wait(250);
            gloria.noteOff();
            gloria.noteOn(392);
            gloria.wait(250);
            gloria.noteOn(440);
            gloria.wait(250);
            gloria.noteOff();
            gloria.noteOn(440);
            gloria.wait(250);
            gloria.noteOn(392);
            gloria.wait(500);

            gloria.noteOn(349);
            gloria.wait(250);
            gloria.noteOff();
            gloria.noteOn(349);
            gloria.wait(250);
            gloria.noteOn(330);
            gloria.wait(250);
            gloria.noteOff();
            gloria.noteOn(330);
            gloria.wait(250);
            gloria.noteOn(294);
            gloria.wait(250);
            gloria.noteOff();
            gloria.noteOn(294);
            gloria.wait(250);
            gloria.noteOn(262);
            gloria.wait(500);

            gloria.noteOn(392);
            gloria.wait(250);
            gloria.noteOff();
            gloria.noteOn(392);
            gloria.wait(250);
            gloria.noteOn(349);
            gloria.wait(250);
            gloria.noteOff();
            gloria.noteOn(349);
            gloria.wait(250);
            gloria.noteOn(330);
            gloria.wait(250);
            gloria.noteOff();
            gloria.noteOn(330);
            gloria.wait(250);
            gloria.noteOn(294);
            gloria.wait(500);

            gloria.noteOn(392);
            gloria.wait(250);
            gloria.noteOff();
            gloria.noteOn(392);
            gloria.wait(250);
            gloria.noteOn(349);
            gloria.wait(250);
            gloria.noteOff();
            gloria.noteOn(349);
            gloria.wait(250);
            gloria.noteOn(330);
            gloria.wait(250);
            gloria.noteOff();
            gloria.noteOn(330);
            gloria.wait(250);
            gloria.noteOn(294);
            gloria.wait(500);

            gloria.noteOn(262);
            gloria.wait(250);
            gloria.noteOff();
            gloria.noteOn(262);
            gloria.wait(250);
            gloria.noteOn(392);
            gloria.wait(250);
            gloria.noteOff();
            gloria.noteOn(392);
            gloria.wait(250);
            gloria.noteOn(440);
            gloria.wait(250);
            gloria.noteOff();
            gloria.noteOn(440);
            gloria.wait(250);
            gloria.noteOn(392);
            gloria.wait(500);

            gloria.noteOn(349);
            gloria.wait(250);
            gloria.noteOff();
            gloria.noteOn(349);
            gloria.wait(250);
            gloria.noteOn(330);
            gloria.wait(250);
            gloria.noteOff();
            gloria.noteOn(330);
            gloria.wait(250);
            gloria.noteOn(294);
            gloria.wait(250);
            gloria.noteOff();
            gloria.noteOn(294);
            gloria.wait(250);
            gloria.noteOn(262);
            gloria.wait(500);
            gloria.noteOff();
        }

        static void PlaySongOne()
        {
            //
            // Row Row Row Your Boat
            //
            gloria.noteOn(262);
            gloria.wait(250);
            gloria.noteOff();
            gloria.noteOn(262);
            gloria.wait(250);
            gloria.noteOff();
            gloria.noteOn(262);
            gloria.wait(250);
            gloria.noteOn(294);
            gloria.wait(250);
            gloria.noteOn(330);
            gloria.wait(400);
            gloria.noteOff();

            gloria.noteOn(330);
            gloria.wait(250);
            gloria.noteOn(294);
            gloria.wait(500);
            gloria.noteOn(330);
            gloria.wait(250);
            gloria.noteOn(349);
            gloria.wait(250);
            gloria.noteOn(392);
            gloria.wait(500);

            gloria.noteOn(262);
            gloria.wait(250);
            gloria.noteOff();
            gloria.noteOn(262);
            gloria.wait(250);
            gloria.noteOn(392);
            gloria.wait(250);
            gloria.noteOff();
            gloria.noteOn(392);
            gloria.wait(250);
            gloria.noteOn(330);
            gloria.wait(250);
            gloria.noteOff();
            gloria.noteOn(330);
            gloria.wait(250);
            gloria.noteOn(262);
            gloria.wait(250);
            gloria.noteOff();
            gloria.noteOn(262);
            gloria.wait(350);

            gloria.noteOn(392);
            gloria.wait(250);
            gloria.noteOff();
            gloria.noteOn(349);
            gloria.wait(250);
            gloria.noteOn(330);
            gloria.wait(500);
            gloria.noteOn(294);
            gloria.wait(250);
            gloria.noteOff();
            gloria.noteOn(262);
            gloria.wait(500);
            gloria.noteOff();
        }

        static void DisplayWelcomeScreen()
        {
            //
            // Welcome user to game
            //
            Console.Clear();
            Console.WriteLine("Welcome to Finch Robot Karaoke with your robot 'singer' Gloria!");
            Console.WriteLine();
        }

        static void DisplayClosingScreen()
        {
            //
            // Song time is over, disconnect Finch
            //
            Console.WriteLine();
            Console.WriteLine("Thank you for playing Karaoke Finch!");
            gloria.disConnect();
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

    }
}
