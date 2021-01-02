using System;
using System.Collections.Generic;
using System.Text;

namespace Day7
{
    public class BagType
    {
        public BagColorType Color { get; }
        public List<Tuple<int, BagColorType>> ContainableBagColors { get; } = new List<Tuple<int, BagColorType>>();

        public BagType(string line)
        {
            line = line.Replace("bags", "bag");
            Color = new BagColorType(line.Substring(0, line.IndexOf("contain")));

            string contains = line.Substring(line.IndexOf("contain") + "contain".Length);
            string[] colors = contains.Split(",");

            foreach (string bag in colors)
            {
                int count;
                string tempBag = bag.Trim();
                if (int.TryParse(tempBag.Substring(0, tempBag.IndexOf(' ')), out count))
                {
                    string color = tempBag.Substring(tempBag.IndexOf(" ")).Trim();
                    ContainableBagColors.Add(new Tuple<int, BagColorType>(count, new BagColorType(color)));
                }
            }
        }

        public bool ContainsColor(BagColorType color)
        {

            foreach(Tuple<int, BagColorType> item in ContainableBagColors)
            {
                if (item.Item2.Equals(color))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsEmpty()
        {
            return ContainableBagColors.Count == 0;
        }
    }
}
