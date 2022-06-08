using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XlsxTests
{
    public static class EncDecClass
    {
        //Два словаря для кодирование и декодирования текста
        static Dictionary<string, string> decodeCodes = new Dictionary<string, string>()
        {
            {"81","~" },
            {"82","}" },
            {"83","|"},
            {"84","{"},
            {"85","z"},
            {"86","y"},
            {"87","x"},
            {"88","w"},
            {"89","v"},
            {"8A","u"},
            {"8B","t"},
            {"8C","s"},
            {"8D","r"},
            {"8E","q"},
            {"8F","p"},
            {"90","o"},
            {"91","n"},
            {"92","m"},
            {"93","l"},
            {"94","k"},
            {"95","j"},
            {"96","i"},
            {"97","h"},
            {"98","g"},
            {"99","f"},
            {"9A","e"},
            {"9B","d"},
            {"9C","c"},
            {"9D","b"},
            {"9E","a"},
            {"A0","_"},
            {"A1","^"},
            {"A2","]"},
            {"A3","?"},
            {"A4","["},
            {"A5","Z"},
            {"A6","Y"},
            {"A7","X"},
            {"A8","W"},
            {"A9","V"},
            {"AA","U"},
            {"AB","T"},
            {"AC","S"},
            {"AD","R"},
            {"AE","Q"},
            {"AF","P"},
            {"B0","O"},
            {"B1","N"},
            {"B2","M"},
            {"B3","L"},
            {"B4","K"},
            {"B5","J"},
            {"B6","I"},
            {"B7","H"},
            {"B8","G"},
            {"B9","F"},
            {"BA","E"},
            {"BB","D"},
            {"BC","C"},
            {"BD","B"},
            {"BE","A"},
            {"BF","@"},
            {"C0","?"},
            {"C1",">"},
            {"C2","="},
            {"C3","<"},
            {"C4",";"},
            {"C5",":"},
            {"C6","9"},
            {"C7","8"},
            {"C8","7"},
            {"C9","6"},
            {"CA","5"},
            {"CB","4"},
            {"CC","3"},
            {"CD","2"},
            {"CE","1"},
            {"CF","0"},
            {"D0","/"},
            {"D1","."},
            {"D2","-"},
            {"D3",","},
            {"D4","+"},
            {"D5","*"},
            {"D6",")"},
            {"D7","("},
            {"D8","'"},
            {"D9","&"},
            {"DA","%"},
            {"DB","$"},
            {"DC","#"},
            {"DD","\u0022"},
            {"DE","!" },
            {"DF"," "},
            {"F5", "\r\n" },
};
        static Dictionary<string, string> encodeCodes = new Dictionary<string, string>()
        {
            {"81", "з"},
            {"82", "}"},
            {"83", "|"},
            {"84", "{"},
            {"85", "г"},
            {"86", "у"},
            {"87", "х"},
            {"88", "ж"},
            {"89", "ц"},
            {"8A", "ю"},
            {"8B", "т"},
            {"8C", "ь"},
            {"8D", "я"},
            {"8E", "э"},
            {"8F", "р"},
            {"90", "ф"},
            {"91", "и"},
            {"92", "м"},
            {"93", "л"},
            {"94", "к"},
            {"95", "п"},
            {"96", "б"},
            {"97", "н"},
            {"98", "ш"},
            {"99", "ы"},
            {"9A", "е"},
            {"9B", "д"},
            {"9C", "с"},
            {"9D", "в"},
            {"9E", "а"},
            {"A0", "_"},
            {"A1", "ч"},
            {"A2", "]"},
            {"A3", "о"},
            {"A4", "["},
            {"A5", "Г"},
            {"A6", "У"},
            {"A7", "Х"},
            {"A8", "Ж"},
            {"A9", "Ц"},
            {"AA", "Ю"},
            {"AB", "Т"},
            {"AC", "Ь"},
            {"AD", "Я"},
            {"AE", "Э"},
            {"AF", "Р"},
            {"B0", "Ф"},
            {"B1", "И"},
            {"B2", "М"},
            {"B3", "Л"},
            {"B4", "К"},
            {"B5", "П"},
            {"B6", "Б"},
            {"B7", "Н"},
            {"B8", "Ш"},
            {"B9", "Ы"},
            {"BA", "Е"},
            {"BB", "Д"},
            {"BC", "С"},
            {"BD", "В"},
            {"BE", "А"},
            {"BF", "@"},
            {"C0", "?"},
            {"C1", ">"},
            {"C2", "="},
            {"C3", "<"},
            {"C4", ";"},
            {"C5", ":"},
            {"C6", "9"},
            {"C7", "8"},
            {"C8", "7"},
            {"C9", "6"},
            {"CA", "5"},
            {"CB", "4"},
            {"CC", "3"},
            {"CD", "2"},
            {"CE", "1"},
            {"CF", "0"},
            {"D0", "/"},
            {"D1", "."},
            {"D2", "-"},
            {"D3", ","},
            {"D4", "+"},
            {"D5", "*"},
            {"D6", ")"},
            {"D7", "("},
            {"D8", "'"},
            {"D9", "&"},
            {"DA", "%"},
            {"DB", "$"},
            {"DC", "#"},
            {"DD", "\u0022"},
            {"DE", "!"},
            {"DF", " " },
        };

        public static string EncodeString(string text)
        {
            string encodeText = String.Empty;
            string charsFromTextBox;
            string formattedText =   text.Replace("О", "0"); //В алфавите нет данных букв, поэтому нужно заменять
            formattedText = formattedText.Replace("Ч", "4");
            formattedText = formattedText.Replace("Й", "И");
            formattedText = formattedText.Replace("Щ", "Ш");
            formattedText = formattedText.Replace("й", "и");
            formattedText = formattedText.Replace("З", "3");
            formattedText = formattedText.Replace("щ", "ш");
            formattedText = formattedText.Replace("ц", "4");
            formattedText = formattedText.Replace("ъ", "ь");
            formattedText = formattedText.Replace("ё", "е");

            int countTabSymbols = 0;
            int countKeys = 0;
            for (int i = 0; i < formattedText.Length; i++)
            {
                charsFromTextBox = Convert.ToString(formattedText[i]); //Для каждого символа ищем свое значение в словаре
                foreach (var value in encodeCodes)
                {
                    if(charsFromTextBox == "\r" || charsFromTextBox == "\n") //Костыль от бага в интерфейсе, связанного с переносом строки, там где это не нужно было
                    {
                        countTabSymbols++;

                        if(countTabSymbols == 2)
                        {
                            countTabSymbols = 0;
                            break;
                        }

                        encodeText += "F5"; //Символ переноса в игре re: outbreak 
                        break;
                    }
                    if (charsFromTextBox == value.Value)
                    {
                        encodeText += value.Key;
                        break;
                    }

                    countKeys++;
                    if (countKeys == encodeCodes.Count)
                    {
                        countKeys = 0;
                        encodeText += charsFromTextBox;
                        break;
                    }
                }

                countKeys = 0;
            }

            return encodeText;
        }

        public static string DecodeString(string text) //Принцип работы аналогичен методу EncodeString()
        {
            string? decodeText = String.Empty;
            string charsForGetTextBox = String.Empty;

            int countKeys = 0;
            for (int i = 1; i < text.Length; i += 2)
            {
                charsForGetTextBox += text[i - 1];
                charsForGetTextBox += text[i];
                foreach (var code in decodeCodes)
                {
                    if (charsForGetTextBox == code.Key)
                    {
                        decodeText += code.Value;
                        break;
                    }

                    countKeys++;
                    if (countKeys == decodeCodes.Count)
                    {
                        countKeys = 0;
                        decodeText += charsForGetTextBox;
                        break;
                    }
                }

                countKeys = 0;
                charsForGetTextBox = "";
            }

            return decodeText;
        }

        public static string[,] CreateEncodedTable(string[,] table)
        {
            string[,] encodedTable = new string[table.GetLength(0),
                                                table.GetLength(1)];

            for (int raw = 0; raw < table.GetLength(0); raw++)
            {
                for (int column = 0; column < table.GetLength(1); column++)
                {
                    if(column % 2 != 0)
                    {
                        encodedTable[raw, column] = DecodeString(EncodeString(table[raw, column]));   
                    }
                    else 
                    {
                        encodedTable[raw, column] = table[raw,column];
                    }
                }
            }

            return encodedTable;
        }
    }
}
