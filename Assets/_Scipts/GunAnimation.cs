using System;
using UnityEngine;

public class GunAnimation : MonoBehaviour
{
    private const string shoot = "Shoot";

    [SerializeField] private Gun _gun;
    [SerializeField] private Animator _animator;

    private void Start()
    {
        _gun.OnShoot += Shoot;
    }

    private void OnDestroy()
    {
        _gun.OnShoot -= Shoot;
    }

    private void Shoot()
    {
        _animator.SetTrigger(shoot);
    }
}
