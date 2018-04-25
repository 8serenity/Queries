using DataAccessLayer;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System.Linq;
using System.Threading.Tasks;
using Models.DataObjects;
using System;
using Microsoft.Owin.Security;

namespace Queries.Infrastructure
{
    public class AppUserManager : UserManager<AppUser, string>
    {
        public AppUserManager(IUserStore<AppUser, string> store)
            : base(store)
        {
            UserValidator = new UserValidator<AppUser, string>(this);
            PasswordValidator = new PasswordValidator();
        }

        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options,
            IOwinContext context)
        {
            //AppIdentityDbContext db = context.Get<AppIdentityDbContext>();
            AppUserManager manager = new AppUserManager(new MyUserStore());
            //AppUserManager manager = new AppUserManager(new UserStore<AppUser>(db));
            return manager;
        }
    }

    public class SignInManager : SignInManager<AppUser, string>
    {
        public SignInManager(UserManager<AppUser, string> userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager) { }

        public void SignOut()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }

    public class MyUserStore : IUserStore<AppUser, string>, IUserPasswordStore<AppUser, string>,
        IUserEmailStore<AppUser, string>, IUserLockoutStore<AppUser, string>, IUserTwoFactorStore<AppUser, string>
    {
        private IRepository<AppUser> _userRepository;

        public MyUserStore()
        {
            _userRepository = RepositoryFactory.EntityRepo<AppUser>();
        }
        public void Dispose()
        {
            _userRepository.Dispose();
        }
        #region IUserStore
        public Task CreateAsync(AppUser user)
        {
            return Task.Run(() =>
            {
                _userRepository.Save(user);
            });
        }

        public Task DeleteAsync(AppUser user)
        {
            return Task.Run(() =>
            {
                _userRepository.Delete(user);
            });
        }
        public Task<AppUser> FindByIdAsync(string userId)
        {
            return Task.Run(() => _userRepository.GetById(userId));
        }

        public Task<AppUser> FindByNameAsync(string userName)
        {
            return Task.Run(() => _userRepository.Get().SingleOrDefault(x => x.Name == userName));
        }

        public Task UpdateAsync(AppUser user)
        {
            return Task.Run(() => _userRepository.Update(user));
        }
        #endregion
        #region IUserPasswordStore
        public Task SetPasswordHashAsync(AppUser user, string passwordHash)
        {
            return Task.Run(() => user.PasswordHash = passwordHash);
        }

        public Task<string> GetPasswordHashAsync(AppUser user)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(AppUser user)
        {
            return Task.FromResult(true);
        }
        #endregion
        #region IUserEmailStore
        public Task SetEmailAsync(AppUser user, string email)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetEmailAsync(AppUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetEmailConfirmedAsync(AppUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(AppUser user, bool confirmed)
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> FindByEmailAsync(string email)
        {
            return Task.Run(() => _userRepository.Get().SingleOrDefault(x => x.Email == email));
        }
        #endregion
        #region IUserLockoutStore
        public Task<DateTimeOffset> GetLockoutEndDateAsync(AppUser user)
        {
            return Task.FromResult(DateTimeOffset.MaxValue);
        }

        public Task SetLockoutEndDateAsync(AppUser user, DateTimeOffset lockoutEnd)
        {
            return Task.CompletedTask;
        }

        public Task<int> IncrementAccessFailedCountAsync(AppUser user)
        {
            return Task.FromResult(0);
        }

        public Task ResetAccessFailedCountAsync(AppUser user)
        {
            return Task.CompletedTask;
        }

        public Task<int> GetAccessFailedCountAsync(AppUser user)
        {
            return Task.FromResult(0);
        }

        public Task<bool> GetLockoutEnabledAsync(AppUser user)
        {
            return Task.FromResult(false);
        }

        public Task SetLockoutEnabledAsync(AppUser user, bool enabled)
        {
            return Task.CompletedTask;
        }
        #endregion
        #region IUserTwoFactorStore
        public Task SetTwoFactorEnabledAsync(AppUser user, bool enabled)
        {
            return Task.CompletedTask;
        }

        public Task<bool> GetTwoFactorEnabledAsync(AppUser user)
        {
            return Task.FromResult(false);
        }
        #endregion
    }
}