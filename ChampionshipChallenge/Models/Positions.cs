using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;

namespace CodeChallenge.Models
{
    public class Positions
    {
        public IEnumerable<TeamRecord> TeamRecords { get; set; }

        internal Dictionary<string, TeamRecord> _TeamRecords { get; set; } = new Dictionary<string, TeamRecord>();
    }
}
