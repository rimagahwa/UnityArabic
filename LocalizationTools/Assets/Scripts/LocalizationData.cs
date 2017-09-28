using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * used to fill the dictionary
 * The classes must have the Serializable attribute so we can convert from/to JSON
 */

[System.Serializable]
public class LocalizationData  {

    public LocalizationItem[] items;
}

/**
 *  used to convert objects from JSON format 
 *  so a Dictionary can use this classe's Object to get the JSON data
 *  Since a Dictionry in Unity can't get the JSON data directly
 */
 [System.Serializable]
public class LocalizationItem
{
    public string key;
    public string value;
}
