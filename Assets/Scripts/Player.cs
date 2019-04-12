using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour {

    public List<Action> actions;

	// Use this for initialization
	void Start () {
	}

    public void SetActions(List<Action> acs)
    {
        actions = acs;
    }

}
