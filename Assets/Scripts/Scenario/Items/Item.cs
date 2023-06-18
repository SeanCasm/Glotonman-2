using UnityEngine;
using UnityEngine.Events;

namespace Glotonman2.Scenario.Items
{
    public class Item : MonoBehaviour
    {
        public float m_Speed = 20;
        private Rigidbody2D body;
        private Animator anim;
        public int m_BonusTime;
        public float m_SpawnProb;
        public UnityEvent<float, int> m_OnPlayerCollected;
        public Vector2 direction { get; set; } = Vector2.zero;
        private BoxCollider2D boxCollider2D;
        protected void Start()
        {
            boxCollider2D = GetComponent<BoxCollider2D>();
            body = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }
        protected void FixedUpdate()
        {
            body.velocity = direction * m_Speed * Time.deltaTime;
        }
        private void OnEnable()
        {
            if (boxCollider2D)
                boxCollider2D.enabled = true;
        }
        protected void OnAnimationDisable() => gameObject.SetActive(false);
        public void OnCollisionDisable()
        {
            boxCollider2D.enabled = false;
            anim.SetTrigger("Hide");
            direction = Vector2.zero;
        }
        public void SetSpawnPoint(Vector2 point) => transform.position = point;
        public void SetActiveSelf(bool active) => gameObject.SetActive(active);
        protected void OnCollisionWithPlayer()
        {
            boxCollider2D.enabled = false;
            direction = Vector2.zero;
            anim.SetTrigger("Collected");
        }
    }
}