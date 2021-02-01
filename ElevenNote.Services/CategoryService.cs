﻿using ElevenNote.Data;
using ElevenNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class CategoryService
    {
        private readonly Guid _userId;

        public CategoryService(Guid userId)
        {
            _userId = userId;
        }



        // CREATE INSTANCE OF CATEGORY
        public bool CreateCategory(CategoryCreate model)
        {
            var entity =
                new Category()
                {
                    CategoryName = model.CategoryName
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public CategoryDetail GetCategoryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Categories
                    .Single(e => e.CategoryId == id);
                return
                    new CategoryDetail
                    {
                        CategoryId = entity.CategoryId,
                        CategoryName = entity.CategoryName
                    };
            }
        }

        // PUT
       public bool UpdateCategory(CategoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Categories
                    .Single(e => e.CategoryId == model.CategoryId);

                entity.CategoryName = model.CategoryName;
                entity.CategoryId = model.CategoryId;
                return ctx.SaveChanges() == 1;
            }
        }

        // DELETE
        public bool DeleteCategory(int categoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Categories
                    .Single(e => e.CategoryId == categoryId);
                ctx.Categories.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        // GET CATEGORIES
        public IEnumerable<CategoryListItem> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Categories
                    .Select(
                        e =>
                        new CategoryListItem
                        {
                            CategoryId = e.CategoryId,
                            CategoryName = e.CategoryName
                        });
                return query.ToArray();
            }
        }
    }
}

