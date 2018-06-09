using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowSwitcher : MonoBehaviour {

	public void ChangeWindow(int winId)
    {
        WindowManager.instance.Window = (WindowManager.Windows)winId;
	}
}