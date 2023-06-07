﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Závěrečný_projekt___Launcher_Login_Saver
{
    public class Launchers
    {
        public int Choose { get; set; }
        private string[] pole;
        public string[] Pole
        {
            get { return pole; }
            set { pole = value; }
        }
        private string[] poles;
        public string[] Poles
        {
            get { return poles; }
            set { poles = value; }
        }
        public Launchers()
        {
            pole = new string[8];
            poles = new string[8] { "Steam", "Ubisoft", "Origin", "BattleNet", "Epic Games", "Discord", "Twitch", "Only Fans" };
        }
        public Launchers(int choose)
        {
            this.Choose = choose;
        }
        public void WriteDown()
        {
            Console.Clear();
            LoginPlatform info = new LoginPlatform();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("           MENU PLATFORM");
            Console.WriteLine("-----------------------------------");
            Console.ResetColor();
            foreach (string e in poles)
            {
                int pozice = Array.IndexOf(poles, e);
                Console.WriteLine(pozice + 1 + ") " + e);
            }
            try
            {

                Console.WriteLine("-------------------------------------------");
                Console.Write("Vyber číslo platformy kterou chceš doplnit: ");
                int choose = int.Parse(Console.ReadLine());
                Console.WriteLine("-------------------------------------------");
                Console.Write("Napiš jméno: ");
                string inputName = Console.ReadLine();
                Console.Write("Napiš heslo: ");
                string inputPassword = Console.ReadLine();
                info.Name = inputName;
                info.Password = inputPassword;
                pole[choose - 1] = $"{info.Name},{info.Password}";
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Chyba: " + ex.Message);
                Console.ResetColor();
            }
        }
        public void ChooseInventory()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("           MENU PLATFORM");
            Console.WriteLine("-----------------------------------");
            Console.ResetColor();
            foreach (string e in poles)
            {

                int pozice = Array.IndexOf(poles, e);
                Console.WriteLine(pozice + 1 + ") " + e);
            }
            try
            {
                Console.WriteLine("-----------------------------------");
                Console.Write("Vyber si platformu o které budou vypsané infomace: ");
                int chosInventory = int.Parse(Console.ReadLine());
                if (pole[chosInventory - 1] == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Tato platforma nebyla doplněna");
                    Console.WriteLine("-----------------------------------");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("-----------------------------------");
                    string[] bozongas = pole[chosInventory - 1].Split(",");
                    Console.WriteLine("Jméno:");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(bozongas[0]);
                    Console.ResetColor();
                    Console.WriteLine("Heslo:");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(bozongas[1]);
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }
        public void InventoryShow()
        {
            Console.Clear();
            int i = 0;
            foreach (string e in pole)
            {
                if (e == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(poles[i] + ": " + "nezadáno");
                    Console.ResetColor();
                }
                else
                {
                    string[] karte = e.Split(",");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{poles[i]}: Jméno: {karte[0]}, Heslo: {karte[1]}");
                    Console.ResetColor();
                }
                i++;
            }
        }
        public void Save(string uloziste)
        {
            LoginPlatform loginPlatform = new LoginPlatform();
            try
            {
                using (StreamWriter writer = new StreamWriter(uloziste))
                {
                    string line = $"{loginPlatform.Name},{loginPlatform.Password}";
                }  
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
        }
        public void Load(string uloziste)
        {
            LoginPlatform loginPlatform = new LoginPlatform();
            try
            {
                if(File.Exists(uloziste))
                {
                    using (StreamReader reader = new StreamReader(uloziste))
                    {
                        string line;
                        int i = 0;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] parts = line.Split(",");
                            if (parts.Length == 2)
                            {
                                loginPlatform.Name = parts[0];
                                loginPlatform.Password = parts[1];
                                foreach (var e in pole)
                                {
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Uložistě nenalezeno");
                }
                
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
        }
    }
}

