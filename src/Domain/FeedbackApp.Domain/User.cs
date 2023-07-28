using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Domain
{
    public class User : IdentityUser<int>, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Status { get; set; } = true;
    }
}
