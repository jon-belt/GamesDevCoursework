using UnityEngine;
using TMPro;

public class TimerCountdown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;

    private bool startTimer;

    void Start()
    {
       startTimer = false;

    }

    void Update()
    {
        if(startTimer == true){
            //90 second countdown starts
            if(remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
            }
            else if (remainingTime < 0)
            {
                remainingTime = 0;
            }

            int mins = Mathf.FloorToInt(remainingTime / 60);
            int secs = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", mins, secs);
        }
    }

    public void setTrue(){
        Debug.Log("Timer Started");            
        startTimer = true;
        remainingTime = 60;
    }

    public void setFalse(){
        Debug.Log("Timer Stopped");
        startTimer = false;
    }
}
