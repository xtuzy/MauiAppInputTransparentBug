using System.Diagnostics;

namespace MauiAppInputTransparentBug;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
		PanGestureRecognizer panGestureRecognizer = new PanGestureRecognizer();
		panGestureRecognizer.PanUpdated += (sender, e) =>
		{
#if WINDOWS
			Debug.WriteLine($"Pan {e.StatusType.ToString()}");
#else
			Console.WriteLine($"Pan {e.StatusType.ToString()}");
#endif
            if (e.StatusType == GestureStatus.Completed||
			e.StatusType == GestureStatus.Canceled)
			{
                //scrollView.InputTransparent = false;
                //scrollView.CascadeInputTransparent = true;
            }
			else if(e.StatusType == GestureStatus.Started) 
			{
                scrollView.InputTransparent = true;
                scrollView.CascadeInputTransparent = false;
            }
		};

		rect.GestureRecognizers.Add(panGestureRecognizer);
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

