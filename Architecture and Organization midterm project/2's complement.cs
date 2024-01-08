// An efficient c# program to find 2's complement
using System;
using System.Text;

class GFG
{
    // Method to find two's complement
    public static string findTwoscomplement(StringBuilder str)
    {
        int n = str.Length;

        // Traverse the string to get
        // first '1' from the last of string
        int i;
        for (i = n - 1; i >= 0; i--)
        {
            if (str[i] == '1')
            {
                break;
            }
        }

        // If there exists no '1' concat 1
        // at the starting of string
        if (i == -1)
        {
            return "1" + str;
        }

        // Continue traversal after the
        // position of first '1'
        for (int k = i - 1; k >= 0; k--)
        {
            // Just flip the values
            if (str[k] == '1')
            {
                str.Remove(k, k + 1 - k).Insert(k, "0");
            }
            else if (str[k] == '.')
            {
                //str.Remove(k, k + 1 - k).Insert(k, ".");
                continue;
            }
            else if (str[k] == '0')
            {
                str.Remove(k, k + 1 - k).Insert(k, "1");
            }
        }

        // return the modified string
        string str1 = str.ToString();
        if (str1.Contains("."))
        {
            //str.Length--;
        }

        return str.ToString();

    }
}