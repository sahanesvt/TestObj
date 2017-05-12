using System;
using System.Collections.Generic;

namespace TestObjectClass2
{
    public class CompositeBeam
    {
        private BotFlange bf = new BotFlange();
        private Web wb = new Web();
        private TopFlange tf = new TopFlange();
        private Bolster blst = new Bolster();
        private Slab slb = new Slab();
        private Reinforcing reinf = new Reinforcing(0, 0, 0, true);
        private List<Reinforcing> reinforcing = new List<Reinforcing>();

        public BotFlange BotFlange
        {
            get { return bf; }
            set
            {
                bf = value;
                bf.BotLocation = 0;
                bf.CG = bf.y / 2;
                bf.TopLocation = bf.y;
                wb.BotLocation = bf.y;
                wb.CG = bf.y + wb.y / 2;
                wb.TopLocation = bf.y + wb.y;
                tf.BotLocation = bf.y + wb.y;
                tf.CG = bf.y + wb.y + tf.y / 2;
                tf.TopLocation = bf.y + wb.y + tf.y;
                blst.BotLocation = bf.y + wb.y + tf.y;
                blst.CG = bf.y + wb.y + tf.y + blst.y / 2;
                blst.TopLocation = bf.y + wb.y + tf.y + blst.y;
                slb.BotLocation = bf.y + wb.y + tf.y + blst.y;
                slb.CG = bf.y + wb.y + tf.y + blst.y + slb.y / 2;
                slb.TopLocation = bf.y + wb.y + tf.y + blst.y + slb.y;
                foreach (Reinforcing reinf in reinforcing)
                {
                    if (reinf.DistToTopOfSlab)
                    {
                        reinf.Location = slb.TopLocation - reinf.DistToSlab;
                    }
                    else
                    {
                        reinf.Location = slb.BotLocation + reinf.DistToSlab;
                    }
                }

            }
        }
        public Web Web 
        {
            get { return wb; }
            set
            {
                wb = value;
                bf.BotLocation = 0;
                bf.CG = bf.y / 2;
                bf.TopLocation = bf.y;
                wb.BotLocation = bf.y;
                wb.CG = bf.y + wb.y / 2;
                wb.TopLocation = bf.y + wb.y;
                tf.BotLocation = bf.y + wb.y;
                tf.CG = bf.y + wb.y + tf.y / 2;
                tf.TopLocation = bf.y + wb.y + tf.y;
                blst.BotLocation = bf.y + wb.y + tf.y;
                blst.CG = bf.y + wb.y + tf.y + blst.y / 2;
                blst.TopLocation = bf.y + wb.y + tf.y + blst.y;
                slb.BotLocation = bf.y + wb.y + tf.y + blst.y;
                slb.CG = bf.y + wb.y + tf.y + blst.y + slb.y / 2;
                slb.TopLocation = bf.y + wb.y + tf.y + blst.y + slb.y;
                foreach (Reinforcing reinf in reinforcing)
                {
                    if (reinf.DistToTopOfSlab)
                    {
                        reinf.Location = slb.TopLocation - reinf.DistToSlab;
                    }
                    else
                    {
                        reinf.Location = slb.BotLocation + reinf.DistToSlab;
                    }
                }

            }
        }
        public TopFlange TopFlange 
        {
            get { return tf; }
            set
            {
                tf = value;
                bf.BotLocation = 0;
                bf.CG = bf.y / 2;
                bf.TopLocation = bf.y;
                wb.BotLocation = bf.y;
                wb.CG = bf.y + wb.y / 2;
                wb.TopLocation = bf.y + wb.y;
                tf.BotLocation = bf.y + wb.y;
                tf.CG = bf.y + wb.y + tf.y / 2;
                tf.TopLocation = bf.y + wb.y + tf.y;
                blst.BotLocation = bf.y + wb.y + tf.y;
                blst.CG = bf.y + wb.y + tf.y + blst.y / 2;
                blst.TopLocation = bf.y + wb.y + tf.y + blst.y;
                slb.BotLocation = bf.y + wb.y + tf.y + blst.y;
                slb.CG = bf.y + wb.y + tf.y + blst.y + slb.y / 2;
                slb.TopLocation = bf.y + wb.y + tf.y + blst.y + slb.y;
                foreach (Reinforcing reinf in reinforcing)
                {
                    if (reinf.DistToTopOfSlab)
                    {
                        reinf.Location = slb.TopLocation - reinf.DistToSlab;
                    }
                    else
                    {
                        reinf.Location = slb.BotLocation + reinf.DistToSlab;
                    }
                }

            }
        }
        public Bolster Bolster 
        {
            get { return blst; }
            set
            {
                blst = value;
                bf.BotLocation = 0;
                bf.CG = bf.y / 2;
                bf.TopLocation = bf.y;
                wb.BotLocation = bf.y;
                wb.CG = bf.y + wb.y / 2;
                wb.TopLocation = bf.y + wb.y;
                tf.BotLocation = bf.y + wb.y;
                tf.CG = bf.y + wb.y + tf.y / 2;
                tf.TopLocation = bf.y + wb.y + tf.y;
                blst.BotLocation = bf.y + wb.y + tf.y;
                blst.CG = bf.y + wb.y + tf.y + blst.y / 2;
                blst.TopLocation = bf.y + wb.y + tf.y + blst.y;
                slb.BotLocation = bf.y + wb.y + tf.y + blst.y;
                slb.CG = bf.y + wb.y + tf.y + blst.y + slb.y / 2;
                slb.TopLocation = bf.y + wb.y + tf.y + blst.y + slb.y;
                foreach (Reinforcing reinf in reinforcing)
                {
                    if (reinf.DistToTopOfSlab)
                    {
                        reinf.Location = slb.TopLocation - reinf.DistToSlab;
                    }
                    else
                    {
                        reinf.Location = slb.BotLocation + reinf.DistToSlab;
                    }
                }

            }
        }
        public Slab Slab 
        {
            get { return slb; }
            set
            {
                slb = value;
                bf.BotLocation = 0;
                bf.CG = bf.y / 2;
                bf.TopLocation = bf.y;
                wb.BotLocation = bf.y;
                wb.CG = bf.y + wb.y / 2;
                wb.TopLocation = bf.y + wb.y;
                tf.BotLocation = bf.y + wb.y;
                tf.CG = bf.y + wb.y + tf.y / 2;
                tf.TopLocation = bf.y + wb.y + tf.y;
                blst.BotLocation = bf.y + wb.y + tf.y;
                blst.CG = bf.y + wb.y + tf.y + blst.y / 2;
                blst.TopLocation = bf.y + wb.y + tf.y + blst.y;
                slb.BotLocation = bf.y + wb.y + tf.y + blst.y;
                slb.CG = bf.y + wb.y + tf.y + blst.y + slb.y / 2;
                slb.TopLocation = bf.y + wb.y + tf.y + blst.y + slb.y;
                foreach (Reinforcing reinf in reinforcing)
                {
                    if (reinf.DistToTopOfSlab)
                    {
                        reinf.Location = slb.TopLocation - reinf.DistToSlab;
                    }
                    else
                    {
                        reinf.Location = slb.BotLocation + reinf.DistToSlab;
                    }
                }

            }
        }
        public List<Reinforcing> Reinforcing
        {
            get { return reinforcing; }
            set
            {
                reinforcing = value;
                bf.BotLocation = 0;
                bf.CG = BotFlange.y / 2;
                bf.TopLocation = bf.y;
                wb.BotLocation = bf.y;
                wb.CG = bf.y + Web.y / 2;
                wb.TopLocation = bf.y + Web.y;
                tf.BotLocation = bf.y + wb.y;
                tf.CG = bf.y + wb.y + tf.y / 2;
                tf.TopLocation = bf.y + wb.y + tf.y;
                blst.BotLocation = bf.y + wb.y + tf.y;
                blst.CG = bf.y + wb.y + tf.y + blst.y / 2;
                blst.TopLocation = bf.y + wb.y + tf.y + blst.y;
                slb.BotLocation = bf.y + wb.y + tf.y + blst.y;
                slb.CG = bf.y + wb.y + tf.y + blst.y + slb.y / 2;
                slb.TopLocation = bf.y + wb.y + tf.y + blst.y + slb.y;
                foreach (Reinforcing reinf in reinforcing)
                {
                    if (reinf.DistToTopOfSlab)
                    {
                        reinf.Location = slb.TopLocation - reinf.DistToSlab;
                    }
                    else
                    {
                        reinf.Location = slb.BotLocation + reinf.DistToSlab;
                    }
                }

            }
        }

