using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Switcher : MonoBehaviour
{

    [SerializeField] private GameObject CombatUI;
    [SerializeField] private GameObject Bars;
    [SerializeField] private GameObject playerInventory;
    [SerializeField] private GameObject baseInventory;
    [SerializeField] private GameObject statPanel;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject backgroundWildernessButton;
    [SerializeField] private GameObject basePlayButton;
    [SerializeField] private GameObject walkAroundButton;
    [SerializeField] private GameObject stopWalkingButton;
    [SerializeField] private GameObject crasftButton;
    [SerializeField] private GameObject manageInventoryButton;

    public static UI_Switcher instance;

    // Start is called before the first frame update
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(obj: this);
        }
    }

    void Start()
    {
        CombatUI.SetActive(false);
        Bars.SetActive(false);
        playerInventory.SetActive(false);
        baseInventory.SetActive(false);
        statPanel.SetActive(false);
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
        backgroundWildernessButton.SetActive(false);
        basePlayButton.SetActive(true);
        walkAroundButton.SetActive(true);
        stopWalkingButton.SetActive(true);
        crasftButton.SetActive(true);
        manageInventoryButton.SetActive(true);
    }

    // Update is called once per frame
    public void manageInventory()
    {
        CombatUI.SetActive(false);
        Bars.SetActive(false);
        playerInventory.SetActive(true);
        baseInventory.SetActive(true);
        statPanel.SetActive(false);
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
        backgroundWildernessButton.SetActive(false);
        basePlayButton.SetActive(true);
        walkAroundButton.SetActive(true);
        stopWalkingButton.SetActive(true);
        crasftButton.SetActive(true);
        manageInventoryButton.SetActive(true);
    }

    public void enteringWilderness()
    {

    }

    public void fighting()
    {

    }

    public void enteringBase()
    {

    }

    public void roamingAround()
    {

    }

    public void crafting()
    {

    }

    public void building()
    {

    }

    public void pausing()
    {

    }
}
