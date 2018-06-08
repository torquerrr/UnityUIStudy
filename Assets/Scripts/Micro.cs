using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Micro : MonoBehaviour {

    private string[] _devices;
    private AudioClip _clip;
    int _sampleWindow = 128;
    private Button _btn;

    [SerializeField]
    private InputField _fld;

    [SerializeField]
    private Slider _sld;

    public List<RectTransform> lst;
    public CoolNames KoolNames;

    // testing public enum
    public enum CoolNames
    {
        Petya,
        Vasya,
        Kolya
    }

	void Start ()
    {
        _devices = Microphone.devices;

        _clip = Microphone.Start(_devices[0], true, 999, 44100);

        _fld.text = _devices[0];
	}
	
	void LateUpdate () {
        float levelMax = 0;
        float[] waveData = new float[_sampleWindow];
        int micPosition = Microphone.GetPosition(null) - (_sampleWindow + 1); // null means the first microphone
        if (micPosition < 0)
        {
            return;
        }

        _clip.GetData(waveData, micPosition);

        for (int i = 0; i < _sampleWindow; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }
        float val = Mathf.Clamp(levelMax * 2, 0.0f, 1.0f);
        _sld.value = val;
    }

    public void MouseHover()
    {
        Debug.Log($"Hovering, and the name selected is {KoolNames.ToString()}");
    }

    public void SetColor(GameObject obj)
    {
        obj.GetComponent<Image>().color = new Color(Random.value, Random.value, Random.value);
    }
}
