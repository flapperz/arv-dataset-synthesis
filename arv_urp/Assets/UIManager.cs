using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Button loadButton;
    // Start is called before the first frame update
    void Start()
    {
        loadButton = GameObject.Find("Load").GetComponent<Button>();
        loadButton.onClick.AddListener(OnLoadClick);
    }

    private void OnLoadClick()
    {
        TestCaseList testCaseList =  JsonInterpreter.Interpret("testCase.json");
        PipeManager.Instance.ApplyTestCase(testCaseList.list[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
