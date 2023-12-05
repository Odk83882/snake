using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    private void Awake()
    {
        //quitButton.onClick.AddListener(Quit);
    }

    // Start is called before the first frame update

    public void Back()
    {
        SceneManager.LoadSceneAsync("Menu");

    }


}
