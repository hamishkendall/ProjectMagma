using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Enemy : ScriptableObject {

    public new string name;
    public GameObject[] itemsContained;
    public int damagePossible;
    public int expReward;
    public float heath;
}
