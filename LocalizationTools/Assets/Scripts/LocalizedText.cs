using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ArabicSupport;

/*
 * Shows the localized text based on the JSON file
 */

public class LocalizedText : MonoBehaviour
{

    public string key;//Use Unity Editor to write the key that is stored in the JSON file
    private string value;

    public bool arabicSupport;
    public bool ShowTashkeel = false;
    public bool UseHinduNumbers = true;

    // Use this for initialization
    void Start()
    {
        /*
         * Text Object Attached 
         */

        Text text =GetComponent<Text>();

        if (text != null)
        {
            Debug.Log(gameObject + " has text: " + text.name + " key:" + key);
            if (LocalizationManager.instance != null)
            {
                //Search for the key in the Dictionary and return the value of the key
                value = LocalizationManager.instance.GetLocalizedValue(key);

                //if Arabic is checked , fix the Arabic text
                if (arabicSupport)
                {
                    text.text = ArabicFixer.Fix(value, ShowTashkeel, UseHinduNumbers);
                }
                else
                {
                    text.text = value;
                }
             
               
                Debug.Log("Changed to text.text " + text.text);
            }
            else
            {
                text.text = "Error";
            }

        }



    }

}