using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MorseCodeInterpreter
{
    class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, List<Unit>> dict = GenMorseDictionary();
            List<List<Unit>> morseString = GenMorseMessage("we need help", dict);
            string text = DecodeMorse(morseString, dict);
            Console.WriteLine(text);
        }
        static private Dictionary<string, List<Unit>> GenMorseDictionary()
        {
            Dot dot = new Dot();
            Dash dash = new Dash();

            return new Dictionary<string, List<Unit>>()
            {
                {"a", new List<Unit>() { dot, dash }},
                {"b", new List<Unit>() { dash, dot, dot, dot }},
                {"c", new List<Unit>() { dash, dot, dash, dot }},
                {"d", new List<Unit>() { dash, dot }},
                {"e", new List<Unit>() { dot }},
                {"f", new List<Unit>() { dot, dot, dash, dot }},
                {"g", new List<Unit>() { dash, dash, dot }},
                {"h", new List<Unit>() { dot, dot, dot, dot }},
                {"i", new List<Unit>() { dot, dot }},
                {"j", new List<Unit>() { dot, dash, dash, dash }},
                {"k", new List<Unit>() { dash, dot, dash }},
                {"l", new List<Unit>() { dot, dash, dot, dot }},
                {"m", new List<Unit>() { dash, dash }},
                {"n", new List<Unit>() { dash, dot }},
                {"o", new List<Unit>() { dash, dash, dash }},
                {"p", new List<Unit>() { dot, dash, dash, dot }},
                {"q", new List<Unit>() { dash, dash, dot, dash }},
                {"r", new List<Unit>() { dot, dash, dot }},
                {"s", new List<Unit>() { dot, dot, dot }},
                {"t", new List<Unit>() { dash }},
                {"u", new List<Unit>() { dot, dot, dash }},
                {"v", new List<Unit>() { dot, dot, dot, dash }},
                {"w", new List<Unit>() { dot, dash, dash }},
                {"x", new List<Unit>() { dash, dot, dot, dash }},
                {"y", new List<Unit>() { dash, dot, dash, dash }},
                {"z", new List<Unit>() { dash, dash, dot, dot }},
                {"0", new List<Unit>() { dash, dash, dash, dash, dash }},
                {"1", new List<Unit>() { dot, dash, dash, dash, dash }},
                {"2", new List<Unit>() { dot, dot, dash, dash, dash }},
                {"3", new List<Unit>() { dot, dot, dot, dash, dash }},
                {"4", new List<Unit>() { dot, dot, dot, dot, dash }},
                {"5", new List<Unit>() { dot, dot, dot, dot, dot }},
                {"6", new List<Unit>() { dash, dot, dot, dot, dot }},
                {"7", new List<Unit>() { dash, dash, dot, dot, dot }},
                {"8", new List<Unit>() { dash, dash, dash, dot, dot }},
                {"9", new List<Unit>() { dash, dash, dash, dash, dot }},
                {"letterSpace", new List<Unit>() { null }},
                {"wordSpace", new List<Unit>() { null, null, null }}
            };
        }

        private static List<List<Unit>> GenMorseMessage(string textMessage, Dictionary<string, List<Unit>> dict)
        {
            List<List<Unit>> message = new List<List<Unit>>();
            foreach (char character in textMessage)
            {
                List<Unit> morse = new List<Unit>();
                if (character.ToString().Equals(" "))
                {
                    dict.TryGetValue("wordSpace", out morse);
                }
                else
                {
                    dict.TryGetValue(character.ToString().ToLower(), out morse);
                    dict.TryGetValue("letterSpace", out List<Unit> ls);
                    message.Add(ls);
                }
                message.Add(morse);               
            }
            return message;
        }

        private static string DecodeMorse(List<List<Unit>> message, Dictionary<string, List<Unit>> dict)
        {
            StringBuilder messageString = new StringBuilder();

            foreach (var unit in message)
            {
                dict.TryGetValue("letterSpace", out List<Unit> value);
                if (unit != value)
                {
                    dict.TryGetValue("wordSpace", out value);
                    if (unit == value)
                    {
                        messageString.Append(" ");
                    }
                    else
                    {
                        messageString.Append(dict.FirstOrDefault(x => x.Value == unit).Key);
                    }
                }
            }
            return messageString.ToString();
        }
    }
}