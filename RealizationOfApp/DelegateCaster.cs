using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealizationOfApp
{
    public static class DelegateCaster
    {
        public static WinEventHandler<EventArgs> CastToEvHan<T>(WinEventHandler<T> eventHandler)where T:EventArgs
        {
            return (x, y) =>
            {
                if (y is T z)
                {
                    eventHandler.Invoke(x, z);
                }
                else
                    throw new ArgumentException("Not suitable EvArgs");
            };
        }
    }
}
