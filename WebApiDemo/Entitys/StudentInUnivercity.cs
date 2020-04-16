using System;
using System.Collections.Generic;

namespace WebApiDemo.Entitys
{
    public partial class StudentInUnivercity
    {
        public int? StudentId { get; set; }
        public int? UnivercityId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Univercity Univercity { get; set; }
    }
}
