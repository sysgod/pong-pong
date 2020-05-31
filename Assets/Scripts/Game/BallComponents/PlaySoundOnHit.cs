using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnHit : MonoBehaviour
{
    public AudioClip clip;
    private void OnCollisionExit2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(clip,transform.position);
    }
}
