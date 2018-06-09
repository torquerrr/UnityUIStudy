using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WindowManager : MonoBehaviour {

    public static WindowManager instance = null;
    private class SwitchEvent : UnityEvent<bool> { };

    [Header("Available windows")]
    [SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private GameObject modalPanel;
    [SerializeField]
    private GameObject containersPanel;

    private GameObject mainMenuClone;
    private GameObject modalPanelClone;
    private GameObject containersPanelClone;
    private SwitchEvent onNeedToSwitch;
    private bool needToSwitch;
    private Windows _Window;

    public Windows Window
    {
        get
        {
            return _Window;
        }
        set
        {
            _Window = value;
            if (onNeedToSwitch != null)
            {
                onNeedToSwitch.Invoke(true);
            }
        }
    }

    public enum Windows
    {
        MainMenu,
        ModalPanel,
        ContainersPanel
    }

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

        // event handler for Window value change
        onNeedToSwitch = new SwitchEvent();
        onNeedToSwitch.AddListener((switchKey) => needToSwitch = switchKey);

        // set default window
        Window = Windows.MainMenu;
    }

    private void Update()
    {
        if (needToSwitch)
        {
            switch (Window)
            {
                case Windows.MainMenu:
                    mainMenuClone = Instantiate(mainMenu, this.transform);
                    Destroy(modalPanelClone);
                    Destroy(containersPanelClone);
                    onNeedToSwitch.Invoke(false);
                    break;
                case Windows.ModalPanel:
                    modalPanelClone = Instantiate(modalPanel, this.transform);
                    Destroy(mainMenuClone);
                    Destroy(containersPanelClone);
                    onNeedToSwitch.Invoke(false);
                    break;
                case Windows.ContainersPanel:
                    containersPanelClone = Instantiate(containersPanel, this.transform);
                    Destroy(modalPanelClone);
                    Destroy(mainMenuClone);
                    onNeedToSwitch.Invoke(false);
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
