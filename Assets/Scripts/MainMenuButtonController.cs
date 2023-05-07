using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonController : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuButtons;
    [SerializeField] private GameObject storyMenuButtons;
    [SerializeField] private GameObject story1;
    [SerializeField] private GameObject story2;
    [SerializeField] private GameObject story3;
    [SerializeField] private GameObject story4;
    [SerializeField] private GameObject story5;
    [SerializeField] private GameObject storyBackground;
    [SerializeField] private GameObject controlsText;

    public void LoadGameScene()
    {
        SceneManager.LoadScene(2);
    }

    public void OpenStoryMenu()
    {
        mainMenuButtons.gameObject.SetActive(false);
        storyMenuButtons.gameObject.SetActive(true);
        storyBackground.gameObject.SetActive(true);
        controlsText.gameObject.SetActive(false);
    }

    public void CloseStoryMenu()
    {
        mainMenuButtons.gameObject.SetActive(true);
        storyMenuButtons.gameObject.SetActive(false);
        storyBackground.gameObject.SetActive(false);
        controlsText.gameObject.SetActive(true);
        story1.gameObject.SetActive(false);
        story2.gameObject.SetActive(false);
        story3.gameObject.SetActive(false);
        story4.gameObject.SetActive(false);
        story5.gameObject.SetActive(false);
    }

    public void OpenStory1()
    {
        story1.gameObject.SetActive(true);
        story2.gameObject.SetActive(false);
        story3.gameObject.SetActive(false);
        story4.gameObject.SetActive(false);
        story5.gameObject.SetActive(false);
    }

    public void OpenStory2()
    {
        story1.gameObject.SetActive(false);
        story2.gameObject.SetActive(true);
        story3.gameObject.SetActive(false);
        story4.gameObject.SetActive(false);
        story5.gameObject.SetActive(false);
    }

    public void OpenStory3()
    {
        story1.gameObject.SetActive(false);
        story2.gameObject.SetActive(false);
        story3.gameObject.SetActive(true);
        story4.gameObject.SetActive(false);
        story5.gameObject.SetActive(false);
    }

    public void OpenStory4()
    {
        story1.gameObject.SetActive(false);
        story2.gameObject.SetActive(false);
        story3.gameObject.SetActive(false);
        story4.gameObject.SetActive(true);
        story5.gameObject.SetActive(false);
    }

    public void OpenStory5()
    {
        story1.gameObject.SetActive(false);
        story2.gameObject.SetActive(false);
        story3.gameObject.SetActive(false);
        story4.gameObject.SetActive(false);
        story5.gameObject.SetActive(true);
    }
}
