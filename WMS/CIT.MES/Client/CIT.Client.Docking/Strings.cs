using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace CIT.Client.Docking
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Strings
	{
		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(resourceMan, null))
				{
					ResourceManager resourceManager = resourceMan = new ResourceManager("CIT.Client.Docking.Strings", typeof(Strings).Assembly);
				}
				return resourceMan;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return resourceCulture;
			}
			set
			{
				resourceCulture = value;
			}
		}

		internal static string Category_Docking => ResourceManager.GetString("Category_Docking", resourceCulture);

		internal static string Category_DockingNotification => ResourceManager.GetString("Category_DockingNotification", resourceCulture);

		internal static string Category_PropertyChanged => ResourceManager.GetString("Category_PropertyChanged", resourceCulture);

		internal static string DockAreaEditor_FloatCheckBoxText => ResourceManager.GetString("DockAreaEditor_FloatCheckBoxText", resourceCulture);

		internal static string DockContent_AllowEndUserDocking_Description => ResourceManager.GetString("DockContent_AllowEndUserDocking_Description", resourceCulture);

		internal static string DockContent_AutoHidePortion_Description => ResourceManager.GetString("DockContent_AutoHidePortion_Description", resourceCulture);

		internal static string DockContent_CloseButton_Description => ResourceManager.GetString("DockContent_CloseButton_Description", resourceCulture);

		internal static string DockContent_CloseButtonVisible_Description => ResourceManager.GetString("DockContent_CloseButtonVisible_Description", resourceCulture);

		internal static string DockContent_Constructor_InvalidForm => ResourceManager.GetString("DockContent_Constructor_InvalidForm", resourceCulture);

		internal static string DockContent_DockAreas_Description => ResourceManager.GetString("DockContent_DockAreas_Description", resourceCulture);

		internal static string DockContent_DockStateChanged_Description => ResourceManager.GetString("DockContent_DockStateChanged_Description", resourceCulture);

		internal static string DockContent_HideOnClose_Description => ResourceManager.GetString("DockContent_HideOnClose_Description", resourceCulture);

		internal static string DockContent_ShowHint_Description => ResourceManager.GetString("DockContent_ShowHint_Description", resourceCulture);

		internal static string DockContent_TabPageContextMenu_Description => ResourceManager.GetString("DockContent_TabPageContextMenu_Description", resourceCulture);

		internal static string DockContent_TabText_Description => ResourceManager.GetString("DockContent_TabText_Description", resourceCulture);

		internal static string DockContent_ToolTipText_Description => ResourceManager.GetString("DockContent_ToolTipText_Description", resourceCulture);

		internal static string DockContentHandler_AutoHidePortion_OutOfRange => ResourceManager.GetString("DockContentHandler_AutoHidePortion_OutOfRange", resourceCulture);

		internal static string DockContentHandler_DockAreas_InvalidValue => ResourceManager.GetString("DockContentHandler_DockAreas_InvalidValue", resourceCulture);

		internal static string DockContentHandler_DockPane_InvalidValue => ResourceManager.GetString("DockContentHandler_DockPane_InvalidValue", resourceCulture);

		internal static string DockContentHandler_FloatPane_InvalidValue => ResourceManager.GetString("DockContentHandler_FloatPane_InvalidValue", resourceCulture);

		internal static string DockContentHandler_IsFloat_InvalidValue => ResourceManager.GetString("DockContentHandler_IsFloat_InvalidValue", resourceCulture);

		internal static string DockContentHandler_SetDockState_InvalidState => ResourceManager.GetString("DockContentHandler_SetDockState_InvalidState", resourceCulture);

		internal static string DockContentHandler_SetDockState_NullPanel => ResourceManager.GetString("DockContentHandler_SetDockState_NullPanel", resourceCulture);

		internal static string DockContentHandler_Show_InvalidBeforeContent => ResourceManager.GetString("DockContentHandler_Show_InvalidBeforeContent", resourceCulture);

		internal static string DockContentHandler_Show_InvalidDockState => ResourceManager.GetString("DockContentHandler_Show_InvalidDockState", resourceCulture);

		internal static string DockContentHandler_Show_InvalidPrevPane => ResourceManager.GetString("DockContentHandler_Show_InvalidPrevPane", resourceCulture);

		internal static string DockContentHandler_Show_NullDockPanel => ResourceManager.GetString("DockContentHandler_Show_NullDockPanel", resourceCulture);

		internal static string DockContentHandler_Show_NullPane => ResourceManager.GetString("DockContentHandler_Show_NullPane", resourceCulture);

		internal static string DockContentHandler_ShowHint_InvalidValue => ResourceManager.GetString("DockContentHandler_ShowHint_InvalidValue", resourceCulture);

		internal static string DockHandler_TabPageContextMenuStrip_Description => ResourceManager.GetString("DockHandler_TabPageContextMenuStrip_Description", resourceCulture);

		internal static string DockIndicator_ToolTipText => ResourceManager.GetString("DockIndicator_ToolTipText", resourceCulture);

		internal static string DockPane_ActiveContent_InvalidValue => ResourceManager.GetString("DockPane_ActiveContent_InvalidValue", resourceCulture);

		internal static string DockPane_Constructor_NullContent => ResourceManager.GetString("DockPane_Constructor_NullContent", resourceCulture);

		internal static string DockPane_Constructor_NullDockPanel => ResourceManager.GetString("DockPane_Constructor_NullDockPanel", resourceCulture);

		internal static string DockPane_DockTo_InvalidContainer => ResourceManager.GetString("DockPane_DockTo_InvalidContainer", resourceCulture);

		internal static string DockPane_DockTo_NoPrevPane => ResourceManager.GetString("DockPane_DockTo_NoPrevPane", resourceCulture);

		internal static string DockPane_DockTo_NullContainer => ResourceManager.GetString("DockPane_DockTo_NullContainer", resourceCulture);

		internal static string DockPane_DockTo_NullPrevPane => ResourceManager.GetString("DockPane_DockTo_NullPrevPane", resourceCulture);

		internal static string DockPane_DockTo_SelfPrevPane => ResourceManager.GetString("DockPane_DockTo_SelfPrevPane", resourceCulture);

		internal static string DockPane_FloatWindow_InvalidValue => ResourceManager.GetString("DockPane_FloatWindow_InvalidValue", resourceCulture);

		internal static string DockPane_SetContentIndex_InvalidContent => ResourceManager.GetString("DockPane_SetContentIndex_InvalidContent", resourceCulture);

		internal static string DockPane_SetContentIndex_InvalidIndex => ResourceManager.GetString("DockPane_SetContentIndex_InvalidIndex", resourceCulture);

		internal static string DockPane_SetDockState_InvalidState => ResourceManager.GetString("DockPane_SetDockState_InvalidState", resourceCulture);

		internal static string DockPaneCaption_ToolTipAutoHide => ResourceManager.GetString("DockPaneCaption_ToolTipAutoHide", resourceCulture);

		internal static string DockPaneCaption_ToolTipClose => ResourceManager.GetString("DockPaneCaption_ToolTipClose", resourceCulture);

		internal static string DockPaneCaption_ToolTipOptions => ResourceManager.GetString("DockPaneCaption_ToolTipOptions", resourceCulture);

		internal static string DockPanel_ActiveAutoHideContent_InvalidValue => ResourceManager.GetString("DockPanel_ActiveAutoHideContent_InvalidValue", resourceCulture);

		internal static string DockPanel_ActiveContentChanged_Description => ResourceManager.GetString("DockPanel_ActiveContentChanged_Description", resourceCulture);

		internal static string DockPanel_ActiveDocumentChanged_Description => ResourceManager.GetString("DockPanel_ActiveDocumentChanged_Description", resourceCulture);

		internal static string DockPanel_ActivePaneChanged_Description => ResourceManager.GetString("DockPanel_ActivePaneChanged_Description", resourceCulture);

		internal static string DockPanel_AllowEndUserDocking_Description => ResourceManager.GetString("DockPanel_AllowEndUserDocking_Description", resourceCulture);

		internal static string DockPanel_AllowEndUserNestedDocking_Description => ResourceManager.GetString("DockPanel_AllowEndUserNestedDocking_Description", resourceCulture);

		internal static string DockPanel_ContentAdded_Description => ResourceManager.GetString("DockPanel_ContentAdded_Description", resourceCulture);

		internal static string DockPanel_ContentRemoved_Description => ResourceManager.GetString("DockPanel_ContentRemoved_Description", resourceCulture);

		internal static string DockPanel_DefaultFloatWindowSize_Description => ResourceManager.GetString("DockPanel_DefaultFloatWindowSize_Description", resourceCulture);

		internal static string DockPanel_Description => ResourceManager.GetString("DockPanel_Description", resourceCulture);

		internal static string DockPanel_DockBottomPortion_Description => ResourceManager.GetString("DockPanel_DockBottomPortion_Description", resourceCulture);

		internal static string DockPanel_DockLeftPortion_Description => ResourceManager.GetString("DockPanel_DockLeftPortion_Description", resourceCulture);

		internal static string DockPanel_DockPanelSkin => ResourceManager.GetString("DockPanel_DockPanelSkin", resourceCulture);

		internal static string DockPanel_DockRightPortion_Description => ResourceManager.GetString("DockPanel_DockRightPortion_Description", resourceCulture);

		internal static string DockPanel_DockTopPortion_Description => ResourceManager.GetString("DockPanel_DockTopPortion_Description", resourceCulture);

		internal static string DockPanel_DocumentStyle_Description => ResourceManager.GetString("DockPanel_DocumentStyle_Description", resourceCulture);

		internal static string DockPanel_DocumentTabStripLocation => ResourceManager.GetString("DockPanel_DocumentTabStripLocation", resourceCulture);

		internal static string DockPanel_LoadFromXml_AlreadyInitialized => ResourceManager.GetString("DockPanel_LoadFromXml_AlreadyInitialized", resourceCulture);

		internal static string DockPanel_LoadFromXml_InvalidFormatVersion => ResourceManager.GetString("DockPanel_LoadFromXml_InvalidFormatVersion", resourceCulture);

		internal static string DockPanel_LoadFromXml_InvalidXmlFormat => ResourceManager.GetString("DockPanel_LoadFromXml_InvalidXmlFormat", resourceCulture);

		internal static string DockPanel_ParentForm_Invalid => ResourceManager.GetString("DockPanel_ParentForm_Invalid", resourceCulture);

		internal static string DockPanel_Persistor_XmlFileComment1 => ResourceManager.GetString("DockPanel_Persistor_XmlFileComment1", resourceCulture);

		internal static string DockPanel_Persistor_XmlFileComment2 => ResourceManager.GetString("DockPanel_Persistor_XmlFileComment2", resourceCulture);

		internal static string DockPanel_RightToLeftLayout_Description => ResourceManager.GetString("DockPanel_RightToLeftLayout_Description", resourceCulture);

		internal static string DockPanel_SetPaneIndex_InvalidIndex => ResourceManager.GetString("DockPanel_SetPaneIndex_InvalidIndex", resourceCulture);

		internal static string DockPanel_SetPaneIndex_InvalidPane => ResourceManager.GetString("DockPanel_SetPaneIndex_InvalidPane", resourceCulture);

		internal static string DockPanel_ShowDocumentIcon_Description => ResourceManager.GetString("DockPanel_ShowDocumentIcon_Description", resourceCulture);

		internal static string DockPaneStrip_ToolTipClose => ResourceManager.GetString("DockPaneStrip_ToolTipClose", resourceCulture);

		internal static string DockPaneStrip_ToolTipWindowList => ResourceManager.GetString("DockPaneStrip_ToolTipWindowList", resourceCulture);

		internal static string FloatWindow_Constructor_NullDockPanel => ResourceManager.GetString("FloatWindow_Constructor_NullDockPanel", resourceCulture);

		internal static string FloatWindow_SetPaneIndex_InvalidIndex => ResourceManager.GetString("FloatWindow_SetPaneIndex_InvalidIndex", resourceCulture);

		internal static string FloatWindow_SetPaneIndex_InvalidPane => ResourceManager.GetString("FloatWindow_SetPaneIndex_InvalidPane", resourceCulture);

		internal static string IDockDragSource_DockTo_InvalidPanel => ResourceManager.GetString("IDockDragSource_DockTo_InvalidPanel", resourceCulture);

		internal Strings()
		{
		}
	}
}
