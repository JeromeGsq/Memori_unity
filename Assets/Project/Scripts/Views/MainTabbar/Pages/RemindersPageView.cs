using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RemindersPageViewModel))]
public class RemindersPageView : BaseView<RemindersPageViewModel>
{
	[Space(20)]

	[SerializeField]
	private ScrollRect scrollRect;

	public override void Start()
	{
		base.Start();

		this.scrollRect.onValueChanged.AddListener((vector) =>
		{
			this.ViewModel?.SetScrollAmount(this.scrollRect.verticalNormalizedPosition);
		});
	}
}
