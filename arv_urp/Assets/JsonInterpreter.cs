using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Serialization;

public class JsonInterpreter
{
    public static TestCaseList Interpret(string fname)
    {
        var jsonString = File.ReadAllText(fname);
        return JsonUtility.FromJson<TestCaseList>(jsonString);
    }

    public static void CreateExampleTestcase(string fname)
    {
        var testCaseList = new TestCaseList();
        testCaseList.list = new List<TestCase>
        {
            new TestCase(),
            new TestCase(),
            new TestCase()
        };
        
        File.WriteAllText(fname, JsonUtility.ToJson(testCaseList));
    }
}

[Serializable]
public class TestCaseList
{
    public List<TestCase> list;
}

[Serializable]
public class TestCase
{
    public Vector3 cameraTilt;
    public Vector3 cameraOffset;
    public bool aNode;
    public bool flange;
    public bool corner;
    public string cornerDirection;
    public float aNodeZ;
    public float flangeZ;
    public float cornerZ;

    public TestCase(Vector3 cameraTilt = default, Vector3 cameraOffset = default, bool aNode = default, bool flange = default, bool corner = default, string cornerDirection = "right", float aNodeZ = default, float flangeZ = default, float cornerZ = default)
    {
        this.cameraTilt = cameraTilt;
        this.cameraOffset = cameraOffset;
        this.aNode = aNode;
        this.flange = flange;
        this.corner = corner;
        this.cornerDirection = cornerDirection;
        this.aNodeZ = aNodeZ;
        this.flangeZ = flangeZ;
        this.cornerZ = cornerZ;
    }
}