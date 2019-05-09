//By Saeed Shirvani

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HuffmanCoder
{
    class Program
    {
        private static List<HuffmanNode> NodeList = new List<HuffmanNode>();
        private static Dictionary<char, string> CodingDictonary = new Dictionary<char, string>();
        static void Main(string[] args)
        {
            Console.Write("Please type your text and press Enter: ");
            string text = Console.ReadLine();

            if (text == string.Empty)
                return;

            //Add first char to list
            NodeList.Add(new HuffmanNode(text[0]));

            //Add remaining chars to list
            for (int i = 1; i <= text.Length - 1; i++)
            {
                HuffmanNode existingNode = NodeList.Find(n => n.chr == text[i]);
                if (existingNode == null)
                {
                    NodeList.Add(new HuffmanNode(text[i]));
                }
                else
                {
                    existingNode.frequency++;
                }
            }

            //sort the list
            NodeList.Sort();

            while (NodeList.Count > 1)
            {
                NodeList.Add(new HuffmanNode(NodeList[0], NodeList[1]));
                NodeList.RemoveRange(0, 2);
                NodeList.Sort();
            }

            //collect huffman codes
            NodeList[0].CollectCodes(string.Empty, CodingDictonary);

            Console.WriteLine("================================================");
            Console.WriteLine(text);
            Console.WriteLine("================================================");

            foreach (KeyValuePair<char, string> keyValuePair in CodingDictonary)
            {
                Console.WriteLine($"{keyValuePair.Key}: {keyValuePair.Value}");
            }
            Console.WriteLine("================================================");

            string codedText = "";
            for (int i = 0; i <= text.Length - 1; i++)
            {
                codedText += CodingDictonary[text[i]];
            }
            Console.WriteLine("Huffman coded text: " + codedText);
            Console.WriteLine("================================================");

            Console.ReadLine();
        }
    }
}
