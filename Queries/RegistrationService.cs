using DataAccessLayer;
using Models.DataObjects;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;

namespace Queries
{
    public class RegistrationService : IDisposable
    {
        public IRepository<User> Users { get; set; }
        public IRepository<Query> Queries { get; set; }

        public RegistrationService()
        {
            Users = RepositoryFactory.EntityRepo<User>();
            Queries = RepositoryFactory.EntityRepo<Query>();
        }

        public Query Save(QueryView query)
        {
            Query newQuery = new Query();
            newQuery.QueryText = query.QueryText;
            newQuery.DateWritten = DateTime.Today;
            newQuery.QueryStatus = 1;

            User newUser = UserExists(query.Email);

            if (newUser == null)
            {
                newUser = new User();
                newUser.Email = query.Email;
                newUser.Name = query.Name;
                newUser.Surname = query.Surname;
                newUser.Password = Membership.GeneratePassword(8, 1);
                newUser.Birthdate = query.Birthdate;
                newQuery.UserId = Users.Save(newUser).Id;
            }
            else
            {
                newQuery.UserId = newUser.Id;
            }

            return Queries.Save(newQuery);
        }

        public User UserExists(string email)
        {
            return Users.Get().SingleOrDefault(x => x.Email == email);
        }

        public int UserValid(UserLoginView user)
        {
            var checkedUser = UserExists(user.Email);
            if (checkedUser != null && user.Password == checkedUser.Password)
            {
                return checkedUser.Id;
            }

            return 0;
        }

        public List<UserQueryView> UserQueries(int id)
        {
            List<UserQueryView> userQueries = new List<UserQueryView>();
            var queries = Queries.Get().Where(x => x.UserId == id);
            foreach (var q in queries)
            {
                UserQueryView usrQuerytmp = new UserQueryView();
                usrQuerytmp.Id = q.Id;
                usrQuerytmp.QueryText = q.QueryText;
                usrQuerytmp.DateWritten = q.DateWritten;
                usrQuerytmp.QueryStatus = q.QueryStatus;
                userQueries.Add(usrQuerytmp);
            }

            return userQueries;
        }

        public void Dispose()
        {
            Users.Dispose();
            Queries.Dispose();
        }
    }
}