using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TMBscr : MonoBehaviour
{
    public int atk;
    public int attack;
    public bool attackcool;

    private Animator anim;
    private AudioSource audioSource;
    public AudioClip ShootSound;

    void Start()
    {
        atk = 5;
        attack = 0;
        attackcool = false;
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        StartCoroutine(Fire());
    }

    IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(3.0f);
            audioSource.PlayOneShot(ShootSound);
            anim.SetBool("attack", true);
            attack = 1;
            yield return new WaitForSeconds(5.0f);
            Destroy(this.gameObject);
            yield break;
        }
    }
    public IEnumerator DemegeCool()
    {
        while (true)
        {
            attackcool = true;
            yield return new WaitForSeconds(0.1f);
            attackcool = false;
            yield break;
        }
    }
}
