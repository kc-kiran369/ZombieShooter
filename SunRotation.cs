using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotation : MonoBehaviour
{ 
    [SerializeField]float RotationRatePerSecond = 0.5f;
    void Update()
    {
        if (GameState.currentGameState == GameState.CurrentGameState.Playing)
        {
            transform.Rotate((RotationRatePerSecond*Time.deltaTime)%360,0,0);
        }
    }
}
