using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonScale : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float duration = 0.3f; // 애니메이션의 지속 시간
    public Vector3 targetScale = new Vector3(1.2f, 1.2f, 0); // 목표 크기

    private Vector3 initialScale; // 초기 크기

    private void Awake()
    {
        initialScale = transform.localScale;
    }

    // 마우스 커서가 버튼 위에 올라갔을 때
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(targetScale, duration);
    }

    // 마우스 커서가 버튼 위에서 벗어났을 때
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(initialScale, duration);
    }
}