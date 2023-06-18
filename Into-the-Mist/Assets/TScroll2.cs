using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TScroll2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < MaxY)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y+speed * Time.deltaTime, transform.position.z);
            }
        else if (Input.GetKey(KeyCode.Return))
            {
                SceneManager.LoadScene(2);
            }
    }

    public float MaxY;
    public float speed = 5;


    
}

