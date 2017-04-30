using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLCar.Core
{
    /// <summary>
    /// 表示继承于该接口的类型是领域实体类
    /// </summary>
    public interface IEntity
    {
        int ID { get; set; }
        Guid guid { get; set; }
    }
}
