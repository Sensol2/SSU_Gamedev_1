using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonScale : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float duration = 0.3f; // �ִϸ��̼��� ���� �ð�
    public Vector3 targetScale = new Vector3(1.2f, 1.2f, 0); // ��ǥ ũ��

    private Vector3 initialScale; // �ʱ� ũ��

    private void Awake()
    {
        initialScale = transform.localScale;
    }

    // ���콺 Ŀ���� ��ư ���� �ö��� ��
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(targetScale, duration);
    }

    // ���콺 Ŀ���� ��ư ������ ����� ��
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(initialScale, duration);
    }
}