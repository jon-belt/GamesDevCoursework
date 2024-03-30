using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    //references 
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;

    //variables

    [SerializeField, Range(0, 24)] private float TimeOfDay;
    [SerializeField] private int DayCount;
    [SerializeField] private float MinsPerDay = 12f;    //amount of real world mins to in game days
                                                        //every real world 12 mins should be an in game 24 hours
    private float lastLogTime = -1;
    private bool dayPassed = false;

    void Start()
    {
        //game starts at '6 am'
        TimeOfDay = 11;
        //TimeOfDay = 6 ;
        DayCount = 1;
        
        UpdateLighting(TimeOfDay / 24f);
    }

    private void Update()
    {
        CheckDay();

        if (Preset == null)
        {
            return;
        }

        if (Application.isPlaying)
        {
            float realSecondsPerDay = MinsPerDay * 60f;             //multiply daily mins by 60 to number of real seconds per in game day
            float timeProgressionRate = 24f / realSecondsPerDay;    //24 in-game hours divided by the number of real seconds per in-game day

            TimeOfDay += Time.deltaTime * timeProgressionRate;      //uses delta time and the progression rate to determine the day cycle
            TimeOfDay %= 24f;       //wraps time of day so it stays 24 hours

            UpdateLighting(TimeOfDay / 24f);


            //used for debugging, could make the game laggy so worth removing for final iteration
            float inGameMinutes = TimeOfDay * 60;
            if ((int)(inGameMinutes / 30) > (int)(lastLogTime / 30))
            {
                //Debug.Log($"In-game Time: {TimeOfDay} hours");
                lastLogTime = inGameMinutes;
            }
        }
        else
        {
            UpdateLighting(TimeOfDay / 24f);
        }
    }

    private void UpdateLighting(float timePercent){
        RenderSettings.ambientLight = Preset.AmbientColour.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColour.Evaluate(timePercent);

        if(DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColour.Evaluate(timePercent);
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }
    }

    //try to find a directional lighjt to use if we have not already set one
    private void OnValidate()
    {
        if (DirectionalLight != null)
        {
            return;
        }

        //search for lighting tab sun
        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }

        //search scene for a directional light
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach(Light light in lights)
            {
                if(light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }

        }
    }

    private void CheckDay()
    {
        // Increment day count just after midnight
        if (TimeOfDay >= 0.0 && TimeOfDay < 1.0 && !dayPassed) // Assuming TimeOfDay resets to 0 at midnight
        {
            DayCount++;
            dayPassed = true; // Mark that the day has been counted
            Debug.Log("Starting Day: " + DayCount);
        }
        else if (TimeOfDay >= 1.0) // Ensure dayPassed is reset after TimeOfDay has sufficiently advanced
        {
            dayPassed = false;
        }
    }

    public float GetTimeOfDay()
    {
        return TimeOfDay;
    }

    public float GetDayCount()
    {
        return DayCount;
    }
}
