using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBumper : MonoBehaviour {

    private void Awake()
    {
        StartCoroutine(BumperTime());
    }

    IEnumerator BumperTime()
    {

        yield return new WaitForSeconds(20);
        Destroy(gameObject);
        yield break;

    }
}