        public CompositeBeam()
        {
            BotFlange = bf;
            Web = wb;
            TopFlange = tf;
            Bolster = blst;
            Slab = slb;
            Reinforcing = reinforcing;
        }

        public CompositeBeam(BeamParts beamParts)
        {
            BotFlange = beamParts.BotFlange;
            Web = beamParts.Web;
            TopFlange = beamParts.TopFlange;
            Bolster = beamParts.Bolster;
            Slab = beamParts.Slab;
            Reinforcing = beamParts.Reinforcing;

        }

        public double Area(double modRatio, bool composite, bool positiveMoment)
        {
            return ElasticProps.BeamArea(this, modRatio, composite, positiveMoment);
        }

        public double NA_Elastic(double modRatio, bool composite, bool positiveMoment)
        {
            return ElasticProps.NeutralAxis(this, modRatio, composite, positiveMoment);
        }

        public double I_Elastic(double modRatio, bool composite, bool positiveMoment)
        {
            return ElasticProps.MomentOfInertia(this, modRatio, composite, positiveMoment);
        }

        public double S_Elastic(double modRatio, bool composite, bool positiveMoment, double location)
        {
            return ElasticProps.SectionModulus(this, modRatio, composite, positiveMoment, location);
        }

        public double f_Elastic(double moment, double modRatio, bool composite, bool positiveMoment, double location)
        {
            return ElasticProps.Stress(moment, this, modRatio, composite, positiveMoment, location);
        }

