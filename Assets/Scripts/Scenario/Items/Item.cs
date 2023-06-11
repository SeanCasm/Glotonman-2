using UnityEngine;


namespace Glotonman2.Scenario.Items
{
    public class Item : MonoBehaviour
    {
        public float m_Speed = 20;
        private Rigidbody2D body;
        private Animator anim;
        public Vector2 direction { get; set; } = Vector2.zero;

        protected void Start()
        {
            body = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }
        protected void FixedUpdate()
        {
            body.velocity = direction * m_Speed * Time.deltaTime;
        }
        protected void OnAnimationDisable() => gameObject.SetActive(false);
        public void OnCollisionDisable() => anim.SetTrigger("Hide");
        protected void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                direction = Vector2.zero;
                anim.SetTrigger("Collected");
            }
        }
    }
}