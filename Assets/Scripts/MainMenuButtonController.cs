using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtonController : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuButtons;
    [SerializeField] private GameObject storyMenuButtons;
    [SerializeField] private GameObject story1;
    [SerializeField] private GameObject story2;
    [SerializeField] private GameObject story3;

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenStoryMenu()
    {
        mainMenuButtons.gameObject.SetActive(false);
        storyMenuButtons.gameObject.SetActive(true);
    }

    public void CloseStoryMenu()
    {
        mainMenuButtons.gameObject.SetActive(true);
        storyMenuButtons.gameObject.SetActive(false);
        story1.gameObject.SetActive(false);
        story2.gameObject.SetActive(false);
        story3.gameObject.SetActive(false);
    }

    public void OpenStory1()
    {
        story1.gameObject.SetActive(true);
        story2.gameObject.SetActive(false);
        story3.gameObject.SetActive(false);
    }

    public void OpenStory2()
    {
        story1.gameObject.SetActive(false);
        story2.gameObject.SetActive(true);
        story3.gameObject.SetActive(false);
    }

    public void OpenStory3()
    {
        story1.gameObject.SetActive(false);
        story2.gameObject.SetActive(false);
        story3.gameObject.SetActive(true);
    }

}
