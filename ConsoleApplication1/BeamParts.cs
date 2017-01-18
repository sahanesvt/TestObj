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
        private Reinforcing reinf = new Reinforcing(0, 0, 0, true);
        private List<Reinforcing> reinforcing = new List<Reinforcing>();
        //private void populateReinf()
        //{
        //    reinforcing.Add(reinf);
        //}

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
                foreach(Reinforcing reinf in reinforcing)
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

        public BeamParts()
        {
            BotFlange = bf;
            Web = wb;
            TopFlange = tf;
            Bolster = blst;
            Slab = slb;
            Reinforcing = reinforcing;
        }

        public BeamParts(BotFlange botFlange, Web web, TopFlange topFlange, Bolster bolster, Slab slab)
        {
            BotFlange = botFlange;
            Web = web;
            TopFlange = topFlange;
            Bolster = bolster;
            Slab = slab;
            Reinforcing = reinforcing;

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
