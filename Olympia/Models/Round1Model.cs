using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Olympia.Models
{
    public class Round1Model
    {
        public List<Vong1> listQues { get; set; }
        public ListPlayer players { get; set; }

        public Round1Model()
        {
            listQues = new List<Vong1>();
            players = new ListPlayer();
        }
    }
}