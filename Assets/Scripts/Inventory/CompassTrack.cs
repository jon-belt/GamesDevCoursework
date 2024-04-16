using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassTrack : MonoBehaviour
{
    public GameObject needle;
    public bool purchased = false;

    void Update()
    {
        Vector3 target = needle.transform.position;     //gets needle position

        Vector3 relativeTarget = transform.parent.InverseTransformPoint(target);        //uses InverseTransformpoint to find location to point to

        float needleRotation = Mathf.Atan2(relativeTarget.x, relativeTarget.z) * Mathf.Rad2Deg;     //works out needle rotation

        transform.localRotation = Quaternion.Euler(0, needleRotation, 0);       //apply needle rotation
    }
}
