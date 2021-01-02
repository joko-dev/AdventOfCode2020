using System;
using System.Collections.Generic;
using System.Text;

namespace Day7
{
    public class BagColorType
    {
        public string Color { get;  }

        public BagColorType(string color)
        {
            color = color.Replace("bags", "bag");
            color = color.Replace("bag", "");
            color = color.Replace(".", "");
            Color = color.Trim();
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(BagColorType))
            {
                BagColorType color = (BagColorType)obj;
                return  color.Color == this.Color;
            }
            else
            {
                return base.Equals(obj);
            }
           
        }
    }
}
