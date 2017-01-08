using System;

namespace TestObjectClass2
{
    public class BeamParts
    {
        public BotFlange botFlange_ { get; set; }
        public Web web_ { get; set; }
        public TopFlange topFlange_ { get; set; }
        public Bolster bolster_ { get; set; }
        public Slab slab_ { get; set; }

        public BeamParts() { }

        public BeamParts(BotFlange botFlange, Web web, TopFlange topFlange, Bolster bolster, Slab slab)
        {
            botFlange_ = botFlange;
            web_ = web;
            topFlange_ = topFlange;
            bolster_ = bolster;
            slab_ = slab;
        }

    }
}
