using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartupManager : MonoBehaviour {

    //The Co rotuine will start automaticaly  
    private IEnumerator Start () {
        //check if we are ready
        while (!LocalizationManager.instance.GetIsReady())
        {
            yield return null; //wait 1 frame
        }

        //Load the scene when the relavent file has loaded
        SceneManager.LoadScene("MenuScreen");
	}
	

}
