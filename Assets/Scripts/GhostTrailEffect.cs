using UnityEngine;
using DG.Tweening;

public class GhostTrailEffect : MonoBehaviour
{
    public GameObject player;
    SpriteRenderer sprite;
    public Transform ghostsParent;
    public Color trailColor;
    public Color fadeColor;
    public float trailInterval;
    public float fadeTime;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void ShowGhost()
    {
        Sequence s = DOTween.Sequence();
        /*  DOTween
            Append : �̸ֹ��̼� �ٷ� ����
            AppendCallback : ��ٸ� �� �ݹ�ȣ��
            AppendInterval : �ð� ��ٸ�
        */
        for (int i = 0; i < ghostsParent.childCount; i++)
        {
            Transform currentGhost = ghostsParent.GetChild(i);
            s.AppendCallback(() => currentGhost.position = player.transform.position);
            s.Append(currentGhost.GetComponent<SpriteRenderer>().material.DOColor(trailColor, 0));
            s.AppendCallback(() => FadeSprite(currentGhost));
            s.AppendInterval(trailInterval);
        }
    }
    // ȿ�� ���̵� �ƿ�
    public void FadeSprite(Transform current)
    {
        current.GetComponent<SpriteRenderer>().material.DOKill();
        current.GetComponent<SpriteRenderer>().material.DOColor(fadeColor, fadeTime);
    }


}