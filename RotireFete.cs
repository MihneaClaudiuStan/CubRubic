using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotireFete : MonoBehaviour
{
    private Stare stare;
    private Citire citire;
    private int layerMask = 1 << 8;


    // Start is called before the first frame update
    void Start()
    {
        citire = FindObjectOfType<Citire>();
        stare = FindObjectOfType<Stare>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !Stare.autoRotating)
        {            
            citire.ReadState();
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f, layerMask))
            {
                GameObject face = hit.collider.gameObject;
                // Make a list of all the sides (lists of face GameObjects)
                List<List<GameObject>> csidese = new List<List<GameObject>>()
                {
                    stare.sus,
                    stare.jos,
                    stare.stanga,
                    stare.dreapta,
                    stare.fata,
                    stare.spate
                };
                // If the face hit exists within a side
                foreach (List<GameObject> cside in csidese)
                {
                    if (cside.Contains(face))
                    {
                      
                        stare.PickUp(cside);
              
                        cside[4].transform.parent.GetComponent<Pivot>().Rotate(cside);
                    }
                }
            }
        }
    }
}

