using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenseFramework.ValChanger
{
    interface IValueChanger
    {
        double changeValue(ref double value);
    }
}
