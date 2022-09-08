using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    public int value;
    float x;
    float y;
    float z;
    Vector3 pos;
    void Start()
    {
        x = Random.Range(-6.0f, 7.0f);
        y = Random.Range(-3.0f, 0.0f);
        z = 18;
        pos = new Vector3(x, y, z);
        transform.position = pos;
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Hook") {
            HookMovement hook = GameObject.Find("Hook Parent").GetComponent<HookMovement>();
            hook.returnHook();
            source.PlayOneShot(clip);
            Destroy(gameObject);
        }
        ScoreManager.instance.AddPoint(value);
    }
}