using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradeTypes { speed, capacity}

[CreateAssetMenu(fileName = "Upgrade", menuName = "ScriptableObjects/Upgrade", order = 1)]
public class Upgrade : ScriptableObject
{
    public float value;
}
