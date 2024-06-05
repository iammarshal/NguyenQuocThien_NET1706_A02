﻿using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer
{
    public class NewsArticleDAO
    {
        public static List<NewsArticle> GetNewsArticles()
        {
            var listNewsArticles = new List<NewsArticle>();
            try
            {
                using (var _context = new FunewsManagementDbContext())
                {
                    listNewsArticles = _context.NewsArticles
                        .AsNoTracking().Include(c => c.Category).Include(c => c.Tags).Include(c => c.CreatedBy)
                        .ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listNewsArticles;
        }
        public static void AddNewsArticle(NewsArticle newsArticle)
        {
            try
            {
                using (var _context = new FunewsManagementDbContext())
                {
                    _context.NewsArticles.Add(newsArticle);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void UpdateNewsArticle(NewsArticle newsArticle)
        {
            try
            {
                using (var _context = new FunewsManagementDbContext())
                {
                    //_context.NewsArticles.Include(c => c.Category).Include(c => c.CreatedBy).Include(c => c.Tags).ToList();
                    _context.NewsArticles.Update(newsArticle);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteNewsArticle(NewsArticle newsArticle)
        {
            try
            {
                using (var _context = new FunewsManagementDbContext())
                {
                    _context.NewsArticles.Remove(newsArticle);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static async Task<NewsArticle> GetNewsArticleById(string id)
        {
            using (var _context = new FunewsManagementDbContext())
            {
                return await _context.NewsArticles
                    .Include(c => c.Category)
                    .Include(c => c.Tags)
                    .Include(c => c.CreatedBy)
                    .SingleOrDefaultAsync(c => c.NewsArticleId == id);
            }
        }

        public static List<NewsArticle> GetNewsArticlesByCreatedId(short Id)
        {
            using (var _context = new FunewsManagementDbContext())
            {
                return _context.NewsArticles
                    .Include(c => c.Category)
                    .Include(c => c.Tags)
                    .Include(c => c.CreatedBy)
                    .Where(c => c.NewsStatus == true && c.CreatedById == Id)
                    .ToList();
            }
        }
    }
}
