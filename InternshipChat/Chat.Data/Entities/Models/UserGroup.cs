using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Chat.Data.Entities.Models
{
    public class UserGroup
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int GroupId { get; set; }
        public GroupChat GroupChat { get; set; } = null!;
    }
}
