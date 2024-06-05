﻿using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.SystemAccountRepo
{
    public interface ISystemAccountRepo
    {
        public Task<SystemAccount> CheckLogin(string Accountemail, string password);
        List<SystemAccount> GetSystemAccount();
        void AddSystemAccount(SystemAccount systemAccount);
        void UpdateSystemAccount(SystemAccount systemAccount);
        Task DeleteSystemAccount(SystemAccount systemAccount);
        SystemAccount GetSystemAccountById(short id);
        SystemAccount GetSystemAccountByEmail(string email);
        Task DeleteNewsArticleAndTags(List<NewsArticle> newsArticles);
        void UpdateUserProfile(string loggedInUsername, SystemAccount updatedProfile);
        SystemAccount GetLoggedInUser(string email);
    }
}
