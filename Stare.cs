using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stare : MonoBehaviour
{
    public List<GameObject> fata = new List<GameObject>();
    public List<GameObject> spate = new List<GameObject>();
    public List<GameObject> sus = new List<GameObject>();
    public List<GameObject> jos = new List<GameObject>();
    public List<GameObject> dreapta = new List<GameObject>();
    public List<GameObject> stanga = new List<GameObject>();


    public static bool autoRotating = false;
    public static bool started = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUp(List<GameObject> cubeSide)
    {
        foreach (GameObject face in cubeSide)
        {

            if (face != cubeSide[4])
            {
                face.transform.parent.transform.parent = cubeSide[4].transform.parent;
            }
        }
    }

    public void PutDown(List<GameObject> littleCubes, Transform pivot)
    {
        foreach (GameObject littleCube in littleCubes)
        {
            if (littleCube != littleCubes[4])
            {
                littleCube.transform.parent.transform.parent = pivot;
            }
        }
    }

    string GetSideString(List<GameObject> side)
    {
        string sideString = "";
        foreach (GameObject face in side)
        {
            sideString += face.name[0].ToString();
        }
        return sideString;
    }

    public string GetStateString()
    {
        string stateString = "";
        stateString += GetSideString(sus);
        stateString += GetSideString(dreapta);
        stateString += GetSideString(fata);
        stateString += GetSideString(jos);
        stateString += GetSideString(stanga);
        stateString += GetSideString(spate);
        return stateString;
    }

}
