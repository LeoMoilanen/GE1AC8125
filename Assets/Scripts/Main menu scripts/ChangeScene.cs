using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private Button startGameButton;

    // Start is called before the first frame update
    void Start()
    {
        Button startGame = startGameButton.GetComponent<Button>();
        startGame.onClick.AddListener(ChangeSceneOnClick);
    }

    private void ChangeSceneOnClick()
    {
        SceneManager.LoadScene(1);
    }
}
