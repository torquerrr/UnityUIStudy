using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour {

    private UnityEvent onTimeEnded = new UnityEvent();
    private float countdown;
    private bool isTicking = false;

    public static void AddAsUniqueComponent(GameObject gameObject, float countdown, UnityAction callback)
    {
        if (gameObject.GetComponent<Timer>() == null)
        {
            Timer timer = gameObject.AddComponent<Timer>();
            timer.CreateTimer(countdown, callback);
        }
    }

    public void CreateTimer(float seconds, UnityAction callback)
    {
        countdown = seconds;
        onTimeEnded.AddListener(callback);
        isTicking = true;
    }

	void Update ()
    {
		if (isTicking)
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0.0f)
            {
                onTimeEnded.Invoke();
                isTicking = false;
                onTimeEnded.RemoveAllListeners();
            }
        }
	}
}
