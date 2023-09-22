using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace genkrv
{
    internal class Generator
    {
        private const string latinaL = "abcdefghijklmnopqrstuvwxyz";
        private const string latinaU = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string cyrL = "абвгдеёжзийклмнопрстуфхцчшщъьыэюя";
        private const string cyrU = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        private const string digits = "0123456789";
        private const string spec = "!#$%&()*+-=.,/<>?@[]^_`{}|~";
        private const string latina = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string cyr = "абвгдеёжзийклмнопрстуфхцчшщъьыэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

        private string alphabet = "";

        private bool noRepeats = false;

        public byte alphabetLength() { 
            return Convert.ToByte(alphabet.Length);
        }
        private void generateAlphabet(byte rule) {
            alphabet = "";
            byte[] rules = new byte[] { 1, 2, 4, 8, 16, 32, 64 };
            short ruleSet = rule;
            while (ruleSet > 0) {
                for (int i = rules.Length - 1; i >= 0; i--)
                {
                    if (rules[i] > ruleSet) rules[i] = 0;
                    if (rules[i] <= ruleSet) ruleSet -= rules[i];
                }
            }
                for (int i = 0; i < rules.Length; i++)
                {
                    switch (rules[i])
                    {
                        case 1:
                            if ((rules[4] == 0 && rules[5] == 0) || (rules[4] != 0 && rules[5] != 0))
                            {
                                alphabet += latina;
                                break;
                            }
                            if (rules[4] != 0) {
                                alphabet += latinaL;
                            }
                            if (rules[5] != 0) {
                                alphabet += latinaU;
                            }
                            break;
                        case 2:
                            if ((rules[4] == 0 && rules[5] == 0) || (rules[4] != 0 && rules[5] != 0))
                            {
                                alphabet += cyr;
                                break;
                            }
                            if (rules[4] != 0)
                            {
                                alphabet += cyrL;
                            }
                            if (rules[5] != 0)
                            {
                                alphabet += cyrU;
                            }
                            break;
                        case 4:
                            alphabet += digits;
                            break;
                        case 8:
                            alphabet += spec;
                            break;
                        case 64:
                            noRepeats = true;
                        break;
                        default:
                            break;
                    }//Конец свича
                }//Конец цикла формирования алфавита
        }//Конец метода

        public string generatePassword(short length, byte rule) {
            generateAlphabet(rule);
            if (length > alphabetLength()) length = alphabetLength();
            StringBuilder password = new StringBuilder();
            Random random = new Random();
            if (noRepeats) {
                HashSet<char> usedChars = new HashSet<char>();
                for (int i = 0; i < length; i++)
                {
                    int index = random.Next(alphabetLength());
                    char nextChar = alphabet[index];
                    if (!usedChars.Contains(nextChar))
                    {
                        password.Append(alphabet[index]);
                        usedChars.Add(nextChar);
                    }
                }
            }
            else { 
            for (int i = 0; i < length; i++)
            {
                int index = random.Next(alphabetLength());
                char nextChar = alphabet[index];
                password.Append(alphabet[index]);
            } 
        }
            return password.ToString();
        }
    }
}
