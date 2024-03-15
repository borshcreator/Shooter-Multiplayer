using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 5f;
    [SerializeField] private Rigidbody _rigidbody;

   public void Init(Vector3 velocity)
    {
        _rigidbody.velocity = velocity;
        StartCoroutine(DestroyRoutine());
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy();
    }

    private IEnumerator DestroyRoutine()
    {
        yield return new WaitForSecondsRealtime(_lifeTime);
        Destroy();
    }
}
