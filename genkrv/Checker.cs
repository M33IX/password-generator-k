using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace genkrv
{
    internal class Checker
    {
        //Todo протестить регулярки

        private short[] repeatsArray = new short[1500];
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
            short[] straightRules = new short[] { 1, 2, 4, 8, 16, 32, 64 };
            short[] reverseRules = new short[] { 1, 2, 4, 8, 16, 32, 64 };
            Array.Fill(repeatsArray, (short) 0);
            short ruleSet = rule;
            while (ruleSet > 0)
            {
                for (int i = straightRules.Length - 1; i >= 0; i--)
                {
                    if (straightRules[i] > ruleSet)
                    {
                        straightRules[i] = 0;
                        continue;
                    }
                    if (straightRules[i] <= ruleSet)
                    {
                        ruleSet -= straightRules[i];
                        reverseRules[i] = 0;
                    }//Конец if
                }//Конец for
            }//Конец вайла
            foreach (short straightRule in straightRules)
            {
                switch (straightRule)
                {
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
                        if ((straightRules[0] == straightRules[1]) || (straightRules[0] != 0 && straightRules[1] != 0))
                        {
                            if (!Regex.IsMatch(password, lowerLatinaP) || !Regex.IsMatch(password, lowerCyrP))
                            {
                                return false;
                            }
                        }
                        else if (straightRules[0] == 0)
                        {
                            if (Regex.IsMatch(password, lowerLatinaP)) return false;
                        }
                        else if (Regex.IsMatch(password, lowerCyrP)) return false;
                        break;
                    case 32:
                        if ((straightRules[0] == straightRules[1]) || (straightRules[0] != 0 && straightRules[1] != 0))
                        {
                            if (!Regex.IsMatch(password, upperLatinaP) || !Regex.IsMatch(password, upperCyrP))
                            {
                                return false;
                            }
                        }
                        else if (straightRules[0] == 0)
                        {
                            if (Regex.IsMatch(password, upperLatinaP)) return false;
                        }
                        else if (Regex.IsMatch(password, upperCyrP)) return false;
                        break;
                    case 64:
                        {
                            for (int x = 0; x < password.Length; x++)
                            {
                                repeatsArray[(int)password[x]]++;
                            }
                            foreach (short value in repeatsArray)
                            {
                                if (value > 1) return false;
                            }
                            break;
                        }
                    default:
                        break;
                }//Конец switch
            }//Конец for обработки прямого порядка

            if (reverseRules[4] != 0 && reverseRules[5] != 0)
            {
                reverseRules[4] = 0;
                reverseRules[5] = 0;
            }
            foreach (byte reverseRule in reverseRules)
            {
                switch (reverseRule)
                {
                    case 1:
                        if (Regex.IsMatch(password, latinaP))
                        {
                            return false;
                        }
                        break;
                    case 2:
                        if (Regex.IsMatch(password, cyrP))
                        {
                            return false;
                        }
                        break;
                    case 4:
                        if (Regex.IsMatch(password, digitsP))
                        {
                            return false;
                        }
                        break;
                    case 8:
                        if (Regex.IsMatch(password, specP))
                        {
                            return false;
                        }
                        break;
                    case 16:
                        if ((reverseRules[0] == reverseRules[1]) || (reverseRules[0] != 0 && reverseRules[1] != 0))
                        {
                            if (Regex.IsMatch(password, lowerLatinaP) || Regex.IsMatch(password, lowerCyrP))
                            {
                                return false;
                            }
                        }
                        else if (reverseRules[0] == 0)
                        {
                            if (Regex.IsMatch(password, lowerLatinaP)) return false;
                        }
                        else if (Regex.IsMatch(password, lowerCyrP)) return false;
                        break;
                    case 32:
                        if ((reverseRules[0] == reverseRules[1]) || (reverseRules[0] != 0 && reverseRules[1] != 0))
                        {
                            if (Regex.IsMatch(password, upperLatinaP) || Regex.IsMatch(password, upperCyrP))
                            {
                                return false;
                            }
                        }
                        else if (reverseRules[0] == 0)
                        {
                            if (Regex.IsMatch(password, upperLatinaP)) return false;
                        }
                        else if (Regex.IsMatch(password, upperCyrP)) return false;
                        break;
                    default:
                        break;
                }//Конец switch
            }//Конец for обработки обратного порядка

            return true;
        }
    }
}
