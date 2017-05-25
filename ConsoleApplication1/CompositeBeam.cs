using System;
using System.Collections.Generic;

namespace TestObjectClass2
{
    public class CompositeBeam
    {
        private BotFlange _botflange = new BotFlange();
        private Web _web = new Web();
        private TopFlange _topflange = new TopFlange();
        private Bolster _bolster = new Bolster();
        private Slab _slab = new Slab();
        //private Reinforcing reinf = new Reinforcing(0, 0, 0, true);
        private List<Reinforcing> _reinforcing = new List<Reinforcing>();

        private void _setLocations(BotFlange botFlange, Web web, TopFlange topFlange, Bolster bolster, Slab slab, Reinforcing reinforcing)
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

        public CompositeBeam()
        {
            BotFlange = _botflange;
            Web = _web;
            TopFlange = _topflange;
            Bolster = _bolster;
            Slab = _slab;
            Reinforcing = _reinforcing;
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
