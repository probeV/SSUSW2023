using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//팝업 및 애니메이션 설정
public class Panel_Handler : MonoBehaviour
{
    //씬 시작
    void Start()
    {
        //초기화
        DOTween.Init();
        transform.localScale = Vector3.one * 0.1f;

        //객체 비활성
        gameObject.SetActive(false);
    }

    //Show 버튼 -> 팝업 활성
    public void Show()
    {
        gameObject.SetActive(true);

        var seq = DOTween.Sequence();

        seq.Append(transform.DOScale(1.1f, 0.2f));
        seq.Append(transform.DOScale(1f, 0.1f));

        seq.Play();
    }

    //Hide 버튼 -> 팝업 비활성
    public void Hide()
    {
        var seq = DOTween.Sequence();

        transform.localScale = Vector3.one * 0.2f;

        seq.Append(transform.DOScale(1.1f, 0.1f));
        seq.Append(transform.DOScale(0.2f, 0.2f));

        seq.Play().OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }
}