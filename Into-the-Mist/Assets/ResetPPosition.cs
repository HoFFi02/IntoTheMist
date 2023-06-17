using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("Player x", -19f);
        PlayerPrefs.SetFloat("Player y", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
