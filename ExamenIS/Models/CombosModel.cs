using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenIS.Models
{
    public class CombosModel : ProductoModel
    {
        public List<ProductoModel> Productos { get; set; }
    }
}