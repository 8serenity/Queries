using System;
using System.Collections.Generic;

namespace Models.DataObjects
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual DateTime Birthdate { get; set; }  

        public virtual IList<Query> Queries { get; set; }

        public User()
        {
            Queries = new List<Query>();
        }

    }
}