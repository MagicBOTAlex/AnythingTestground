using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public string[] DontDestroyTags;
    public float DelayBeforeDestroy = 3f;

    private void OnCollisionEnter(Collision collision)
    {
        if (DontDestroyTags.Any(x => collision.gameObject.CompareTag(x))) 
            return;
        else 
            Destroy(gameObject);
    }

    private void OnEnable()
    {
        StartCoroutine(StartDestroyer());
    }

    IEnumerator StartDestroyer()
    {
        yield return new WaitForSecondsRealtime(DelayBeforeDestroy);
        Destroy(gameObject);
    }
}
