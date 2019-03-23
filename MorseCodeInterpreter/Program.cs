using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MorseCodeInterpreter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MorseCodeInterpreter mc = new MorseCodeInterpreter();
            Console.WriteLine(mc.DecodeMorse(mc.GenMorseMessage("ab ba")));
        }
    }

    public class Dot
    {
        public Dot()
        {

        }
    }

    public class Dash : Dot
    {
        public Dash()
        {

        }
    }

    public class MorseCodeInterpreter
    {
        internal readonly Dictionary<string, List<Dot>> dictionary = new Dictionary<string, List<Dot>>();
        public MorseCodeInterpreter()
        {
            GenMorseDictionary();
        }
        internal List<List<Dot>> GenMorseMessage(string textMessage)
        {
            List<List<Dot>> message = new List<List<Dot>>();
            foreach (char character in textMessage)
            {
                List<Dot> morse = new List<Dot>();
                if (character.ToString().Equals(" "))
                { 
                    dictionary.TryGetValue("wordSpace", out morse);
                }
                else
                {
                    dictionary.TryGetValue(character.ToString().ToLower(), out morse);
                }
                dictionary.TryGetValue("letterSpace", out List<Dot> ls);
                message.Add(morse);
            }
            return message;
        }

        internal void GenMorseDictionary()
        {            
            List<Dot> letterSpace = new List<Dot>() { null };
            List<Dot> wordSpace = new List<Dot>() { null, null, null };
            List<Dot> a = new List<Dot>() { new Dot(), new Dash() };
            List<Dot> b = new List<Dot>() { new Dash(), new Dot(), new Dot(), new Dot() };

            dictionary.Add("letterSpace", letterSpace);
            dictionary.Add("wordSpace", wordSpace);
            dictionary.Add("a", a);
            dictionary.Add("b", b);
        }

        internal string DecodeMorse(List<List<Dot>> message)
        {
            StringBuilder messageString = new StringBuilder();

            foreach (var unit in message)
            {
                dictionary.TryGetValue("letterSpace", out List<Dot> value);
                if (unit != value)
                {
                    dictionary.TryGetValue("wordSpace", out value);
                    if (unit == value)
                    {
                        messageString.Append(" ");
                    }
                    else
                    {
                        messageString.Append(dictionary.FirstOrDefault(x => x.Value == unit).Key);
                    }
                }
            }
            return messageString.ToString();
        }
    }
}
