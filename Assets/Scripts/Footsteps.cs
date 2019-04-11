using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour {

    public ParticleSystem LeftDust;
    public ParticleSystem RightDust;

    public void LeftFootstep()
    {
        LeftDust.gameObject.SetActive(false);
        LeftDust.gameObject.SetActive(true);
    }

    public void RightFootstep()
    {
        RightDust.gameObject.SetActive(false);
        RightDust.gameObject.SetActive(true);
    }

    public void LeftCrouch()
    {
        LeftDust.gameObject.SetActive(false);
        LeftDust.gameObject.SetActive(true);
    }

    public void RightCrouch()
    {
        RightDust.gameObject.SetActive(false);
        RightDust.gameObject.SetActive(true);
    }
}
