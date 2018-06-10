using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuManager : MonoBehaviour {

    #region GeneralMenu
    public GameObject MainMenu;
    #endregion

    #region Options
    public GameObject OptionsMenu;
    public GameObject GeneralPanel;
    public GameObject GraphicsPanel;
    public GameObject SoundsPanel;
    #endregion


    public void SetOptionsMenu()
    {
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }

    public void SetMainMenu()
    {
        MainMenu.SetActive(true);
        OptionsMenu.SetActive(false);
    }

    public void SetGeneralPanel()
    {
        GeneralPanel.SetActive(true);
        GraphicsPanel.SetActive(false);
        SoundsPanel.SetActive(false);
    }

    public void SetGraphicsPanel()
    {
        GeneralPanel.SetActive(false);
        GraphicsPanel.SetActive(true);
        SoundsPanel.SetActive(false);
    }

    public void SetSoundsPanel()
    {
        GeneralPanel.SetActive(false);
        GraphicsPanel.SetActive(false);
        SoundsPanel.SetActive(true);
    }
}
