using System;

namespace SeleniumTest.Utils.DataUtil;

internal class GenerateRandom
{
    private static Random _random = new Random();

    public String RandomString(int size)
    {
        String str = "abcdefghijklmnopqrstuvwxyz";
        String ran = "";

        for (int i = 0; i < size; i++)
        {
            int x = _random.Next(26);
            ran = ran + str[x];
        }
        return ran;
    }

    public String RandomNumbers(int maxValue)
    {
        return _random.Next(maxValue).ToString();
    }

    public String RandomNumbers(int minValue, int maxValue)
    {
        return _random.Next(minValue,maxValue).ToString();
    }

    public String RandomTwoDecimals()
    {
        return String.Format("{0:0.00}", _random.NextDouble());
    }

    public String RandomEmail()
    {
        return RandomString(9) + RandomNumbers(99) + "@random.rnd";
    }

    public String RandomFutureDate(int maxDays)
    {
        DateTime start = DateTime.Today;
        return start.AddDays(_random.Next(1,maxDays)).ToString();
    }

    public String RandomPastDate(int maxDays)
    {
        DateTime start = DateTime.Today;
        int negativeDays = -1 * (_random.Next(1, maxDays));
        return start.AddDays(negativeDays).ToString();
    }
}
