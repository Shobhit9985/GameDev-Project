using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CullingScript : MonoBehaviour
{
    public int culRange = 100;
    public bool softCulling = false;

    void OnEnable()
    {
        foreach (Transform toCul in transform)
        {
            TurnOnOff(toCul, false);
            StartCoroutine(CheckRange(toCul, 0));
        }
    }

    IEnumerator CheckRange(Transform toCul, float waitFor)
    {
        yield return new WaitForSeconds(waitFor);
        float curRange = Vector3.Distance(Camera.main.transform.position, toCul.position);

        if (curRange < culRange)
        {
            TurnOnOff(toCul, true);
        }
        else
        {
            TurnOnOff(toCul, false);
        }

        float checkIn = Mathf.Max(0.5f, 5 * curRange / culRange);
        StartCoroutine(CheckRange(toCul, checkIn));
    }

    void TurnOnOff(Transform toCul, bool state)
    {
        if (!softCulling)
        {
            toCul.gameObject.SetActive(state);
        }
        else
        {
            Renderer[] renderers = toCul.GetComponentsInChildren<Renderer>();
            foreach (Renderer r in renderers)
            {
                r.enabled = state;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        foreach (Transform toCul in transform)
        {
            Gizmos.DrawWireSphere(toCul.position, culRange);
        }
    }
}
