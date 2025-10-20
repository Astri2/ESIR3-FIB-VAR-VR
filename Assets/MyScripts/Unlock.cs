using System.Collections;
using UnityEngine;

public class Unlock : MonoBehaviour
{
    public GameObject ChestLock;
    public GameObject ChestLockTongue;
    public Animator lockAnim;
    public Animator keyAnim;
    public GameObject HideKey;
    public GameObject Key;

    private void Awake()
    {
        HideKey.GetComponent<Renderer>().enabled = false;
        Key.GetComponent<Renderer>().enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lock"))
        {
            Key.GetComponent<Renderer>().enabled = false;
            HideKey.GetComponent<Renderer>().enabled = true;
            keyAnim.SetTrigger("Unlock");            
            StartCoroutine(DisableAfterAnimation());
        }
    }

    private IEnumerator DisableAfterAnimation()
    {
        yield return new WaitForSeconds(1f);
        lockAnim.SetTrigger("Open");
        yield return new WaitForSeconds(1f);
        ChestLock.SetActive(false);
        ChestLockTongue.SetActive(false);
        Key.SetActive(false);
        HideKey.SetActive(false);
    }
}