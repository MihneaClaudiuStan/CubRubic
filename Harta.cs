using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Harta : MonoBehaviour
{
    private Stare stare;

    public Transform sus;
    public Transform jos;
    public Transform stanga;
    public Transform dreapta;
    public Transform fata;
    public Transform spate;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Set()
    {
        stare = FindObjectOfType<Stare>();

        UpdateMap(stare.fata, fata);
        UpdateMap(stare.spate, spate);
        UpdateMap(stare.stanga, stanga);
        UpdateMap(stare.dreapta, dreapta);
        UpdateMap(stare.sus, sus);
        UpdateMap(stare.jos, jos);
    }


    void UpdateMap(List<GameObject> face, Transform side)
    {
        int i = 0;
        foreach (Transform map in side)
        {
            if (face[i].name[0] == 'F')
            {
                map.GetComponent<Image>().color = new Color(1, 0.5f, 0, 1);
            }
            if (face[i].name[0] == 'B')
            {
                map.GetComponent<Image>().color = Color.red;
            }
            if (face[i].name[0] == 'U')
            {
                map.GetComponent<Image>().color = Color.yellow;
            }
            if (face[i].name[0] == 'D')
            {
                map.GetComponent<Image>().color = Color.white;
            }
            if (face[i].name[0] == 'L')
            {
                map.GetComponent<Image>().color = Color.green;
            }
            if (face[i].name[0] == 'R')
            {
                map.GetComponent<Image>().color = Color.blue;
            }
            i++;
        }
    }
}
