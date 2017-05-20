using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestObjectClass2
{
    public class StructuralSteel:Material
    {
        private double _fy = 0, _fu = 0;

        public double Fy
        {
            get { return _fy; }
            set { _fy = value; }
        }

        public double Fu
        {
            get { return _fu; }
            set { _fu = value; }
        }

    }
}
