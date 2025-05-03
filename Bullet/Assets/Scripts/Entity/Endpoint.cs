using UnityEngine;

namespace Unchord
{
    public class Endpoint : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            Bullet bullet = collision.gameObject.GetComponentInParent<Bullet>();

            if (bullet == null)
                return;

            bullet.OnBulletEndpointReached();
        }
    }
}