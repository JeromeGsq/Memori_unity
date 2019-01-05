using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RemindersPageViewModel))]
public class RemindersPageView : BaseView<RemindersPageViewModel>
{
	[SerializeField]
	private Transform reminderAnchor;

	[SerializeField]
	private GameObject reminderPrefab;

	[SerializeField]
	private List<GameObject> reminderViews;

	[Space(20)]

	[SerializeField]
	private ScrollRect scrollRect;

	public override void Start()
	{
		base.Start();

		this.ViewModel?.SetScrollAmount(1);
		this.scrollRect.onValueChanged.AddListener((vector) =>
		{
			if(this.scrollRect.content.sizeDelta.y > Screen.height)
			{
				this.ViewModel?.SetScrollAmount(this.scrollRect.verticalNormalizedPosition);
			}
			else
			{
				this.ViewModel?.SetScrollAmount(1);
			}
		});

		this.InitRemindersViews(this.ViewModel?.Reminders);

		LayoutRebuilder.MarkLayoutForRebuild(transform as RectTransform);
	}

	public override void OnEnable()
	{
		base.OnEnable();
		LayoutRebuilder.ForceRebuildLayoutImmediate(transform as RectTransform);
		LayoutRebuilder.ForceRebuildLayoutImmediate(reminderAnchor as RectTransform);
	}

	public override void OnPropertyChanged(object sender, PropertyChangedEventArgs property)
	{
		base.OnPropertyChanged(sender, property);

		if(property.PropertyName == nameof(this.ViewModel.Reminders))
		{
			this.InitRemindersViews(this.ViewModel.Reminders);
		}
	}

	private void InitRemindersViews(List<Reminder> reminders)
	{
		if(reminders == null)
		{
			Debug.LogWarning("InitRemindersViews() : Reminders are null");
			return;
		}

		foreach(var item in this.reminderViews)
		{
			Destroy(item.gameObject);
		}

		Debug.Log("InitFeelingViews() : Generating reminders cells");

		foreach(var reminder in reminders)
		{
			GameObject reminderView = Instantiate(this.reminderPrefab, this.reminderAnchor);
			reminderView.GetComponent<ReminderViewModel>().SetModel(reminder, this.ViewModel);
			this.reminderViews.Add(reminderView);
		}

		LayoutRebuilder.ForceRebuildLayoutImmediate(transform as RectTransform);
		LayoutRebuilder.ForceRebuildLayoutImmediate(reminderAnchor as RectTransform);
	}
}
