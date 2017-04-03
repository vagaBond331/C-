using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Olympia.Models
{
    public class Round2Model
    {
        public int group { get; set; }
        public List<Vong2> list { get; set; }
        public List<char[]> quesChar { get; set; }
        public ListPlayer players { get; set; }
        public Round2Model()
        {
            group = 0;
            list = new List<Vong2>();
            quesChar = new List<char[]>();
            players = new ListPlayer();
        }
    }
}