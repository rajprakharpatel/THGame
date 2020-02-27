using System;
using System.Text;
using static System.Security.Cryptography.RandomNumberGenerator;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using System.Timers;
using UnityEngine.Analytics;
using UnityEngine.Networking;
using Random = System.Random;

public class Hacker : MonoBehaviour
{
    int _level = 1;
    int _tries = 3;
    private int _progress = 0;
    private int _quesNo = 1;
    //int[] _qDone = {0,0,0,0,0,0,0,0,0,0,0,0};

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

    private enum Screen
    {
        MainScreen,
        Play,
        HighScores
    };

    private Screen _currentScreen, _previousScreen;

    private void OnUserInput(string input)
    {
        int l = input.Length;
        if (input == "menu")
            ShowMainMenu();
        else if (l >= 5 && input.Substring(0, 5).ToUpper() == "FORCE")
        {
            _level = 100;
            NewHighScore(input.Substring(startIndex: 14));
        }
        else switch (_currentScreen)
        {
            case Screen.MainScreen:
                RunMainMenu(input);
                break;
            case Screen.Play:
                CheckAnswer(input);
                break;
            case Screen.HighScores:
                NewHighScore(input);
                break;
            default:
                Terminal.WriteLine("Hello There");
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
            switch (_level)
            {
                case 1:
                    Terminal.WriteLine(".______   .______        ______     _______ .______       _______     _______.     _______.");
                    Terminal.WriteLine("|   _  \\  |   _  \\      /  __  \\   /  _____||   _  \\     |   ____|   /       |    /       |");
                    Terminal.WriteLine("|  |_)  | |  |_)  |    |  |  |  | |  |  __  |  |_)  |    |  |__     |   (----`   |   (----`");
                    Terminal.WriteLine("|   ___/  |      /     |  |  |  | |  | |_ | |      /     |   __|     \\   \\        \\   \\    ");
                    Terminal.WriteLine("|  |      |  |\\  \\----.|  `--\'  | |  |__| | |  |\\  \\----.|  |____.----)   |   .----)   |   ");
                    Terminal.WriteLine("| _|      | _| `._____| \\______/   \\______| | _| `._____||_______|_______/    |_______/ \n   ");

                    Terminal.WriteLine(" __       _______ ____    ____  _______  __          __  ");
                    Terminal.WriteLine("|  |     |   ____|\\   \\  /   / |   ____||  |        /_ |"); 
                    Terminal.WriteLine("|  |     |  |__    \\   \\/   /  |  |__   |  |         | |"); 
                    Terminal.WriteLine("|  |     |   __|    \\      /   |   __|  |  |         | | ");
                    Terminal.WriteLine("|  `----.|  |____    \\    /    |  |____ |  `----.    | | ");
                    Terminal.WriteLine("|_______||_______|    \\__/     |_______||_______|    |_| ");
                    break;
                
                case 2:
                    Terminal.WriteLine(".______   .______        ______     _______ .______       _______     _______.     _______.");
                    Terminal.WriteLine("|   _  \\  |   _  \\      /  __  \\   /  _____||   _  \\     |   ____|   /       |    /       |");
                    Terminal.WriteLine("|  |_)  | |  |_)  |    |  |  |  | |  |  __  |  |_)  |    |  |__     |   (----`   |   (----`");
                    Terminal.WriteLine("|   ___/  |      /     |  |  |  | |  | |_ | |      /     |   __|     \\   \\        \\   \\    ");
                    Terminal.WriteLine("|  |      |  |\\  \\----.|  `--\'  | |  |__| | |  |\\  \\----.|  |____.----)   |   .----)   |   ");
                    Terminal.WriteLine("| _|      | _| `._____| \\______/   \\______| | _| `._____||_______|_______/    |_______/   \n ");

                    Terminal.WriteLine(" __       _______ ____    ____  _______  __          ___   ");
                    Terminal.WriteLine("|  |     |   ____|\\   \\  /   / |   ____||  |        |__ \\ ");
                    Terminal.WriteLine("|  |     |  |__    \\   \\/   /  |  |__   |  |           ) | ");
                    Terminal.WriteLine("|  |     |   __|    \\      /   |   __|  |  |          / /  ");
                    Terminal.WriteLine("|  `----.|  |____    \\    /    |  |____ |  `----.    / /_  ");
                    Terminal.WriteLine("|_______||_______|    \\__/     |_______||_______|   |____| ");
                    break;
                case 3:
                    Terminal.WriteLine(".______   .______        ______     _______ .______       _______     _______.     _______.");
                    Terminal.WriteLine("|   _  \\  |   _  \\      /  __  \\   /  _____||   _  \\     |   ____|   /       |    /       |");
                    Terminal.WriteLine("|  |_)  | |  |_)  |    |  |  |  | |  |  __  |  |_)  |    |  |__     |   (----`   |   (----`");
                    Terminal.WriteLine("|   ___/  |      /     |  |  |  | |  | |_ | |      /     |   __|     \\   \\        \\   \\    ");
                    Terminal.WriteLine("|  |      |  |\\  \\----.|  `--\'  | |  |__| | |  |\\  \\----.|  |____.----)   |   .----)   |   ");
                    Terminal.WriteLine("| _|      | _| `._____| \\______/   \\______| | _| `._____||_______|_______/    |_______/  \n ");

                    Terminal.WriteLine(" __       _______ ____    ____  _______  __          ____   ");
                    Terminal.WriteLine("|  |     |   ____|\\   \\  /   / |   ____||  |        |___ \\");  
                    Terminal.WriteLine("|  |     |  |__    \\   \\/   /  |  |__   |  |          __) |"); 
                    Terminal.WriteLine("|  |     |   __|    \\      /   |   __|  |  |         |__ <  ");
                    Terminal.WriteLine("|  `----.|  |____    \\    /    |  |____ |  `----.    ___) | ");
                    Terminal.WriteLine("|_______||_______|    \\__/     |_______||_______|   |____/  ");
                    break;
            }
            string str = "";
            int j = 0;
            for (j = 0; j < i; j++)
                str += "█";
            Terminal.WriteLine("\n");
            Terminal.WriteLine(str + (j+1) + "%");
            yield return new WaitForSeconds(0.05f);
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

    /*bool CheckIfQDone(int q)
    {
        for (int i = 0; i < _qDone.Length; i++)
        {
            if (q == i)
            {
                return true;
            }
        }

        return false;
    }*/

    void SelectQuestion()
    {
        Random random = new Random();
        Terminal.ClearScreen();
        switch (_quesNo)
        {
            case 1:
                Terminal.WriteLine("First you have to shut down the safety measures \n Identify the Character");
                break;
            case 2:
                Terminal.WriteLine("Identify the Character");
                break;
            case 3:
                Terminal.WriteLine("Identify the Character");
                break;
            case 4:
                Terminal.WriteLine("Security Measures Shut Down");
                Terminal.WriteLine("Breach the Firewall to access files");
                Terminal.WriteLine("Identify the Symbol");
                break;
            case 5:
                Terminal.WriteLine("Identify the Symbol");
                break;
            case 6:
                Terminal.WriteLine("Firewall Breached");
                Terminal.WriteLine("Security Breach Detected");
                Terminal.WriteLine("Prevent System Shutdown . . . .");
                break;
            default:
                Terminal.WriteLine("Identify the symbol");
                break;
        }
        switch (_level)
        {
            case 1:
                int rand1 = random.Next(1,6);
                //if(CheckIfQDone(rand1))
                //SelectQuestion();
                switch (rand1)
                {
                    case 1:
                        //_qDone[0] = 1;
                        _ques = Ques.Casper;
                        StartCoroutine(DrawFigure("Assets/Figures/casper.txt"));
                        break;
                    case 2:
                        //_qDone[1] = 2;
                        _ques = Ques.Homer;
                        StartCoroutine(DrawFigure("Assets/Figures/Homer.txt"));
                        break;
                    case 3:
                        //_qDone[2] = 3;
                        _ques = Ques.AtBomb;
                        StartCoroutine(DrawFigure("Assets/Figures/AtBombman.txt"));
                        break;
                    case 4:
                        //_qDone[3] = 4;
                        _ques = Ques.Smurfs;
                        StartCoroutine(DrawFigure("Assets/Figures/Smurfs.txt"));
                        break;
                    case 5:
                        //_qDone[4] = 5;
                        _ques = Ques.Sonic;
                        StartCoroutine(DrawFigure("Assets/Figures/sonic.txt"));
                        break;
                }
                break;

                case 2:
                int rand2 = random.Next(6,10);
                //if(CheckIfQDone(rand2))
                //    SelectQuestion();
                switch (rand2)
                {
                    case 6:
                        //_qDone[0] = 6;
                        _ques = Ques.BioHaz;
                        StartCoroutine(DrawFigure("Assets/Figures/BioHaz.txt"));
                        break;
                    case 7:
                        //_qDone[1] = 7;
                        _ques = Ques.Peace;
                        StartCoroutine(DrawFigure("Assets/Figures/peace.txt"));
                        break;
                    case 8:
                        //_qDone[2] = 8;
                        _ques = Ques.HitMan;
                        StartCoroutine(DrawFigure("Assets/Figures/Hit.txt"));
                        break;
                    case 9:
                        //_qDone[3] = 9;
                        _ques = Ques.Volks;
                        StartCoroutine(DrawFigure("Assets/Figures/Volks.txt"));
                        break;
                }
                break;

                case 3:
                int rand3 = random.Next(10,13);
                //if(CheckIfQDone(rand3))
                 //   SelectQuestion();
                switch (rand3)
                {
                    case 10:
                        //_qDone[0] = 10;
                        _ques = Ques.SquidWard;
                        StartCoroutine(DrawFigure("Assets/Figures/Squidward.txt"));
                        break;
                    case 11:
                        //_qDone[1] = 11;
                        _ques = Ques.Popoye;
                        StartCoroutine(DrawFigure("Assets/Figures/Popoye.txt"));
                        break;
                    case 12:
                        //_qDone[3] = 12;
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
            case "SMURFET":
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
        if (_tries > 0)
        {
            switch (_level)
            {
                case 1:
                    _tries--;
                    Terminal.WriteLine("WRONG... \n" + (_tries + 1) + " chances left \n" +
                                       " Try Again");
                    break;
                case 2:
                    _tries--;
                    Terminal.WriteLine("WRONG... \n" + (_tries + 1) + " chances left \n" +
                                       " Try Again");
                    break;
                case 3:
                    _tries--;
                    Terminal.WriteLine("WRONG... \n" + (_tries + 1) + " chances left \n" +
                                       " Try Again");
                    break;
            }
        }
        else
        {
            StartCoroutine(DrawFigure("Assets/Figures/GameOver.txt"));
            StartCoroutine(DrawDots(5));
            _previousScreen = Screen.Play;
            Invoke(nameof(HighScores), 5);
        }
    }

    private void LevelUp()
    {
        if (_progress < 99) return;
        _level++;
        _progress = 0;
    }
    void Win()
    {
        switch (_level)
        {
            case 1:
                Terminal.ClearScreen();
                StartCoroutine(DrawDots(5));
                _progress += 33;
                StartCoroutine(ShowProgress(_progress));
                Invoke(nameof(LevelUp), 8);
                _tries++;
                Invoke(nameof(Play), 8);
                break;
            case 2:
                Terminal.ClearScreen();
                StartCoroutine(DrawDots(5));
                _progress += 50;
                StartCoroutine(ShowProgress(_progress));
                Invoke(nameof(LevelUp), 8);
                _tries++;
                Invoke(nameof(Play), 8);
                break;
            case 3:
                Terminal.ClearScreen();
                Terminal.WriteLine("System shutdown successfully stopped");
                Terminal.WriteLine("Full Access Granted  . . . .");
                StartCoroutine(DrawFigure("Assets/Figures/GFinished.txt"));
                Invoke(nameof(HighScores), 8);
                break;
        }
        _quesNo++;
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
            StartCoroutine(DrawDots(3));
            Invoke(nameof(Exit), 5);
        }
    }

    void Exit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    void NewHighScore(string inp)
    {
        _previousScreen = _currentScreen;
        string str = inp + "------------------------------------------" + (_level*10+_tries*5);
        File.AppendAllText("Assets/HighScores.txt", str + Environment.NewLine);
        HighScores();
    }
    void HighScores()
    {
        if (_previousScreen == Screen.Play)
            Terminal.WriteLine("Enter Your name");
        else
            StartCoroutine(DrawFigure("Assets/HighScores.txt"));
        _previousScreen = _currentScreen;
        _currentScreen = Screen.HighScores;
    }

    void Play()
    {
        _previousScreen = _currentScreen;
        _currentScreen = Screen.Play;
        SelectQuestion();
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
        _currentScreen = Screen.MainScreen;
        _previousScreen = _currentScreen;
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