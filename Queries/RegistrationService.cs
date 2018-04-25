using DataAccessLayer;
using Models.DataObjects;
using Models.ViewModels;
using Queries.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace Queries
{
    public class RegistrationService : IDisposable
    {

        private async Task CreateUser(AppUser userToCreate)
        {
            await Users.CreateAsync(userToCreate);
        }

        private SignInManager MySignInManager;

        public AppUserManager Users { get; set; }

        public IRepository<Query> Queries { get; set; }

        public RegistrationService(SignInManager manager)
        {
            MySignInManager = manager;
            Users = HttpContext.Current.GetOwinContext().GetUserManager<AppUserManager>();
            Queries = RepositoryFactory.EntityRepo<Query>();
        }

        public Query Save(QueryView query)
        {
            Query newQuery = new Query();
            newQuery.QueryText = query.QueryText;
            newQuery.DateWritten = DateTime.Today;
            newQuery.QueryStatus = 1;

            AppUser newUser = UserExists(query.Email);

            if (newUser == null)
            {
                newUser = new AppUser();
                newUser.Id = Guid.NewGuid().ToString();
                newUser.Email = query.Email;
                newUser.Name = query.Name;
                newUser.UserName = query.Name;
                newUser.Surname = query.Surname;
                var newPas = Membership.GeneratePassword(8, 1);
                //newUser.PasswordHash = newPas.GetHashCode().ToString();
                newUser.Birthdate = query.Birthdate.Date;
                var result = Users.Create(newUser, newPas);
                newQuery.UserId = newUser.Id;
            }
            else
            {
                newQuery.User = newUser;
                Queries.Save(newQuery);
            }

            return Queries.Save(newQuery);
        }

        public AppUser UserExists(string email)
        {
            return Users.FindByEmail(email);
        }

        public AppUser UserValid(string email, string password)
        {
            var user = Users.FindByEmail(email);
            if (Users.CheckPassword(user, password))
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public List<UserQueryView> UserQueries(string userName)
        {
            return Queries.Get()
                .Where(x => x.User.UserName == userName)
                .Select(x => new UserQueryView() {
                    Id = x.Id,
                    QueryText = x.QueryText,
                    DateWritten = x.DateWritten,
                    QueryStatus = x.QueryStatus
                })
                .ToList();
            //var loggedUser = Users.FindByName(userName);
            //List<UserQueryView> userQueries = new List<UserQueryView>();
            //var queries = Queries.Get().Where(x => x.User.Id == loggedUser.Id);
            //foreach (var q in queries)
            //{
            //    UserQueryView usrQuerytmp = new UserQueryView();
            //    usrQuerytmp.Id = q.Id;
            //    usrQuerytmp.QueryText = q.QueryText;
            //    usrQuerytmp.DateWritten = q.DateWritten;
            //    usrQuerytmp.QueryStatus = q.QueryStatus;
            //    userQueries.Add(usrQuerytmp);
            //}

            //return userQueries;
        }

        public void Dispose()
        {
            Users.Dispose();
            Queries.Dispose();
        }
    }
}