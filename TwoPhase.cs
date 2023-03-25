using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kociemba;


public class TwoPhase : MonoBehaviour
{

    public Citire citire;
    public Stare stare;
    private bool doOnce = true;
    // Start is called before the first frame update
    void Start()
    {
        citire = FindObjectOfType<Citire>();
        stare = FindObjectOfType<Stare>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Stare.started && doOnce)
        {
            doOnce = false;
            Solver();
        }
    }

    public void Solver()
    {

        citire.ReadState();

        // get the state of the cube as a string
        string moveString = stare.GetStateString();
        print(moveString);

        // solve the cube
        string info = "";

        // First time build the tables
       // string solution = SearchRunTime.solution(moveString, out info, buildTables: true);

        //Every other time
        string solution = Search.solution(moveString, out info);

        // convert the solved moves from a string to a list
        List<string> solutionList = StringToList(solution);

        //Automate the list
        Automat.moveList = solutionList;

        print(info);


    }

    List<string> StringToList(string solution)
    {
        List<string> solutionList = new List<string>(solution.Split(new string[] { " " }, System.StringSplitOptions.RemoveEmptyEntries));
        return solutionList;
    }


}
