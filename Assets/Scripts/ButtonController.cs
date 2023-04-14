using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void LoadMainMenuSceneOnClick()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartSceneOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
