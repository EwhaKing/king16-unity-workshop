using UnityEngine;
using System.Collections;

namespace Team8{
public class PlayerRandomScaler : MonoBehaviour
{
    [Header("커지는 비율 범위")]
    public float minGrowthAmount = 0.2f;   // 최소 얼마나 더 커질지
    public float maxGrowthAmount = 0.8f;   // 최대 얼마나 더 커질지

    [Header("최대 크기 제한")]
    public float absoluteMaxScale = 3.0f;

    [Header("원래 크기로 돌아가는 시간")]
    public float duration = 5f;

    [Header("부드럽게 크기 바뀌는 시간")]
    public float scaleChangeDuration = 0.2f;

    private Vector3 originalScale;
    private Coroutine returnCoroutine;
    private Coroutine scaleCoroutine;

    void Awake()
    {
        originalScale = transform.localScale;
    }

    public void ApplyRandomGrowth()
    {
        float currentScale = transform.localScale.x;

        // 무조건 현재보다 커지게
        float growth = Random.Range(minGrowthAmount, maxGrowthAmount);
        float targetScaleValue = currentScale + growth;

        // 최대 크기 제한
        targetScaleValue = Mathf.Min(targetScaleValue, absoluteMaxScale);

        Vector3 targetScale = new Vector3(targetScaleValue, targetScaleValue, 1f);

        // 이전 크기 변경 코루틴 중지
        if (scaleCoroutine != null)
            StopCoroutine(scaleCoroutine);

        scaleCoroutine = StartCoroutine(ChangeScaleSmoothly(targetScale));

        // "마지막으로 먹은 버섯 기준"으로 복귀 시간 갱신
        if (returnCoroutine != null)
            StopCoroutine(returnCoroutine);

        returnCoroutine = StartCoroutine(ReturnToOriginalAfterTime());
    }

    IEnumerator ChangeScaleSmoothly(Vector3 targetScale)
    {
        Vector3 startScale = transform.localScale;
        float time = 0f;

        while (time < scaleChangeDuration)
        {
            time += Time.deltaTime;
            transform.localScale = Vector3.Lerp(startScale, targetScale, time / scaleChangeDuration);
            yield return null;
        }

        transform.localScale = targetScale;
        scaleCoroutine = null;
    }

    IEnumerator ReturnToOriginalAfterTime()
    {
        yield return new WaitForSeconds(duration);

        if (scaleCoroutine != null)
            StopCoroutine(scaleCoroutine);

        scaleCoroutine = StartCoroutine(ChangeScaleSmoothly(originalScale));
        returnCoroutine = null;
    }
}
}