using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
namespace Glotonman2.Controller
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Basic config")]
        public float m_Speed = 2;
        public Vector2 m_SpawnPoint;
        [Header("Speed boost config")]
        public float m_SpeedEffectDelay = .3f;
        public float m_TailLifeTime = .1f;
        public int m_TailAmount = 5;
        private float currentSpeed;
        private Animator animator;
        private Rigidbody2D body;
        private SpriteRenderer spriteRenderer;
        private Vector2 direction = Vector2.zero;
        private State state = State.Normal;
        private Queue<GameObject> sprites = new Queue<GameObject>();

        void Start()
        {
            body = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
            currentSpeed = m_Speed;
        }

        void FixedUpdate()
        {
            body.velocity = direction * currentSpeed * Time.deltaTime;
            if (direction != Vector2.zero)
            {
                float rotationAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);
            }

        }
        IEnumerator SpeedEffect(int timer)
        {
            if (sprites.Count == 0)
            {
                for (int i = 0; i < m_TailAmount; i++)
                {
                    var ob = new GameObject($"Speed_tail_{i}");
                    ob.SetActive(false);
                    var spr = ob.AddComponent<SpriteRenderer>();
                    spr.sortingLayerName = "Player";
                    spr.sortingOrder = -1;
                    spr.color = new Color(1, 1, 1, spr.color.a / 2);
                    sprites.Enqueue(ob);
                }
            }
            float counter = 0;
            while (counter <= timer)
            {
                var ob = sprites.Dequeue();
                ob.transform.position = transform.position;
                ob.transform.rotation = transform.rotation;
                var spr = ob.GetComponent<SpriteRenderer>();
                spr.sprite = spriteRenderer.sprite;
                spr.flipY = spriteRenderer.flipY;
                ob.SetActive(true);
                yield return new WaitForSeconds(m_SpeedEffectDelay);
                StartCoroutine(DisableSprite(ob));
                counter += m_SpeedEffectDelay;
            }
            IEnumerator DisableSprite(GameObject ob)
            {
                yield return new WaitForSeconds(m_TailLifeTime);
                ob.SetActive(false);
                sprites.Enqueue(ob);
            }
            currentSpeed = m_Speed;
        }
        private void Respawn()
        {
            state = State.Normal;
            transform.position = m_SpawnPoint;
        }
        public void IncrementSpeed(float value, int timer)
        {
            currentSpeed = value;
            StartCoroutine(nameof(SpeedEffect), timer);
        }
        public void Hurt()
        {
            state = State.Hurt;
            direction = Vector2.zero;
            animator.SetTrigger("Hurt");
        }

        public void Move(InputAction.CallbackContext context)
        {
            if (state == State.Hurt) return;

            Vector2 newDirection = context.ReadValue<Vector2>();
            bool leftPressed = newDirection.x < 0 || (spriteRenderer.flipY && newDirection.x == 0);

            if (context.performed)
            {
                direction = newDirection;
                spriteRenderer.flipY = leftPressed;
            }
        }
    }
    public enum State
    {
        Hurt, Normal
    }
}
