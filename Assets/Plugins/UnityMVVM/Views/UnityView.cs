using UnityEngine;

public class UnityView : MonoBehaviour, IView
{
	public virtual void Awake()
	{
		var components = this.GetComponents(typeof(UnityEngine.Component));

		IView viewComponent = default(IView);
		IViewModel viewModelComponent = default(IViewModel);

		foreach(var component in components)
		{
			var interfaces = component.GetType().GetInterfaces();
			foreach(var inter in interfaces)
			{
				// If this gameobject contains a component of type IView...
				if(inter.Equals(typeof(IView)))
				{
					viewComponent = component as IView;
				}

				// And if this gameobject contains a component of type IViewModel...
				if(inter.Equals(typeof(IViewModel)))
				{
					viewModelComponent = component as IViewModel;
				}
			}
		}

		if(viewComponent != default(IView) && viewModelComponent != default(IViewModel))
		{
			// ... subscribe 
			viewModelComponent.PropertyChanged += viewComponent.OnPropertyChanged;
		}
	}

	public virtual void Start()
	{
	}

	public virtual void OnEnable()
	{
	}

	public virtual void Update()
	{
	}

	public virtual void LateUpdate()
	{
	}

	public virtual void FixedUpdate()
	{
	}

	public virtual void OnDisable()
	{
	}


	public virtual void OnDestroy()
	{
	}

	public virtual void OnGUI()
	{
	}

	public virtual void OnTriggerEnter()
	{
	}

	public virtual void OnTriggerExit()
	{
	}

	public virtual void OnCollisionEnter()
	{
	}

	public virtual void OnCollisionExit()
	{
	}

	public virtual void OnPropertyChanged(object sender, string property)
	{
	}
}
