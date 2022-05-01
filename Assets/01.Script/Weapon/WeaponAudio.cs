using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAudio : AudioPlayer
{
    [SerializeField]
    private AudioClip shootBulletClip, outofBulletClip, reloadClip;

    public void SetAudioClip(AudioClip shootSound , AudioClip outOfBullet, AudioClip reload)
    {
        shootBulletClip = shootSound;

        outofBulletClip = outOfBullet;
        reloadClip = reload;
    }

    public void PlayShootSound()
    {
        PlayClip(shootBulletClip);
    }

    public void PlayNoBulletSound()
    {
        PlayClip(outofBulletClip);
    }

    public void PlayReloadSound()
    {
        PlayClip(reloadClip);
    }
}
