  public static void CSVFormat(string data)
    {
        int curLine = 0;
        int curCol = 0;
        bool doubleQuota = false;
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            stringBuilder.Append(data[i]);
            if (stringBuilder[0] == '"')
          
            {
                if (stringBuilder.Length >= 2)
                {
                    if (doubleQuota && data[i] == ',')
                    { 
                        var col =  stringBuilder.Remove(0,1).Remove(stringBuilder.Length - 2, 2).ToString();
                        Console.WriteLine("1line:"+curLine+" col:"+curCol+":"+col);
                        stringBuilder.Clear();
                        doubleQuota = false;
                        curCol++;
                        continue;
                    }
            
                    if (data[i] == '"')
                    {
                        if (doubleQuota)
                        {
                            doubleQuota = false;
                            stringBuilder= stringBuilder.Remove(stringBuilder.Length - 1, 1);
                        }
                        else
                        {
                            doubleQuota = true;
                        }
                    }
                    else
                    {
                        doubleQuota = false;
                    }
                }
            }
            else if (data[i] == ',')
            {
              
                var col =  stringBuilder.Remove(stringBuilder.Length - 1, 1).ToString();
                Console.WriteLine("2line:"+curLine+" col:"+curCol+":"+col);
                doubleQuota = false;
                curCol++;
                stringBuilder.Clear();
            }
            else if (data[i] == '\n')
            {
                int cut = 1;
                if (data[i - 1] == '\r')
                    cut = 2;
                var col = stringBuilder.Remove(stringBuilder.Length - cut, cut).ToString(); 
                Console.WriteLine("3line:"+curLine+" col:"+curCol+":"+col);
                curLine++;
                curCol = 0;
                doubleQuota = false;
                stringBuilder.Clear();
            }
        }
    }
