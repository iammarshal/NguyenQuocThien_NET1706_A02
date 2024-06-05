using BusinessObject;
using Repositories.SystemAccountRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SystemAccountService
{
    public class SystemAccountService : ISystemAccountService
    {
        private readonly ISystemAccountRepo _systemAccountRepo;
        public SystemAccountService()
        {
            if (_systemAccountRepo == null)
            {
                _systemAccountRepo = new SystemAccountRepo();
            }
        }
        public async Task<SystemAccount> Login(string Accountemail, string password)
        {
            var getUser = await _systemAccountRepo.CheckLogin(Accountemail, password);
            return getUser;
        }
        public void AddSystemAccount(SystemAccount systemAccount)
        {
            _systemAccountRepo.AddSystemAccount(systemAccount);
        }
        public Task DeleteSystemAccount(SystemAccount systemAccount) => _systemAccountRepo.DeleteSystemAccount(systemAccount);
        
        public  List<SystemAccount>GetSystemAccount() => _systemAccountRepo.GetSystemAccount();
        
        public SystemAccount GetSystemAccountById(short id)
        {
            return _systemAccountRepo.GetSystemAccountById(id);
        }
        public SystemAccount GetSystemAccountByEmail(string email)
        {
            return _systemAccountRepo.GetSystemAccountByEmail(email);
        }
        public void UpdateSystemAccount(SystemAccount systemAccount)
        {
            _systemAccountRepo.UpdateSystemAccount(systemAccount);
        }
        public async Task DeleteNewsArticleAndTags(List<NewsArticle> newsArticles)
        {
            await _systemAccountRepo.DeleteNewsArticleAndTags(newsArticles);
        }
        public void UpdateUserProfile(string loggedInUsername, SystemAccount updatedProfile)
        {
            _systemAccountRepo.UpdateUserProfile(loggedInUsername, updatedProfile);
        }
        public SystemAccount GetLoggedInUser(string email)
        {
            return _systemAccountRepo.GetLoggedInUser(email);
        }
    }
}
