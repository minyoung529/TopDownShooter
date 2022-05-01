using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactScript : PoolableMono
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        ChildAwake();
    }

    protected virtual void ChildAwake()
    {

    }

    public override void Reset()
    {
        transform.localRotation = Quaternion.identity;
    }

    public virtual void SetPosAndRot(Vector3 pos, Quaternion rot)
    {
        transform.SetPositionAndRotation(pos, rot);

        if (audioSource == null || audioSource.clip == null) return;

        audioSource.Play();
    }

    public void DestroyAfterAnimation()
    {
        PoolManager.Instance.Push(this);
    }
}
