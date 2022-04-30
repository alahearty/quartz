using System;

namespace quartz.wpf.domain.Models.Reservoirs
{
    public class BHP
    {
        private DateTime _date;
        private double _pressure;
        private string _drainagePoint;

        public DateTime Date { get => _date; set => _date = value; }
        public double Pressure { get => _pressure; set => _pressure = value; }
        public string DrainagePoint { get => _drainagePoint; set => _drainagePoint = value; }
    }
}