using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCharacter : MonoBehaviour
{
    public static string PlayerName { get; set; }
    public static float BaseSpeed { get; set; } = 2.5f;
    public static int BaseHealth { get; set; } = 50;
    public static int BaseStamina { get; set; } = 50;
    public static float EXP { get; set; } = 0;
    public static int Level { get; set; } = 1;
    public static float BaseAttack { get; set; } = 5;

    public static bool IsPaused { get; set; } = false;
}
