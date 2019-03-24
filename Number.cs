using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustTesting
{
    public class Number
    {
        public int Value { get; private set; }
        public int NumberSystem { get; private set; }

        public Number()
        {
            NumberSystem = 10;
            Value = 0;
        }

        public Number(int numberSystem)
        {
            NumberSystem = numberSystem > 1 ? numberSystem : 10;
            Value = 0;
        }

        public Number(int numberSystem, int value)
        {
            NumberSystem = numberSystem > 1 ? numberSystem : 10;
            Value = value;
        }

        private int Log(int lbase, int number)
        {
            return (int)Math.Log(number, lbase);
        }

        private Dictionary<int, int> getPowers()
        {
            int numberSystem = NumberSystem;
            int number = Value;
            Dictionary<int, int> result = new Dictionary<int, int>();
            int i = 0;
            int value = number;
            while (number >= numberSystem)
            {
                i = Log(numberSystem, number);
                int poweredNumberSystem = (int)Math.Pow(numberSystem, i);
                value = number / poweredNumberSystem;
                number = number - poweredNumberSystem * value;
                result.Add(i, value);
            }
            result.Add(0, number);

            return result;
        }

        private char getSimbolNumber(int value)
        {
            if (value <= 9 && value >= 0) return Convert.ToChar(value.ToString());
            return Convert.ToChar(Convert.ToInt32('A') + value - 10);
        }

        public string GetNumberSystemInfo()
        {
            return $"Number System is {NumberSystem} max = {NumberSystem - 1}:{getSimbolNumber(NumberSystem - 1)}";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            var powers = getPowers();
            int j = 0;
            for(int i = powers.First().Key; i >= 0; i--)
            {
                if(powers.GetPairByIndex(j).Key == i)
                {
                    sb.Append($"{getSimbolNumber(powers.GetPairByIndex(j).Value)}");
                    j++;
                }
                else
                {
                    sb.Append("0");
                }
            }

            return sb.ToString();
        }

    }
}
