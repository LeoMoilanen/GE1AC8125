using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtonController : MonoBehaviour
{
    [SerializeField] private Button startGameButton;

    // Start is called before the first frame update
    void Start()
    {
        Button startGame = startGameButton.GetComponent<Button>();
        startGame.onClick.AddListener(LoadGameSceneOnClick);
    }

    private void LoadGameSceneOnClick()
    {
        SceneManager.LoadScene(1);
    }
}
