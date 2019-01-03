using System.ComponentModel;

public interface IView 
{
	 void OnPropertyChanged(object sender, string property);
}
