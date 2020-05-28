using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core2
{
    public class Story
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public string Type { get; set; }
        public string By { get; set; }
        public string Time { get; set; }
        public string Text { get; set; }
        public bool Dead { get; set; }
        public string Parent { get; set; }
        public string Poll { get; set; }
        public string[] Kids { get; set; }
        public string Url { get; set; }
        public string Score { get; set; }
        public string Title { get; set; }
        public string[] Parts { get; set; }
        public string Decendants { get; set; }
    }
}
