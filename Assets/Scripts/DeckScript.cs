using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckScript : MonoBehaviour
{
    public Sprite[] cardSprites;
    int[] cardValues = new int[53];
    private int currentIndex = 0;

    void Start()
    {
        
    }

    void GetCardValues()
    {
        int num = 0;
        // loop to assign values to the cards
        for (int i = 0; i < cardSprites.Length; i++)
        {
            num = i;
            // count up to the amount of cards, 52
            num %= 13;
            // if there is a remainder after x/13 then remainder
            // is used as the value, unless over 10, then use 10
            if (num > 10 || num == 0)
            {
                num = 10;
            }
            cardValues[i] = num++;
        }

        currentIndex = 1;
    }
}
