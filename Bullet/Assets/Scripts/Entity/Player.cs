using System.Collections;
using UnityEngine;

namespace Unchord
{
    public class Player : MonoBehaviour
    {
        #region Inspector Properties
        public float moveSpeed;
        #endregion

        private Vector3 _moveDirection;

        private void FixedUpdate()
        {
            transform.position += moveSpeed * Time.deltaTime * _moveDirection;
        }

        private void OnTriggerEnter(Collider collision)
        {
            Bullet bullet = collision.gameObject.GetComponentInParent<Bullet>();

            if (bullet == null)
                return;

            bullet.OnPlayerGrazingAreaEnter();
        }

        private void OnTriggerExit(Collider collision)
        {
            Bullet bullet = collision.gameObject.GetComponentInParent<Bullet>();

            if (bullet == null || !bullet.gameObject.activeSelf)
                return;

            bullet.OnPlayerGrazingAreaExit();
        }

        private void OnCollisionEnter(Collision collision)
        {
            Bullet bullet = collision.gameObject.GetComponentInParent<Bullet>();

            if (bullet == null)
                return;

            StartCoroutine(Die());
        }

        private IEnumerator Die()
        {
            Destroy(this.gameObject);

            // TODO: generate dead particle.

            // TODO: refactor sound code after adding FMOD library.
            new MenuEffectSound().sound("PlayerDie");

            yield return StartCoroutine(GameManager.Instance.EndGame());
        }
    }
}