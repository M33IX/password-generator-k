using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace genkrv
{
    internal class Generator
    {/*
        //Todo разбить алфавиты на несколько
        /*
        private char[] alph = new char[] {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
    'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
            'А','Б','В','Г','Д','Е','Ё','Ж','З','И','Й','К','Л','М','Н','О','П','Р','С','Т','У','Ф','Х','Ц','Ч','Ш','Щ','Ъ','Ы','Ь','Э','Ю','Я',
            'а','б','в','г','д','е','ё','ж','з','и','й','к','л','м','н','о','п','р','с','т','у','ф','х','ц','ч','ш','щ','ъ','ь','ы','э','ю','я',
            '0','1','2','3','4','5','6','7','8','9',
            '!','#','$','%','&','(',')','*','+','-','=','.',',','/','<','>','?','@','[',']','^','_','`','{','}','|','~'};
        
        //Todo придумать алгоритм переключения между алфавитами в зависимости от сета правил
        //Todo алгоритм рассчета алфавита в зависимости от правил
        //Стринговый алфавит
        //Стандартный алфавит и массив рабочих значений
        private char[] latinaL = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        private char[] latinaU = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        private char[] cyrL = new char[] { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ь', 'ы', 'э', 'ю', 'я' };
        private char[] cyrU = new char[] { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я' };
        private char[] digits = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private char[] spec = new char[] { '!', '#', '$', '%', '&', '(', ')', '*', '+', '-', '=', '.', ',', '/', '<', '>', '?', '@', '[', ']', '^', '_', '`', '{', '}', '|', '~' };

        public int getAphabetLength() {
            return alph.Length;
        }
        //Todo добавить механизм слияния алфавитов
        //Todo добавить механизм генерации без повторов
        public string generatePassword(int length) {
            StringBuilder password = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i < length; i++) {
                int index = random.Next(length - 1);
                password.Append(alph[index]);
            }
            return password.ToString();
        }
        */

        //Todo провести тесты
        //Todo свзяать с формой
        private const string latinaL = "abcdefghijklmnopqrstuvwxyz";
        private const string latinaU = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string cyrL = "абвгдеёжзийклмнопрстуфхцчшщъьыэюя";
        private const string cyrU = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        private const string digits = "0123456789";
        private const string spec = "!#$%&()*+-=.,/<>?@[]^_`{}|~";
        private const string latina = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string cyr = "абвгдеёжзийклмнопрстуфхцчшщъьыэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

        private string alphabet = "";

        public byte alphabetLength() { 
            return Convert.ToByte(alphabet.Length);
        }
        private void generateAlphabet(byte rule) {
            alphabet = "";
            byte[] rules = new byte[] { 1, 2, 4, 8, 16, 32 };
            while (rule > 0) {
                for (int i = rules.Length - 1; i >= 0; i--)
                {
                    if (rules[i] > rule) rules[i] = 0;
                    if (rules[i] <= rule)
                    {
                        rule -= rules[i];
                        //continue;
                    }
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
                        default:
                            break;
                    }//Конец свича
                }//Конец 
        }//Конец метода

        public string generatePassword(short length, bool noRepeats) {
            StringBuilder password = new StringBuilder();
            Random random = new Random();
            if (noRepeats) {
                for (int i = 0; i < length; i++)
                {
                    int index = random.Next(alphabetLength() - 1);
                    password.Append(alphabet[index]);
                    alphabet = alphabet.Remove(alphabet[index], 1);
                }
            }
            else { 
            for (int i = 0; i < length; i++)
            {
                int index = random.Next(alphabetLength() - 1);
                password.Append(alphabet[index]);
            } 
        }
            return password.ToString();
        }
    }
}
