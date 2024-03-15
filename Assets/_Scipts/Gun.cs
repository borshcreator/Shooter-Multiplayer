using System;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    public Action OnShoot;
    [SerializeField] protected Bullet _bulletPrefab;
}
