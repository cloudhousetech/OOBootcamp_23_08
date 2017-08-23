using System;

namespace OoBootCamp
{
    // Understands specific metric
    public abstract class Unit : IEquatable<Unit>
    {
        protected readonly object UnitType;
        protected readonly double Ratio;
        protected readonly double Offset;

        public static readonly IntervalUnit Celsius = new IntervalUnit();
        public static readonly IntervalUnit Fahrenheit = new IntervalUnit(5 / 9.0, Celsius, 32.0);

        public static readonly QuantityUnit Teaspoon = new QuantityUnit();
        public static readonly QuantityUnit Tablespoon = new QuantityUnit(3, Teaspoon);
        public static readonly QuantityUnit Ounce = new QuantityUnit(2, Tablespoon);
        public static readonly QuantityUnit Cup = new QuantityUnit(8, Ounce);
        public static readonly QuantityUnit Pint = new QuantityUnit(2, Cup);
        public static readonly QuantityUnit Quart = new QuantityUnit(2, Pint);
        public static readonly QuantityUnit Gallon = new QuantityUnit(4, Quart);

        public static readonly QuantityUnit Inch = new QuantityUnit();
        public static readonly QuantityUnit Foot = new QuantityUnit(12, Inch);
        public static readonly QuantityUnit Yard = new QuantityUnit(3, Foot);
        public static readonly QuantityUnit Furlong = new QuantityUnit(220, Yard);
        public static readonly QuantityUnit Mile = new QuantityUnit(8, Furlong);

        internal Unit()
        {
            UnitType = this;
            Ratio = 1.0;
            Offset = 0.0;
        }
        internal Unit(double relativeRatio, Unit relativeQuantityUnit, double offset = 0.0)
        {
            Ratio = relativeRatio * relativeQuantityUnit.Ratio;
            UnitType = relativeQuantityUnit.UnitType;
            Offset = offset;
        }
        internal double ConvertAmount(Unit other, double otherAmount)
        {
            return (otherAmount - other.Offset) * other.Ratio / Ratio + Offset;
        }
        public bool Equals(Unit other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (!IsCompatible(other)) return false;
            return Ratio.Equals(other.Ratio);
        }
        public bool IsCompatible(Unit other)
        {
            return UnitType == other.UnitType;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((QuantityUnit)obj);
        }
        internal int GetHashCode(double amount)
        {
            return ((amount - Offset) * Ratio).GetHashCode();
        }
        public override int GetHashCode()
        {
            return Ratio.GetHashCode();
        }
    }

    public class IntervalUnit : Unit
    {
        internal IntervalUnit()
        {
        }
        internal IntervalUnit(double relativeRatio, Unit relativeQuantityUnit, double offset) : base(relativeRatio, relativeQuantityUnit, offset)
        {
        }

        public IntervalQuantity S(double amount)
        {
            return new IntervalQuantity(amount, this);
        }
    }

    // Understands specific metric
    public class QuantityUnit : Unit
    {
        internal QuantityUnit()
        {
        }
        internal QuantityUnit(double relativeRatio, Unit relativeQuantityUnit, double offset = 0.0) : base(relativeRatio, relativeQuantityUnit, offset)
        {
        }

        public RatioQuantity S(double amount)
        {
            return new RatioQuantity(amount, this);
        }
    }


    // understands measurements.
    public class IntervalQuantity : IEquatable<IntervalQuantity>
    {
        protected readonly double Amount;
        protected readonly Unit Unit;
        private const double Precision = 0.000001;

        internal IntervalQuantity(double amount, Unit quantityUnit)
        {
            Amount = amount;
            Unit = quantityUnit;
        }
        protected double ConvertedAmount(IntervalQuantity other)
        {
            if (!IsCompatible(other))
                throw new InvalidOperationException("Incompatible Unit types");

            return Unit.ConvertAmount(other.Unit, other.Amount);
        }
        public bool Equals(IntervalQuantity other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (!IsCompatible(other)) return false;
            return Math.Abs(Amount - ConvertedAmount(other)) < Precision;
        }
        private bool IsCompatible(IntervalQuantity other)
        {
            return Unit.IsCompatible(other.Unit);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((IntervalQuantity)obj);
        }
        public override int GetHashCode() => Unit.GetHashCode(Amount);
    }
    
