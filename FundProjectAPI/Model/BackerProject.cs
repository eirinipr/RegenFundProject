using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundProjectAPI.Model
{
    public class BackerProject
    {
        public int Id { get; set; }
        public Project Project { get; set; }
        public Backer Backer { get; set; }
    }
}
