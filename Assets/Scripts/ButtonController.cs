using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button returnToMainMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        Button returnToMainMenu = returnToMainMenuButton.GetComponent<Button>();
        returnToMainMenu.onClick.AddListener(LoadMainMenuSceneOnClick);

        Button playAgain = restartButton.GetComponent<Button>();
        playAgain.onClick.AddListener(RestartSceneOnClick);
    }

    private void LoadMainMenuSceneOnClick()
    {
        SceneManager.LoadScene(0);
    }

    private void RestartSceneOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
