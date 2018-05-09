using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {

    // Array of words
    private static string[] itemList = {"Speed Boost", "Bumper", "Size", "Push", "Pike"};



    // Take a random word from the array and set it to randomWord variable, then return it.
    public static string GetRandomItem()
    {

        int randomIndex = Random.Range(0, itemList.Length);
        string randomItem = itemList[randomIndex];

        return randomItem;
    }
}