    // understands measurements.
    public class RatioQuantity : IntervalQuantity
    {
        internal RatioQuantity(double amount, Unit quantityUnit) : base(amount, quantityUnit)
        {
        }
        public static RatioQuantity operator -(RatioQuantity left, RatioQuantity right) => left + -right;
        public static RatioQuantity operator -(RatioQuantity q) => new RatioQuantity(-q.Amount, q.Unit);
        public static RatioQuantity operator +(RatioQuantity left, RatioQuantity right) => new RatioQuantity(left.Amount + left.ConvertedAmount(right), left.Unit);
        public static RatioQuantity operator +(RatioQuantity q) => new RatioQuantity(q.Amount, q.Unit);
    }

    public static class QuantityWeightExtension
    {
        public static RatioQuantity Teaspoon(this double @this) => new RatioQuantity(@this, Unit.Teaspoon);
        public static RatioQuantity Teaspoon(this int @this) => new RatioQuantity(@this, Unit.Teaspoon);
        public static RatioQuantity Tablespoon(this double @this) => new RatioQuantity(@this, Unit.Tablespoon);
        public static RatioQuantity Tablespoon(this int @this) => new RatioQuantity(@this, Unit.Tablespoon);
        public static RatioQuantity Ounce(this double @this) => new RatioQuantity(@this, Unit.Ounce);
        public static RatioQuantity Ounce(this int @this) => new RatioQuantity(@this, Unit.Ounce);
        public static RatioQuantity Cup(this double @this) => new RatioQuantity(@this, Unit.Cup);
        public static RatioQuantity Cup(this int @this) => new RatioQuantity(@this, Unit.Cup);
        public static RatioQuantity Pint(this double @this) => new RatioQuantity(@this, Unit.Pint);
        public static RatioQuantity Pint(this int @this) => new RatioQuantity(@this, Unit.Pint);
        public static RatioQuantity Quart(this double @this) => new RatioQuantity(@this, Unit.Quart);
        public static RatioQuantity Quart(this int @this) => new RatioQuantity(@this, Unit.Quart);
        public static RatioQuantity Gallon(this double @this) => new RatioQuantity(@this, Unit.Gallon);
        public static RatioQuantity Gallon(this int @this) => new RatioQuantity(@this, Unit.Gallon);
        
        public static RatioQuantity Inch(this double @this) => new RatioQuantity(@this, Unit.Inch);
        public static RatioQuantity Inch(this int @this) => new RatioQuantity(@this, Unit.Inch);
        public static RatioQuantity Foot(this double @this) => new RatioQuantity(@this, Unit.Foot);
        public static RatioQuantity Foot(this int @this) => new RatioQuantity(@this, Unit.Foot);
        public static RatioQuantity Yard(this double @this) => new RatioQuantity(@this, Unit.Yard);
        public static RatioQuantity Yard(this int @this) => new RatioQuantity(@this, Unit.Yard);
        public static RatioQuantity Furlong(this double @this) => new RatioQuantity(@this, Unit.Furlong);
        public static RatioQuantity Furlong(this int @this) => new RatioQuantity(@this, Unit.Furlong);
        public static RatioQuantity Mile(this double @this) => new RatioQuantity(@this, Unit.Mile);
        public static RatioQuantity Mile(this int @this) => new RatioQuantity(@this, Unit.Mile);

        public static IntervalQuantity Celsius(this double @this) => new IntervalQuantity(@this, Unit.Celsius);
        public static IntervalQuantity Celsius(this int @this) => new IntervalQuantity(@this, Unit.Celsius);
        public static IntervalQuantity Fahrenheit(this double @this) => new IntervalQuantity(@this, Unit.Fahrenheit);
        public static IntervalQuantity Fahrenheit(this int @this) => new IntervalQuantity(@this, Unit.Fahrenheit);
    }
}
