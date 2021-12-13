using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour
{
    private static PipeManager _instance;
    public static PipeManager Instance { get { return _instance; } }
    
    public GameObject Flange;

    public GameObject ANode;

    public GameObject Corner;

    private Dictionary<NodeType, Vector3> InitialPosition = new Dictionary<NodeType, Vector3>();

    private Camera camera;

    private readonly float UNSEEN_Z_OFFSET = -4f;
    private readonly float UNSEEN_CORNER_Z_OFFSET = 4.5f;
        
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
    
    void Start()
    {
        InitialPosition[NodeType.Flange] = Flange.transform.position;
        InitialPosition[NodeType.ANode] = ANode.transform.position;
        InitialPosition[NodeType.Corner] = Corner.transform.position;
        
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyTestCase(TestCase testCase)
    {
        camera.transform.Translate(testCase.cameraOffset);
        camera.transform.Rotate(testCase.cameraTilt);

        SetNodePos(NodeType.ANode, testCase.aNode, testCase.aNodeZ);
        SetNodePos(NodeType.Flange, testCase.flange, testCase.flangeZ);
        SetNodePos(NodeType.Corner, testCase.corner, testCase.cornerZ);
        if (testCase.corner)
            RotateCorner(testCase.cornerDirection);
    }

    public void SetNodePos(NodeType nodeType, bool isNode, float z)
    {
        GameObject node;
        switch (nodeType)
        {
            case NodeType.ANode:
                node = ANode;
                break;
            case NodeType.Flange:
                node = Flange;
                break;
            case NodeType.Corner:
                node = Corner;
                break;
            default:
                return;
        }

        if (nodeType == NodeType.Corner)
        {
            var pos = node.transform.position;
            node.transform.position = InitialPosition[nodeType] + (isNode ? Vector3.forward * z : Vector3.forward * UNSEEN_CORNER_Z_OFFSET);
        }
        else
        {
            var pos = node.transform.position;
            node.transform.position = InitialPosition[nodeType] + (isNode ? Vector3.forward * z : Vector3.forward * UNSEEN_Z_OFFSET);
        }
    }

    public void RotateCorner(String direction)
    {
        Corner.transform.rotation = direction == "left" ? Quaternion.Euler(0, 0, 180) : Quaternion.Euler(0, 0, 0);
    }
}

public enum NodeType
{
    Flange = 0,
    ANode = 1,
    Corner = 2
}
