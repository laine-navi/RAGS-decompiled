using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Xceed.Wpf.Toolkit.Core.Input;

[TypeConverter(typeof(KeyModifierCollectionConverter))]
public class KeyModifierCollection : Collection<KeyModifier>
{
	public bool AreActive
	{
		get
		{
			if (Count == 0)
			{
				return true;
			}
			if (Contains(KeyModifier.Blocked))
			{
				return false;
			}
			if (Contains(KeyModifier.Exact))
			{
				return IsExactMatch();
			}
			return MatchAny();
		}
	}

	private static bool IsKeyPressed(KeyModifier modifier, ICollection<Key> keys)
	{
		switch (modifier)
		{
		case KeyModifier.Alt:
			if (!keys.Contains((Key)120))
			{
				return keys.Contains((Key)121);
			}
			return true;
		case KeyModifier.LeftAlt:
			return keys.Contains((Key)120);
		case KeyModifier.RightAlt:
			return keys.Contains((Key)121);
		case KeyModifier.Ctrl:
			if (!keys.Contains((Key)118))
			{
				return keys.Contains((Key)119);
			}
			return true;
		case KeyModifier.LeftCtrl:
			return keys.Contains((Key)118);
		case KeyModifier.RightCtrl:
			return keys.Contains((Key)119);
		case KeyModifier.Shift:
			if (!keys.Contains((Key)116))
			{
				return keys.Contains((Key)117);
			}
			return true;
		case KeyModifier.LeftShift:
			return keys.Contains((Key)116);
		case KeyModifier.RightShift:
			return keys.Contains((Key)117);
		case KeyModifier.None:
			return true;
		default:
			throw new NotSupportedException("Unknown modifier");
		}
	}

	private static bool HasModifier(Key key, ICollection<KeyModifier> modifiers)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected I4, but got Unknown
		switch (key - 116)
		{
		case 4:
			if (!modifiers.Contains(KeyModifier.Alt))
			{
				return modifiers.Contains(KeyModifier.LeftAlt);
			}
			return true;
		case 5:
			if (!modifiers.Contains(KeyModifier.Alt))
			{
				return modifiers.Contains(KeyModifier.RightAlt);
			}
			return true;
		case 2:
			if (!modifiers.Contains(KeyModifier.Ctrl))
			{
				return modifiers.Contains(KeyModifier.LeftCtrl);
			}
			return true;
		case 3:
			if (!modifiers.Contains(KeyModifier.Ctrl))
			{
				return modifiers.Contains(KeyModifier.RightCtrl);
			}
			return true;
		case 0:
			if (!modifiers.Contains(KeyModifier.Shift))
			{
				return modifiers.Contains(KeyModifier.LeftShift);
			}
			return true;
		case 1:
			if (!modifiers.Contains(KeyModifier.Shift))
			{
				return modifiers.Contains(KeyModifier.RightShift);
			}
			return true;
		default:
			throw new NotSupportedException("Unknown key");
		}
	}

	private bool IsExactMatch()
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		HashSet<KeyModifier> keyModifiers = GetKeyModifiers();
		HashSet<Key> keysPressed = GetKeysPressed();
		if (Contains(KeyModifier.None))
		{
			if (keyModifiers.Count == 0)
			{
				return keysPressed.Count == 0;
			}
			return false;
		}
		foreach (KeyModifier item in keyModifiers)
		{
			if (!IsKeyPressed(item, keysPressed))
			{
				return false;
			}
		}
		foreach (Key item2 in keysPressed)
		{
			if (!HasModifier(item2, keyModifiers))
			{
				return false;
			}
		}
		return true;
	}

	private bool MatchAny()
	{
		if (Contains(KeyModifier.None))
		{
			return true;
		}
		HashSet<KeyModifier> keyModifiers = GetKeyModifiers();
		HashSet<Key> keysPressed = GetKeysPressed();
		foreach (KeyModifier item in keyModifiers)
		{
			if (IsKeyPressed(item, keysPressed))
			{
				return true;
			}
		}
		return false;
	}

	private HashSet<KeyModifier> GetKeyModifiers()
	{
		HashSet<KeyModifier> hashSet = new HashSet<KeyModifier>();
		using IEnumerator<KeyModifier> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			KeyModifier current = enumerator.Current;
			switch (current)
			{
			case KeyModifier.Ctrl:
			case KeyModifier.LeftCtrl:
			case KeyModifier.RightCtrl:
			case KeyModifier.Shift:
			case KeyModifier.LeftShift:
			case KeyModifier.RightShift:
			case KeyModifier.Alt:
			case KeyModifier.LeftAlt:
			case KeyModifier.RightAlt:
				if (!hashSet.Contains(current))
				{
					hashSet.Add(current);
				}
				break;
			}
		}
		return hashSet;
	}

	private HashSet<Key> GetKeysPressed()
	{
		HashSet<Key> hashSet = new HashSet<Key>();
		if (Keyboard.IsKeyDown((Key)120))
		{
			hashSet.Add((Key)120);
		}
		if (Keyboard.IsKeyDown((Key)121))
		{
			hashSet.Add((Key)121);
		}
		if (Keyboard.IsKeyDown((Key)118))
		{
			hashSet.Add((Key)118);
		}
		if (Keyboard.IsKeyDown((Key)119))
		{
			hashSet.Add((Key)119);
		}
		if (Keyboard.IsKeyDown((Key)116))
		{
			hashSet.Add((Key)116);
		}
		if (Keyboard.IsKeyDown((Key)117))
		{
			hashSet.Add((Key)117);
		}
		return hashSet;
	}
}
