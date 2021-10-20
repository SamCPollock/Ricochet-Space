/*
File name:      SceneButton.cs 
Author name:    Sam Pollock, Student #101279608 
Last modified:  October 1, 2021
Description:    Handles scene changing.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_SceneButton : MonoBehaviour
{
    [SerializeField]
    //int targetSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSceneChangeButtonPressed(int targetSceneIndex)
    {
        SceneManager.LoadScene(targetSceneIndex);
    }
}
