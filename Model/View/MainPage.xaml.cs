using Model.ViewModel;

namespace Model.View;

public partial class MainPage : ContentPage
{
	

	public MainPage(MainpageVm myvm)
	{
		InitializeComponent();
		BindingContext= myvm;
	}

	
}

