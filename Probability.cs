/* 
 * Copyright (c) 2017 by Fred George
 * May be used freely except for training; license required for training.
 */

using System;

namespace OoBootCamp
{
    // Understands the likelihood of something occurring
    public class Probability : IEquatable<Probability>
    {
        private readonly double _fraction;
        private readonly double ImpossibleFraction = 0.0;
        private readonly double CertainFraction = 1.0;

        public Probability(double likelihoodAsFraction)
        {
            if (likelihoodAsFraction < ImpossibleFraction)
                throw new ArgumentException();

            if (likelihoodAsFraction > CertainFraction)
                throw new ArgumentException();

            _fraction = likelihoodAsFraction;
        }

        public bool Equals(Probability other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return this._fraction.Equals(other._fraction);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Probability) obj);
        }

        public override int GetHashCode()
        {
            return _fraction.GetHashCode();
        }

        public Probability Not()
        {
            return new Probability(CertainFraction - _fraction);
        }
        
        public Probability And(Probability other)
        {
            return new Probability(_fraction * other._fraction);
        }

        public Probability Or(Probability other)
        {
            return Not().And(other.Not()).Not();
//            return new Probability(CertainFraction - (CertainFraction - _fraction) * (CertainFraction - other._fraction));
//            return new Probability(_fraction + other._fraction - _fraction * other._fraction);
//            return new Probability(_fraction + other._fraction - And(other)._fraction);
        }

    }


}