using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int playerHealth;

    [SerializeField] private int playerFloor;

    void PlayerOnDamaged()
    {
        playerHealth--;
    }
}
