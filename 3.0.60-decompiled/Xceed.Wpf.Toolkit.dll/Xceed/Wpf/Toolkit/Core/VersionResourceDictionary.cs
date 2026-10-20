using System;
using System.ComponentModel;
using System.Windows;

namespace Xceed.Wpf.Toolkit.Core;

public class VersionResourceDictionary : ResourceDictionary, ISupportInitialize
{
	private enum InitState
	{
		NotInitialized,
		Initializing,
		Initialized
	}

	private int _initializingCount;

	private string _assemblyName;

	private string _sourcePath;

	public string AssemblyName
	{
		get
		{
			return _assemblyName;
		}
		set
		{
			EnsureInitialization();
			_assemblyName = value;
		}
	}

	public string SourcePath
	{
		get
		{
			return _sourcePath;
		}
		set
		{
			EnsureInitialization();
			_sourcePath = value;
		}
	}

	public VersionResourceDictionary()
	{
	}

	public VersionResourceDictionary(string assemblyName, string sourcePath)
	{
		((ISupportInitialize)this).BeginInit();
		AssemblyName = assemblyName;
		SourcePath = sourcePath;
		((ISupportInitialize)this).EndInit();
	}

	private void EnsureInitialization()
	{
		if (_initializingCount <= 0)
		{
			throw new InvalidOperationException("VersionResourceDictionary properties can only be set while initializing");
		}
	}

	void ISupportInitialize.BeginInit()
	{
		((ResourceDictionary)this).BeginInit();
		_initializingCount++;
	}

	void ISupportInitialize.EndInit()
	{
		_initializingCount--;
		if (_initializingCount <= 0)
		{
			if (((ResourceDictionary)this).Source != null)
			{
				throw new InvalidOperationException("Source property cannot be initialized on the VersionResourceDictionary");
			}
			if (string.IsNullOrEmpty(AssemblyName) || string.IsNullOrEmpty(SourcePath))
			{
				throw new InvalidOperationException("AssemblyName and SourcePath must be set during initialization");
			}
			string uriString = string.Format("{0};v{1};component/{2}", AssemblyName, "2.1.0.0", SourcePath);
			((ResourceDictionary)this).Source = new Uri(uriString, UriKind.Relative);
		}
		((ResourceDictionary)this).EndInit();
	}
}
