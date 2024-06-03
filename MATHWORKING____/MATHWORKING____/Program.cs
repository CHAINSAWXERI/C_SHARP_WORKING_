//static void Main(string[] args)
//{
    List<int> fools = new List<int>();
    Console.Write("Введите Длинну Массива: ");
    int length = Convert.ToInt32(Console.ReadLine());
    for (int i = 0; i < length; i++)
    {
        Random rnd = new Random();
        int value = rnd.Next(1, 21);
        fools.Add(value);
        Console.WriteLine(value);
    }

    Console.WriteLine();

    int MaxResult = 0;
    List<int> reward = new List<int>();

    if (fools.Count > 1)
    {
        reward.Add(fools[0]);
        if (fools.Count > 2)
        {
            reward.Add(Max(fools[0], fools[1]));

            if (fools.Count > 3)
            {
                reward.Add(Max(fools[1], (fools[0] + fools[2])));

                if (fools.Count > 4)
                {
                    reward.Add(Max((fools[1] + fools[3]), (fools[0] + fools[2])));

                    for (int i = 0; i < fools.Count; i++)
                    {
                        reward.Add(Max((reward[i - 2] + fools[i]), (reward[i - 1])));
                    }

                    MaxResult = reward.Max();
                }
                else
                {
                    MaxResult = Max((fools[1] + fools[3]), (fools[0] + fools[2]));
                }
            }
            else
            {
                MaxResult = Max(fools[1], (fools[0] + fools[2]));
            }
        }
        else
        {
            MaxResult = Max(fools[0], fools[1]);
        }
    }
    else
    {
        MaxResult = fools[0];
    }

    
    Console.WriteLine();
    Console.WriteLine("Максимальное значение что мы можем выкрасть = " + MaxResult);
//}

static int Max(int a, int b)
{
    return a > b ? a : b;
}

