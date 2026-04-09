using UnityEngine;

namespace Team8
{
    public class RemovableObstacle : MonoBehaviour
    {
        public float speed = 3f;
        public float moveDistance = 3f;

        private bool isDying = false;
        private float deathSpeed = 5f;

        private Vector3 startPos;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            startPos = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (isDying)
            {
                transform.position += Vector3.down * deathSpeed * Time.deltaTime;

                if (transform.position.y < -10f)
                    Destroy(gameObject);
                return;
            }

            float offset = Mathf.Sin(Time.time * speed) * moveDistance;
            transform.position = startPos + new Vector3(offset, 0, 0);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag("Player")) return;

            bool stompedFromAbove = collision.transform.position.y > transform.position.y + 0.3f;

            if (stompedFromAbove)
            {
                isDying = true;
            }
        }
    }
}
