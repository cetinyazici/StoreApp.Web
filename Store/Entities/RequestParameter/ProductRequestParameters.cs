using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestParameter
{
    public abstract class ProductRequestParameters : RequestParameters
    {
        public int? CategoryId { get; set; }
    }
}
