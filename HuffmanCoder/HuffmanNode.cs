using System;
using System.Collections.Generic;

namespace HuffmanCoder
{
    public class HuffmanNode : IComparable<HuffmanNode>
    {
        public char chr;
        public int frequency;
        public string code;
        public HuffmanNode parent;
        public HuffmanNode left;
        public HuffmanNode right;
        public bool isLeaf;

        public HuffmanNode(char val)
        {
            chr = val;
            frequency = 1;
            code = "";
            parent = left = right = null;
            isLeaf = true;
        }

        public HuffmanNode(HuffmanNode node1, HuffmanNode node2)
        {
            code = "";
            isLeaf = false;
            parent = null;

            if (node1.frequency >= node2.frequency)
            {
                right = node1;
                left = node2;
            }
            else if (node2.frequency > node1.frequency)
            {
                right = node2;
                left = node1;
            }
            else
            {
                return;
            }

            right.code += "1";
            left.code += "0";
            node1.parent = node2.parent = this;
            this.frequency = node1.frequency + node2.frequency;
        }

        public void CollectCodes(string prevCodes, Dictionary<char, string> codingDictionary)
        {
            if (isLeaf)
            {
                codingDictionary.Add(this.chr, prevCodes + this.code);
            }
            else
            {
                left.CollectCodes(prevCodes + this.code, codingDictionary);
                right.CollectCodes(prevCodes + this.code, codingDictionary);
            }
        }

        public int CompareTo(HuffmanNode otherNode)
        {
            return this.frequency.CompareTo(otherNode.frequency);
        }
    }
}