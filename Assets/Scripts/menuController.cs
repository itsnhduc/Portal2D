using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour {

    
    void Start () {

    }

    public void LoadScene(string scene) {
        SceneManager.LoadScene(scene);
    }
    public void Closegame()
    {
        Application.Quit();
    }
}
