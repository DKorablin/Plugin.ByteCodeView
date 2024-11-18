using System;
using System.ComponentModel.Design;
using System.IO;
using System.Windows.Forms;
using AlphaOmega.Debug;

namespace Plugin.ByteCodeView.Directory
{
	public partial class DocumentBinary : DocumentBase
	{
		internal static DisplayMode[] DisplayModes = (DisplayMode[])Enum.GetValues(typeof(DisplayMode));
		private DocumentBinarySettings _settings;

		public override DocumentBaseSettings Settings => this.SettingsI;

		private DocumentBinarySettings SettingsI => this._settings ?? (this._settings = new DocumentBinarySettings());

		public DocumentBinary()
			: base(ClassItemType.ConstantPool)
		{
			InitializeComponent();
			tsddlView.Items.AddRange(Array.ConvertAll(DocumentBinary.DisplayModes, delegate(DisplayMode mode) { return mode.ToString(); }));
			tsddlView.SelectedIndex = 0;
		}

		protected override void ShowFile(ClassFile info)
		{
			ISectionData section = this.GetSectionData();
			tsbnView.Enabled = this.Plugin.DirectoryViewers.ContainsKey(this.SettingsI.Header);

			bvBytes.SetBytes(section.GetData());
		}

		protected override void SetCaption()
		{
			String[] captions;
			switch(this.SettingsI.Header)
			{
			case ClassItemType.Method:
			case ClassItemType.Field:
				captions = new String[] { this.SettingsI.Header.ToString(), this.SettingsI.NodeName, Path.GetFileName(this.Settings.FilePath) };
				break;
			default:
				captions = new String[] { Constant.GetHeaderName(this.SettingsI.Header), Path.GetFileName(this.Settings.FilePath) };
				break;
			}

			base.Window.Caption = String.Join(" - ", captions);
			//base.SetCaption();
		}

		private ISectionData GetSectionData()
		{
			ClassFile info = base.GetFile();
			switch(this.SettingsI.Header)
			{
			case ClassItemType.Field:
				foreach(Field_Info field in info.Fields)
					if(field.ToString() == this.SettingsI.NodeName)
						return (ISectionData)field;
				throw new ArgumentException($"Field '{this.SettingsI.NodeName}' not found");
			case ClassItemType.Method:
				foreach(MethodInfo method in info.Methods)
					if(method.ToString() == this.SettingsI.NodeName)
						return (ISectionData)method;
				throw new ArgumentException($"Method '{this.SettingsI.NodeName}' not found");
			default:
				return (ISectionData)base.Plugin.GetSectionData(this.SettingsI.Header, this.SettingsI.NodeName, info);
			}
		}

		private void tsddlView_SelectedIndexChanged(Object sender, EventArgs e)
		{
			DisplayMode mode = DocumentBinary.DisplayModes[tsddlView.SelectedIndex];
			bvBytes.SetDisplayMode(mode);
		}

		private void tsbnSave_Click(Object sender, EventArgs e)
		{
			String peFilePath = Path.GetFullPath(this.Settings.FilePath);
			using(SaveFileDialog dlg = new SaveFileDialog() { InitialDirectory = peFilePath, OverwritePrompt = true, AddExtension = true, DefaultExt = "bin", Filter = "BIN file (*.bin)|*.bin|All files (*.*)|*.*", })
				if(dlg.ShowDialog() == DialogResult.OK)
					bvBytes.SaveToFile(dlg.FileName);
		}

		private void tsbnView_Click(Object sender, EventArgs e)
		{
			this.Plugin.CreateWindow(this.SettingsI.Header,
				new DocumentBaseSettings() { FilePath = this.SettingsI.FilePath, });
		}
	}
}