using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

#pragma warning disable S2368

namespace LookingForArrayElements
{
    public static class DecimalCounter
    {
        public static int GetDecimalsCount(decimal[] arrayToSearch, decimal[][] ranges)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }
            else if (ranges is null)
            {
                throw new ArgumentNullException(nameof(ranges));
            }
            else
            {
                for (int x = 0; x < ranges.Length; x++)
                {
                    if (ranges[x] is null)
                    {
                        throw new ArgumentNullException(nameof(ranges));
                    }
                    else if ((ranges[x].Length > 0 && ranges[x].Length < 2) || ranges[x].Length > 2)
                    {
                        throw new ArgumentException(null);
                    }
                }

                int sum = 0;

                foreach (decimal[] range in ranges)
                {
                    for (int i = 0; i < arrayToSearch.Length; i++)
                    {
                        if (range.Length == 0)
                        {
                            continue;
                        }

                        if (range[0] == decimal.One)
                        {
                            range[0] = 0.1m;
                        }

                        if (range[1] == decimal.One)
                        {
                            range[1] = 0.1m;
                        }

                        if (arrayToSearch[i] >= range[0] && arrayToSearch[i] <= range[1])
                        {
                            sum++;
                        }
                    }
                }

                return sum;
            }
        }

        public static int GetDecimalsCount(decimal[] arrayToSearch, decimal[][] ranges, int startIndex, int count)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }
            else if (ranges is null)
            {
                throw new ArgumentNullException(nameof(ranges));
            }
            else if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }
            else
            {
                for (int x = 0; x < ranges.Length; x++)
                {
                    if (ranges[x] is null)
                    {
                        throw new ArgumentNullException(nameof(ranges));
                    }
                    else if ((ranges[x].Length > 0 && ranges[x].Length < 2) || ranges[x].Length > 2)
                    {
                        throw new ArgumentException(null);
                    }
                }
            }

            if (startIndex + count > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayToSearch));
            }
            else
            {
                int value = 0;

                foreach (decimal[] range in ranges)
                {
                    for (int i = startIndex; i <= startIndex + count; i++)
                    {
                        if (range.Length == 0)
                        {
                            continue;
                        }

                        if (i - startIndex >= count)
                        {
                            continue;
                        }

                        if (range[0] == decimal.One)
                        {
                            range[0] = 0.1m;
                        }

                        if (range[1] == decimal.One)
                        {
                            range[1] = 0.1m;
                        }

                        if (arrayToSearch[i] >= range[0] && arrayToSearch[i] <= range[1])
                        {
                            value++;
                        }
                    }
                }

                return value;
            }
        }
    }
}
