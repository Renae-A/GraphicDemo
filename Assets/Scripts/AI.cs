using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class AI : MonoBehaviour {

    public GameObject target;
    private NavMeshAgent nav;

	// Use this for initialization
	void Start () {
        nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Follow()
    {
        float distance = Vector3.Distance(this.transform.position, target.transform.position);
        //nav.SetDestination(pos)
    }
}
