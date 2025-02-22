using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    public float speedMove=2f;
    void Update()
    {
        if(GameManager.instance.IsDead)
        {
            return;
        }
        transform.position+=new Vector3(-speedMove,0,0)*Time.deltaTime;
    }
}
