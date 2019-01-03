public class UnityViewCell : UnityView
{
	public void SetViewModel(IViewModel viewModel)
	{
		var components = this.GetComponents(typeof(UnityEngine.Component));

		IViewModel viewModelComponent = default(IViewModel);

		foreach(var component in components)
		{
			var interfaces = component.GetType().GetInterfaces();
			foreach(var inter in interfaces)
			{
				if(inter.Equals(typeof(IViewModel)))
				{
					viewModelComponent = component as IViewModel;
					break;
				}
			}
		}

		viewModelComponent = viewModel;

		this.Init();
	}
}
