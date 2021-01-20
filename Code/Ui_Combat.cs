using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ui_Combat : MonoBehaviour
{
    [SerializeField] private Player playerScript;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject homeButton;


    private bool isPaused;
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        isPaused = false;

        pausePanel = GameObject.FindGameObjectWithTag("pausePanel");
        pausePanel.SetActive(false);
    }

    public void attackAction()
    {
        playerScript.Invoke("giveDamage", 0.25f);
    }

    public void fleeAction()
    {
        playerScript.Invoke("runAwayAttempt", 0.25f);
    }

    public void braceyourself()
    {
        playerScript.Invoke("braceyourselfAction", 0.25f);
    }

    public void pauseGame()
    {
        if (isPaused == true)
        {
            homeButton.SetActive(true);
            isPaused = false;
            Time.timeScale = 1;
            pausePanel.SetActive(false);

            return;
        }
        if (isPaused == false)
        {
            homeButton.SetActive(false);
            isPaused = true;
            Time.timeScale = 0;
            pausePanel.SetActive(true);

            return;
        }
    }

    public void toMainMenu()
    {
        GameObject[] GameObjects = (FindObjectsOfType<GameObject>() as GameObject[]);

        for (int i = 0; i < GameObjects.Length; i++)
        {
            isPaused = false;
            Time.timeScale = 1;
            Destroy(GameObjects[i]);
        }

        SceneManager.LoadScene(0);
    }

    public void upgradeVitality()
    {
        playerScript.upgradeVitality();
    }

    public void upgradeStrength()
    {
        playerScript.upgradeStrength();
    }

    public void upgradeDexterity()
    {
        playerScript.upgradeDexterity();
    }
}
