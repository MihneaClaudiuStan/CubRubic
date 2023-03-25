using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotire : MonoBehaviour
{
    Vector2 primapoz;
    Vector2 douapoz;
    Vector2 rotirecurenta;
    Vector3 prevpoz;
    Vector3 mousedelta;
    public GameObject target;
    float speed = 200f;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        rotire();
        trage();
    }

    void trage()
    {
        if(Input.GetMouseButton(1))
        {
            mousedelta = Input.mousePosition - prevpoz;
            mousedelta *= 0.1f;
            transform.rotation = Quaternion.Euler(mousedelta.y, -mousedelta.x, 0) * transform.rotation;
        }
        else
        {
            if (transform.rotation != target.transform.rotation)
            {
                var step = speed * Time.deltaTime;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, target.transform.rotation, step);
            }
        }
        prevpoz = Input.mousePosition;
    }



    void rotire()
    {
        if(Input.GetMouseButtonDown(1))
        {
            // pozitia 2D al primului click
            primapoz = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
           // print(primapoz);
        }
        if (Input.GetMouseButtonUp(1))
        {
            // pozitia 2D al 2lea click
            douapoz = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            rotirecurenta = new Vector2(douapoz.x - primapoz.x,douapoz.y - primapoz.y);
            rotirecurenta.Normalize();
            if (RotireStanga(rotirecurenta))
            {
                target.transform.Rotate(0, 90, 0, Space.World);
            }
            else if (RotireDreapta(rotirecurenta))
            {
                target.transform.Rotate(0, -90, 0, Space.World);
            }
            else if (RotireSusStanga(rotirecurenta))
            {
                target.transform.Rotate(90, 0, 0, Space.World);
            }
            else if (RotireSusDreapta(rotirecurenta))
            {
                target.transform.Rotate(0, 0, -90,Space.World);
            }
            else if (RotireJosStanga(rotirecurenta))
            {
                target.transform.Rotate(0, 0, 90,Space.World);
            }
            else if (RotireJosDreapta(rotirecurenta))
            {
                target.transform.Rotate(-90, 0, 0,Space.World);
            }

        }
    }

    bool RotireStanga(Vector2 swipe)
    {
        return rotirecurenta.x < 0 && rotirecurenta.y > -0.5f && rotirecurenta.y < 0.5f;
    }
     
    bool RotireDreapta(Vector2 swipe)
    {
        return rotirecurenta.x > 0 && rotirecurenta.y > -0.5f && rotirecurenta.y < 0.5f;
    }

    bool RotireSusStanga(Vector2 swipe)
    {
        return rotirecurenta.y > 0 && rotirecurenta.x < 0f;
    }

    bool RotireSusDreapta(Vector2 swipe)
    {
        return rotirecurenta.y > 0 && rotirecurenta.x < 0f;
    }

    bool RotireJosStanga(Vector2 swipe)
    {
        return rotirecurenta.y < 0 && rotirecurenta.x < 0f;
    }

    bool RotireJosDreapta(Vector2 Swipe)
    {
        return rotirecurenta.y < 0 && rotirecurenta.x > 0f;
    }

}
