using System.Collections.Generic;

namespace TestObjectClass2
{
    public class BeamParts
    {
        private BotFlange bf = new BotFlange();
        private Web wb = new Web();
        private TopFlange tf = new TopFlange();
        private Bolster blst = new Bolster();
        private Slab slb = new Slab();
        //private Reinforcing reinforcing = new Reinforcing(0, 0, 0, true);

        public BotFlange BotFlange 
        {
            get { return bf; }
            set
            {
                bf = value;
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

            }
        }
        public Web Web 
        {
            get { return wb; }
            set
            {
                wb = value;
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

            }
        }
        public TopFlange TopFlange 
        {
            get { return tf; }
            set
            {
                tf = value;
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

            }
        }
        public Bolster Bolster 
        {
            get { return blst; }
            set
            {
                blst = value;
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

            }
        }
        public Slab Slab 
        {
            get { return slb; }
            set
            {
                slb = value;
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

            }
        }
        //private List<Reinforcing> reinf;
        //public List<Reinforcing> Reinf
        //{
        //    get { return reinf; }
        //    set { reinf = value; }
        //}

        public BeamParts()
        {
            BotFlange = bf;
            Web = wb;
            TopFlange = tf;
            Bolster = blst;
            Slab = slb;
            //Reinf.Add(reinforcing);
        }

        public BeamParts(BotFlange botFlange, Web web, TopFlange topFlange, Bolster bolster, Slab slab)
        {
            BotFlange = botFlange;
            Web = web;
            TopFlange = topFlange;
            Bolster = bolster;
            Slab = slab;

            BotFlange.BotLocation = 0;
            BotFlange.CG = BotFlange.y / 2;
            BotFlange.TopLocation = BotFlange.y;
            Web.BotLocation = BotFlange.y;
            Web.CG = BotFlange.y + Web.y / 2;
            Web.TopLocation = BotFlange.y + Web.y;
            TopFlange.BotLocation = BotFlange.y + Web.y;
            TopFlange.CG = BotFlange.y + Web.y + TopFlange.y / 2;
            TopFlange.TopLocation = BotFlange.y + Web.y + TopFlange.y;
            Bolster.BotLocation = BotFlange.y + Web.y + TopFlange.y;
            Bolster.CG = BotFlange.y + Web.y + TopFlange.y + Bolster.y / 2;
            Bolster.TopLocation = BotFlange.y + Web.y + TopFlange.y + Bolster.y;
            Slab.BotLocation = BotFlange.y + Web.y + TopFlange.y + Bolster.y;
            Slab.CG = BotFlange.y + Web.y + TopFlange.y + Bolster.y + Slab.y / 2;
            Slab.TopLocation = BotFlange.y + Web.y + TopFlange.y + Bolster.y + Slab.y;

        }

    }
}
