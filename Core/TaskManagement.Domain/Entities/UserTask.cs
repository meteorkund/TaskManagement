using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities.Common;

namespace TaskManagement.Domain.Entities
{
    public class UserTask : BaseEntity
    {
        public string Description { get; set; }
    }
}
