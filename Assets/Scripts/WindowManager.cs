using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour {

    public static WindowManager instance = null;

    [Header("Available windows")]
    [SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private GameObject modalPanel;
    [SerializeField]
    private GameObject containersPanel;

    public bool NeedToSwitch { get; set; }
    public Windows Window { get; set; }
    public enum Windows
    {
        MainMenu,
        ModalPanel,
        ContainersPanel
    }

    private GameObject mainMenuClone;
    private GameObject modalPanelClone;
    private GameObject containersPanelClone;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        // set default window
        Window = Windows.MainMenu;
        NeedToSwitch = true;
    }

    private void Update()
    {
        if (NeedToSwitch)
        {
            switch (Window)
            {
                case Windows.MainMenu:
                    mainMenuClone = Instantiate(mainMenu, this.transform);
                    Destroy(modalPanelClone);
                    Destroy(containersPanelClone);
                    NeedToSwitch = false;
                    break;
                case Windows.ModalPanel:
                    modalPanelClone = Instantiate(modalPanel, this.transform);
                    Destroy(mainMenuClone);
                    Destroy(containersPanelClone);
                    NeedToSwitch = false;
                    break;
                case Windows.ContainersPanel:
                    containersPanelClone = Instantiate(containersPanel, this.transform);
                    Destroy(modalPanelClone);
                    Destroy(mainMenuClone);
                    NeedToSwitch = false;
                    break;
            }
        }
    }

    public Windows GetCurrentWindow()
    {
        Debug.Log($"Current window is {Window}");
        return Window;
    }
}
