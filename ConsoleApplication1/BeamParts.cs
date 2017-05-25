using System.Collections.Generic;

namespace TestObjectClass2
{
    public class BeamParts
    {
        private BotFlange _botflange = new BotFlange();
        private Web _web = new Web();
        private TopFlange _topflange = new TopFlange();
        private Bolster _bolster = new Bolster();
        private Slab _slab = new Slab();
        //private Reinforcing reinf = new Reinforcing(0, 0, 0, true);
        private List<Reinforcing> _reinforcing = new List<Reinforcing>();

        private void _setLocations(BotFlange botFlange, Web web, TopFlange topFlange, Bolster bolster, Slab slab,Reinforcing reinforcing)
        {
            _botflange = botFlange;
            _web = web;
            _topflange = topFlange;
            _bolster = bolster;
            _slab = slab;
            _reinforcing.Add(reinforcing);

            _setLocations();
        }
        private void _setLocations()
        {
            _botflange.BotLocation = 0;
            _botflange.CG = BotFlange.y / 2;
            _botflange.TopLocation = _botflange.y;
            _web.BotLocation = _botflange.y;
            _web.CG = _botflange.y + Web.y / 2;
            _web.TopLocation = _botflange.y + Web.y;
            _topflange.BotLocation = _botflange.y + _web.y;
            _topflange.CG = _botflange.y + _web.y + _topflange.y / 2;
            _topflange.TopLocation = _botflange.y + _web.y + _topflange.y;
            _bolster.BotLocation = _botflange.y + _web.y + _topflange.y;
            _bolster.CG = _botflange.y + _web.y + _topflange.y + _bolster.y / 2;
            _bolster.TopLocation = _botflange.y + _web.y + _topflange.y + _bolster.y;
            _slab.BotLocation = _botflange.y + _web.y + _topflange.y + _bolster.y;
            _slab.CG = _botflange.y + _web.y + _topflange.y + _bolster.y + _slab.y / 2;
            _slab.TopLocation = _botflange.y + _web.y + _topflange.y + _bolster.y + _slab.y;
            foreach (Reinforcing reinf in _reinforcing)
            {
                if (reinf.DistToTopOfSlab)
                {
                    reinf.Location = _slab.TopLocation - reinf.DistToSlab;
                }
                else
                {
                    reinf.Location = _slab.BotLocation + reinf.DistToSlab;
                }
            }
        }

        public BotFlange BotFlange 
        {
            get { return _botflange; }
            set
            {
                _botflange = value;
                _setLocations();
            }
        }
        public Web Web 
        {
            get { return _web; }
            set
            {
                _web = value;
                _setLocations();
            }
        }
        public TopFlange TopFlange 
        {
            get { return _topflange; }
            set
            {
                _topflange = value;
                _setLocations();
            }
        }
        public Bolster Bolster 
        {
            get { return _bolster; }
            set
            {
                _bolster = value;
                _setLocations();
            }
        }
        public Slab Slab 
        {
            get { return _slab; }
            set
            {
                _slab = value;
                _setLocations();
            }
        }
        public List<Reinforcing> Reinforcing
        {
            get { return _reinforcing; }
            set
            {
                _reinforcing = value;
                _setLocations();
            }
        }

        public BeamParts()
        {
            BotFlange = _botflange;
            Web = _web;
            TopFlange = _topflange;
            Bolster = _bolster;
            Slab = _slab;
            Reinforcing = _reinforcing;
        }

        public BeamParts(BotFlange botFlange, Web web, TopFlange topFlange, Bolster bolster, Slab slab,Reinforcing reinforcing)
        {
            BotFlange = botFlange;
            Web = web;
            TopFlange = topFlange;
            Bolster = bolster;
            Slab = slab;
            Reinforcing.Add(reinforcing);

            _setLocations();
        }

    }
}
