using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Queries.Models;

namespace Queries.Models
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
    }
}