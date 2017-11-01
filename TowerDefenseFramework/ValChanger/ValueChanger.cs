using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenseFramework.ValChanger
{
    class MultishotDmgDecreaser : IValueChanger
    {
        double percentage;
        double absolute;

        public MultishotDmgDecreaser(double percentage, double absolute, bool increase)
        {
            this.percentage = (increase ? percentage : -percentage);
            this.absolute = (increase ? absolute : -absolute); 
        }

        public double changeValue(ref double value)
        {
            value = (1 + percentage) * value + absolute;
            return value;
        }
    }
}
