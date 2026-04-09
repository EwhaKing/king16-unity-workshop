using UnityEngine;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Team4
{
    public class ScreenDisturber : MonoBehaviour
    {
        [Header("UI Reference")]
        public Image blackScreen; // 검은색 이미지 오브젝트를 연결하세요.

        private void Start()
        {
            if (blackScreen != null)
            {
                // 시작할 때는 화면이 보여야 하므로 투명하게 설정
                blackScreen.gameObject.SetActive(false);
                StartCoroutine(DisturbanceLoop());
            }
        }

        IEnumerator DisturbanceLoop()
        {
            while (true)
            {
                // 1. 10초 대기 (평상시)
                yield return new WaitForSeconds(5f);

                // 2. 전조 증상: 0.5초 간격으로 3번 깜빡임
                for (int i = 0; i < 2; i++)
                {
                    blackScreen.gameObject.SetActive(true);  // 화면 가림
                    yield return new WaitForSeconds(0.5f);
                    blackScreen.gameObject.SetActive(false); // 화면 복구
                    yield return new WaitForSeconds(0.5f);
                }

                // 3. 암전: 5초 동안 완전히 꺼짐
                blackScreen.gameObject.SetActive(true);
                yield return new WaitForSeconds(3f);

                // 4. 다시 화면 복구
                blackScreen.gameObject.SetActive(false);
            }
        }
    }
}