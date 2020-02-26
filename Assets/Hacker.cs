using System;
using System.Text;
using static System.Security.Cryptography.RandomNumberGenerator;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using System.Timers;
using Random = System.Random;

public class Hacker : MonoBehaviour
{
    int level = 1;
    int tries = 3;
    private int _progress = 0;

    enum Ques
    {
        AtBomb,
        BioHaz,
        Casper,
        GhostBusters,
        HitMan,
        Homer,
        Peace,
        Popoye,
        Smurfs,
        Sonic,
        SquidWard,
        Volks
    }

    private Ques _ques;

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
        Terminal.ClearScreen();
        for (int i = 0; i < p; i++)
        {
            switch (level)
            {
                case 1:
                    Terminal.WriteLine(" __       _______ ____    ____  _______  __          __  ");
                    Terminal.WriteLine("|  |     |   ____|\\   \\  /   / |   ____||  |        /_ |"); 
                    Terminal.WriteLine("|  |     |  |__    \\   \\/   /  |  |__   |  |         | |"); 
                    Terminal.WriteLine("|  |     |   __|    \\      /   |   __|  |  |         | | ");
                    Terminal.WriteLine("|  `----.|  |____    \\    /    |  |____ |  `----.    | | ");
                    Terminal.WriteLine("|_______||_______|    \\__/     |_______||_______|    |_| ");
                    break;
                
                case 2:
                    Terminal.WriteLine(" __       _______ ____    ____  _______  __          ___   ");
                    Terminal.WriteLine("|  |     |   ____|\\   \\  /   / |   ____||  |        |__ \\ ");
                    Terminal.WriteLine("|  |     |  |__    \\   \\/   /  |  |__   |  |           ) | ");
                    Terminal.WriteLine("|  |     |   __|    \\      /   |   __|  |  |          / /  ");
                    Terminal.WriteLine("|  `----.|  |____    \\    /    |  |____ |  `----.    / /_  ");
                    Terminal.WriteLine("|_______||_______|    \\__/     |_______||_______|   |____| ");
                    break;
                case 3:
                    Terminal.WriteLine(" __       _______ ____    ____  _______  __          ____   ");
                    Terminal.WriteLine("|  |     |   ____|\\   \\  /   / |   ____||  |        |___ \\");  
                    Terminal.WriteLine("|  |     |  |__    \\   \\/   /  |  |__   |  |          __) |"); 
                    Terminal.WriteLine("|  |     |   __|    \\      /   |   __|  |  |         |__ <  ");
                    Terminal.WriteLine("|  `----.|  |____    \\    /    |  |____ |  `----.    ___) | ");
                    Terminal.WriteLine("|_______||_______|    \\__/     |_______||_______|   |____/  ");
                    break;
            }

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

    void SelectQuestion()
    {
        Random random = new Random();
        switch (level)
        {
            case 1:
                int rand1 = random.Next(1,6);
                Terminal.ClearScreen();
                Terminal.WriteLine("First you have to shut down the safety measures \n Identify the logo");
                switch (rand1)
                {
                    case 1:
                        _ques = Ques.HitMan;
                        StartCoroutine(DrawFigure("Assets/Figures/Hit.txt"));
                        break;
                    case 2:
                        _ques = Ques.Homer;
                        StartCoroutine(DrawFigure("Assets/Figures/Homer.txt"));
                        break;
                    case 3:
                        _ques = Ques.Peace;
                        StartCoroutine(DrawFigure("Assets/Figures/peace.txt"));
                        break;
                    case 4:
                        _ques = Ques.Smurfs;
                        StartCoroutine(DrawFigure("Assets/Figures/Smurfs.txt"));
                        break;
                    case 5:
                        _ques = Ques.Sonic;
                        StartCoroutine(DrawFigure("Assets/Figures/sonic.txt"));
                        break;
                }
                break;

                case 2:
                int rand2 = random.Next(6,10);
                Terminal.ClearScreen();
                Terminal.WriteLine("First you have to shut down the safety measures \n Identify the logo");
                switch (rand2)
                {
                    case 6:
                        _ques = Ques.BioHaz;
                        StartCoroutine(DrawFigure("Assets/Figures/BioHaz.txt"));
                        break;
                    case 7:
                        _ques = Ques.AtBomb;
                        StartCoroutine(DrawFigure("Assets/Figures/AtBombman.txt"));
                        break;
                    case 8:
                        _ques = Ques.Casper;
                        StartCoroutine(DrawFigure("Assets/Figures/casper.txt"));
                        break;
                    case 9:
                        _ques = Ques.Volks;
                        StartCoroutine(DrawFigure("Assets/Figures/Volks.txt"));
                        break;
                }
                break;

                case 3:
                int rand3 = random.Next(10,13);
                Terminal.ClearScreen();
                Terminal.WriteLine("First you have to shut down the safety measures \n Identify the logo");
                switch (rand3)
                {
                    case 10:
                        _ques = Ques.SquidWard;
                        StartCoroutine(DrawFigure("Assets/Figures/Squidward.txt"));
                        break;
                    case 11:
                        _ques = Ques.Popoye;
                        StartCoroutine(DrawFigure("Assets/Figures/Popoye.txt"));
                        break;
                    case 12:
                        _ques = Ques.GhostBusters;
                        StartCoroutine(DrawFigure("Assets/Figures/ghostbusters.txt"));
                        break;
                }
                break;
        }
    }

    void CheckAnswer(string input)
    {
        switch (input.ToUpper())
        {
            case "HITMAN":
                if (_ques  == Ques.HitMan)
                    Win();
                break;
            case "PEACE":
                if (_ques  == Ques.Peace)
                    Win();
                break;
            case "ATOMIC BOMBERMAN":
                if (_ques  == Ques.AtBomb)
                    Win();
                break;
            case "CASPER":
                if (_ques  == Ques.Casper)
                    Win();
                break;
            case "HOMER":
                if (_ques  == Ques.Homer)
                    Win();
                break;
            case "SONIC THE HEDGEHOG":
                if (_ques  == Ques.Sonic)
                    Win();
                break;
            case "POPOYE":
                if (_ques  == Ques.Popoye)
                    Win();
                break;
            case "VOLKSWAGEN":
                if (_ques  == Ques.Volks)
                    Win();
                break;
            case "SQUIDWARD":
                if (_ques  == Ques.SquidWard)
                    Win();
                break;
            case "SMURFS":
                if (_ques  == Ques.Smurfs)
                    Win();
                break;
            case "BIOHAZARD":
                if (_ques  == Ques.BioHaz)
                    Win();
                break;
            case "GHOSTBUSTERS":
                if (_ques  == Ques.GhostBusters)
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
                _progress += 33;
                StartCoroutine(ShowProgress(_progress));
                if (_progress >= 99)
                {
                    level++;
                    tries++;
                }
                
                Invoke(nameof(Play), 10);
                
                break;
            case 2:
                Terminal.ClearScreen();
                Terminal.WriteLine("Firewall Breached");
                Terminal.WriteLine("Security Breach Detected");
                Terminal.WriteLine("System Shutdown in progress. . . .");
                _progress += 50;
                StartCoroutine(ShowProgress(_progress));
                if (_progress >= 99)
                {
                    level++;
                    tries+=2;
                }
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
        SelectQuestion();
        /*if (level == 1)
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
        }*/
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