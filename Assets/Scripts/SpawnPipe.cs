using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPipe : MonoBehaviour
{
    
    private float timeControl=0;
    public GameObject PipePrefabsEasy;
    public GameObject PipePrefabsDiff;
    void Update()
    {
        if(GameManager.instance.IsDead)
        {
            return;
        }
        timeControl+=Time.deltaTime;
        if(timeControl>=GameManager.instance.delay)
        {
            SpawnPipePos();
            timeControl=0;
        }
            
    }
    private void SpawnPipePos()
    {	
        if(GameManager.instance.tipObject.activeSelf)
        {
            return;
        }
        else
        {
            if(GameManager.instance.score>100)
            {
                GameObject pipe=Instantiate(PipePrefabsDiff);
                pipe.transform.position +=new Vector3(0,Random.Range(-1.0f,2.5f),0);
                Destroy(pipe,8f);
            }
            else
            {
                GameObject pipe=Instantiate(PipePrefabsEasy);
                pipe.transform.position +=new Vector3(0,Random.Range(-1.0f,2.5f),0);
                Destroy(pipe,8f);
            }
        }
    }
}
