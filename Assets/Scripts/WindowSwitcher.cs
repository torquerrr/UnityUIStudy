using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowSwitcher : MonoBehaviour {

	public void ChangeWindow(int winId)
    {
        WindowManager.instance.Window = (WindowManager.Windows)winId;
        WindowManager.instance.NeedToSwitch = true;
	}
}