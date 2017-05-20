using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestObjectClass2
{
    public abstract class Material
    {
        public virtual String Name { get; set; } = "";
        public virtual double Density { get; set; } = 0;
        //public virtual double CompressiveStrength { get; set; } = 0;
        //public virtual double TensionStrength { get; set; } = 0;
        public virtual double ModulusOfElasticity { get; set; } = 0;


        public Material() { }
    }
}