        public double Q(double modRatio, bool composite, bool positiveMoment, double location)
        {
            return ElasticProps.FirstMoment_Q(this, modRatio, composite, positiveMoment, location);
        }



        /*public double NA_Plastic()
        {
            return ElasticProps.PlasticNeutralAxis(BotFlange, Web, TopFlange, Bolster, Slab);
            
        }*/

        public double NA_Plastic(bool composite, bool positiveMoment)
        {
            return PlasticProps.PlasticNeutralAxis(BotFlange, Web, TopFlange, Bolster, Slab, Reinforcing, composite, positiveMoment);
        }

        /*public double Mp()
        {
            double[] top = ElasticProps.PlasticTop(BotFlange, Web, TopFlange, Bolster, Slab);
            double[] bot = ElasticProps.PlasticBottom(BotFlange, Web, TopFlange, Bolster, Slab);
            return (top[0] * top[1] + bot[0] * bot[1]) / 12;
        }*/

        public double Mp(bool composite, bool positiveMoment)
        {
            return PlasticProps.PlasticMoment(BotFlange, Web, TopFlange, Bolster, Slab, Reinforcing, composite, positiveMoment);
        }

        public double D_c(double modRatio, bool composite, bool positiveMoment)
        {
            double NA = ElasticProps.NeutralAxis(BotFlange, Web, TopFlange, Bolster, Slab, Reinforcing, modRatio, composite, positiveMoment);
            if (positiveMoment)
            {
                return Web.TopLocation - NA;
            }
            else
            {
                return NA - Web.BotLocation;
            }
        }

        public double F_crw(double modRatio, bool composite, bool positiveMoment)
        {
            double Dc = D_c(modRatio, composite, positiveMoment);
            double k = 9 / Math.Pow(Dc / Web.y, 2);
            return Math.Min(0.7 * Web.Strength, 0.9 * Web.ElastMod * k / Math.Pow(Web.y / Web.x, 2));
        }
                
    }
}
