using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        JsonInterpreter.CreateExampleTestcase("testCaseExample.json");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
