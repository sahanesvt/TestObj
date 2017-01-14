using System;

namespace TestObjectClass2
{
    public class CompositeBeam
    {
        private BotFlange bf = new BotFlange();
        private Web wb = new Web();
        private TopFlange tf = new TopFlange();
        private Bolster blst = new Bolster();
        private Slab slb = new Slab();

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

            }
        }

        public CompositeBeam()
        {
            BotFlange = bf;
            Web = wb;
            TopFlange = tf;
            Bolster = blst;
            Slab = slb;
        }

        public CompositeBeam(BeamParts beamParts)
        {
            BotFlange = beamParts.BotFlange;
            Web = beamParts.Web;
            TopFlange = beamParts.TopFlange;
            Bolster = beamParts.Bolster;
            Slab = beamParts.Slab;
        }

        public double Area(double modRatio)
        {
            return BotFlange.Area() + Web.Area() + TopFlange.Area() + (Bolster.Area() + Slab.Area()) / modRatio;
        }

        public double NA_Elastc(double modRatio)
        {
            return Properties.elasticNeutralAxis(BotFlange, Web, TopFlange, Bolster, Slab, modRatio);
        }

        public double I_Elastic(double modRatio)
        {
            return Properties.elasticMomentOfInertia(BotFlange, Web, TopFlange, Bolster, Slab, modRatio);
        }

        public double S_Elastic(double modRatio, double location)
        {
            double NA = Properties.elasticNeutralAxis(BotFlange, Web, TopFlange, Bolster, Slab, modRatio);
            double I_Elastic = Properties.elasticMomentOfInertia(BotFlange, Web, TopFlange, Bolster, Slab, modRatio);
            return I_Elastic / Math.Abs(NA - location);
        }

        public double NA_Plastic()
        {
            return Properties.plasticNeutralAxis(BotFlange, Web, TopFlange, Bolster, Slab);
        }

        public double Mp()
        {
            double[] top = Properties.plasticTop(BotFlange, Web, TopFlange, Bolster, Slab);
            double[] bot = Properties.plasticBottom(BotFlange, Web, TopFlange, Bolster, Slab);

            return (top[0] * top[1] + bot[0] * bot[1])/12;
        }
                
    }
}
