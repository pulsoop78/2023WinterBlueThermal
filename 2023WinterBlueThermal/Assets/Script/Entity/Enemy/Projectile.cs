using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _speed = 5;
    private float _maxRange = 0; //����ü ��Ÿ�
    private float currentRange = 0;
    private int _damage = 0; //����ü ���ݷ�

    public void SetDamage(int damage)
    {
        _damage = damage;
    }

    public void SetRange(float maxRange)
    {
        _maxRange = maxRange;
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    private void FixedUpdate()
    {
        MoveProjectile();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().GetDamage(_damage);
        }
        Destroy(this.gameObject);
    }

    private void MoveProjectile()
    {
        Vector3 nextPosition = (Vector3.forward * _speed * Time.deltaTime);
        transform.Translate(nextPosition);
        currentRange += nextPosition.magnitude;
        DestroyMissedProjectile();
    }

    private void DestroyMissedProjectile()
    {
        if (currentRange >= _maxRange)
        {
            Destroy(this.gameObject);
        }
    }
}