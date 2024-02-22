using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dabloons_Service
{
    [DataContract]
    public class Matches
    {
        [DataMember]
        public int MatchId { get; set; }

        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public TimeSpan TimeTaken { get; set; }

        [DataMember]
        public int MoneyAccumulated { get; set; }

        [DataMember]
        public int TowersBuilt { get; set; }

        [DataMember]
        public char Result { get; set; }
    }
}
