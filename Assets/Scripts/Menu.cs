using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    
    private void Awake()
    {
        //quitButton.onClick.AddListener(Quit);
    }

    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadSceneAsync("Snake");
    }

    public void Quit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}    