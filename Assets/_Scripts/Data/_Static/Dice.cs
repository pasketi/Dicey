using UnityEngine;
using System.Collections;
using System;

public static class Dice {

    // Use formatting 2D8+10D4+5, where xDy is a dice roll and everything else is just a plus modifier
    public static int Roll(string roll)
    {
        int total = 0, IndexOfLatest = 0;
        char[] plus = { '+' }, tempChar = new char[7];
        int parts = _countChar(roll, plus[0]) + 1;
        bool secondGo = false;

        if (parts > 1)
        {
            for (int i = 0; i <= roll.Length; i++)
            {
                if (i != roll.IndexOfAny(plus, IndexOfLatest) && i != roll.Length)
                {
                    tempChar[i - IndexOfLatest] = roll.ToCharArray()[i];
                }

                if (i == roll.IndexOfAny(plus, IndexOfLatest) || i == roll.Length)
                {
                    string tempString = new string(tempChar, 0, i - IndexOfLatest);
                    IndexOfLatest = i + 1;
                    int Ds = _countChar(tempString, 'D');
                    if (Ds != 0)
                    {
                        total += RollOne(tempString);
                        //Debug.Log("Roll value after " + tempString + ": " + total.ToString());
                        tempChar = new char[7];
                    }
                    else if (Ds == 0)
                    {
                        total += int.Parse(tempString);
                        //Debug.Log("Roll value after " + tempString + ": " + total.ToString());
                        tempChar = new char[7];
                    }
                    if (!secondGo) secondGo = true;
                }
            }
        }
        else if (parts == 1)
        {
            if (_countChar(roll, 'D') == 1)
            {
                return RollOne(roll);
            }
            else if (int.TryParse(roll, out total) == false)
            {
                Debug.LogError("PARSE FAILED: SINGLE NUMBER");
                return 0;
            }
        }
        else
        {
            Debug.LogError("PARTS IF EQUAL OR UNDER 0 FOR SONE NON-APPARENT REASON! RETURNING 0!");
            return 0;
        }

        return total;
    }

    public static int RollOne(string die)
    {
        int total = 0;
        int pDice = 0;
        int pSides = 0;
        int loopUntil = 0;

        if (_countChar(die, 'D') != 1) {
            Debug.LogError("NO Ds FOUND! RETURNING");
            return 0;
        }
        else
        {
            int D = die.IndexOf('D');
            char[] dice = new char[3], sides = new char[3];

            if (die.IndexOf('\0') == -1)
                loopUntil = die.Length;
            else
                loopUntil = die.IndexOf('\0');
            for (int i = 0; i < loopUntil; i++)
            {
                if (i < D)
                    dice[i] = die.ToCharArray()[i];
                else if (i > D)
                {
                    sides[i - (D + 1)] = die.ToCharArray()[i];
                }
            }

            if (int.TryParse(new string(sides), out pSides) == false || int.TryParse(new string(dice), out pDice) == false)
            {
                Debug.LogError("PARSE FAILED: ONE DIE!");
                return 0;
            }

            for (int j = 0; j < pDice; j++)
            {
                total += UnityEngine.Random.Range(1, pSides + 1);
            }
            return total;
        }
    }

    //The simple way

    public static int Roll(int dice, int sides)
    {
        int total = 0;

        for (int i = 0; i < dice; i++)
        {
            total += UnityEngine.Random.Range(1, sides + 1);
        }

        return total;
    }

    private static int _countChar(string str, char cha)
    {
        int count = 0;
        foreach (char c in str)
            if (c == cha) count++;
        return count;
    }
}
