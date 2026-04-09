using UnityEngine;

namespace Team1
{
    public class Move_Down : MonoBehaviour
    {
        public GameObject block;      // 내려갈 블록
        public float speed;           // 내려가는 속도
        private bool isFalling = false;

        // isTrigger가 체크되어 있다면 이 함수가 실행됩니다.
        private void OnTriggerEnter2D(Collider2D other)
        {
            // Trigger에서는 'other'가 부딪힌 상대방의 Collider입니다.
            if (other.CompareTag("Player"))
            {
                isFalling = true;
            }
        }

        void Update()
        {
            if (isFalling && block != null)
            {
                // 프레임 속도에 맞춰 아래로 이동
                block.transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
        }
    }
}