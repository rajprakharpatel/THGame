using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class Hacker : MonoBehaviour
{
    int level = 1;
    int tries = 3;

    enum Screen
    {
        MainScreen,
        Play,
        HighScores,
        Lose
    };

    Screen currentScreen, previousScreen;

    void OnUserInput(string input)
    {
        if (input == "menu")
            ShowMainMenu();
        //else if (input.Substring(0,5) == "Force")
        //{
        //    level = 100;
        //    NewHighScore(input.Substring(startIndex: 14));
        //}
        else switch (currentScreen)
        {
            case Screen.MainScreen:
                RunMainMenu(input);
                break;
            case Screen.Play:
                CheckAnswer(input);
                break;
            case Screen.Lose:
                Terminal.WriteLine("kkk");
                break;
            case Screen.HighScores:
                NewHighScore(input);
                break;
        }
    }

    IEnumerator DrawFigure(string fName)
    {
        StreamReader sr = new StreamReader(fName);
        sr.BaseStream.Seek(0, SeekOrigin.Begin);
        var str = sr.ReadLine();
        while (str != null)
        {
            Terminal.WriteLine(str);
            str = sr.ReadLine();
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator ShowProgress(int p)
    {
        for (int i = 0; i < p; i++)
        {
            Terminal.ClearScreen();
            Terminal.WriteLine(".______   .______        ______     _______ .______       _______     _______.     _______.");
            Terminal.WriteLine("|   _  \\  |   _  \\      /  __  \\   /  _____||   _  \\     |   ____|   /       |    /       |");
            Terminal.WriteLine("|  |_)  | |  |_)  |    |  |  |  | |  |  __  |  |_)  |    |  |__     |   (----`   |   (----`");
            Terminal.WriteLine("|   ___/  |      /     |  |  |  | |  | |_ | |      /     |   __|     \\   \\        \\   \\    ");
            Terminal.WriteLine("|  |      |  |\\  \\----.|  `--\'  | |  |__| | |  |\\  \\----.|  |____.----)   |   .----)   |   ");
            Terminal.WriteLine("| _|      | _| `._____| \\______/   \\______| | _| `._____||_______|_______/    |_______/    ");
            string str = "";
            int j = 0;
            for (j = 0; j < i; j++)
                str += "█";
            Terminal.WriteLine("\n");
            Terminal.WriteLine(str + (j+1) + "%");
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator DrawDots(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Terminal.WriteLine(".");
            yield return new WaitForSeconds(seconds: 0.4f);
        }
    }

    void CheckAnswer(string input)
    {
        switch (input.ToUpper())
        {
            case "HITMAN":
                if (level == 1)
                    Win();
                break;
            case "PEACE":
                if (level == 2)
                    Win();
                break;
            case "GHOSTBUSTERS":
                if (level == 3)
                    Win();
                break;
            default:
                Lose();
                break;
        }
    }

    void Lose()
    {
        if (tries > 0)
        {
            switch (level)
            {
                case 1:
                    tries--;
                    Terminal.WriteLine("WRONG... \n" + (tries + 1) + " chances left \n" +
                                       " Try Again");
                    break;
                case 2:
                    tries--;
                    Terminal.WriteLine("WRONG... \n" + (tries + 1) + " chances left \n" +
                                       " Try Again");
                    break;
                case 3:
                    tries--;
                    Terminal.WriteLine("WRONG... \n" + (tries + 1) + " chances left \n" +
                                       " Try Again");
                    break;
            }
        }
        else
        {
            Terminal.WriteLine("Enter your Name");
            Terminal.ClearScreen();
            Terminal.WriteLine("Level  " + level);
        }
    }

    void Win()
    {
        switch (level)
        {
            case 1:
                Terminal.ClearScreen();
                Terminal.WriteLine("Security Measures Shut Down");
                Terminal.WriteLine(".");
                Terminal.WriteLine(".");
                Terminal.WriteLine("Breach the Firewall to access files");
                StartCoroutine(ShowProgress(35));
                level++;
                tries++;
                Invoke(nameof(Play), 10);
                
                break;
            case 2:
                Terminal.ClearScreen();
                Terminal.WriteLine("Firewall Breached");
                Terminal.WriteLine("Security Breach Detected");
                Terminal.WriteLine("System Shutdown in progress. . . .");
                StartCoroutine(ShowProgress(70));
                level++;
                tries += 2;
                Invoke(nameof(Play), 10);
                break;
            case 3:
                Terminal.ClearScreen();
                Terminal.WriteLine("System shutdown successfully stopped");
                Terminal.WriteLine("Full Access Granted  . . . .");
                StartCoroutine(ShowProgress(100));
                Invoke(nameof(HighScores), 10);
                break;
        }
    }

    void RunMainMenu(string input)
    {
        if (input == "1")
            Play();
        else if (input == "2")
            HighScores();
        else if (input == "3")
        {
            Terminal.WriteLine("Exiting...");
            Exit();
        }
    }

    void Exit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    void NewHighScore(string inp)
    {
        string str = inp + "------------------------------------------" + level;
        File.AppendAllText("Assets/HighScores.txt", str + Environment.NewLine);
        HighScores();
    }
    void HighScores()
    {
        if (previousScreen == Screen.Lose || previousScreen == Screen.Play)
            Terminal.WriteLine("Enter Your name");
        else
            StartCoroutine(DrawFigure("Assets/HighScores.txt"));
        previousScreen = currentScreen;
        currentScreen = Screen.HighScores;
    }

    void Play()
    {
        previousScreen = currentScreen;
        currentScreen = Screen.Play;
        if (level == 1)
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("First you have to shut down the safety measures \n Identify the logo");
            StartCoroutine(DrawFigure("Assets/Figures/Hit.txt"));
        }

        if (level == 2)
        {
            Terminal.ClearScreen();
            StartCoroutine(DrawFigure("Assets/Figures/BioHaz.txt"));
        }

        if (level == 3)
        {
            Terminal.ClearScreen();
            StartCoroutine(DrawFigure("Assets/Figures/casper.txt"));
        }
    }

    private static void Delay(int timeDelay)
    {
        int i = 0;
        //  ameTir = new System.Timers.Timer();
        var delayTimer = new System.Timers.Timer {Interval = timeDelay, AutoReset = false};
        //so that it only calls the method once
        delayTimer.Elapsed += (s, args) => i = 1;
        delayTimer.Start();
        while (i == 0)
        {
        }

        ;
    }

    void ShowMainMenu()
    {
        previousScreen = currentScreen;
        currentScreen = Screen.MainScreen;
        Terminal.WriteLine("1. Play");
        Terminal.WriteLine("2. HighScores");
        Terminal.WriteLine("3. Exit");
    }

    // Start is called before the first frame update

    void Start()
    {
        Terminal.WriteLine("Welcome to Terminal Hacker Game");
        ShowMainMenu();
    }

    // Update is called once per frame
    void Update()
    {
    }
}