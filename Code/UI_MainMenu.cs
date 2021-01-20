using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject firstPersonPlayer;
    [SerializeField] private GameObject homeCamera;
    [SerializeField] private GameObject levelButton;
    [SerializeField] private GameObject startWalking;
    [SerializeField] private GameObject stopwalking;

    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void goHomeButton()
    {
        SceneManager.LoadScene(1);
    }

    public void startLevel()
    {
        SceneManager.LoadScene(2); 
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void activateFirstPerson()
    {
        homeCamera.SetActive(false);
        levelButton.SetActive(false);
        startWalking.SetActive(false);
        stopwalking.SetActive(true);
        firstPersonPlayer.SetActive(true);
    }

    public void deactivateFirstPerson()
    {
        homeCamera.SetActive(true);
        levelButton.SetActive(true);
        startWalking.SetActive(true);
        stopwalking.SetActive(false);
        firstPersonPlayer.SetActive(false);
    }
}
