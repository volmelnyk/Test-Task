using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1
{
   public class Node
    {
        public int Id { get; set; }
        public string Sentence { get; set; }

        public Node() { }
        public Node(string sentence) { this.Sentence = sentence; }
    }
}
