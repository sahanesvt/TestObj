using System;

namespace TestObjectClass2
{
    public class BeamParts
    {
        private BotFlange bf = new BotFlange();
        private Web wb = new Web();
        private TopFlange tf = new TopFlange();
        private Bolster blst = new Bolster();
        private Slab slb = new Slab();

        public BotFlange BotFlange //{ get; set; }
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

                //bf.BeamBotFlange = value;
                //bf.BeamWeb = wb;
                //bf.BeamTopFlange = tf;
                //bf.BeamBolster = blst;
                //bf.BeamSlab = slb;
            }
        }
        public Web Web //{ get; set; }
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

                //wb.BeamBotFlange = bf;
                //wb.BeamWeb = value;
                //wb.BeamTopFlange = tf;
                //wb.BeamBolster = blst;
                //wb.BeamSlab = slb;
            }
        }
        public TopFlange TopFlange //{ get; set; }
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

                //tf.BeamBotFlange = bf;
                //tf.BeamWeb = wb;
                //tf.BeamTopFlange = value;
                //tf.BeamBolster = blst;
                //tf.BeamSlab = slb;
            }
        }
        public Bolster Bolster //{ get; set; }
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

                //blst.BeamBotFlange = bf;
                //blst.BeamWeb = wb;
                //blst.BeamTopFlange = tf;
                //blst.BeamBolster = value;
                //blst.BeamSlab = slb;
            }
        }
        public Slab Slab //{ get; set; }
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

                //slb.BeamBotFlange = bf;
                //slb.BeamWeb = wb;
                //slb.BeamTopFlange = tf;
                //slb.BeamBolster = blst;
                //slb.BeamSlab = value;
            }
        }

        public BeamParts()
        {
            BotFlange = bf;
            Web = wb;
            TopFlange = tf;
            Bolster = blst;
            Slab = slb;
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

            //BotFlange.BeamBotFlange = BotFlange;
            //BotFlange.BeamWeb = Web;
            //BotFlange.BeamTopFlange = TopFlange;
            //BotFlange.BeamBolster = Bolster;
            //BotFlange.BeamSlab = Slab;
            //Web.BeamBotFlange = BotFlange;
            //Web.BeamWeb = Web;
            //Web.BeamTopFlange = TopFlange;
            //Web.BeamBolster = Bolster;
            //Web.BeamSlab = Slab;
            //TopFlange.BeamBotFlange = BotFlange;
            //TopFlange.BeamWeb = Web;
            //TopFlange.BeamTopFlange = TopFlange;
            //TopFlange.BeamBolster = Bolster;
            //TopFlange.BeamSlab = Slab;
            //Bolster.BeamBotFlange = BotFlange;
            //Bolster.BeamWeb = Web;
            //Bolster.BeamTopFlange = TopFlange;
            //Bolster.BeamBolster = Bolster;
            //Bolster.BeamSlab = Slab;
            //Slab.BeamBotFlange = BotFlange;
            //Slab.BeamWeb = Web;
            //Slab.BeamTopFlange = TopFlange;
            //Slab.BeamBolster = Bolster;
            //Slab.BeamSlab = Slab;
        }

    }
}
