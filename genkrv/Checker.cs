using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace genkrv
{
    internal class Checker
    {
        //Todo протестить регулярки

        short[] repeatsArray = new short[1500];
        //Посмотреть чар коды латиницы и оптимизировать массив
        const string latinaP = @"[A-Za-z]";
        const string cyrP = @"[А-Яа-я]";
        const string digitsP = @"[0-9]";
        const string specP = @"[!#\$%&\(\)\*\+\-=\.,/<>?@\[\]\^_`\{\}\|~]";
        const string lowerLatinaP = @"[a-z]";
        const string lowerCyrP = @"[а-я]";
        const string upperLatinaP = @"[A-Z]";
        const string upperCyrP = @"[А-Я]";
        public bool check(byte rule, string password) {
            short[] rules = new short[] { 1, 2, 4, 8, 16, 32, 64 };
            Array.Fill(repeatsArray, (short) 0);
            short ruleSet = rule;
            while (ruleSet > 0) {
                for (int i = rules.Length - 1; i >= 0; i--) {
                    if (rules[i] > ruleSet) continue;
                    if (rules[i] <= ruleSet) {
                        short currentRule = rules[i];
                        ruleSet -= rules[i];
                        rules[i] = 0;
                        switch (currentRule) {
                            case 1:
                                if (!Regex.IsMatch(password, latinaP)) return false;
                                break;
                            case 2:
                                if (!Regex.IsMatch(password, cyrP)) return false;
                                break;
                            case 4:
                                if (!Regex.IsMatch(password, digitsP)) return false;
                                break;
                            case 8:
                                if (!Regex.IsMatch(password, specP)) return false;
                                break;
                            case 16:
                                if (rules[0] == rules[1]) {
                                    if (!Regex.IsMatch(password, lowerLatinaP) || !Regex.IsMatch(password, lowerCyrP)) return false;
                                    else { 
                                        if (rules[0] == 0) if (!Regex.IsMatch(password, lowerLatinaP)) return false;
                                        else if (!Regex.IsMatch(password, lowerCyrP)) return false;
                                    }
                                }
                                break;
                            case 32:
                                if (rules[0] == rules[1])
                                {
                                    if (!Regex.IsMatch(password, upperLatinaP) || !Regex.IsMatch(password, upperCyrP)) return false;
                                    else
                                    {
                                        if (rules[0] == 0) if (!Regex.IsMatch(password, upperLatinaP)) return false;
                                            else if (!Regex.IsMatch(password, upperCyrP)) return false;
                                    }
                                }
                                break;
                            case 64:
                                for (int x = 0; x < password.Length; x++) {
                                    repeatsArray[(int)password[x]]++;
                                }
                                for (short x = 0; x < repeatsArray.Length; x++) { 
                                    if (repeatsArray[x] > 1) return false;
                                }
                                break;
                             default:
                                break;
                        }//Конец свича
                    }//Конец вилки при совпадении условия
                }//Конец цикла по массиву
            }//Конец вайла
            if (rules[4] != 0 && rules[5] != 0)
            {
                rules[4] = 0;
                rules[5] = 0;
            } //Конец условия
            for (short i = 0; i < rules.Length; i++) { 
                switch (rules[i]) {
                    case 1:
                        if (Regex.IsMatch(password, latinaP)) return false;
                        break;
                    case 2:
                        if (Regex.IsMatch(password, cyrP)) return false;
                        break;
                    case 4:
                        if (Regex.IsMatch(password, digitsP)) return false;
                        break;
                    case 8:
                        if (Regex.IsMatch(password, specP)) return false;
                        break;
                    case 16:
                        if (rules[0] == rules[1])
                        {
                            if (Regex.IsMatch(password, lowerLatinaP) || Regex.IsMatch(password, lowerCyrP)) return false;
                            else
                            {
                                if (rules[0] == 0) if (Regex.IsMatch(password, lowerLatinaP)) return false;
                                    else if (Regex.IsMatch(password, lowerCyrP)) return false;
                            }
                        }
                        break;
                    case 32:
                        if (rules[0] == rules[1])
                        {
                            if (Regex.IsMatch(password, upperLatinaP) || Regex.IsMatch(password, upperCyrP)) return false;
                            else
                            {
                                if (rules[0] == 0) if (Regex.IsMatch(password, upperLatinaP)) return false;
                                    else if (Regex.IsMatch(password, upperCyrP)) return false;
                            }
                        }
                        break;
                    case 64:
                        break;
                    default:
                        break;
                }//Конец свича
            }//Конец for

            return true;
        }
    }
}
