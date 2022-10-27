using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ModificatorsToMonsterTriggerData", menuName = "ModificatorsToMonsterTriggers", order = 51)]
public class ModificatorsToMonsterTrigger : ScriptableObject
{
    [SerializeField] private bool _stunCheck;

    public bool isNeedToStun()
    {
        return _stunCheck;
    }

    public void setStunCheck(bool newValue)
    {
        _stunCheck = newValue;
    }

    [SerializeField] private bool _slowdownCheck;

    public bool isNeedToSlowdown()
    {
        return _slowdownCheck;
    }

    public void setSlowdownCheck(bool newValue)
    {
        _slowdownCheck = newValue;
    }

    [SerializeField] private bool _explosionCheck;

    public bool isNeedToExposion()
    {
        return _explosionCheck;
    }

    public void setExposionCheck(bool newValue)
    {
        _explosionCheck = newValue;
    }

    [SerializeField] private bool _ResExposureCheck;

    public bool isNeedToResExposure()
    {
        return _ResExposureCheck;
    }

    public void setResExposureCheck(bool newValue)
    {
        _ResExposureCheck = newValue;
    }


}

