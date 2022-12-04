﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities.Common;
using TaskManagement.Domain.Entities.Identity;

namespace TaskManagement.Domain.Entities
{
    public class UserTask : BaseEntity
    {
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Days { get; set; }
        public bool IsDone { get; set; }

    }
}
