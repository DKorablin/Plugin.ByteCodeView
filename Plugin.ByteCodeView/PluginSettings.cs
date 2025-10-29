using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Plugin.ByteCodeView
{
	public class PluginSettings : INotifyPropertyChanged
	{
		private Boolean? _monitorFileChange;
		private Boolean? _showAsHexValue;
		private Boolean? _showBaseMetaTables;
		private String _loadedFilesI;
		private UInt32 _maxArrayDisplay = 10;

		[Category("Appearance")]
		[DefaultValue(false)]
		[Description("Show integer value in hexadecimal format")]
		public Boolean ShowAsHexValue
		{
			get => this._showAsHexValue.GetValueOrDefault();
			set
			{
				Boolean isChanged = this._showAsHexValue != null && this._showAsHexValue != value;
				if(isChanged)
					this.SetField(ref this._showAsHexValue, value, nameof(ShowAsHexValue));
			}
		}

		[Category("Appearance")]
		[Description("Show basic structure data")]
		[DefaultValue(false)]
		public Boolean ShowBaseMetaTables
		{
			get => this._showBaseMetaTables.GetValueOrDefault();
			set => this.SetField(ref this._showBaseMetaTables, value, nameof(ShowBaseMetaTables));
		}

		[Category("Appearance")]
		[DefaultValue(typeof(UInt32),"10")]
		[Description("Maximum items in array to display")]
		public UInt32 MaxArrayDisplay
		{
			get => this._maxArrayDisplay;
			set
			{
				Boolean isChanged = this._maxArrayDisplay != value;
				if(isChanged)
					this.SetField(ref this._maxArrayDisplay, value, nameof(MaxArrayDisplay));
			}
		}

		[Category("Data")]
		[DefaultValue(false)]
		[Description("Monitor file change on file system")]
		public Boolean MonitorFileChange
		{
			get => this._monitorFileChange.GetValueOrDefault();
			set
			{
				Boolean isChanged = this._monitorFileChange != null && this._monitorFileChange != value;
				if(isChanged)
					this.SetField(ref this._monitorFileChange, value, nameof(MonitorFileChange));
			}
		}

		[Category("Data")]
		//[ReadOnly(true)]
		[Browsable(false)]
		[Description("Loaded files")]
		public String LoadedFilesI
		{
			get => this._loadedFilesI;
			set => this.SetField(ref this._loadedFilesI, value, nameof(LoadedFilesI));
		}

		/// <remarks>.NET 2.0 XML Serializer fix</remarks>
		internal String[] LoadedFiles
		{
			get => this.LoadedFilesI == null
					? new String[] { }
					: this.LoadedFilesI.Split(new Char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
			set => this.LoadedFilesI = value == null ? null : String.Join("|", value);
		}

		#region INotifyPropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;
		private Boolean SetField<T>(ref T field, T value, String propertyName)
		{
			if(EqualityComparer<T>.Default.Equals(field, value))
				return false;

			field = value;
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
			return true;
		}
		#endregion INotifyPropertyChanged
	}
}