using UnityEngine;

public class TimerLogic : MonoBehaviour
{
    public GameObject timer;
    public GameObject timerBase;
    public TimerCountdown timerCountdown;
    public LightingManager lightingManager;

    public bool purchased = false;
    public bool toggleTimer;

    void Start()
    {
        purchased = false;
        toggleTimer = true;
        timer.SetActive(false);
        timerBase.SetActive(false);
    }

    void Update()
    {
        float TimeOfDay = lightingManager.GetTimeOfDay();    //retrieves the time of day from the lighting manager
        if(purchased == true)
        {
            //triggers between 16.5 & 17.0, only once due to bool toggle
            if(TimeOfDay >= 16.0 && TimeOfDay < 17.0 && toggleTimer == true)
            {
                toggleTimer = false;    //toggle off

                //show the timer in the ui
                timer.SetActive(true);
                timerBase.SetActive(true);

                //toggles the start of the timer in TimerCountdown.cs
                timerCountdown.setTrue();
            }

            //triggers only if toggle is false and the time of day is after the timer animation has finished.
            if (toggleTimer == false && TimeOfDay >= 18.0)
            {
                //sets toggle back for next day
                toggleTimer = true;

                //hide the timer in the ui
                timer.SetActive(false);
                timerBase.SetActive(false);

                //resets toggle for next day
                timerCountdown.setFalse();
            }
        }
    }

    public void Purchase()
    {
        purchased = true;
    }
}
