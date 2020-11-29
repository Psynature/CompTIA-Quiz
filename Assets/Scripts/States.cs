using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class States : MonoBehaviour
{
    [SerializeField] List<State> states;

    public List<State> GetStates()
    {
        return states;
    }
}
