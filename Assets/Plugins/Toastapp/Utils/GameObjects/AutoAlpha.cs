using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class AutoAlpha : MonoBehaviour
{
	private CanvasGroup canvasGroup;

    [SerializeField]
    private float delay;

	private void Awake()
	{
		if(this.canvasGroup == null)
		{
			this.canvasGroup = this.GetComponent<CanvasGroup>();
		}
	}

	private void OnEnable()
	{
        this.canvasGroup.alpha = 0;

        StartCoroutine(CoroutineUtils.DelaySeconds(() =>
        {
            DOTween.To(() => canvasGroup.alpha, x => canvasGroup.alpha = x, 1, 0.3f);
        }, this.delay));
	}

}
