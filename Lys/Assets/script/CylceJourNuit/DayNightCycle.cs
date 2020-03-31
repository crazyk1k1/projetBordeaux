using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour
{

    [Header("Time")]
    [Tooltip("Day Length in Minutes")]
    [SerializeField]
    private float _targetDayLength = 0.5f; //length of day in minutes
    public float targetDayLength
    {
        get
        {
            return _targetDayLength;
        }
    }
    [SerializeField]
    private float elapsedTime;
    [SerializeField]
    private bool use24Clock = true;
    [SerializeField]
    private Text clockText;
    [SerializeField]
    [Range(0f, 1f)]
    private float _timeOfDay;
    public float timeOfDay
    {
        get
        {
            return _timeOfDay;
        }
    }
    [SerializeField]
    private int _dayNumber = 0; //tracks the days passed
    public int dayNumber
    {
        get
        {
            return _dayNumber;
        }
    }
    [SerializeField]
    private int _yearNumber = 0;
    public int yearNumber
    {
        get
        {
            return _yearNumber;
        }
    }
    private float _timeScale = 100f;
    [SerializeField]
    private int _yearLength = 100;
    public float yearLength
    {
        get
        {
            return _yearLength;
        }
    }
    public bool pause = false;

    [Header("SunLight")]
    [SerializeField]
    private Transform DailyRotation;
    [SerializeField]
    private Light sun;
    private float intensity;
    [SerializeField]
    private float sunBaseIntensity = 1.0f;
    [SerializeField]
    private float sunVariation = 1.5f;
    [SerializeField]
    private Gradient sunColor;

    private void Update()
    {
        if(!pause)
        {
            UpdateTimeScale();
            UpdateTime();
        }

        adjustSunRotation();
        SunIntensity();
    }

    private void UpdateTimeScale()
    {
        _timeScale = 24 / (_targetDayLength / 60);
    }

    private void UpdateTime()
    {
        _timeOfDay += Time.deltaTime * _timeScale / 86400; // secondes dans un jour
        if(timeOfDay > 1)
        {
            _dayNumber++;
            _timeOfDay -= 1;

            if(_dayNumber > _yearLength)
            {
                _yearNumber++;
                _dayNumber = 0;
            }
        }
    }


    private void adjustSunRotation()
    {
        float SunAngle = timeOfDay * 360;
        DailyRotation.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, SunAngle));
    }

    private void SunIntensity()
    {
        intensity = Vector3.Dot(sun.transform.forward, Vector3.down);
        intensity = Mathf.Clamp01(intensity);

        sun.intensity = intensity * sunVariation * sunBaseIntensity;
    }

    private void AdjustSunColor()
    {
        sun.color = sunColor.Evaluate(intensity);
    }
}
    
