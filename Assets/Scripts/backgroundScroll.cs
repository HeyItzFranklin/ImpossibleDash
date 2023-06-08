using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScroll : MonoBehaviour
{
    public static float speed;
    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        speed = -7.0f;

        playerControl.onDeath += Reset;

    }

    // Update is called once per frame
    void Update()
    {
        if (playerControl.isAlive == true)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }


    }

    void Reset()
    {
        StartCoroutine(Stalling());
        

    }

    IEnumerator Stalling()
    {
        yield return new WaitForSeconds(.9f);
        gameObject.transform.position = startPos;
              
    }

    private void OnDisable()
    {
        playerControl.onDeath -= Reset;
    }
}
