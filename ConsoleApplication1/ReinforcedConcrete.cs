using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestObjectClass2
{
    public class ReinforcedConcrete : Material
    {
        private double _g_c_for_mod = 0;
        private bool _mod_by_commentary = true;

        public bool ModulusByLRFDCommentary
        {
            get
            {
                return _mod_by_commentary;
            }
            set
            {
                _mod_by_commentary = value;
                ModulusByLRFDCommentary = _mod_by_commentary;
                calc_E_c(_mod_by_commentary);
            }
        }
        public double f_c
        {
          get
            {
                return base.CompressiveStrength;
            }
          set
            {
                f_c = value;
                base.CompressiveStrength = f_c;
                calc_E_c(_mod_by_commentary);
            }
        }
        public override double CompressiveStrength
        {
            get
            {
                return base.CompressiveStrength;
            }

            set
            {
                base.CompressiveStrength = value;
                f_c = base.CompressiveStrength;
                calc_E_c(_mod_by_commentary);
            }
        }
        public double g_c_forWeight
        {
            get
            {
                return base.Density;
            }
            set
            {
                g_c_forWeight = value;
                base.Density = g_c_forWeight;
                if (!_mod_by_commentary)
                {
                    calc_E_c(_mod_by_commentary);
                }
            }
        }
        public override double Density
        {
            get
            {
                return base.Density;
            }

            set
            {
                base.Density = value;
                g_c_forWeight = base.Density;
                if (!_mod_by_commentary)
                {
                    calc_E_c(_mod_by_commentary);
                }
            }
        }
        public double g_c_forModulus
        {
            get
            {
                return _g_c_for_mod;
            }
            set
            {
                g_c_forModulus = value;
                _g_c_for_mod = g_c_forModulus;
                calc_E_c(_mod_by_commentary);
            }
        } 
        public double E_c
        {
            get
            {
                return base.ModulusOfElasticity;
            }
            set
            {
                E_c = value;
                base.ModulusOfElasticity = E_c;
            }
        }
        public override double ModulusOfElasticity
        {
            get
            {
                return base.ModulusOfElasticity;
            }

            set
            {
                base.ModulusOfElasticity = value;
                E_c = base.ModulusOfElasticity;
            }
        }
        public double K_1 { get; set; } = 1;
        private void calc_E_c(bool LRFD_Commentary)
        {
            if (LRFD_Commentary)
            {
                E_c = 1820 * Math.Sqrt(f_c);
            }
            else
            {
                double g_c;
                if(g_c_forModulus == 0)
                {
                    g_c = g_c_forWeight;
                }
                else
                {
                    g_c = g_c_forModulus;
                }

                E_c = 33000 * K_1 * Math.Pow(g_c, 1.5) * Math.Sqrt(f_c);
            }
        }



    }
}
