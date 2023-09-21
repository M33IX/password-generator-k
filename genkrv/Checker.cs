using System;
using System.Collections.Generic;
using System.Text;

namespace genkrv
{
    internal class Checker
    {
        short[] repeatsArray = new short[1500];

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
                            //Todo написать регулярки
                            case 1:
                                break;
                            case 2:
                                break;
                            case 4:
                                break;
                            case 8:
                                break;
                            case 16:
                                break;
                            case 32:
                                break;
                            case 64:
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
                    //Todo Написать регулярки
                    case 1:
                        break;
                    case 2:
                        break;
                    case 4:
                        break;
                    case 8:
                        break;
                    case 16:
                        break;
                    case 32:
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
