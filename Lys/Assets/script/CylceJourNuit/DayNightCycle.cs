﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    private float elapseTime;
    [SerializeField]
    private float elapsedTime;
    [SerializeField]
    private bool use24Clock = true;
    [SerializeField]
    private TextMeshProUGUI clockText;
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

    public int dayNumberWeek = 1;
    public int weekLenght = 7;
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
    [SerializeField]
    private AnimationCurve timeCurve;
    private float timeCurveNormalization;

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

    [Header("Season")]
    [SerializeField]
    private Transform sunSeasonalRotation;
    [SerializeField]
    [Range(-45f, 45f)]
    private float maxSeasonalTilt;

    [Header("Modules")]
    private List<DNModuleBase> moduleList = new List<DNModuleBase>();

    public float timeHour;


    private void UpdateTimeScale()
    {
        _timeScale = 24 / (_targetDayLength / 60);
        _timeScale *= timeCurve.Evaluate(elapsedTime / (targetDayLength * 60));
        _timeScale /= timeCurveNormalization;
    }

    private void NormalTimeCurve()
    {
        float stepSize = 0.01f;
        int numberSteps = Mathf.FloorToInt(1f / stepSize);
        float curveTotal = 0;

        for (int i = 0; i < numberSteps; i++)
        {
            curveTotal += timeCurve.Evaluate(i * stepSize);
        }

        timeCurveNormalization = curveTotal / numberSteps;
    }

    private void Start()
    {
        NormalTimeCurve();
    }

    private void Update()
    {
        if(!pause)
        {
            UpdateTimeScale();
            UpdateTime();
            UpdateClock();
        }

        adjustSunRotation();
        SunIntensity();
        AdjustSunColor();
        UpdateModules();
    }

    private void UpdateTime()
    {
        _timeOfDay += Time.deltaTime * _timeScale / 86400; // secondes dans un jour
        elapsedTime += Time.deltaTime;
        if(timeOfDay > 1)
        {
            elapsedTime = 0;
            _dayNumber++;
            _timeOfDay -= 1;

            dayNumberWeek++;

            if(_dayNumber > _yearLength)
            {
                _yearNumber++;
                _dayNumber = 0;
            }

            if(dayNumberWeek > weekLenght)
            {
                dayNumberWeek = 1;
            }
        }
    }

    private void UpdateClock()
    {
        float time = elapsedTime / (targetDayLength * 60);
        float hour = Mathf.FloorToInt(time * 24);
        float minute = Mathf.FloorToInt(((time * 24) - hour) * 60);

        timeHour = Mathf.FloorToInt(time * 24);

        string hourString;
        string minuteString;

        if(!use24Clock && hour > 12)
        {
            hour -= 12;
        }

        if(hour < 10)
        {
            hourString = "0" + hour.ToString();
        }
        else
        {
            hourString = hour.ToString();
        }

        if (minute < 10)
        {
            minuteString = "0" + minute.ToString();
        }
        else
        {
            minuteString = minute.ToString();
        }

        if(use24Clock)
        {
            clockText.text = hourString + " : " + minuteString;
        }
        else if(time > 0.5f)
        {
            clockText.text = hourString + " : " + minuteString + " PM";
        }
        else
        {
            clockText.text = hourString + " : " + minuteString + " AM";
        }
        
        
    }


    private void adjustSunRotation()
    {
        float SunAngle = timeOfDay * 360;
        DailyRotation.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, SunAngle));

        float seasonalAngle = -maxSeasonalTilt * Mathf.Cos(dayNumber / _yearLength * 2f * Mathf.PI);
        sunSeasonalRotation.localRotation = Quaternion.Euler(new Vector3(seasonalAngle, 0f, 0f));
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

    public void AddModule(DNModuleBase module)
    {
        moduleList.Add(module);
    }

    public void RemoveModule(DNModuleBase module)
    {
        moduleList.Remove(module);
    }

    private void UpdateModules()
    {
        foreach (DNModuleBase module in moduleList)
        {
            module.UpdateModule(intensity);
        }
    }
}
    
