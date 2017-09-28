using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
/*
 * Gets a JSON file and puts in a Dictionary , so we can look up the key/value pairs stored in the JSON
 */

public class LocalizationManager : MonoBehaviour {

    public static LocalizationManager instance;

    private Dictionary<string, string> localizedText;
    private bool isReady = false;
    private string missingTextString = "Localized text not found";

    void Awake () 
    {
        if (instance == null) {
            instance = this;
        } else if (instance != this)
        {
            Destroy (gameObject);
        }

        DontDestroyOnLoad (gameObject);
    }
    
    /*
     * Use this function for an OnClick()
     * So the file loads when the button is clicked
     * Finally when the file is loaded set isReady=true and move to the next Scene
     */
    public void LoadLocalizedText(string fileName)
    {
        localizedText = new Dictionary<string, string> ();

        string filePath = Path.Combine (Application.streamingAssetsPath, fileName);

        if (File.Exists (filePath)) {
            string dataAsJson = File.ReadAllText (filePath);
            LocalizationData loadedData = JsonUtility.FromJson<LocalizationData> (dataAsJson);

            for (int i = 0; i < loadedData.items.Length; i++) 
            {
                localizedText.Add (loadedData.items [i].key, loadedData.items [i].value);   
            }

            Debug.Log ("Data loaded, dictionary contains: " + localizedText.Count + " entries");
        } else 
        {
            Debug.LogError ("Cannot find file!");
        }

        isReady = true;
    }

    /*
     * if the key is succesfully found return it
     * otherwise inform that "Localized text not found"
     */

    public string GetLocalizedValue(string key)
    {
        string result = missingTextString;

        if (localizedText.ContainsKey (key)) 
        {
            result = localizedText [key];
        }

        Debug.Log("GetLocalizedValue result: " + result);
        return result; 

    }

    public bool GetIsReady()
    {
        return isReady;
    }

}
 