using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_1._4_U1_2C.AccesoDatos
{
    public class ParameterSQL
    {
        public string Name {  get; set; }
        public object Value { get; set; }
        public ParameterSQL(string name , object value) 
        {
        Name  = name; 
        Value = value;
        }
    }
}
