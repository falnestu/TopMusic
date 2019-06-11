﻿using Common.Entities;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class CategoryService
    {
        public static IEnumerable<Category> GetAll()
        {
            List<Category> categories = null;
            using (TopMusicEntities db = new TopMusicEntities())
            {
                categories = db.Category.ToList();
            }
            return categories;
        }

        public static bool Delete(int id)
        {
            using (TopMusicEntities db = new TopMusicEntities())
            {
                var category = db.Category.Find(id);
                if (category == null)
                {
                    return false;
                }

                db.Album.RemoveRange(category.Album);
                db.Category.Remove(category);
                db.SaveChanges();
                return true;
            }
        }

        public static Category Get(int id)
        {
            using (TopMusicEntities db = new TopMusicEntities())
            {
                return db.Category.Find(id);
            }
        }

        public static int Create(string name, string description)
        {
            using (TopMusicEntities db = new TopMusicEntities())
            {
                var category = new Category
                {
                    Name = name,
                    Description = description,
                    Statut = (int)CategoryStatus.Invisible
                };
                db.Category.Add(category);
                db.SaveChanges();
                return category.CategoryID;
            }
        }

        public static int Save(int id, string name, string description, object status)
        {
            using (TopMusicEntities db = new TopMusicEntities())
            {
                var category = db.Category.Find(id);
                category.Name = name;
                category.Description = description;
                category.Statut = (int)status;
                return db.SaveChanges();
            }
        }
    }
}
