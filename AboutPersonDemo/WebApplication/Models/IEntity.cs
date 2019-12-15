using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    /// <summary>
    /// 标识为聚合内实体的接口类型
    /// </summary>
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
