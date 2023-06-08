using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerScript : MonoBehaviour
{
    public GameObject child;
   
    

    // Start is called before the first frame update
    
    void Start()
    {

        playerControl.onDeath += spawnObjects;

       

    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void spawnObjects()
    {
        child.SetActive(true);
     
    }
}
