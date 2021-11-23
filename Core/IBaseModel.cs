using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
