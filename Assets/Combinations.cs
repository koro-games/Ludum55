using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[CreateAssetMenu(fileName = "Combinations", menuName = "ScriptableObjects/Combinations", order = 1)]
public class Combinations : ScriptableObject
{
    public Combination[] combination;
}
[System.Serializable]
public class Combination
{
    public string name;
    public Vector2Int[] sequence;
    public int score;
}

