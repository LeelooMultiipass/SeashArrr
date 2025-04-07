using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public InputActionAsset inputActionAsset;

    private InputActionMap NavigationMap;
    private void Start()
    {
      
    }
    

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        if (sceneName == "Test Lylou")
        {
            NavigationMap = inputActionAsset.FindActionMap("GameplayNavigation");  
        }
        
    }
}
