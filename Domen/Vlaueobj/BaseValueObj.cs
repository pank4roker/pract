using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Vlaueobj
{
    public abstract class BaseValueObj
    {
        public override bool Equals(object? obj)
        {
            // TODO: Проресерчить, как сравнивать (DeepCLone, DeepCompare)
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
