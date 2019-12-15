using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication.Models;
using WebApplication.Models.EntityFrameworlRepository;

namespace WebApplication.Controllers
{
    public class CategoryController : ApiController
    {
        public IHttpActionResult Post()
        {
            //TODO:商品分类-分类属性-分类属性值如何形成一个以商品分类为聚合根的领域模型

            using (CodeFirstContainer1 dbContext = new CodeFirstContainer1())
            {
                CategoryRepository categoryRepository = new CategoryRepository(dbContext);
            }
            return Ok();
        }

        public IHttpActionResult Get()
        {
            using (CodeFirstContainer1 dbContext = new CodeFirstContainer1())
            {
                CategoryRepository categoryRepository = new CategoryRepository(dbContext);

                //TODO：使用规约模式解决什么问题。
                //涉及知识：委托Delegate，表达树Expression
                //categoryRepository.DoGetAll(t => t.Name == "123", x => x.Name, SortOrder.Ascending);
                var query = from categoryInfo in dbContext.Category
                            where categoryInfo.Name == "123"
                            select categoryInfo;

                dbContext.Category.Where((x, y) =>  x.Name == "123" && y == 1);

                return Ok();
            }
        }
    }
}
