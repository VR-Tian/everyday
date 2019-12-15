using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    /// <summary>
    /// 标识实体为聚合根的接口类型
    /// </summary>
    public interface IAggregateRoot : IEntity
    {

    }
}