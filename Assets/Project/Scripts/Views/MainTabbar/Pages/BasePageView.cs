public class BasePageView<T> : BaseView<T>, IPageView
{
	public void SetActive(bool active)
	{
		this.gameObject.SetActive(active);
	}
}
