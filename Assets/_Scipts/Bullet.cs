using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 5f;
    [SerializeField] private Rigidbody _rigidbody;
    private int _damage;

   public void Init(Vector3 velocity, int damage = 0)
    {
        _rigidbody.velocity = velocity;
        _damage = damage;
        StartCoroutine(DestroyRoutine());
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent(out EnemeyCharacter enemy))
        {
            enemy.ApplyDamage(_damage);
        }

        Destroy();
    }

    private IEnumerator DestroyRoutine()
    {
        yield return new WaitForSecondsRealtime(_lifeTime);
        Destroy();
    }
}
