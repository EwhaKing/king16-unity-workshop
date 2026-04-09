using UnityEngine;

namespace Team8
{
    public class ObstacleVertical : MonoBehaviour
    {
        public float speed = 3f;
        public float moveDistance = 3f;

        private Vector3 startPos;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            startPos = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            float offset = Mathf.Sin(Time.time * speed) * moveDistance;
            transform.position = startPos + new Vector3(0, offset, 0);
        }
    }

}
