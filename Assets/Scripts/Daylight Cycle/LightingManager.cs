using Unity.Mathematics;
using UnityEngine;
[ExecuteAlways]
public class LightingManager : MonoBehaviour, IDataPersistence
{
    //references 
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;

    //variables
    [SerializeField, Range(0, 24)] public float TimeOfDay;
    [SerializeField] public int DayCount;
    [SerializeField] public float MinsPerDay = 12f;    //amount of real world mins to in game days
                                                        //every real world 12 mins should be an in game 24 hours
    //private float lastLogTime = -1;
    private bool dayPassed = false;
    private bool newGame = true;

    void Start()
    {
        if (newGame == true)
        {
            TimeOfDay = 6.5f ;
            DayCount = 1;
            newGame = false;
        }
        
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

            // //used for debugging, could make the game laggy so worth removing for final iteration
            // float inGameMinutes = TimeOfDay * 60;
            // if ((int)(inGameMinutes / 30) > (int)(lastLogTime / 30))
            // {
            //     //Debug.Log($"In-game Time: {TimeOfDay} hours");
            //     lastLogTime = inGameMinutes;
            // }
        }
        else
        {
            UpdateLighting(TimeOfDay / 24f);
        }
    }

    private void UpdateLighting(float timePercent){
        if(DirectionalLight != null)
        {
            //changes ambient light and fog to equal the colour in the preset
            RenderSettings.ambientLight = Preset.AmbientColour.Evaluate(timePercent);
            RenderSettings.fogColor = Preset.FogColour.Evaluate(timePercent);


            //changes main light source to equal the colour in the preset
            DirectionalLight.color = Preset.DirectionalColour.Evaluate(timePercent);

            //angles light in the sky to act as the sun by using quaternion to calculate the rotation
            quaternion sunTransform = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
            DirectionalLight.transform.localRotation = sunTransform;
        }
    }

    //try to find a directional light to use if we have not already set one
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
        //increment day count just after enemies stop spawning
        //"if timeOfDay == 6.1" cannot be used due to the nature of the float numbers
        //this method is used in all scripts that check the time of day
        if (TimeOfDay >= 6.0 && TimeOfDay < 6.2 && !dayPassed)
        {
            DayCount++;
            dayPassed = true;
            Debug.Log("Starting Day: " + DayCount);
        }
        else if (TimeOfDay >= 6.2) //ensure dayPassed is reset after TimeOfDay has sufficiently advanced
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

    public void LoadData(GameData data)
    {
        this.TimeOfDay = data.timeOfDay;
        this.DayCount = data.dayNum;
        this.newGame = data.lightingManagerNewGame;
    }

    public void SaveData(ref GameData data)
    {
        data.timeOfDay = this.TimeOfDay;
        data.dayNum = this.DayCount;
        data.lightingManagerNewGame = this.newGame;
    }
}
