using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class LocalizedTextEditor : EditorWindow {

    public LocalizationData localizationData;

    [MenuItem ("Window/Localized Text Editor")] //This will be shown in the tool bar of the Unity Editor
    static void Init()
    {
        EditorWindow.GetWindow(typeof(LocalizedTextEditor)).Show();
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Load data"))
        {
            LoadGameData();
        }

        if (GUILayout.Button("Create new data"))
        {
            CreatNewData();
        }

        //if there's data that loaded
        if (localizationData != null)
        {
            if (GUILayout.Button("Save data"))
            {
                SaveGameData();
            }

            SerializedObject serializedObject = new SerializedObject(this);//from this window
            SerializedProperty serializedProperty = serializedObject.FindProperty("localizationData");// this will be shown in the editor
            EditorGUILayout.PropertyField(serializedProperty, true);

            serializedObject.ApplyModifiedProperties();

            
        }

        
    }


    private void SaveGameData()
    {
        //where to save
        string filePath = EditorUtility.SaveFilePanel("Save localization data file", Application.streamingAssetsPath,
            "", "json");

        //Save the data as json String
        if (!string.IsNullOrEmpty(filePath))
        {
            string dataAsJson = JsonUtility.ToJson(localizationData);
            File.WriteAllText(filePath, dataAsJson);
        }
    }

    private void LoadGameData()
    {
        string filePath = EditorUtility.OpenFilePanel("Select loclization data file", Application.streamingAssetsPath, "json");

        if (!string.IsNullOrEmpty(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);

            localizationData = JsonUtility.FromJson<LocalizationData>(dataAsJson);
        }
    }


    /**
     * Creates an Array that has a key/value pair 
     */

    private void CreatNewData()
    {
        localizationData = new LocalizationData();
    }
}
