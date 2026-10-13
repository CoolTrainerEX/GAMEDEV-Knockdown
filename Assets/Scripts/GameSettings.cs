using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Scriptable Objects/GameSettings")]
public class GameSettings : ScriptableObject
{
    [Header("Game")]
    public GameObject ball;
    [Min(0)] public float cannonSpeed = 20;
    [Min(0)] public float cannonForce = 1000;
    [Min(0)] public float ballLifetime = 5;

    [Header("Platform")]
    [Min(0)] public float platformSpeed = 1;
    [Min(0)] public float platformTreshold = 0.01f;
}
