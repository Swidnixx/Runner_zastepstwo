using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSO : ScriptableObject
{
    public int level = 1;
    public int upgradePrice = 100;

    public bool IsActive;
    public float Duration;
}
