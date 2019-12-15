using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication.Models.EntityFrameworlRepository
{
    /// <summary>
    /// 商品分类仓储实现
    /// </summary>
    internal class CategoryRepository : EntiryFrameworkRepository<Category>
    {
        public CategoryRepository(DbContext objContext) : base(objContext)
        {

        }
    }
}