using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PikePosition : MonoBehaviour {

    public Transform pikeSpawnTransform;

    private void Awake()
    {
        StartCoroutine(PikeTime());
    }

    // Update is called once per frame
    void FixedUpdate () {

        if (pikeSpawnTransform != null)
        {
            this.transform.position = pikeSpawnTransform.transform.position;
            this.transform.rotation = pikeSpawnTransform.transform.rotation;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    IEnumerator PikeTime()
    {

        yield return new WaitForSeconds(5);
        Destroy(gameObject);
        yield break;

    }
}
