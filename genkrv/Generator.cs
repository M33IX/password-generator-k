using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;

namespace genkrv
{
    internal class Generator
    {
        private char[] alph = new char[] {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
    'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
            'А','Б','В','Г','Д','Е','Ё','Ж','З','И','Й','К','Л','М','Н','О','П','Р','С','Т','У','Ф','Х','Ц','Ч','Ш','Щ','Ъ','Ы','Ь','Э','Ю','Я',
            'а','б','в','г','д','е','ё','ж','з','и','й','к','л','м','н','о','п','р','с','т','у','ф','х','ц','ч','ш','щ','ъ','ь','ы','э','ю','я',
            '0','1','2','3','4','5','6','7','8','9',
            '!','#','$','%','&','(',')','*','+','-','=','.',',','/','<','>','?','@','[',']','^','_','`','{','}','|','~'};

        public int getAphabetLength() {
            return alph.Length;
        }

        public string generatePassword(int length) {
            StringBuilder password = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i < length; i++) {
                int index = random.Next(length - 1);
                password.Append(alph[index]);
            }
            return password.ToString();
        }

    }
}
