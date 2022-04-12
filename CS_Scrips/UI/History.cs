using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class History : MonoBehaviour
{
    public static History Instance;
    private Dictionary<int, StepHistory> StepHistory;
    private int indice = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void AddStep()
    {
        StepHistory.Add(indice, new StepHistory());
        indice++;
   
    }

    public void removeStep()
    {
        StepHistory.Remove(indice);
        indice--;

        if (indice <= 0)
        {
            indice = 0;
        }
    }

}
