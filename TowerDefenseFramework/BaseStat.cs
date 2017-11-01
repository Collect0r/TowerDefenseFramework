using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenseFramework
{
    class BaseStat
    {
        private object lockObject = new object();

        private double baseStat;
        private double statIncrease_Perc;
        private double statIncrease_Abs;

        public double getAmount()
        {
            return baseStat * (1 + statIncrease_Perc) + statIncrease_Abs;
        }

        public void changeBaseStat(double amount)
        {
            lock (lockObject)
            {
                baseStat = Math.Max(baseStat + amount, 0);
            }
        }

        public void changeStatIncrease_Perc(double amount)
        {
            lock (lockObject)
            {
                statIncrease_Perc = Math.Max(statIncrease_Perc + amount, -1);
            }
        }

        public void changeStatIncrease_Abs(double amount)
        {
            lock (lockObject)
            {
                statIncrease_Abs = Math.Max(statIncrease_Abs + amount, -baseStat);
            }
        }

    }
}
