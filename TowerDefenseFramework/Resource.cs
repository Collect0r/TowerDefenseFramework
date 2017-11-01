using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TowerDefenseFramework
{
    enum ResourceType { LIFE, MANA, SHIELD }
    class Resource
    {
        object amountLockObj;

        ResourceType resourceType;
        BaseStat maxAmountStat;
        double amount;
        double autoregAmount;
        int autoregInterval_ms;
        
        // all or nothing
        public bool decreaseFull(double amount)
        {
            lock (amountLockObj)
            {
                if (this.amount >= amount)
                {
                    this.amount -= amount;
                    return true;
                }

                return false;
            }
        }

        // down to zero with rest TODO
        public double decreaseWithRest(double amount)
        {
            lock (amountLockObj)
            {
                if (this.amount >= amount)
                {
                    this.amount -= amount;
                    return 0;
                }
                else
                {
                    double temp = amount - this.amount;
                    this.amount = 0;
                    return temp;
                }
            }
        }

        // all or nothing
        public bool increaseFull(double amount)
        {
            lock (amountLockObj)
            {
                double newAmount = this.amount + amount;
                double maxAmount = maxAmountStat.getAmount();

                if (newAmount <= maxAmount)
                {
                    amount = newAmount;
                    return true;
                }

                return false;
            }
        }

        // down to zero with rest TODO
        public double increaseWithRest(double amount)
        {
            lock (amountLockObj)
            {
                double newAmount = this.amount + amount;
                double maxAmount = maxAmountStat.getAmount();

                if (newAmount <= maxAmount)
                {
                    this.amount = newAmount;
                    return 0;
                }
                else
                {
                    double temp = newAmount - maxAmount;
                    this.amount = maxAmount;
                    return temp;
                }
            }
        }

        public void changeAutoregInterval(int newInterval_ms)
        {

        }
    }
}
