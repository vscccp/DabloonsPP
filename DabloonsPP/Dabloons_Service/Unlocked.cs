using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dabloons_Service
{
    [DataContract]
    public class Unlocked
    {
        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public int GameCurrency { get; set; }

        [DataMember]
        public int MapsUnlocked { get; set; }

        [DataMember]
        public int MoneyTiers { get; set; }

        [DataMember]
        public int HealthTiers { get; set; }
    }
}
