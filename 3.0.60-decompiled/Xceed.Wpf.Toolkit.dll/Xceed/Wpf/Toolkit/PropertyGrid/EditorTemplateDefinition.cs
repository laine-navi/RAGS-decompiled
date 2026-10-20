using System.Windows;

namespace Xceed.Wpf.Toolkit.PropertyGrid;

public class EditorTemplateDefinition : EditorDefinitionBase
{
	public static readonly DependencyProperty EditingTemplateProperty = DependencyProperty.Register("EditingTemplate", typeof(DataTemplate), typeof(EditorTemplateDefinition), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));

	public DataTemplate EditingTemplate
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (DataTemplate)((DependencyObject)this).GetValue(EditingTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EditingTemplateProperty, (object)value);
		}
	}

	protected sealed override FrameworkElement GenerateEditingElement(PropertyItemBase propertyItem)
	{
		if (EditingTemplate == null)
		{
			return null;
		}
		DependencyObject val = ((FrameworkTemplate)EditingTemplate).LoadContent();
		return (FrameworkElement)(object)((val is FrameworkElement) ? val : null);
	}

	static EditorTemplateDefinition()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected Obj, but got Unknown
	}
}
