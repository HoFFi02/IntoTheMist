using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float x = PlayerPrefs.GetFloat("Player x");
        float y = PlayerPrefs.GetFloat("Player y"); //nazwa klucza, w słowniku, niepowtarzalne klucze, jak dictionary
        Player.transform.position = new Vector3(x,y,0);

        //PlayerPrefs.SetFloat("Player x", value)
        //PlayerPrefs.SetFloat("Player y", value) to w skrypcia zanim odpalisz grę
    }

    //PlayerPrefs.SetFloat("Player x", start.position x)
    //PlayerPrefs.SetFloat("Player y", start.position y) to w skrypcia zanim odpalisz grę
    //to ma byc w skrypcia w poprzedniej scenie w wioska w starcie
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject Player;
}
