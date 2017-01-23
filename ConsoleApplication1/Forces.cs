using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestObjectClass2
{
    public class Force
    {
        public double Moment { get; set; }
        public double Shear { get; set; }
        public double Torsion { get; set; }
        public double ModRatio { get; set; }
        public bool Composite { get; set; }

        public Force()
        {
            Moment = 0;
            Shear = 0;
            Torsion = 0;
            ModRatio = 1;
            Composite = true;
        }
        
        public Force(double moment, double shear, double torsion, double modRatio, bool composite)
        {
            Moment = moment;
            Shear = shear;
            Torsion = torsion;
            ModRatio = modRatio;
            Composite = composite;
        }

    }
}
