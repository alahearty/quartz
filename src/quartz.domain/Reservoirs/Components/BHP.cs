using System;

namespace Quartz.Domain.Reservoirs
{
    public class BHP
    {
        public virtual DateTime Date { get; set; }
        public virtual double Pressure { get; set; }
        public virtual string DrainagePoint { get; set; }
    }
}
