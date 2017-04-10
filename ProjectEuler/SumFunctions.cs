using System.Collections.Generic;

namespace ProjectEuler
{
    public static class SumFunctions
    {
        public static long ComputeMaximumPath(List<List<long>> numbers)
        {
            while (true)
            {
                var secondToLastLine = numbers[numbers.Count - 2];
                var lastLine = numbers[numbers.Count - 1];

                var newSecondToLastLine = new List<long>();

                for (var i = 0; i < secondToLastLine.Count; i++)
                {
                    if (lastLine[i] > lastLine[i + 1])
                    {
                        newSecondToLastLine.Add(secondToLastLine[i] + lastLine[i]);
                    }
                    else
                    {
                        newSecondToLastLine.Add(secondToLastLine[i] + lastLine[i + 1]);
                    }
                }

                numbers[numbers.Count - 2] = newSecondToLastLine;
                numbers.RemoveAt(numbers.Count - 1);

                if (numbers.Count == 1)
                {
                    return numbers[0][0];
                }
            }
        }
    }
}
