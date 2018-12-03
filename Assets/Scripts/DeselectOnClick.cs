public class DeselectOnClick : Selectable {

	public override void OnSelected()
	{
		UIcontroller.instance.HideBottomUI();
	}
}
