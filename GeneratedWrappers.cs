using System;
using System.Runtime.InteropServices;
namespace com.daxode.imgui
{
	public static class ImGuiConstants
	{
#if UNITY_64
		public const int PtrSize = 64/4;
#else
		public const int PtrSize = 32/4;
#endif
	}

	/// <summary>
	/// Flags for ImDrawList functions
	/// (Legacy: bit 0 must always correspond to ImDrawFlags_Closed to be backward compatible with old API using a bool. Bits 1..3 must be unused)
	/// </summary>
	[Flags]
	public enum ImDrawFlags
	{
		None = 0,
		/// PathStroke(), AddPolyline(): specify that shape should be closed (Important: this is always == 1 for legacy reason)
		Closed = 1 << 0,
		/// AddRect(), AddRectFilled(), PathRect(): enable rounding top-left corner only (when rounding &gt; 0.0f, we default to all corners). Was 0x01.
		RoundCornersTopLeft = 1 << 4,
		/// AddRect(), AddRectFilled(), PathRect(): enable rounding top-right corner only (when rounding &gt; 0.0f, we default to all corners). Was 0x02.
		RoundCornersTopRight = 1 << 5,
		/// AddRect(), AddRectFilled(), PathRect(): enable rounding bottom-left corner only (when rounding &gt; 0.0f, we default to all corners). Was 0x04.
		RoundCornersBottomLeft = 1 << 6,
		/// AddRect(), AddRectFilled(), PathRect(): enable rounding bottom-right corner only (when rounding &gt; 0.0f, we default to all corners). Wax 0x08.
		RoundCornersBottomRight = 1 << 7,
		/// AddRect(), AddRectFilled(), PathRect(): disable rounding on all corners (when rounding &gt; 0.0f). This is NOT zero, NOT an implicit flag!
		RoundCornersNone = 1 << 8,
		RoundCornersTop = ImDrawFlags.RoundCornersTopLeft | ImDrawFlags.RoundCornersTopRight,
		RoundCornersBottom = ImDrawFlags.RoundCornersBottomLeft | ImDrawFlags.RoundCornersBottomRight,
		RoundCornersLeft = ImDrawFlags.RoundCornersBottomLeft | ImDrawFlags.RoundCornersTopLeft,
		RoundCornersRight = ImDrawFlags.RoundCornersBottomRight | ImDrawFlags.RoundCornersTopRight,
		RoundCornersAll = ImDrawFlags.RoundCornersTopLeft | ImDrawFlags.RoundCornersTopRight | ImDrawFlags.RoundCornersBottomLeft | ImDrawFlags.RoundCornersBottomRight,
		/// Default to ALL corners if none of the _RoundCornersXX flags are specified.
		RoundCornersDefault = ImDrawFlags.RoundCornersAll,
		RoundCornersMask = ImDrawFlags.RoundCornersAll | ImDrawFlags.RoundCornersNone,
	}

	/// <summary>
	/// Flags for ImDrawList instance. Those are set automatically by ImGui:: functions from ImGuiIO settings, and generally not manipulated directly.
	/// It is however possible to temporarily alter flags between calls to ImDrawList:: functions.
	/// </summary>
	[Flags]
	public enum ImDrawListFlags
	{
		None = 0,
		/// Enable anti-aliased lines/borders (*2 the number of triangles for 1.0f wide line or lines thin enough to be drawn using textures, otherwise *3 the number of triangles)
		AntiAliasedLines = 1 << 0,
		/// Enable anti-aliased lines/borders using textures when possible. Require backend to render with bilinear filtering (NOT point/nearest filtering).
		AntiAliasedLinesUseTex = 1 << 1,
		/// Enable anti-aliased edge around filled shapes (rounded rectangles, circles).
		AntiAliasedFill = 1 << 2,
		/// Can emit 'VtxOffset &gt; 0' to allow large meshes. Set when 'ImGuiBackendFlags_RendererHasVtxOffset' is enabled.
		AllowVtxOffset = 1 << 3,
	}

	/// <summary>
	/// Flags for ImFontAtlas build
	/// </summary>
	[Flags]
	public enum ImFontAtlasFlags
	{
		None = 0,
		/// Don't round the height to next power of two
		NoPowerOfTwoHeight = 1 << 0,
		/// Don't build software mouse cursors into the atlas (save a little texture memory)
		NoMouseCursors = 1 << 1,
		/// Don't build thick line textures into the atlas (save a little texture memory, allow support for point/nearest filtering). The AntiAliasedLinesUseTex features uses them, otherwise they will be rendered using polygons (more expensive for CPU/GPU).
		NoBakedLines = 1 << 2,
	}

	/// <summary>
	/// Backend capabilities flags stored in io.BackendFlags. Set by imgui_impl_xxx or custom backend.
	/// </summary>
	[Flags]
	public enum ImGuiBackendFlags
	{
		None = 0,
		/// Backend Platform supports gamepad and currently has one connected.
		HasGamepad = 1 << 0,
		/// Backend Platform supports honoring GetMouseCursor() value to change the OS cursor shape.
		HasMouseCursors = 1 << 1,
		/// Backend Platform supports io.WantSetMousePos requests to reposition the OS mouse position (only used if ImGuiConfigFlags_NavEnableSetMousePos is set).
		HasSetMousePos = 1 << 2,
		/// Backend Renderer supports ImDrawCmd::VtxOffset. This enables output of large meshes (64K+ vertices) while still using 16-bit indices.
		RendererHasVtxOffset = 1 << 3,
		/// Backend Platform supports multiple viewports.
		PlatformHasViewports = 1 << 10,
		/// Backend Platform supports calling io.AddMouseViewportEvent() with the viewport under the mouse. IF POSSIBLE, ignore viewports with the ImGuiViewportFlags_NoInputs flag (Win32 backend, GLFW 3.30+ backend can do this, SDL backend cannot). If this cannot be done, Dear ImGui needs to use a flawed heuristic to find the viewport under.
		HasMouseHoveredViewport = 1 << 11,
		/// Backend Renderer supports multiple viewports.
		RendererHasViewports = 1 << 12,
	}

	/// <summary>
	/// Flags for InvisibleButton() [extended in imgui_internal.h]
	/// </summary>
	[Flags]
	public enum ImGuiButtonFlags
	{
		None = 0,
		/// React on left mouse button (default)
		MouseButtonLeft = 1 << 0,
		/// React on right mouse button
		MouseButtonRight = 1 << 1,
		/// React on center mouse button
		MouseButtonMiddle = 1 << 2,
		MouseButtonMask = ImGuiButtonFlags.MouseButtonLeft | ImGuiButtonFlags.MouseButtonRight | ImGuiButtonFlags.MouseButtonMiddle,
		MouseButtonDefault = ImGuiButtonFlags.MouseButtonLeft,
	}

	/// <summary>
	/// Flags for ImGui::BeginChild()
	/// (Legacy: bit 0 must always correspond to ImGuiChildFlags_Border to be backward compatible with old API using 'bool border = false'.
	/// About using AutoResizeX/AutoResizeY flags:
	/// - May be combined with SetNextWindowSizeConstraints() to set a min/max size for each axis (see "Demo-&gt;Child-&gt;Auto-resize with Constraints").
	/// - Size measurement for a given axis is only performed when the child window is within visible boundaries, or is just appearing.
	///   - This allows BeginChild() to return false when not within boundaries (e.g. when scrolling), which is more optimal. BUT it won't update its auto-size while clipped.
	///     While not perfect, it is a better default behavior as the always-on performance gain is more valuable than the occasional "resizing after becoming visible again" glitch.
	///   - You may also use ImGuiChildFlags_AlwaysAutoResize to force an update even when child window is not in view.
	///     HOWEVER PLEASE UNDERSTAND THAT DOING SO WILL PREVENT BeginChild() FROM EVER RETURNING FALSE, disabling benefits of coarse clipping.
	/// </summary>
	[Flags]
	public enum ImGuiChildFlags
	{
		None = 0,
		/// Show an outer border and enable WindowPadding. (IMPORTANT: this is always == 1 == true for legacy reason)
		Border = 1 << 0,
		/// Pad with style.WindowPadding even if no border are drawn (no padding by default for non-bordered child windows because it makes more sense)
		AlwaysUseWindowPadding = 1 << 1,
		/// Allow resize from right border (layout direction). Enable .ini saving (unless ImGuiWindowFlags_NoSavedSettings passed to window flags)
		ResizeX = 1 << 2,
		/// Allow resize from bottom border (layout direction). "
		ResizeY = 1 << 3,
		/// Enable auto-resizing width. Read "IMPORTANT: Size measurement" details above.
		AutoResizeX = 1 << 4,
		/// Enable auto-resizing height. Read "IMPORTANT: Size measurement" details above.
		AutoResizeY = 1 << 5,
		/// Combined with AutoResizeX/AutoResizeY. Always measure size even when child is hidden, always return true, always disable clipping optimization! NOT RECOMMENDED.
		AlwaysAutoResize = 1 << 6,
		/// Style the child window like a framed item: use FrameBg, FrameRounding, FrameBorderSize, FramePadding instead of ChildBg, ChildRounding, ChildBorderSize, WindowPadding.
		FrameStyle = 1 << 7,
	}

	/// <summary>
	/// Enumeration for PushStyleColor() / PopStyleColor()
	/// </summary>
	public enum ImGuiCol
	{
		Text = 0,
		TextDisabled = 1,
		/// Background of normal windows
		WindowBg = 2,
		/// Background of child windows
		ChildBg = 3,
		/// Background of popups, menus, tooltips windows
		PopupBg = 4,
		Border = 5,
		BorderShadow = 6,
		/// Background of checkbox, radio button, plot, slider, text input
		FrameBg = 7,
		FrameBgHovered = 8,
		FrameBgActive = 9,
		/// Title bar
		TitleBg = 10,
		/// Title bar when focused
		TitleBgActive = 11,
		/// Title bar when collapsed
		TitleBgCollapsed = 12,
		MenuBarBg = 13,
		ScrollbarBg = 14,
		ScrollbarGrab = 15,
		ScrollbarGrabHovered = 16,
		ScrollbarGrabActive = 17,
		/// Checkbox tick and RadioButton circle
		CheckMark = 18,
		SliderGrab = 19,
		SliderGrabActive = 20,
		Button = 21,
		ButtonHovered = 22,
		ButtonActive = 23,
		/// Header* colors are used for CollapsingHeader, TreeNode, Selectable, MenuItem
		Header = 24,
		HeaderHovered = 25,
		HeaderActive = 26,
		Separator = 27,
		SeparatorHovered = 28,
		SeparatorActive = 29,
		/// Resize grip in lower-right and lower-left corners of windows.
		ResizeGrip = 30,
		ResizeGripHovered = 31,
		ResizeGripActive = 32,
		/// TabItem in a TabBar
		Tab = 33,
		TabHovered = 34,
		TabActive = 35,
		TabUnfocused = 36,
		TabUnfocusedActive = 37,
		/// Preview overlay color when about to docking something
		DockingPreview = 38,
		/// Background color for empty node (e.g. CentralNode with no window docked into it)
		DockingEmptyBg = 39,
		PlotLines = 40,
		PlotLinesHovered = 41,
		PlotHistogram = 42,
		PlotHistogramHovered = 43,
		/// Table header background
		TableHeaderBg = 44,
		/// Table outer and header borders (prefer using Alpha=1.0 here)
		TableBorderStrong = 45,
		/// Table inner borders (prefer using Alpha=1.0 here)
		TableBorderLight = 46,
		/// Table row background (even rows)
		TableRowBg = 47,
		/// Table row background (odd rows)
		TableRowBgAlt = 48,
		TextSelectedBg = 49,
		/// Rectangle highlighting a drop target
		DragDropTarget = 50,
		/// Gamepad/keyboard: current highlighted item
		NavHighlight = 51,
		/// Highlight window when using CTRL+TAB
		NavWindowingHighlight = 52,
		/// Darken/colorize entire screen behind the CTRL+TAB window list, when active
		NavWindowingDimBg = 53,
		/// Darken/colorize entire screen behind a modal window, when one is active
		ModalWindowDimBg = 54,
		COUNT = 55,
	}

	/// <summary>
	/// Flags for ColorEdit3() / ColorEdit4() / ColorPicker3() / ColorPicker4() / ColorButton()
	/// </summary>
	[Flags]
	public enum ImGuiColorEditFlags
	{
		None = 0,
		///              // ColorEdit, ColorPicker, ColorButton: ignore Alpha component (will only read 3 components from the input pointer).
		NoAlpha = 1 << 1,
		///              // ColorEdit: disable picker when clicking on color square.
		NoPicker = 1 << 2,
		///              // ColorEdit: disable toggling options menu when right-clicking on inputs/small preview.
		NoOptions = 1 << 3,
		///              // ColorEdit, ColorPicker: disable color square preview next to the inputs. (e.g. to show only the inputs)
		NoSmallPreview = 1 << 4,
		///              // ColorEdit, ColorPicker: disable inputs sliders/text widgets (e.g. to show only the small preview color square).
		NoInputs = 1 << 5,
		///              // ColorEdit, ColorPicker, ColorButton: disable tooltip when hovering the preview.
		NoTooltip = 1 << 6,
		///              // ColorEdit, ColorPicker: disable display of inline text label (the label is still forwarded to the tooltip and picker).
		NoLabel = 1 << 7,
		///              // ColorPicker: disable bigger color preview on right side of the picker, use small color square preview instead.
		NoSidePreview = 1 << 8,
		///              // ColorEdit: disable drag and drop target. ColorButton: disable drag and drop source.
		NoDragDrop = 1 << 9,
		///              // ColorButton: disable border (which is enforced by default)
		NoBorder = 1 << 10,
		///              // ColorEdit, ColorPicker: show vertical alpha bar/gradient in picker.
		AlphaBar = 1 << 16,
		///              // ColorEdit, ColorPicker, ColorButton: display preview as a transparent color over a checkerboard, instead of opaque.
		AlphaPreview = 1 << 17,
		///              // ColorEdit, ColorPicker, ColorButton: display half opaque / half checkerboard, instead of opaque.
		AlphaPreviewHalf = 1 << 18,
		///              // (WIP) ColorEdit: Currently only disable 0.0f..1.0f limits in RGBA edition (note: you probably want to use ImGuiColorEditFlags_Float flag as well).
		HDR = 1 << 19,
		/// [Display]    // ColorEdit: override _display_ type among RGB/HSV/Hex. ColorPicker: select any combination using one or more of RGB/HSV/Hex.
		DisplayRGB = 1 << 20,
		/// [Display]    // "
		DisplayHSV = 1 << 21,
		/// [Display]    // "
		DisplayHex = 1 << 22,
		/// [DataType]   // ColorEdit, ColorPicker, ColorButton: _display_ values formatted as 0..255.
		Uint8 = 1 << 23,
		/// [DataType]   // ColorEdit, ColorPicker, ColorButton: _display_ values formatted as 0.0f..1.0f floats instead of 0..255 integers. No round-trip of value via integers.
		Float = 1 << 24,
		/// [Picker]     // ColorPicker: bar for Hue, rectangle for Sat/Value.
		PickerHueBar = 1 << 25,
		/// [Picker]     // ColorPicker: wheel for Hue, triangle for Sat/Value.
		PickerHueWheel = 1 << 26,
		/// [Input]      // ColorEdit, ColorPicker: input and output data in RGB format.
		InputRGB = 1 << 27,
		/// [Input]      // ColorEdit, ColorPicker: input and output data in HSV format.
		InputHSV = 1 << 28,
		DefaultOptions = ImGuiColorEditFlags.Uint8 | ImGuiColorEditFlags.DisplayRGB | ImGuiColorEditFlags.InputRGB | ImGuiColorEditFlags.PickerHueBar,
		DisplayMask = ImGuiColorEditFlags.DisplayRGB | ImGuiColorEditFlags.DisplayHSV | ImGuiColorEditFlags.DisplayHex,
		DataTypeMask = ImGuiColorEditFlags.Uint8 | ImGuiColorEditFlags.Float,
		PickerMask = ImGuiColorEditFlags.PickerHueWheel | ImGuiColorEditFlags.PickerHueBar,
		InputMask = ImGuiColorEditFlags.InputRGB | ImGuiColorEditFlags.InputHSV,
	}

	/// <summary>
	/// Flags for ImGui::BeginCombo()
	/// </summary>
	[Flags]
	public enum ImGuiComboFlags
	{
		None = 0,
		/// Align the popup toward the left by default
		PopupAlignLeft = 1 << 0,
		/// Max ~4 items visible. Tip: If you want your combo popup to be a specific size you can use SetNextWindowSizeConstraints() prior to calling BeginCombo()
		HeightSmall = 1 << 1,
		/// Max ~8 items visible (default)
		HeightRegular = 1 << 2,
		/// Max ~20 items visible
		HeightLarge = 1 << 3,
		/// As many fitting items as possible
		HeightLargest = 1 << 4,
		/// Display on the preview box without the square arrow button
		NoArrowButton = 1 << 5,
		/// Display only a square arrow button
		NoPreview = 1 << 6,
		/// Width dynamically calculated from preview contents
		WidthFitPreview = 1 << 7,
		HeightMask = ImGuiComboFlags.HeightSmall | ImGuiComboFlags.HeightRegular | ImGuiComboFlags.HeightLarge | ImGuiComboFlags.HeightLargest,
	}

	/// <summary>
	/// Enumeration for ImGui::SetNextWindow***(), SetWindow***(), SetNextItem***() functions
	/// Represent a condition.
	/// Important: Treat as a regular enum! Do NOT combine multiple values using binary operators! All the functions above treat 0 as a shortcut to ImGuiCond_Always.
	/// </summary>
	public enum ImGuiCond
	{
		/// No condition (always set the variable), same as _Always
		None = 0,
		/// No condition (always set the variable), same as _None
		Always = 1 << 0,
		/// Set the variable once per runtime session (only the first call will succeed)
		Once = 1 << 1,
		/// Set the variable if the object/window has no persistently saved data (no entry in .ini file)
		FirstUseEver = 1 << 2,
		/// Set the variable if the object/window is appearing after being hidden/inactive (or the first time)
		Appearing = 1 << 3,
	}

	/// <summary>
	/// Configuration flags stored in io.ConfigFlags. Set by user/application.
	/// </summary>
	[Flags]
	public enum ImGuiConfigFlags
	{
		None = 0,
		/// Master keyboard navigation enable flag. Enable full Tabbing + directional arrows + space/enter to activate.
		NavEnableKeyboard = 1 << 0,
		/// Master gamepad navigation enable flag. Backend also needs to set ImGuiBackendFlags_HasGamepad.
		NavEnableGamepad = 1 << 1,
		/// Instruct navigation to move the mouse cursor. May be useful on TV/console systems where moving a virtual mouse is awkward. Will update io.MousePos and set io.WantSetMousePos=true. If enabled you MUST honor io.WantSetMousePos requests in your backend, otherwise ImGui will react as if the mouse is jumping around back and forth.
		NavEnableSetMousePos = 1 << 2,
		/// Instruct navigation to not set the io.WantCaptureKeyboard flag when io.NavActive is set.
		NavNoCaptureKeyboard = 1 << 3,
		/// Instruct imgui to clear mouse position/buttons in NewFrame(). This allows ignoring the mouse information set by the backend.
		NoMouse = 1 << 4,
		/// Instruct backend to not alter mouse cursor shape and visibility. Use if the backend cursor changes are interfering with yours and you don't want to use SetMouseCursor() to change mouse cursor. You may want to honor requests from imgui by reading GetMouseCursor() yourself instead.
		NoMouseCursorChange = 1 << 5,
		/// Docking enable flags.
		DockingEnable = 1 << 6,
		/// Viewport enable flags (require both ImGuiBackendFlags_PlatformHasViewports + ImGuiBackendFlags_RendererHasViewports set by the respective backends)
		ViewportsEnable = 1 << 10,
		/// [BETA: Don't use] FIXME-DPI: Reposition and resize imgui windows when the DpiScale of a viewport changed (mostly useful for the main viewport hosting other window). Note that resizing the main window itself is up to your application.
		DpiEnableScaleViewports = 1 << 14,
		/// [BETA: Don't use] FIXME-DPI: Request bitmap-scaled fonts to match DpiScale. This is a very low-quality workaround. The correct way to handle DPI is _currently_ to replace the atlas and/or fonts in the Platform_OnChangedViewport callback, but this is all early work in progress.
		DpiEnableScaleFonts = 1 << 15,
		/// Application is SRGB-aware.
		IsSRGB = 1 << 20,
		/// Application is using a touch screen instead of a mouse.
		IsTouchScreen = 1 << 21,
	}

	/// <summary>
	/// A primary data type
	/// </summary>
	public enum ImGuiDataType
	{
		/// signed char / char (with sensible compilers)
		S8 = 0,
		/// unsigned char
		U8 = 1,
		/// short
		S16 = 2,
		/// unsigned short
		U16 = 3,
		/// int
		S32 = 4,
		/// unsigned int
		U32 = 5,
		/// long long / __int64
		S64 = 6,
		/// unsigned long long / unsigned __int64
		U64 = 7,
		/// float
		Float = 8,
		/// double
		Double = 9,
		COUNT = 10,
	}

	/// <summary>
	/// A cardinal direction
	/// </summary>
	public enum ImGuiDir
	{
		None = -1,
		Left = 0,
		Right = 1,
		Up = 2,
		Down = 3,
		COUNT = 4,
	}

	/// <summary>
	/// Flags for ImGui::DockSpace(), shared/inherited by child nodes.
	/// (Some flags can be applied to individual nodes directly)
	/// FIXME-DOCK: Also see ImGuiDockNodeFlagsPrivate_ which may involve using the WIP and internal DockBuilder api.
	/// </summary>
	[Flags]
	public enum ImGuiDockNodeFlags
	{
		None = 0,
		///       // Don't display the dockspace node but keep it alive. Windows docked into this dockspace node won't be undocked.
		KeepAliveOnly = 1 << 0,
		///       // Disable docking over the Central Node, which will be always kept empty.
		NoDockingOverCentralNode = 1 << 2,
		///       // Enable passthru dockspace: 1) DockSpace() will render a ImGuiCol_WindowBg background covering everything excepted the Central Node when empty. Meaning the host window should probably use SetNextWindowBgAlpha(0.0f) prior to Begin() when using this. 2) When Central Node is empty: let inputs pass-through + won't display a DockingEmptyBg background. See demo for details.
		PassthruCentralNode = 1 << 3,
		///       // Disable other windows/nodes from splitting this node.
		NoDockingSplit = 1 << 4,
		/// Saved // Disable resizing node using the splitter/separators. Useful with programmatically setup dockspaces.
		NoResize = 1 << 5,
		///       // Tab bar will automatically hide when there is a single window in the dock node.
		AutoHideTabBar = 1 << 6,
		///       // Disable undocking this node.
		NoUndocking = 1 << 7,
	}

	/// <summary>
	/// Flags for ImGui::BeginDragDropSource(), ImGui::AcceptDragDropPayload()
	/// </summary>
	[Flags]
	public enum ImGuiDragDropFlags
	{
		None = 0,
		/// Disable preview tooltip. By default, a successful call to BeginDragDropSource opens a tooltip so you can display a preview or description of the source contents. This flag disables this behavior.
		SourceNoPreviewTooltip = 1 << 0,
		/// By default, when dragging we clear data so that IsItemHovered() will return false, to avoid subsequent user code submitting tooltips. This flag disables this behavior so you can still call IsItemHovered() on the source item.
		SourceNoDisableHover = 1 << 1,
		/// Disable the behavior that allows to open tree nodes and collapsing header by holding over them while dragging a source item.
		SourceNoHoldToOpenOthers = 1 << 2,
		/// Allow items such as Text(), Image() that have no unique identifier to be used as drag source, by manufacturing a temporary identifier based on their window-relative position. This is extremely unusual within the dear imgui ecosystem and so we made it explicit.
		SourceAllowNullID = 1 << 3,
		/// External source (from outside of dear imgui), won't attempt to read current item/window info. Will always return true. Only one Extern source can be active simultaneously.
		SourceExtern = 1 << 4,
		/// Automatically expire the payload if the source cease to be submitted (otherwise payloads are persisting while being dragged)
		SourceAutoExpirePayload = 1 << 5,
		/// AcceptDragDropPayload() will returns true even before the mouse button is released. You can then call IsDelivery() to test if the payload needs to be delivered.
		AcceptBeforeDelivery = 1 << 10,
		/// Do not draw the default highlight rectangle when hovering over target.
		AcceptNoDrawDefaultRect = 1 << 11,
		/// Request hiding the BeginDragDropSource tooltip from the BeginDragDropTarget site.
		AcceptNoPreviewTooltip = 1 << 12,
		/// For peeking ahead and inspecting the payload before delivery.
		AcceptPeekOnly = ImGuiDragDropFlags.AcceptBeforeDelivery | ImGuiDragDropFlags.AcceptNoDrawDefaultRect,
	}

	/// <summary>
	/// Flags for ImGui::IsWindowFocused()
	/// </summary>
	[Flags]
	public enum ImGuiFocusedFlags
	{
		None = 0,
		/// Return true if any children of the window is focused
		ChildWindows = 1 << 0,
		/// Test from root window (top most parent of the current hierarchy)
		RootWindow = 1 << 1,
		/// Return true if any window is focused. Important: If you are trying to tell how to dispatch your low-level inputs, do NOT use this. Use 'io.WantCaptureMouse' instead! Please read the FAQ!
		AnyWindow = 1 << 2,
		/// Do not consider popup hierarchy (do not treat popup emitter as parent of popup) (when used with _ChildWindows or _RootWindow)
		NoPopupHierarchy = 1 << 3,
		/// Consider docking hierarchy (treat dockspace host as parent of docked window) (when used with _ChildWindows or _RootWindow)
		DockHierarchy = 1 << 4,
		RootAndChildWindows = ImGuiFocusedFlags.RootWindow | ImGuiFocusedFlags.ChildWindows,
	}

	/// <summary>
	/// Flags for ImGui::IsItemHovered(), ImGui::IsWindowHovered()
	/// Note: if you are trying to check whether your mouse should be dispatched to Dear ImGui or to your app, you should use 'io.WantCaptureMouse' instead! Please read the FAQ!
	/// Note: windows with the ImGuiWindowFlags_NoInputs flag are ignored by IsWindowHovered() calls.
	/// </summary>
	[Flags]
	public enum ImGuiHoveredFlags
	{
		/// Return true if directly over the item/window, not obstructed by another window, not obstructed by an active popup or modal blocking inputs under them.
		None = 0,
		/// IsWindowHovered() only: Return true if any children of the window is hovered
		ChildWindows = 1 << 0,
		/// IsWindowHovered() only: Test from root window (top most parent of the current hierarchy)
		RootWindow = 1 << 1,
		/// IsWindowHovered() only: Return true if any window is hovered
		AnyWindow = 1 << 2,
		/// IsWindowHovered() only: Do not consider popup hierarchy (do not treat popup emitter as parent of popup) (when used with _ChildWindows or _RootWindow)
		NoPopupHierarchy = 1 << 3,
		/// IsWindowHovered() only: Consider docking hierarchy (treat dockspace host as parent of docked window) (when used with _ChildWindows or _RootWindow)
		DockHierarchy = 1 << 4,
		/// Return true even if a popup window is normally blocking access to this item/window
		AllowWhenBlockedByPopup = 1 << 5,
		/// Return true even if an active item is blocking access to this item/window. Useful for Drag and Drop patterns.
		AllowWhenBlockedByActiveItem = 1 << 7,
		/// IsItemHovered() only: Return true even if the item uses AllowOverlap mode and is overlapped by another hoverable item.
		AllowWhenOverlappedByItem = 1 << 8,
		/// IsItemHovered() only: Return true even if the position is obstructed or overlapped by another window.
		AllowWhenOverlappedByWindow = 1 << 9,
		/// IsItemHovered() only: Return true even if the item is disabled
		AllowWhenDisabled = 1 << 10,
		/// IsItemHovered() only: Disable using gamepad/keyboard navigation state when active, always query mouse
		NoNavOverride = 1 << 11,
		AllowWhenOverlapped = ImGuiHoveredFlags.AllowWhenOverlappedByItem | ImGuiHoveredFlags.AllowWhenOverlappedByWindow,
		RectOnly = ImGuiHoveredFlags.AllowWhenBlockedByPopup | ImGuiHoveredFlags.AllowWhenBlockedByActiveItem | ImGuiHoveredFlags.AllowWhenOverlapped,
		RootAndChildWindows = ImGuiHoveredFlags.RootWindow | ImGuiHoveredFlags.ChildWindows,
		/// Shortcut for standard flags when using IsItemHovered() + SetTooltip() sequence.
		ForTooltip = 1 << 12,
		/// Require mouse to be stationary for style.HoverStationaryDelay (~0.15 sec) _at least one time_. After this, can move on same item/window. Using the stationary test tends to reduces the need for a long delay.
		Stationary = 1 << 13,
		/// IsItemHovered() only: Return true immediately (default). As this is the default you generally ignore this.
		DelayNone = 1 << 14,
		/// IsItemHovered() only: Return true after style.HoverDelayShort elapsed (~0.15 sec) (shared between items) + requires mouse to be stationary for style.HoverStationaryDelay (once per item).
		DelayShort = 1 << 15,
		/// IsItemHovered() only: Return true after style.HoverDelayNormal elapsed (~0.40 sec) (shared between items) + requires mouse to be stationary for style.HoverStationaryDelay (once per item).
		DelayNormal = 1 << 16,
		/// IsItemHovered() only: Disable shared delay system where moving from one item to the next keeps the previous timer for a short time (standard for tooltips with long delays)
		NoSharedDelay = 1 << 17,
	}

	/// <summary>
	/// Flags for ImGui::InputText()
	/// (Those are per-item flags. There are shared flags in ImGuiIO: io.ConfigInputTextCursorBlink and io.ConfigInputTextEnterKeepActive)
	/// </summary>
	[Flags]
	public enum ImGuiInputTextFlags
	{
		None = 0,
		/// Allow 0123456789.+-*/
		CharsDecimal = 1 << 0,
		/// Allow 0123456789ABCDEFabcdef
		CharsHexadecimal = 1 << 1,
		/// Turn a..z into A..Z
		CharsUppercase = 1 << 2,
		/// Filter out spaces, tabs
		CharsNoBlank = 1 << 3,
		/// Select entire text when first taking mouse focus
		AutoSelectAll = 1 << 4,
		/// Return 'true' when Enter is pressed (as opposed to every time the value was modified). Consider looking at the IsItemDeactivatedAfterEdit() function.
		EnterReturnsTrue = 1 << 5,
		/// Callback on pressing TAB (for completion handling)
		CallbackCompletion = 1 << 6,
		/// Callback on pressing Up/Down arrows (for history handling)
		CallbackHistory = 1 << 7,
		/// Callback on each iteration. User code may query cursor position, modify text buffer.
		CallbackAlways = 1 << 8,
		/// Callback on character inputs to replace or discard them. Modify 'EventChar' to replace or discard, or return 1 in callback to discard.
		CallbackCharFilter = 1 << 9,
		/// Pressing TAB input a '\t' character into the text field
		AllowTabInput = 1 << 10,
		/// In multi-line mode, unfocus with Enter, add new line with Ctrl+Enter (default is opposite: unfocus with Ctrl+Enter, add line with Enter).
		CtrlEnterForNewLine = 1 << 11,
		/// Disable following the cursor horizontally
		NoHorizontalScroll = 1 << 12,
		/// Overwrite mode
		AlwaysOverwrite = 1 << 13,
		/// Read-only mode
		ReadOnly = 1 << 14,
		/// Password mode, display all characters as '*'
		Password = 1 << 15,
		/// Disable undo/redo. Note that input text owns the text data while active, if you want to provide your own undo/redo stack you need e.g. to call ClearActiveID().
		NoUndoRedo = 1 << 16,
		/// Allow 0123456789.+-*/eE (Scientific notation input)
		CharsScientific = 1 << 17,
		/// Callback on buffer capacity changes request (beyond 'buf_size' parameter value), allowing the string to grow. Notify when the string wants to be resized (for string types which hold a cache of their Size). You will be provided a new BufSize in the callback and NEED to honor it. (see misc/cpp/imgui_stdlib.h for an example of using this)
		CallbackResize = 1 << 18,
		/// Callback on any edit (note that InputText() already returns true on edit, the callback is useful mainly to manipulate the underlying buffer while focus is active)
		CallbackEdit = 1 << 19,
		/// Escape key clears content if not empty, and deactivate otherwise (contrast to default behavior of Escape to revert)
		EscapeClearsAll = 1 << 20,
	}

	/// <summary>
	/// A key identifier (ImGuiKey_XXX or ImGuiMod_XXX value): can represent Keyboard, Mouse and Gamepad values.
	/// All our named keys are &gt;= 512. Keys value 0 to 511 are left unused as legacy native/opaque key values (&lt; 1.87).
	/// Since &gt;= 1.89 we increased typing (went from int to enum), some legacy code may need a cast to ImGuiKey.
	/// Read details about the 1.87 and 1.89 transition : https:	///github.com/ocornut/imgui/issues/4921
	/// Note that "Keys" related to physical keys and are not the same concept as input "Characters", the later are submitted via io.AddInputCharacter().
	/// The keyboard key enum values are named after the keys on a standard US keyboard, and on other keyboard types the keys reported may not match the keycaps.
	/// </summary>
	public enum ImGuiKey : int
	{
		None = 0,
		/// == ImGuiKey_NamedKey_BEGIN
		Tab = 512,
		LeftArrow = 513,
		RightArrow = 514,
		UpArrow = 515,
		DownArrow = 516,
		PageUp = 517,
		PageDown = 518,
		Home = 519,
		End = 520,
		Insert = 521,
		Delete = 522,
		Backspace = 523,
		Space = 524,
		Enter = 525,
		Escape = 526,
		LeftCtrl = 527,
		LeftShift = 528,
		LeftAlt = 529,
		LeftSuper = 530,
		RightCtrl = 531,
		RightShift = 532,
		RightAlt = 533,
		RightSuper = 534,
		Menu = 535,
		No0 = 536,
		No1 = 537,
		No2 = 538,
		No3 = 539,
		No4 = 540,
		No5 = 541,
		No6 = 542,
		No7 = 543,
		No8 = 544,
		No9 = 545,
		A = 546,
		B = 547,
		C = 548,
		D = 549,
		E = 550,
		F = 551,
		G = 552,
		H = 553,
		I = 554,
		J = 555,
		K = 556,
		L = 557,
		M = 558,
		N = 559,
		O = 560,
		P = 561,
		Q = 562,
		R = 563,
		S = 564,
		T = 565,
		U = 566,
		V = 567,
		W = 568,
		X = 569,
		Y = 570,
		Z = 571,
		F1 = 572,
		F2 = 573,
		F3 = 574,
		F4 = 575,
		F5 = 576,
		F6 = 577,
		F7 = 578,
		F8 = 579,
		F9 = 580,
		F10 = 581,
		F11 = 582,
		F12 = 583,
		F13 = 584,
		F14 = 585,
		F15 = 586,
		F16 = 587,
		F17 = 588,
		F18 = 589,
		F19 = 590,
		F20 = 591,
		F21 = 592,
		F22 = 593,
		F23 = 594,
		F24 = 595,
		/// '
		Apostrophe = 596,
		/// ,
		Comma = 597,
		/// -
		Minus = 598,
		/// .
		Period = 599,
		/// /
		Slash = 600,
		/// ;
		Semicolon = 601,
		/// =
		Equal = 602,
		/// [
		LeftBracket = 603,
		/// \ (this text inhibit multiline comment caused by backslash)
		Backslash = 604,
		/// ]
		RightBracket = 605,
		/// `
		GraveAccent = 606,
		CapsLock = 607,
		ScrollLock = 608,
		NumLock = 609,
		PrintScreen = 610,
		Pause = 611,
		Keypad0 = 612,
		Keypad1 = 613,
		Keypad2 = 614,
		Keypad3 = 615,
		Keypad4 = 616,
		Keypad5 = 617,
		Keypad6 = 618,
		Keypad7 = 619,
		Keypad8 = 620,
		Keypad9 = 621,
		KeypadDecimal = 622,
		KeypadDivide = 623,
		KeypadMultiply = 624,
		KeypadSubtract = 625,
		KeypadAdd = 626,
		KeypadEnter = 627,
		KeypadEqual = 628,
		/// Available on some keyboard/mouses. Often referred as "Browser Back"
		AppBack = 629,
		AppForward = 630,
		/// Menu (Xbox)      + (Switch)   Start/Options (PS)
		GamepadStart = 631,
		/// View (Xbox)      - (Switch)   Share (PS)
		GamepadBack = 632,
		/// X (Xbox)         Y (Switch)   Square (PS)        // Tap: Toggle Menu. Hold: Windowing mode (Focus/Move/Resize windows)
		GamepadFaceLeft = 633,
		/// B (Xbox)         A (Switch)   Circle (PS)        // Cancel / Close / Exit
		GamepadFaceRight = 634,
		/// Y (Xbox)         X (Switch)   Triangle (PS)      // Text Input / On-screen Keyboard
		GamepadFaceUp = 635,
		/// A (Xbox)         B (Switch)   Cross (PS)         // Activate / Open / Toggle / Tweak
		GamepadFaceDown = 636,
		/// D-pad Left                                       // Move / Tweak / Resize Window (in Windowing mode)
		GamepadDpadLeft = 637,
		/// D-pad Right                                      // Move / Tweak / Resize Window (in Windowing mode)
		GamepadDpadRight = 638,
		/// D-pad Up                                         // Move / Tweak / Resize Window (in Windowing mode)
		GamepadDpadUp = 639,
		/// D-pad Down                                       // Move / Tweak / Resize Window (in Windowing mode)
		GamepadDpadDown = 640,
		/// L Bumper (Xbox)  L (Switch)   L1 (PS)            // Tweak Slower / Focus Previous (in Windowing mode)
		GamepadL1 = 641,
		/// R Bumper (Xbox)  R (Switch)   R1 (PS)            // Tweak Faster / Focus Next (in Windowing mode)
		GamepadR1 = 642,
		/// L Trig. (Xbox)   ZL (Switch)  L2 (PS) [Analog]
		GamepadL2 = 643,
		/// R Trig. (Xbox)   ZR (Switch)  R2 (PS) [Analog]
		GamepadR2 = 644,
		/// L Stick (Xbox)   L3 (Switch)  L3 (PS)
		GamepadL3 = 645,
		/// R Stick (Xbox)   R3 (Switch)  R3 (PS)
		GamepadR3 = 646,
		/// [Analog]                                         // Move Window (in Windowing mode)
		GamepadLStickLeft = 647,
		/// [Analog]                                         // Move Window (in Windowing mode)
		GamepadLStickRight = 648,
		/// [Analog]                                         // Move Window (in Windowing mode)
		GamepadLStickUp = 649,
		/// [Analog]                                         // Move Window (in Windowing mode)
		GamepadLStickDown = 650,
		/// [Analog]
		GamepadRStickLeft = 651,
		/// [Analog]
		GamepadRStickRight = 652,
		/// [Analog]
		GamepadRStickUp = 653,
		/// [Analog]
		GamepadRStickDown = 654,
		MouseLeft = 655,
		MouseRight = 656,
		MouseMiddle = 657,
		MouseX1 = 658,
		MouseX2 = 659,
		MouseWheelX = 660,
		MouseWheelY = 661,
		ReservedForModCtrl = 662,
		ReservedForModShift = 663,
		ReservedForModAlt = 664,
		ReservedForModSuper = 665,
		COUNT = 666,
	}

	/// <summary>
	/// Identify a mouse button.
	/// Those values are guaranteed to be stable and we frequently use 0/1 directly. Named enums provided for convenience.
	/// </summary>
	public enum ImGuiMouseButton
	{
		Left = 0,
		Right = 1,
		Middle = 2,
		COUNT = 5,
	}

	/// <summary>
	/// Enumeration for GetMouseCursor()
	/// User code may request backend to display given cursor by calling SetMouseCursor(), which is why we have some cursors that are marked unused here
	/// </summary>
	public enum ImGuiMouseCursor
	{
		None = -1,
		Arrow = 0,
		/// When hovering over InputText, etc.
		TextInput = 1,
		/// (Unused by Dear ImGui functions)
		ResizeAll = 2,
		/// When hovering over a horizontal border
		ResizeNS = 3,
		/// When hovering over a vertical border or a column
		ResizeEW = 4,
		/// When hovering over the bottom-left corner of a window
		ResizeNESW = 5,
		/// When hovering over the bottom-right corner of a window
		ResizeNWSE = 6,
		/// (Unused by Dear ImGui functions. Use for e.g. hyperlinks)
		Hand = 7,
		/// When hovering something with disallowed interaction. Usually a crossed circle.
		NotAllowed = 8,
		COUNT = 9,
	}

	/// <summary>
	/// Enumeration for AddMouseSourceEvent() actual source of Mouse Input data.
	/// Historically we use "Mouse" terminology everywhere to indicate pointer data, e.g. MousePos, IsMousePressed(), io.AddMousePosEvent()
	/// But that "Mouse" data can come from different source which occasionally may be useful for application to know about.
	/// You can submit a change of pointer type using io.AddMouseSourceEvent().
	/// </summary>
	public enum ImGuiMouseSource : int
	{
		/// Input is coming from an actual mouse.
		Mouse = 0,
		/// Input is coming from a touch screen (no hovering prior to initial press, less precise initial press aiming, dual-axis wheeling possible).
		TouchScreen = 1,
		/// Input is coming from a pressure/magnetic pen (often used in conjunction with high-sampling rates).
		Pen = 2,
		COUNT = 3,
	}

	/// <summary>
	/// Flags for OpenPopup*(), BeginPopupContext*(), IsPopupOpen() functions.
	/// - To be backward compatible with older API which took an 'int mouse_button = 1' argument instead of 'ImGuiPopupFlags flags',
	///   we need to treat small flags values as a mouse button index, so we encode the mouse button in the first few bits of the flags.
	///   It is therefore guaranteed to be legal to pass a mouse button index in ImGuiPopupFlags.
	/// - For the same reason, we exceptionally default the ImGuiPopupFlags argument of BeginPopupContextXXX functions to 1 instead of 0.
	///   IMPORTANT: because the default parameter is 1 (==ImGuiPopupFlags_MouseButtonRight), if you rely on the default parameter
	///   and want to use another flag, you need to pass in the ImGuiPopupFlags_MouseButtonRight flag explicitly.
	/// - Multiple buttons currently cannot be combined/or-ed in those functions (we could allow it later).
	/// </summary>
	[Flags]
	public enum ImGuiPopupFlags
	{
		None = 0,
		/// For BeginPopupContext*(): open on Left Mouse release. Guaranteed to always be == 0 (same as ImGuiMouseButton_Left)
		MouseButtonLeft = 0,
		/// For BeginPopupContext*(): open on Right Mouse release. Guaranteed to always be == 1 (same as ImGuiMouseButton_Right)
		MouseButtonRight = 1,
		/// For BeginPopupContext*(): open on Middle Mouse release. Guaranteed to always be == 2 (same as ImGuiMouseButton_Middle)
		MouseButtonMiddle = 2,
		MouseButtonMask = 0x1F,
		MouseButtonDefault = 1,
		/// For OpenPopup*(), BeginPopupContext*(): don't reopen same popup if already open (won't reposition, won't reinitialize navigation)
		NoReopen = 1 << 5,
		/// For OpenPopup*(), BeginPopupContext*(): don't open if there's already a popup at the same level of the popup stack
		NoOpenOverExistingPopup = 1 << 7,
		/// For BeginPopupContextWindow(): don't return true when hovering items, only when hovering empty space
		NoOpenOverItems = 1 << 8,
		/// For IsPopupOpen(): ignore the ImGuiID parameter and test for any popup.
		AnyPopupId = 1 << 10,
		/// For IsPopupOpen(): search/test at any level of the popup stack (default test in the current level)
		AnyPopupLevel = 1 << 11,
		AnyPopup = ImGuiPopupFlags.AnyPopupId | ImGuiPopupFlags.AnyPopupLevel,
	}

	/// <summary>
	/// Flags for ImGui::Selectable()
	/// </summary>
	[Flags]
	public enum ImGuiSelectableFlags
	{
		None = 0,
		/// Clicking this doesn't close parent popup window
		DontClosePopups = 1 << 0,
		/// Frame will span all columns of its container table (text will still fit in current column)
		SpanAllColumns = 1 << 1,
		/// Generate press events on double clicks too
		AllowDoubleClick = 1 << 2,
		/// Cannot be selected, display grayed out text
		Disabled = 1 << 3,
		/// (WIP) Hit testing to allow subsequent widgets to overlap this one
		AllowOverlap = 1 << 4,
	}

	/// <summary>
	/// Flags for DragFloat(), DragInt(), SliderFloat(), SliderInt() etc.
	/// We use the same sets of flags for DragXXX() and SliderXXX() functions as the features are the same and it makes it easier to swap them.
	/// (Those are per-item flags. There are shared flags in ImGuiIO: io.ConfigDragClickToInputText)
	/// </summary>
	[Flags]
	public enum ImGuiSliderFlags
	{
		None = 0,
		/// Clamp value to min/max bounds when input manually with CTRL+Click. By default CTRL+Click allows going out of bounds.
		AlwaysClamp = 1 << 4,
		/// Make the widget logarithmic (linear otherwise). Consider using ImGuiSliderFlags_NoRoundToFormat with this if using a format-string with small amount of digits.
		Logarithmic = 1 << 5,
		/// Disable rounding underlying value to match precision of the display format string (e.g. %.3f values are rounded to those 3 digits)
		NoRoundToFormat = 1 << 6,
		/// Disable CTRL+Click or Enter key allowing to input text directly into the widget
		NoInput = 1 << 7,
		/// [Internal] We treat using those bits as being potentially a 'float power' argument from the previous API that has got miscast to this enum, and will trigger an assert if needed.
		InvalidMask = 0x7000000F,
	}

	/// <summary>
	/// A sorting direction
	/// </summary>
	public enum ImGuiSortDirection
	{
		None = 0,
		/// Ascending = 0-&gt;9, A-&gt;Z etc.
		Ascending = 1,
		/// Descending = 9-&gt;0, Z-&gt;A etc.
		Descending = 2,
	}

	/// <summary>
	/// Enumeration for PushStyleVar() / PopStyleVar() to temporarily modify the ImGuiStyle structure.
	/// - The enum only refers to fields of ImGuiStyle which makes sense to be pushed/popped inside UI code.
	///   During initialization or between frames, feel free to just poke into ImGuiStyle directly.
	/// - Tip: Use your programming IDE navigation facilities on the names in the _second column_ below to find the actual members and their description.
	///   In Visual Studio IDE: CTRL+comma ("Edit.GoToAll") can follow symbols in comments, whereas CTRL+F12 ("Edit.GoToImplementation") cannot.
	///   With Visual Assist installed: ALT+G ("VAssistX.GoToImplementation") can also follow symbols in comments.
	/// - When changing this enum, you need to update the associated internal table GStyleVarInfo[] accordingly. This is where we link enum values to members offset/type.
	/// </summary>
	public enum ImGuiStyleVar
	{
		/// float     Alpha
		Alpha = 0,
		/// float     DisabledAlpha
		DisabledAlpha = 1,
		/// ImVec2    WindowPadding
		WindowPadding = 2,
		/// float     WindowRounding
		WindowRounding = 3,
		/// float     WindowBorderSize
		WindowBorderSize = 4,
		/// ImVec2    WindowMinSize
		WindowMinSize = 5,
		/// ImVec2    WindowTitleAlign
		WindowTitleAlign = 6,
		/// float     ChildRounding
		ChildRounding = 7,
		/// float     ChildBorderSize
		ChildBorderSize = 8,
		/// float     PopupRounding
		PopupRounding = 9,
		/// float     PopupBorderSize
		PopupBorderSize = 10,
		/// ImVec2    FramePadding
		FramePadding = 11,
		/// float     FrameRounding
		FrameRounding = 12,
		/// float     FrameBorderSize
		FrameBorderSize = 13,
		/// ImVec2    ItemSpacing
		ItemSpacing = 14,
		/// ImVec2    ItemInnerSpacing
		ItemInnerSpacing = 15,
		/// float     IndentSpacing
		IndentSpacing = 16,
		/// ImVec2    CellPadding
		CellPadding = 17,
		/// float     ScrollbarSize
		ScrollbarSize = 18,
		/// float     ScrollbarRounding
		ScrollbarRounding = 19,
		/// float     GrabMinSize
		GrabMinSize = 20,
		/// float     GrabRounding
		GrabRounding = 21,
		/// float     TabRounding
		TabRounding = 22,
		/// float     TabBarBorderSize
		TabBarBorderSize = 23,
		/// ImVec2    ButtonTextAlign
		ButtonTextAlign = 24,
		/// ImVec2    SelectableTextAlign
		SelectableTextAlign = 25,
		/// float  SeparatorTextBorderSize
		SeparatorTextBorderSize = 26,
		/// ImVec2    SeparatorTextAlign
		SeparatorTextAlign = 27,
		/// ImVec2    SeparatorTextPadding
		SeparatorTextPadding = 28,
		/// float     DockingSeparatorSize
		DockingSeparatorSize = 29,
		COUNT = 30,
	}

	/// <summary>
	/// Flags for ImGui::BeginTabBar()
	/// </summary>
	[Flags]
	public enum ImGuiTabBarFlags
	{
		None = 0,
		/// Allow manually dragging tabs to re-order them + New tabs are appended at the end of list
		Reorderable = 1 << 0,
		/// Automatically select new tabs when they appear
		AutoSelectNewTabs = 1 << 1,
		/// Disable buttons to open the tab list popup
		TabListPopupButton = 1 << 2,
		/// Disable behavior of closing tabs (that are submitted with p_open != NULL) with middle mouse button. You may handle this behavior manually on user's side with if (IsItemHovered() && IsMouseClicked(2)) *p_open = false.
		NoCloseWithMiddleMouseButton = 1 << 3,
		/// Disable scrolling buttons (apply when fitting policy is ImGuiTabBarFlags_FittingPolicyScroll)
		NoTabListScrollingButtons = 1 << 4,
		/// Disable tooltips when hovering a tab
		NoTooltip = 1 << 5,
		/// Resize tabs when they don't fit
		FittingPolicyResizeDown = 1 << 6,
		/// Add scroll buttons when tabs don't fit
		FittingPolicyScroll = 1 << 7,
		FittingPolicyMask = ImGuiTabBarFlags.FittingPolicyResizeDown | ImGuiTabBarFlags.FittingPolicyScroll,
		FittingPolicyDefault = ImGuiTabBarFlags.FittingPolicyResizeDown,
	}

	/// <summary>
	/// Flags for ImGui::BeginTabItem()
	/// </summary>
	[Flags]
	public enum ImGuiTabItemFlags
	{
		None = 0,
		/// Display a dot next to the title + set ImGuiTabItemFlags_NoAssumedClosure.
		UnsavedDocument = 1 << 0,
		/// Trigger flag to programmatically make the tab selected when calling BeginTabItem()
		SetSelected = 1 << 1,
		/// Disable behavior of closing tabs (that are submitted with p_open != NULL) with middle mouse button. You may handle this behavior manually on user's side with if (IsItemHovered() && IsMouseClicked(2)) *p_open = false.
		NoCloseWithMiddleMouseButton = 1 << 2,
		/// Don't call PushID()/PopID() on BeginTabItem()/EndTabItem()
		NoPushId = 1 << 3,
		/// Disable tooltip for the given tab
		NoTooltip = 1 << 4,
		/// Disable reordering this tab or having another tab cross over this tab
		NoReorder = 1 << 5,
		/// Enforce the tab position to the left of the tab bar (after the tab list popup button)
		Leading = 1 << 6,
		/// Enforce the tab position to the right of the tab bar (before the scrolling buttons)
		Trailing = 1 << 7,
		/// Tab is selected when trying to close + closure is not immediately assumed (will wait for user to stop submitting the tab). Otherwise closure is assumed when pressing the X, so if you keep submitting the tab may reappear at end of tab bar.
		NoAssumedClosure = 1 << 8,
	}

	/// <summary>
	/// Enum for ImGui::TableSetBgColor()
	/// Background colors are rendering in 3 layers:
	///  - Layer 0: draw with RowBg0 color if set, otherwise draw with ColumnBg0 if set.
	///  - Layer 1: draw with RowBg1 color if set, otherwise draw with ColumnBg1 if set.
	///  - Layer 2: draw with CellBg color if set.
	/// The purpose of the two row/columns layers is to let you decide if a background color change should override or blend with the existing color.
	/// When using ImGuiTableFlags_RowBg on the table, each row has the RowBg0 color automatically set for odd/even rows.
	/// If you set the color of RowBg0 target, your color will override the existing RowBg0 color.
	/// If you set the color of RowBg1 or ColumnBg1 target, your color will blend over the RowBg0 color.
	/// </summary>
	public enum ImGuiTableBgTarget
	{
		None = 0,
		/// Set row background color 0 (generally used for background, automatically set when ImGuiTableFlags_RowBg is used)
		RowBg0 = 1,
		/// Set row background color 1 (generally used for selection marking)
		RowBg1 = 2,
		/// Set cell background color (top-most color)
		CellBg = 3,
	}

	/// <summary>
	/// Flags for ImGui::TableSetupColumn()
	/// </summary>
	[Flags]
	public enum ImGuiTableColumnFlags
	{
		None = 0,
		/// Overriding/master disable flag: hide column, won't show in context menu (unlike calling TableSetColumnEnabled() which manipulates the user accessible state)
		Disabled = 1 << 0,
		/// Default as a hidden/disabled column.
		DefaultHide = 1 << 1,
		/// Default as a sorting column.
		DefaultSort = 1 << 2,
		/// Column will stretch. Preferable with horizontal scrolling disabled (default if table sizing policy is _SizingStretchSame or _SizingStretchProp).
		WidthStretch = 1 << 3,
		/// Column will not stretch. Preferable with horizontal scrolling enabled (default if table sizing policy is _SizingFixedFit and table is resizable).
		WidthFixed = 1 << 4,
		/// Disable manual resizing.
		NoResize = 1 << 5,
		/// Disable manual reordering this column, this will also prevent other columns from crossing over this column.
		NoReorder = 1 << 6,
		/// Disable ability to hide/disable this column.
		NoHide = 1 << 7,
		/// Disable clipping for this column (all NoClip columns will render in a same draw command).
		NoClip = 1 << 8,
		/// Disable ability to sort on this field (even if ImGuiTableFlags_Sortable is set on the table).
		NoSort = 1 << 9,
		/// Disable ability to sort in the ascending direction.
		NoSortAscending = 1 << 10,
		/// Disable ability to sort in the descending direction.
		NoSortDescending = 1 << 11,
		/// TableHeadersRow() will not submit horizontal label for this column. Convenient for some small columns. Name will still appear in context menu or in angled headers.
		NoHeaderLabel = 1 << 12,
		/// Disable header text width contribution to automatic column width.
		NoHeaderWidth = 1 << 13,
		/// Make the initial sort direction Ascending when first sorting on this column (default).
		PreferSortAscending = 1 << 14,
		/// Make the initial sort direction Descending when first sorting on this column.
		PreferSortDescending = 1 << 15,
		/// Use current Indent value when entering cell (default for column 0).
		IndentEnable = 1 << 16,
		/// Ignore current Indent value when entering cell (default for columns &gt; 0). Indentation changes _within_ the cell will still be honored.
		IndentDisable = 1 << 17,
		/// TableHeadersRow() will submit an angled header row for this column. Note this will add an extra row.
		AngledHeader = 1 << 18,
		/// Status: is enabled == not hidden by user/api (referred to as "Hide" in _DefaultHide and _NoHide) flags.
		IsEnabled = 1 << 24,
		/// Status: is visible == is enabled AND not clipped by scrolling.
		IsVisible = 1 << 25,
		/// Status: is currently part of the sort specs
		IsSorted = 1 << 26,
		/// Status: is hovered by mouse
		IsHovered = 1 << 27,
		WidthMask = ImGuiTableColumnFlags.WidthStretch | ImGuiTableColumnFlags.WidthFixed,
		IndentMask = ImGuiTableColumnFlags.IndentEnable | ImGuiTableColumnFlags.IndentDisable,
		StatusMask = ImGuiTableColumnFlags.IsEnabled | ImGuiTableColumnFlags.IsVisible | ImGuiTableColumnFlags.IsSorted | ImGuiTableColumnFlags.IsHovered,
		/// [Internal] Disable user resizing this column directly (it may however we resized indirectly from its left edge)
		NoDirectResize = 1 << 30,
	}

	/// <summary>
	/// Flags for ImGui::BeginTable()
	/// - Important! Sizing policies have complex and subtle side effects, much more so than you would expect.
	///   Read comments/demos carefully + experiment with live demos to get acquainted with them.
	/// - The DEFAULT sizing policies are:
	///    - Default to ImGuiTableFlags_SizingFixedFit    if ScrollX is on, or if host window has ImGuiWindowFlags_AlwaysAutoResize.
	///    - Default to ImGuiTableFlags_SizingStretchSame if ScrollX is off.
	/// - When ScrollX is off:
	///    - Table defaults to ImGuiTableFlags_SizingStretchSame -&gt; all Columns defaults to ImGuiTableColumnFlags_WidthStretch with same weight.
	///    - Columns sizing policy allowed: Stretch (default), Fixed/Auto.
	///    - Fixed Columns (if any) will generally obtain their requested width (unless the table cannot fit them all).
	///    - Stretch Columns will share the remaining width according to their respective weight.
	///    - Mixed Fixed/Stretch columns is possible but has various side-effects on resizing behaviors.
	///      The typical use of mixing sizing policies is: any number of LEADING Fixed columns, followed by one or two TRAILING Stretch columns.
	///      (this is because the visible order of columns have subtle but necessary effects on how they react to manual resizing).
	/// - When ScrollX is on:
	///    - Table defaults to ImGuiTableFlags_SizingFixedFit -&gt; all Columns defaults to ImGuiTableColumnFlags_WidthFixed
	///    - Columns sizing policy allowed: Fixed/Auto mostly.
	///    - Fixed Columns can be enlarged as needed. Table will show a horizontal scrollbar if needed.
	///    - When using auto-resizing (non-resizable) fixed columns, querying the content width to use item right-alignment e.g. SetNextItemWidth(-FLT_MIN) doesn't make sense, would create a feedback loop.
	///    - Using Stretch columns OFTEN DOES NOT MAKE SENSE if ScrollX is on, UNLESS you have specified a value for 'inner_width' in BeginTable().
	///      If you specify a value for 'inner_width' then effectively the scrolling space is known and Stretch or mixed Fixed/Stretch columns become meaningful again.
	/// - Read on documentation at the top of imgui_tables.cpp for details.
	/// </summary>
	[Flags]
	public enum ImGuiTableFlags
	{
		None = 0,
		/// Enable resizing columns.
		Resizable = 1 << 0,
		/// Enable reordering columns in header row (need calling TableSetupColumn() + TableHeadersRow() to display headers)
		Reorderable = 1 << 1,
		/// Enable hiding/disabling columns in context menu.
		Hideable = 1 << 2,
		/// Enable sorting. Call TableGetSortSpecs() to obtain sort specs. Also see ImGuiTableFlags_SortMulti and ImGuiTableFlags_SortTristate.
		Sortable = 1 << 3,
		/// Disable persisting columns order, width and sort settings in the .ini file.
		NoSavedSettings = 1 << 4,
		/// Right-click on columns body/contents will display table context menu. By default it is available in TableHeadersRow().
		ContextMenuInBody = 1 << 5,
		/// Set each RowBg color with ImGuiCol_TableRowBg or ImGuiCol_TableRowBgAlt (equivalent of calling TableSetBgColor with ImGuiTableBgFlags_RowBg0 on each row manually)
		RowBg = 1 << 6,
		/// Draw horizontal borders between rows.
		BordersInnerH = 1 << 7,
		/// Draw horizontal borders at the top and bottom.
		BordersOuterH = 1 << 8,
		/// Draw vertical borders between columns.
		BordersInnerV = 1 << 9,
		/// Draw vertical borders on the left and right sides.
		BordersOuterV = 1 << 10,
		/// Draw horizontal borders.
		BordersH = ImGuiTableFlags.BordersInnerH | ImGuiTableFlags.BordersOuterH,
		/// Draw vertical borders.
		BordersV = ImGuiTableFlags.BordersInnerV | ImGuiTableFlags.BordersOuterV,
		/// Draw inner borders.
		BordersInner = ImGuiTableFlags.BordersInnerV | ImGuiTableFlags.BordersInnerH,
		/// Draw outer borders.
		BordersOuter = ImGuiTableFlags.BordersOuterV | ImGuiTableFlags.BordersOuterH,
		/// Draw all borders.
		Borders = ImGuiTableFlags.BordersInner | ImGuiTableFlags.BordersOuter,
		/// [ALPHA] Disable vertical borders in columns Body (borders will always appear in Headers). -&gt; May move to style
		NoBordersInBody = 1 << 11,
		/// [ALPHA] Disable vertical borders in columns Body until hovered for resize (borders will always appear in Headers). -&gt; May move to style
		NoBordersInBodyUntilResize = 1 << 12,
		/// Columns default to _WidthFixed or _WidthAuto (if resizable or not resizable), matching contents width.
		SizingFixedFit = 1 << 13,
		/// Columns default to _WidthFixed or _WidthAuto (if resizable or not resizable), matching the maximum contents width of all columns. Implicitly enable ImGuiTableFlags_NoKeepColumnsVisible.
		SizingFixedSame = 2 << 13,
		/// Columns default to _WidthStretch with default weights proportional to each columns contents widths.
		SizingStretchProp = 3 << 13,
		/// Columns default to _WidthStretch with default weights all equal, unless overridden by TableSetupColumn().
		SizingStretchSame = 4 << 13,
		/// Make outer width auto-fit to columns, overriding outer_size.x value. Only available when ScrollX/ScrollY are disabled and Stretch columns are not used.
		NoHostExtendX = 1 << 16,
		/// Make outer height stop exactly at outer_size.y (prevent auto-extending table past the limit). Only available when ScrollX/ScrollY are disabled. Data below the limit will be clipped and not visible.
		NoHostExtendY = 1 << 17,
		/// Disable keeping column always minimally visible when ScrollX is off and table gets too small. Not recommended if columns are resizable.
		NoKeepColumnsVisible = 1 << 18,
		/// Disable distributing remainder width to stretched columns (width allocation on a 100-wide table with 3 columns: Without this flag: 33,33,34. With this flag: 33,33,33). With larger number of columns, resizing will appear to be less smooth.
		PreciseWidths = 1 << 19,
		/// Disable clipping rectangle for every individual columns (reduce draw command count, items will be able to overflow into other columns). Generally incompatible with TableSetupScrollFreeze().
		NoClip = 1 << 20,
		/// Default if BordersOuterV is on. Enable outermost padding. Generally desirable if you have headers.
		PadOuterX = 1 << 21,
		/// Default if BordersOuterV is off. Disable outermost padding.
		NoPadOuterX = 1 << 22,
		/// Disable inner padding between columns (double inner padding if BordersOuterV is on, single inner padding if BordersOuterV is off).
		NoPadInnerX = 1 << 23,
		/// Enable horizontal scrolling. Require 'outer_size' parameter of BeginTable() to specify the container size. Changes default sizing policy. Because this creates a child window, ScrollY is currently generally recommended when using ScrollX.
		ScrollX = 1 << 24,
		/// Enable vertical scrolling. Require 'outer_size' parameter of BeginTable() to specify the container size.
		ScrollY = 1 << 25,
		/// Hold shift when clicking headers to sort on multiple column. TableGetSortSpecs() may return specs where (SpecsCount &gt; 1).
		SortMulti = 1 << 26,
		/// Allow no sorting, disable default sorting. TableGetSortSpecs() may return specs where (SpecsCount == 0).
		SortTristate = 1 << 27,
		/// Highlight column headers when hovered (may evolve into a fuller highlight)
		HighlightHoveredColumn = 1 << 28,
		SizingMask = ImGuiTableFlags.SizingFixedFit | ImGuiTableFlags.SizingFixedSame | ImGuiTableFlags.SizingStretchProp | ImGuiTableFlags.SizingStretchSame,
	}

	/// <summary>
	/// Flags for ImGui::TableNextRow()
	/// </summary>
	[Flags]
	public enum ImGuiTableRowFlags
	{
		None = 0,
		/// Identify header row (set default background color + width of its contents accounted differently for auto column width)
		Headers = 1 << 0,
	}

	/// <summary>
	/// Flags for ImGui::TreeNodeEx(), ImGui::CollapsingHeader*()
	/// </summary>
	[Flags]
	public enum ImGuiTreeNodeFlags
	{
		None = 0,
		/// Draw as selected
		Selected = 1 << 0,
		/// Draw frame with background (e.g. for CollapsingHeader)
		Framed = 1 << 1,
		/// Hit testing to allow subsequent widgets to overlap this one
		AllowOverlap = 1 << 2,
		/// Don't do a TreePush() when open (e.g. for CollapsingHeader) = no extra indent nor pushing on ID stack
		NoTreePushOnOpen = 1 << 3,
		/// Don't automatically and temporarily open node when Logging is active (by default logging will automatically open tree nodes)
		NoAutoOpenOnLog = 1 << 4,
		/// Default node to be open
		DefaultOpen = 1 << 5,
		/// Need double-click to open node
		OpenOnDoubleClick = 1 << 6,
		/// Only open when clicking on the arrow part. If ImGuiTreeNodeFlags_OpenOnDoubleClick is also set, single-click arrow or double-click all box to open.
		OpenOnArrow = 1 << 7,
		/// No collapsing, no arrow (use as a convenience for leaf nodes).
		Leaf = 1 << 8,
		/// Display a bullet instead of arrow. IMPORTANT: node can still be marked open/close if you don't set the _Leaf flag!
		Bullet = 1 << 9,
		/// Use FramePadding (even for an unframed text node) to vertically align text baseline to regular widget height. Equivalent to calling AlignTextToFramePadding().
		FramePadding = 1 << 10,
		/// Extend hit box to the right-most edge, even if not framed. This is not the default in order to allow adding other items on the same line. In the future we may refactor the hit system to be front-to-back, allowing natural overlaps and then this can become the default.
		SpanAvailWidth = 1 << 11,
		/// Extend hit box to the left-most and right-most edges (bypass the indented area).
		SpanFullWidth = 1 << 12,
		/// Frame will span all columns of its container table (text will still fit in current column)
		SpanAllColumns = 1 << 13,
		/// (WIP) Nav: left direction may move to this TreeNode() from any of its child (items submitted between TreeNode and TreePop)
		NavLeftJumpsBackHere = 1 << 14,
		CollapsingHeader = ImGuiTreeNodeFlags.Framed | ImGuiTreeNodeFlags.NoTreePushOnOpen | ImGuiTreeNodeFlags.NoAutoOpenOnLog,
	}

	/// <summary>
	/// Flags stored in ImGuiViewport::Flags, giving indications to the platform backends.
	/// </summary>
	[Flags]
	public enum ImGuiViewportFlags
	{
		None = 0,
		/// Represent a Platform Window
		IsPlatformWindow = 1 << 0,
		/// Represent a Platform Monitor (unused yet)
		IsPlatformMonitor = 1 << 1,
		/// Platform Window: Was created/managed by the user application? (rather than our backend)
		OwnedByApp = 1 << 2,
		/// Platform Window: Disable platform decorations: title bar, borders, etc. (generally set all windows, but if ImGuiConfigFlags_ViewportsDecoration is set we only set this on popups/tooltips)
		NoDecoration = 1 << 3,
		/// Platform Window: Disable platform task bar icon (generally set on popups/tooltips, or all windows if ImGuiConfigFlags_ViewportsNoTaskBarIcon is set)
		NoTaskBarIcon = 1 << 4,
		/// Platform Window: Don't take focus when created.
		NoFocusOnAppearing = 1 << 5,
		/// Platform Window: Don't take focus when clicked on.
		NoFocusOnClick = 1 << 6,
		/// Platform Window: Make mouse pass through so we can drag this window while peaking behind it.
		NoInputs = 1 << 7,
		/// Platform Window: Renderer doesn't need to clear the framebuffer ahead (because we will fill it entirely).
		NoRendererClear = 1 << 8,
		/// Platform Window: Avoid merging this window into another host window. This can only be set via ImGuiWindowClass viewport flags override (because we need to now ahead if we are going to create a viewport in the first place!).
		NoAutoMerge = 1 << 9,
		/// Platform Window: Display on top (for tooltips only).
		TopMost = 1 << 10,
		/// Viewport can host multiple imgui windows (secondary viewports are associated to a single window). // FIXME: In practice there's still probably code making the assumption that this is always and only on the MainViewport. Will fix once we add support for "no main viewport".
		CanHostOtherWindows = 1 << 11,
		/// Platform Window: Window is minimized, can skip render. When minimized we tend to avoid using the viewport pos/size for clipping window or testing if they are contained in the viewport.
		IsMinimized = 1 << 12,
		/// Platform Window: Window is focused (last call to Platform_GetWindowFocus() returned true)
		IsFocused = 1 << 13,
	}

	/// <summary>
	/// Flags for ImGui::Begin()
	/// (Those are per-window flags. There are shared flags in ImGuiIO: io.ConfigWindowsResizeFromEdges and io.ConfigWindowsMoveFromTitleBarOnly)
	/// </summary>
	[Flags]
	public enum ImGuiWindowFlags
	{
		None = 0,
		/// Disable title-bar
		NoTitleBar = 1 << 0,
		/// Disable user resizing with the lower-right grip
		NoResize = 1 << 1,
		/// Disable user moving the window
		NoMove = 1 << 2,
		/// Disable scrollbars (window can still scroll with mouse or programmatically)
		NoScrollbar = 1 << 3,
		/// Disable user vertically scrolling with mouse wheel. On child window, mouse wheel will be forwarded to the parent unless NoScrollbar is also set.
		NoScrollWithMouse = 1 << 4,
		/// Disable user collapsing window by double-clicking on it. Also referred to as Window Menu Button (e.g. within a docking node).
		NoCollapse = 1 << 5,
		/// Resize every window to its content every frame
		AlwaysAutoResize = 1 << 6,
		/// Disable drawing background color (WindowBg, etc.) and outside border. Similar as using SetNextWindowBgAlpha(0.0f).
		NoBackground = 1 << 7,
		/// Never load/save settings in .ini file
		NoSavedSettings = 1 << 8,
		/// Disable catching mouse, hovering test with pass through.
		NoMouseInputs = 1 << 9,
		/// Has a menu-bar
		MenuBar = 1 << 10,
		/// Allow horizontal scrollbar to appear (off by default). You may use SetNextWindowContentSize(ImVec2(width,0.0f)); prior to calling Begin() to specify width. Read code in imgui_demo in the "Horizontal Scrolling" section.
		HorizontalScrollbar = 1 << 11,
		/// Disable taking focus when transitioning from hidden to visible state
		NoFocusOnAppearing = 1 << 12,
		/// Disable bringing window to front when taking focus (e.g. clicking on it or programmatically giving it focus)
		NoBringToFrontOnFocus = 1 << 13,
		/// Always show vertical scrollbar (even if ContentSize.y &lt; Size.y)
		AlwaysVerticalScrollbar = 1 << 14,
		/// Always show horizontal scrollbar (even if ContentSize.x &lt; Size.x)
		AlwaysHorizontalScrollbar = 1<< 15,
		/// No gamepad/keyboard navigation within the window
		NoNavInputs = 1 << 16,
		/// No focusing toward this window with gamepad/keyboard navigation (e.g. skipped by CTRL+TAB)
		NoNavFocus = 1 << 17,
		/// Display a dot next to the title. When used in a tab/docking context, tab is selected when clicking the X + closure is not assumed (will wait for user to stop submitting the tab). Otherwise closure is assumed when pressing the X, so if you keep submitting the tab may reappear at end of tab bar.
		UnsavedDocument = 1 << 18,
		/// Disable docking of this window
		NoDocking = 1 << 19,
		NoNav = ImGuiWindowFlags.NoNavInputs | ImGuiWindowFlags.NoNavFocus,
		NoDecoration = ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoCollapse,
		NoInputs = ImGuiWindowFlags.NoMouseInputs | ImGuiWindowFlags.NoNavInputs | ImGuiWindowFlags.NoNavFocus,
		/// [BETA] On child window: share focus scope, allow gamepad/keyboard navigation to cross over parent border to this child or between sibling child windows.
		NavFlattened = 1 << 23,
		/// Don't use! For internal use by BeginChild()
		ChildWindow = 1 << 24,
		/// Don't use! For internal use by BeginTooltip()
		Tooltip = 1 << 25,
		/// Don't use! For internal use by BeginPopup()
		Popup = 1 << 26,
		/// Don't use! For internal use by BeginPopupModal()
		Modal = 1 << 27,
		/// Don't use! For internal use by BeginMenu()
		ChildMenu = 1 << 28,
		/// Don't use! For internal use by Begin()/NewFrame()
		DockNodeHost = 1 << 29,
	}

	/// <summary>
	/// [Internal] For use by ImDrawListSplitter
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImDrawChannel
	{
		public ImVector<ImDrawCmd> _CmdBuffer;
		public ImVector<ushort> _IdxBuffer;
	}

	/// <summary>
	/// Typically, 1 command = 1 GPU draw call (unless command is a callback)
	/// - VtxOffset: When 'io.BackendFlags & ImGuiBackendFlags_RendererHasVtxOffset' is enabled,
	///   this fields allow us to render meshes larger than 64K vertices while keeping 16-bit indices.
	///   Backends made for &lt;1.71. will typically ignore the VtxOffset fields.
	/// - The ClipRect/TextureId/VtxOffset fields must be contiguous as we memcmp() them together (this is asserted for).
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	unsafe partial struct ImDrawCmd
	{
		/// 4*4  // Clipping rectangle (x1, y1, x2, y2). Subtract ImDrawData-&gt;DisplayPos to get clipping rectangle in "viewport" coordinates
		public Unity.Mathematics.float4 ClipRect;
		/// 4-8  // User-provided texture ID. Set by user in ImfontAtlas::SetTexID() for fonts or passed to Image*() functions. Ignore if never using images or multiple fonts atlas.
		public UnityObjRef<UnityEngine.Texture2D> TextureId;
		/// 4    // Start offset in vertex buffer. ImGuiBackendFlags_RendererHasVtxOffset: always 0, otherwise may be &gt;0 to support meshes larger than 64K vertices with 16-bit indices.
		public uint VtxOffset;
		/// 4    // Start offset in index buffer.
		public uint IdxOffset;
		/// 4    // Number of indices (multiple of 3) to be rendered as triangles. Vertices are stored in the callee ImDrawList's vtx_buffer[] array, indices in idx_buffer[].
		public uint ElemCount;
		/// 4-8  // If != NULL, call the function instead of rendering the vertices. clip_rect and texture_id will be set normally.
		public delegate* unmanaged[Cdecl]<ImDrawList*, ImDrawCmd*, void> UserCallback;
		/// 4-8  // The draw callback code can access this.
		public void* UserCallbackData;
	}

	/// <summary>
	/// [Internal] For use by ImDrawList
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImDrawCmdHeader
	{
		public Unity.Mathematics.float4 ClipRect;
		public UnityObjRef<UnityEngine.Texture2D> TextureId;
		public uint VtxOffset;
	}

	/// <summary>
	/// All draw data to render a Dear ImGui frame
	/// (NB: the style and the naming convention here is a little inconsistent, we currently preserve them for backward compatibility purpose,
	/// as this is one of the oldest structure exposed by the library! Basically, ImDrawList == CmdList)
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImDrawData
	{
		/// Only valid after Render() is called and before the next NewFrame() is called.
		public byte Valid;
		/// Number of ImDrawList* to render
		public int CmdListsCount;
		/// For convenience, sum of all ImDrawList's IdxBuffer.Size
		public int TotalIdxCount;
		/// For convenience, sum of all ImDrawList's VtxBuffer.Size
		public int TotalVtxCount;
		/// Array of ImDrawList* to render. The ImDrawLists are owned by ImGuiContext and only pointed to from here.
		public ImVector<Ptr<ImDrawList>> CmdLists;
		/// Top-left position of the viewport to render (== top-left of the orthogonal projection matrix to use) (== GetMainViewport()-&gt;Pos for the main viewport, == (0.0) in most single-viewport applications)
		public Unity.Mathematics.float2 DisplayPos;
		/// Size of the viewport to render (== GetMainViewport()-&gt;Size for the main viewport, == io.DisplaySize in most single-viewport applications)
		public Unity.Mathematics.float2 DisplaySize;
		/// Amount of pixels for each unit of DisplaySize. Based on io.DisplayFramebufferScale. Generally (1,1) on normal display, (2,2) on OSX with Retina display.
		public Unity.Mathematics.float2 FramebufferScale;
		/// Viewport carrying the ImDrawData instance, might be of use to the renderer (generally not).
		public ImGuiViewport* OwnerViewport;
	}

	/// <summary>
	/// Draw command list
	/// This is the low-level list of polygons that ImGui:: functions are filling. At the end of the frame,
	/// all command lists are passed to your ImGuiIO::RenderDrawListFn function for rendering.
	/// Each dear imgui window contains its own ImDrawList. You can use ImGui::GetWindowDrawList() to
	/// access the current window draw list and draw custom primitives.
	/// You can interleave normal ImGui:: calls and adding primitives to the current draw list.
	/// In single viewport mode, top-left is == GetMainViewport()-&gt;Pos (generally 0,0), bottom-right is == GetMainViewport()-&gt;Pos+Size (generally io.DisplaySize).
	/// You are totally free to apply whatever transformation matrix to want to the data (depending on the use of the transformation you may want to apply it to ClipRect as well!)
	/// Important: Primitives are always added to the list and not culled (culling is done at higher-level by ImGui:: functions), if you use this API a lot consider coarse culling your drawn objects.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImDrawList
	{
		/// Draw commands. Typically 1 command = 1 GPU draw call, unless the command is a callback.
		public ImVector<ImDrawCmd> CmdBuffer;
		/// Index buffer. Each command consume ImDrawCmd::ElemCount of those
		public ImVector<ushort> IdxBuffer;
		/// Vertex buffer.
		public ImVector<ImDrawVert> VtxBuffer;
		/// Flags, you may poke into these to adjust anti-aliasing settings per-primitive.
		public ImDrawListFlags Flags;
		/// [Internal] generally == VtxBuffer.Size unless we are past 64K vertices, in which case this gets reset to 0.
		public uint _VtxCurrentIdx;
		/// Pointer to shared draw data (you can use ImGui::GetDrawListSharedData() to get the one from current ImGui context)
		public ImDrawListSharedData* _Data;
		/// Pointer to owner window's name for debugging
		public byte* _OwnerName;
		/// [Internal] point within VtxBuffer.Data after each add command (to avoid using the ImVector&lt;&gt; operators too much)
		public ImDrawVert* _VtxWritePtr;
		/// [Internal] point within IdxBuffer.Data after each add command (to avoid using the ImVector&lt;&gt; operators too much)
		public ushort* _IdxWritePtr;
		/// [Internal]
		public ImVector<Unity.Mathematics.float4> _ClipRectStack;
		/// [Internal]
		public ImVector<UnityObjRef<UnityEngine.Texture2D>> _TextureIdStack;
		/// [Internal] current path building
		public ImVector<Unity.Mathematics.float2> _Path;
		/// [Internal] template of active commands. Fields should match those of CmdBuffer.back().
		public ImDrawCmdHeader _CmdHeader;
		/// [Internal] for channels api (note: prefer using your own persistent instance of ImDrawListSplitter!)
		public ImDrawListSplitter _Splitter;
		/// [Internal] anti-alias fringe is scaled by this value, this helps to keep things sharp while zooming at vertex buffer content
		public float _FringeScale;
	}

	/// <summary>
	/// Split/Merge functions are used to split the draw list into different layers which can be drawn into out of order.
	/// This is used by the Columns/Tables API, so items of each column can be batched together in a same draw call.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImDrawListSplitter
	{
		/// Current channel number (0)
		public int _Current;
		/// Number of active channels (1+)
		public int _Count;
		/// Draw channels (not resized down so _Count might be &lt; Channels.Size)
		public ImVector<ImDrawChannel> _Channels;
	}

	/// <summary>
	/// You can override the vertex format layout by defining IMGUI_OVERRIDE_DRAWVERT_STRUCT_LAYOUT in imconfig.h
	/// The code expect ImVec2 pos (8 bytes), ImVec2 uv (8 bytes), ImU32 col (4 bytes), but you can re-order them or add other fields as needed to simplify integration in your engine.
	/// The type has to be described within the macro (you can either declare the struct or use a typedef). This is because ImVec2/ImU32 are likely not declared at the time you'd want to set your type up.
	/// NOTE: IMGUI DOESN'T CLEAR THE STRUCTURE AND DOESN'T CALL A CONSTRUCTOR SO ANY CUSTOM FIELD WILL BE UNINITIALIZED. IF YOU ADD EXTRA FIELDS (SUCH AS A 'Z' COORDINATES) YOU WILL NEED TO CLEAR THEM DURING RENDER OR TO IGNORE THEM.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImDrawVert
	{
		public Unity.Mathematics.float2 pos;
		public uint col;
		public Unity.Mathematics.float2 uv;
	}

	/// <summary>
	/// Font runtime data and rendering
	/// ImFontAtlas automatically loads a default embedded font for you when you call GetTexDataAsAlpha8() or GetTexDataAsRGBA32().
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImFont
	{
		/// 12-16 // out //            // Sparse. Glyphs-&gt;AdvanceX in a directly indexable way (cache-friendly for CalcTextSize functions which only this this info, and are often bottleneck in large UI).
		public ImVector<float> IndexAdvanceX;
		/// 4     // out // = FallbackGlyph-&gt;AdvanceX
		public float FallbackAdvanceX;
		/// 4     // in  //            // Height of characters/line, set during loading (don't change after loading)
		public float FontSize;
		/// 12-16 // out //            // Sparse. Index glyphs by Unicode code-point.
		public ImVector<uint> IndexLookup;
		/// 12-16 // out //            // All glyphs.
		public ImVector<ImFontGlyph> Glyphs;
		/// 4-8   // out // = FindGlyph(FontFallbackChar)
		public ImFontGlyph* FallbackGlyph;
		/// 4-8   // out //            // What we has been loaded into
		public ImFontAtlas* ContainerAtlas;
		/// 4-8   // in  //            // Pointer within ContainerAtlas-&gt;ConfigData
		public ImFontConfig* ConfigData;
		/// 2     // in  // ~ 1        // Number of ImFontConfig involved in creating this font. Bigger than 1 when merging multiple font sources into one ImFont.
		public short ConfigDataCount;
		/// 2     // out // = FFFD/'?' // Character used if a glyph isn't found.
		public uint FallbackChar;
		/// 2     // out // = '...'/'.'// Character used for ellipsis rendering.
		public uint EllipsisChar;
		/// 1     // out // 1 or 3
		public short EllipsisCharCount;
		/// 4     // out               // Width
		public float EllipsisWidth;
		/// 4     // out               // Step between characters when EllipsisCount &gt; 0
		public float EllipsisCharStep;
		/// 1     // out //
		public byte DirtyLookupTables;
		/// 4     // in  // = 1.f      // Base font scale, multiplied by the per-window font scale which you can adjust with SetWindowFontScale()
		public float Scale;
		/// 4+4   // out //            // Ascent: distance from top to bottom of e.g. 'A' [0..FontSize]
		public float Ascent;
		/// 4+4   // out //            // Ascent: distance from top to bottom of e.g. 'A' [0..FontSize]
		public float Descent;
		/// 4     // out //            // Total surface in pixels to get an idea of the font rasterization/texture cost (not exact, we approximate the cost of padding between glyphs)
		public int MetricsTotalSurface;
		/// 2 bytes if ImWchar=ImWchar16, 34 bytes if ImWchar==ImWchar32. Store 1-bit for each block of 4K codepoints that has one active glyph. This is mainly used to facilitate iterations across all used codepoints.
		public ImFont_Used4kPagesMapArray Used4kPagesMap;
	}

	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImFont_Used4kPagesMapArray
	{
		public fixed byte Used4kPagesMap[((int)((0x10FFFF+1)/4096/8))*(1)];
	}

	/// <summary>
	/// Load and rasterize multiple TTF/OTF fonts into a same texture. The font atlas will build a single texture holding:
	///  - One or more fonts.
	///  - Custom graphics data needed to render the shapes needed by Dear ImGui.
	///  - Mouse cursor shapes for software cursor rendering (unless setting 'Flags |= ImFontAtlasFlags_NoMouseCursors' in the font atlas).
	/// It is the user-code responsibility to setup/build the atlas, then upload the pixel data into a texture accessible by your graphics api.
	///  - Optionally, call any of the AddFont*** functions. If you don't call any, the default font embedded in the code will be loaded for you.
	///  - Call GetTexDataAsAlpha8() or GetTexDataAsRGBA32() to build and retrieve pixels data.
	///  - Upload the pixels data into a texture within your graphics system (see imgui_impl_xxxx.cpp examples)
	///  - Call SetTexID(my_tex_id); and pass the pointer/identifier to your texture in a format natural to your graphics API.
	///    This value will be passed back to you during rendering to identify the texture. Read FAQ entry about ImTextureID for more details.
	/// Common pitfalls:
	/// - If you pass a 'glyph_ranges' array to AddFont*** functions, you need to make sure that your array persist up until the
	///   atlas is build (when calling GetTexData*** or Build()). We only copy the pointer, not the data.
	/// - Important: By default, AddFontFromMemoryTTF() takes ownership of the data. Even though we are not writing to it, we will free the pointer on destruction.
	///   You can set font_cfg-&gt;FontDataOwnedByAtlas=false to keep ownership of your data and it won't be freed,
	/// - Even though many functions are suffixed with "TTF", OTF data is supported just as well.
	/// - This is an old API and it is currently awkward for those and various other reasons! We will address them in the future!
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	unsafe partial struct ImFontAtlas
	{
		/// Build flags (see ImFontAtlasFlags_)
		public ImFontAtlasFlags Flags;
		/// User data to refer to the texture once it has been uploaded to user's graphic systems. It is passed back to you during rendering via the ImDrawCmd structure.
		public UnityObjRef<UnityEngine.Texture2D> TexID;
		/// Texture width desired by user before Build(). Must be a power-of-two. If have many glyphs your graphics API have texture size restrictions you may want to increase texture width to decrease height.
		public int TexDesiredWidth;
		/// Padding between glyphs within texture in pixels. Defaults to 1. If your rendering method doesn't rely on bilinear filtering you may set this to 0 (will also need to set AntiAliasedLinesUseTex = false).
		public int TexGlyphPadding;
		/// Marked as Locked by ImGui::NewFrame() so attempt to modify the atlas will assert.
		public byte Locked;
		/// Store your own atlas related user-data (if e.g. you have multiple font atlas).
		public void* UserData;
		/// Set when texture was built matching current font input
		public byte TexReady;
		/// Tell whether our texture data is known to use colors (rather than just alpha channel), in order to help backend select a format.
		public byte TexPixelsUseColors;
		/// 1 component per pixel, each component is unsigned 8-bit. Total size = TexWidth * TexHeight
		public byte* TexPixelsAlpha8;
		/// 4 component per pixel, each component is unsigned 8-bit. Total size = TexWidth * TexHeight * 4
		public uint* TexPixelsRGBA32;
		/// Texture width calculated during Build().
		public int TexWidth;
		/// Texture height calculated during Build().
		public int TexHeight;
		/// = (1.0f/TexWidth, 1.0f/TexHeight)
		public Unity.Mathematics.float2 TexUvScale;
		/// Texture coordinates to a white pixel
		public Unity.Mathematics.float2 TexUvWhitePixel;
		/// Hold all the fonts returned by AddFont*. Fonts[0] is the default font upon calling ImGui::NewFrame(), use ImGui::PushFont()/PopFont() to change the current font.
		public ImVector<Ptr<ImFont>> Fonts;
		/// Rectangles for packing custom texture data into the atlas.
		public ImVector<ImFontAtlasCustomRect> CustomRects;
		/// Configuration data
		public ImVector<ImFontConfig> ConfigData;
		/// UVs for baked anti-aliased lines
		public ImFontAtlas_TexUvLinesArray TexUvLines;
		/// Opaque interface to a font builder (default to stb_truetype, can be changed to use FreeType by defining IMGUI_ENABLE_FREETYPE).
		public ImFontBuilderIO* FontBuilderIO;
		/// Shared flags (for all fonts) for custom font builder. THIS IS BUILD IMPLEMENTATION DEPENDENT. Per-font override is also available in ImFontConfig.
		public uint FontBuilderFlags;
		/// Custom texture rectangle ID for white pixel and mouse cursors
		public int PackIdMouseCursors;
		/// Custom texture rectangle ID for baked anti-aliased lines
		public int PackIdLines;
	}

	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImFontAtlas_TexUvLinesArray
	{
		public fixed byte TexUvLines[((int)((63)+1))*(16)];
	}

	/// <summary>
	/// See ImFontAtlas::AddCustomRectXXX functions.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImFontAtlasCustomRect
	{
		/// Input    // Desired rectangle dimension
		public ushort Width;
		/// Input    // Desired rectangle dimension
		public ushort Height;
		/// Output   // Packed position in Atlas
		public ushort X;
		/// Output   // Packed position in Atlas
		public ushort Y;
		/// Input    // For custom font glyphs only (ID &lt; 0x110000)
		public uint GlyphID;
		/// Input    // For custom font glyphs only: glyph xadvance
		public float GlyphAdvanceX;
		/// Input    // For custom font glyphs only: glyph display offset
		public Unity.Mathematics.float2 GlyphOffset;
		/// Input    // For custom font glyphs only: target font
		public ImFont* Font;
	}

	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImFontConfig
	{
		///          // TTF/OTF data
		public void* FontData;
		///          // TTF/OTF data size
		public int FontDataSize;
		/// true     // TTF/OTF data ownership taken by the container ImFontAtlas (will delete memory itself).
		public byte FontDataOwnedByAtlas;
		/// 0        // Index of font within TTF/OTF file
		public int FontNo;
		///          // Size in pixels for rasterizer (more or less maps to the resulting font height).
		public float SizePixels;
		/// 2        // Rasterize at higher quality for sub-pixel positioning. Note the difference between 2 and 3 is minimal. You can reduce this to 1 for large glyphs save memory. Read https://github.com/nothings/stb/blob/master/tests/oversample/README.md for details.
		public int OversampleH;
		/// 1        // Rasterize at higher quality for sub-pixel positioning. This is not really useful as we don't use sub-pixel positions on the Y axis.
		public int OversampleV;
		/// false    // Align every glyph to pixel boundary. Useful e.g. if you are merging a non-pixel aligned font with the default font. If enabled, you can set OversampleH/V to 1.
		public byte PixelSnapH;
		/// 0, 0     // Extra spacing (in pixels) between glyphs. Only X axis is supported for now.
		public Unity.Mathematics.float2 GlyphExtraSpacing;
		/// 0, 0     // Offset all glyphs from this font input.
		public Unity.Mathematics.float2 GlyphOffset;
		/// NULL     // THE ARRAY DATA NEEDS TO PERSIST AS LONG AS THE FONT IS ALIVE. Pointer to a user-provided list of Unicode range (2 value per range, values are inclusive, zero-terminated list).
		public uint* GlyphRanges;
		/// 0        // Minimum AdvanceX for glyphs, set Min to align font icons, set both Min/Max to enforce mono-space font
		public float GlyphMinAdvanceX;
		/// FLT_MAX  // Maximum AdvanceX for glyphs
		public float GlyphMaxAdvanceX;
		/// false    // Merge into previous ImFont, so you can combine multiple inputs font into one ImFont (e.g. ASCII font + icons + Japanese glyphs). You may want to use GlyphOffset.y when merge font of different heights.
		public byte MergeMode;
		/// 0        // Settings for custom font builder. THIS IS BUILDER IMPLEMENTATION DEPENDENT. Leave as zero if unsure.
		public uint FontBuilderFlags;
		/// 1.0f     // Linearly brighten (&gt;1.0f) or darken (&lt;1.0f) font output. Brightening small fonts may be a good workaround to make them more readable. This is a silly thing we may remove in the future.
		public float RasterizerMultiply;
		/// 1.0f     // DPI scale for rasterization, not altering other font metrics: make it easy to swap between e.g. a 100% and a 400% fonts for a zooming display. IMPORTANT: If you increase this it is expected that you increase font scale accordingly, otherwise quality may look lowered.
		public float RasterizerDensity;
		/// -1       // Explicitly specify unicode codepoint of ellipsis character. When fonts are being merged first specified ellipsis will be used.
		public uint EllipsisChar;
		/// Name (strictly to ease debugging)
		public ImFontConfig_NameArray Name;
		public ImFont* DstFont;
	}

	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImFontConfig_NameArray
	{
		public fixed byte Name[((int)(40))*(1)];
	}

	/// <summary>
	/// Hold rendering data for one glyph.
	/// (Note: some language parsers may fail to convert the 31+1 bitfield members, in this case maybe drop store a single u32 or we can rework this)
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImFontGlyph
	{
		/// Flag to indicate glyph is colored and should generally ignore tinting (make it usable with no shift on little-endian as this is used in loops)
		public uint Colored;
		/// Flag to indicate glyph has no visible pixels (e.g. space). Allow early out when rendering.
		public uint Visible;
		/// 0x0000..0x10FFFF
		public uint Codepoint;
		/// Distance to next character (= data from font + ImFontConfig::GlyphExtraSpacing.x baked in)
		public float AdvanceX;
		/// Glyph corners
		public float X0;
		/// Glyph corners
		public float Y0;
		/// Glyph corners
		public float X1;
		/// Glyph corners
		public float Y1;
		/// Texture coordinates
		public float U0;
		/// Texture coordinates
		public float V0;
		/// Texture coordinates
		public float U1;
		/// Texture coordinates
		public float V1;
	}

	/// <summary>
	/// Helper to build glyph ranges from text/string data. Feed your application strings/characters to it then call BuildRanges().
	/// This is essentially a tightly packed of vector of 64k booleans = 8KB storage.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImFontGlyphRangesBuilder
	{
		/// Store 1-bit per Unicode code point (0=unused, 1=used)
		public ImVector<uint> UsedChars;
	}

	[StructLayout(LayoutKind.Sequential)]
	unsafe partial struct ImGuiIO
	{
		/// = 0              // See ImGuiConfigFlags_ enum. Set by user/application. Gamepad/keyboard navigation options, etc.
		public ImGuiConfigFlags ConfigFlags;
		/// = 0              // See ImGuiBackendFlags_ enum. Set by backend (imgui_impl_xxx files or custom backend) to communicate features supported by the backend.
		public ImGuiBackendFlags BackendFlags;
		/// &lt;unset&gt;          // Main display size, in pixels (generally == GetMainViewport()-&gt;Size). May change every frame.
		public Unity.Mathematics.float2 DisplaySize;
		/// = 1.0f/60.0f     // Time elapsed since last frame, in seconds. May change every frame.
		public float DeltaTime;
		/// = 5.0f           // Minimum time between saving positions/sizes to .ini file, in seconds.
		public float IniSavingRate;
		/// = "imgui.ini"    // Path to .ini file (important: default "imgui.ini" is relative to current working dir!). Set NULL to disable automatic .ini loading/saving or if you want to manually call LoadIniSettingsXXX() / SaveIniSettingsXXX() functions.
		public byte* IniFilename;
		/// = "imgui_log.txt"// Path to .log file (default parameter to ImGui::LogToFile when no file is specified).
		public byte* LogFilename;
		/// = NULL           // Store your own data.
		public void* UserData;
		/// &lt;auto&gt;           // Font atlas: load, rasterize and pack one or more fonts into a single texture.
		public ImFontAtlas* Fonts;
		/// = 1.0f           // Global scale all fonts
		public float FontGlobalScale;
		/// = false          // Allow user scaling text of individual window with CTRL+Wheel.
		public byte FontAllowUserScaling;
		/// = NULL           // Font to use on NewFrame(). Use NULL to uses Fonts-&gt;Fonts[0].
		public ImFont* FontDefault;
		/// = (1, 1)         // For retina display or other situations where window coordinates are different from framebuffer coordinates. This generally ends up in ImDrawData::FramebufferScale.
		public Unity.Mathematics.float2 DisplayFramebufferScale;
		/// = false          // Simplified docking mode: disable window splitting, so docking is limited to merging multiple windows together into tab-bars.
		public byte ConfigDockingNoSplit;
		/// = false          // Enable docking with holding Shift key (reduce visual noise, allows dropping in wider space)
		public byte ConfigDockingWithShift;
		/// = false          // [BETA] [FIXME: This currently creates regression with auto-sizing and general overhead] Make every single floating window display within a docking node.
		public byte ConfigDockingAlwaysTabBar;
		/// = false          // [BETA] Make window or viewport transparent when docking and only display docking boxes on the target viewport. Useful if rendering of multiple viewport cannot be synced. Best used with ConfigViewportsNoAutoMerge.
		public byte ConfigDockingTransparentPayload;
		/// = false;         // Set to make all floating imgui windows always create their own viewport. Otherwise, they are merged into the main host viewports when overlapping it. May also set ImGuiViewportFlags_NoAutoMerge on individual viewport.
		public byte ConfigViewportsNoAutoMerge;
		/// = false          // Disable default OS task bar icon flag for secondary viewports. When a viewport doesn't want a task bar icon, ImGuiViewportFlags_NoTaskBarIcon will be set on it.
		public byte ConfigViewportsNoTaskBarIcon;
		/// = true           // Disable default OS window decoration flag for secondary viewports. When a viewport doesn't want window decorations, ImGuiViewportFlags_NoDecoration will be set on it. Enabling decoration can create subsequent issues at OS levels (e.g. minimum window size).
		public byte ConfigViewportsNoDecoration;
		/// = false          // Disable default OS parenting to main viewport for secondary viewports. By default, viewports are marked with ParentViewportId = &lt;main_viewport&gt;, expecting the platform backend to setup a parent/child relationship between the OS windows (some backend may ignore this). Set to true if you want the default to be 0, then all viewports will be top-level OS windows.
		public byte ConfigViewportsNoDefaultParent;
		/// = false          // Request ImGui to draw a mouse cursor for you (if you are on a platform without a mouse cursor). Cannot be easily renamed to 'io.ConfigXXX' because this is frequently used by backend implementations.
		public byte MouseDrawCursor;
		/// = defined(__APPLE__) // OS X style: Text editing cursor movement using Alt instead of Ctrl, Shortcuts using Cmd/Super instead of Ctrl, Line/Text Start and End using Cmd+Arrows instead of Home/End, Double click selects by word instead of selecting whole text, Multi-selection in lists uses Cmd/Super instead of Ctrl.
		public byte ConfigMacOSXBehaviors;
		/// = true           // Enable input queue trickling: some types of events submitted during the same frame (e.g. button down + up) will be spread over multiple frames, improving interactions with low framerates.
		public byte ConfigInputTrickleEventQueue;
		/// = true           // Enable blinking cursor (optional as some users consider it to be distracting).
		public byte ConfigInputTextCursorBlink;
		/// = false          // [BETA] Pressing Enter will keep item active and select contents (single-line only).
		public byte ConfigInputTextEnterKeepActive;
		/// = false          // [BETA] Enable turning DragXXX widgets into text input with a simple mouse click-release (without moving). Not desirable on devices without a keyboard.
		public byte ConfigDragClickToInputText;
		/// = true           // Enable resizing of windows from their edges and from the lower-left corner. This requires (io.BackendFlags & ImGuiBackendFlags_HasMouseCursors) because it needs mouse cursor feedback. (This used to be a per-window ImGuiWindowFlags_ResizeFromAnySide flag)
		public byte ConfigWindowsResizeFromEdges;
		/// = false       // Enable allowing to move windows only when clicking on their title bar. Does not apply to windows without a title bar.
		public byte ConfigWindowsMoveFromTitleBarOnly;
		/// = 60.0f          // Timer (in seconds) to free transient windows/tables memory buffers when unused. Set to -1.0f to disable.
		public float ConfigMemoryCompactTimer;
		/// = 0.30f          // Time for a double-click, in seconds.
		public float MouseDoubleClickTime;
		/// = 6.0f           // Distance threshold to stay in to validate a double-click, in pixels.
		public float MouseDoubleClickMaxDist;
		/// = 6.0f           // Distance threshold before considering we are dragging.
		public float MouseDragThreshold;
		/// = 0.275f         // When holding a key/button, time before it starts repeating, in seconds (for buttons in Repeat mode, etc.).
		public float KeyRepeatDelay;
		/// = 0.050f         // When holding a key/button, rate at which it repeats, in seconds.
		public float KeyRepeatRate;
		/// = false          // Enable various tools calling IM_DEBUG_BREAK().
		public byte ConfigDebugIsDebuggerPresent;
		/// = false          // First-time calls to Begin()/BeginChild() will return false. NEEDS TO BE SET AT APPLICATION BOOT TIME if you don't want to miss windows.
		public byte ConfigDebugBeginReturnValueOnce;
		/// = false          // Some calls to Begin()/BeginChild() will return false. Will cycle through window depths then repeat. Suggested use: add "io.ConfigDebugBeginReturnValue = io.KeyShift" in your main loop then occasionally press SHIFT. Windows should be flickering while running.
		public byte ConfigDebugBeginReturnValueLoop;
		/// = false          // Ignore io.AddFocusEvent(false), consequently not calling io.ClearInputKeys() in input processing.
		public byte ConfigDebugIgnoreFocusLoss;
		/// = false          // Save .ini data with extra comments (particularly helpful for Docking, but makes saving slower)
		public byte ConfigDebugIniSettings;
		/// = NULL
		public byte* BackendPlatformName;
		/// = NULL
		public byte* BackendRendererName;
		/// = NULL           // User data for platform backend
		public void* BackendPlatformUserData;
		/// = NULL           // User data for renderer backend
		public void* BackendRendererUserData;
		/// = NULL           // User data for non C++ programming language backend
		public void* BackendLanguageUserData;
		public delegate* unmanaged[Cdecl]<System.IntPtr, char*> GetClipboardTextFn;
		public delegate* unmanaged[Cdecl]<System.IntPtr, byte*, void> SetClipboardTextFn;
		public void* ClipboardUserData;
		public delegate* unmanaged[Cdecl]<ImGuiViewport*, ImGuiPlatformImeData*, void> SetPlatformImeDataFn;
		/// '.'              // [Experimental] Configure decimal point e.g. '.' or ',' useful for some languages (e.g. German), generally pulled from *localeconv()-&gt;decimal_point
		public uint PlatformLocaleDecimalPoint;
		/// Set when Dear ImGui will use mouse inputs, in this case do not dispatch them to your main game/application (either way, always pass on mouse inputs to imgui). (e.g. unclicked mouse is hovering over an imgui window, widget is active, mouse was clicked over an imgui window, etc.).
		public byte WantCaptureMouse;
		/// Set when Dear ImGui will use keyboard inputs, in this case do not dispatch them to your main game/application (either way, always pass keyboard inputs to imgui). (e.g. InputText active, or an imgui window is focused and navigation is enabled, etc.).
		public byte WantCaptureKeyboard;
		/// Mobile/console: when set, you may display an on-screen keyboard. This is set by Dear ImGui when it wants textual keyboard input to happen (e.g. when a InputText widget is active).
		public byte WantTextInput;
		/// MousePos has been altered, backend should reposition mouse on next frame. Rarely used! Set only when ImGuiConfigFlags_NavEnableSetMousePos flag is enabled.
		public byte WantSetMousePos;
		/// When manual .ini load/save is active (io.IniFilename == NULL), this will be set to notify your application that you can call SaveIniSettingsToMemory() and save yourself. Important: clear io.WantSaveIniSettings yourself after saving!
		public byte WantSaveIniSettings;
		/// Keyboard/Gamepad navigation is currently allowed (will handle ImGuiKey_NavXXX events) = a window is focused and it doesn't use the ImGuiWindowFlags_NoNavInputs flag.
		public byte NavActive;
		/// Keyboard/Gamepad navigation is visible and allowed (will handle ImGuiKey_NavXXX events).
		public byte NavVisible;
		/// Estimate of application framerate (rolling average over 60 frames, based on io.DeltaTime), in frame per second. Solely for convenience. Slow applications may not want to use a moving average or may want to reset underlying buffers occasionally.
		public float Framerate;
		/// Vertices output during last call to Render()
		public int MetricsRenderVertices;
		/// Indices output during last call to Render() = number of triangles * 3
		public int MetricsRenderIndices;
		/// Number of visible windows
		public int MetricsRenderWindows;
		/// Number of active windows
		public int MetricsActiveWindows;
		/// Mouse delta. Note that this is zero if either current or previous position are invalid (-FLT_MAX,-FLT_MAX), so a disappearing/reappearing mouse won't have a huge delta.
		public Unity.Mathematics.float2 MouseDelta;
		/// Parent UI context (needs to be set explicitly by parent).
		public ImGuiContext* Ctx;
		/// Mouse position, in pixels. Set to ImVec2(-FLT_MAX, -FLT_MAX) if mouse is unavailable (on another screen, etc.)
		public Unity.Mathematics.float2 MousePos;
		/// Mouse buttons: 0=left, 1=right, 2=middle + extras (ImGuiMouseButton_COUNT == 5). Dear ImGui mostly uses left and right buttons. Other buttons allow us to track if the mouse is being used by your application + available to user as a convenience via IsMouse** API.
		public ImGuiIO_MouseDownArray MouseDown;
		/// Mouse wheel Vertical: 1 unit scrolls about 5 lines text. &gt;0 scrolls Up, &lt;0 scrolls Down. Hold SHIFT to turn vertical scroll into horizontal scroll.
		public float MouseWheel;
		/// Mouse wheel Horizontal. &gt;0 scrolls Left, &lt;0 scrolls Right. Most users don't have a mouse with a horizontal wheel, may not be filled by all backends.
		public float MouseWheelH;
		/// Mouse actual input peripheral (Mouse/TouchScreen/Pen).
		public ImGuiMouseSource MouseSource;
		/// (Optional) Modify using io.AddMouseViewportEvent(). With multi-viewports: viewport the OS mouse is hovering. If possible _IGNORING_ viewports with the ImGuiViewportFlags_NoInputs flag is much better (few backends can handle that). Set io.BackendFlags |= ImGuiBackendFlags_HasMouseHoveredViewport if you can provide this info. If you don't imgui will infer the value using the rectangles and last focused time of the viewports it knows about (ignoring other OS windows).
		public uint MouseHoveredViewport;
		/// Keyboard modifier down: Control
		public byte KeyCtrl;
		/// Keyboard modifier down: Shift
		public byte KeyShift;
		/// Keyboard modifier down: Alt
		public byte KeyAlt;
		/// Keyboard modifier down: Cmd/Super/Windows
		public byte KeySuper;
		/// Key mods flags (any of ImGuiMod_Ctrl/ImGuiMod_Shift/ImGuiMod_Alt/ImGuiMod_Super flags, same as io.KeyCtrl/KeyShift/KeyAlt/KeySuper but merged into flags. DOES NOT CONTAINS ImGuiMod_Shortcut which is pretranslated). Read-only, updated by NewFrame()
		public int KeyMods;
		/// Key state for all known keys. Use IsKeyXXX() functions to access this.
		public ImGuiIO_KeysDataArray KeysData;
		/// Alternative to WantCaptureMouse: (WantCaptureMouse == true && WantCaptureMouseUnlessPopupClose == false) when a click over void is expected to close a popup.
		public byte WantCaptureMouseUnlessPopupClose;
		/// Previous mouse position (note that MouseDelta is not necessary == MousePos-MousePosPrev, in case either position is invalid)
		public Unity.Mathematics.float2 MousePosPrev;
		/// Position at time of clicking
		public ImGuiIO_MouseClickedPosArray MouseClickedPos;
		/// Time of last click (used to figure out double-click)
		public ImGuiIO_MouseClickedTimeArray MouseClickedTime;
		/// Mouse button went from !Down to Down (same as MouseClickedCount[x] != 0)
		public ImGuiIO_MouseClickedArray MouseClicked;
		/// Has mouse button been double-clicked? (same as MouseClickedCount[x] == 2)
		public ImGuiIO_MouseDoubleClickedArray MouseDoubleClicked;
		/// == 0 (not clicked), == 1 (same as MouseClicked[]), == 2 (double-clicked), == 3 (triple-clicked) etc. when going from !Down to Down
		public ImGuiIO_MouseClickedCountArray MouseClickedCount;
		/// Count successive number of clicks. Stays valid after mouse release. Reset after another click is done.
		public ImGuiIO_MouseClickedLastCountArray MouseClickedLastCount;
		/// Mouse button went from Down to !Down
		public ImGuiIO_MouseReleasedArray MouseReleased;
		/// Track if button was clicked inside a dear imgui window or over void blocked by a popup. We don't request mouse capture from the application if click started outside ImGui bounds.
		public ImGuiIO_MouseDownOwnedArray MouseDownOwned;
		/// Track if button was clicked inside a dear imgui window.
		public ImGuiIO_MouseDownOwnedUnlessPopupCloseArray MouseDownOwnedUnlessPopupClose;
		/// On a non-Mac system, holding SHIFT requests WheelY to perform the equivalent of a WheelX event. On a Mac system this is already enforced by the system.
		public byte MouseWheelRequestAxisSwap;
		/// Duration the mouse button has been down (0.0f == just clicked)
		public ImGuiIO_MouseDownDurationArray MouseDownDuration;
		/// Previous time the mouse button has been down
		public ImGuiIO_MouseDownDurationPrevArray MouseDownDurationPrev;
		/// Maximum distance, absolute, on each axis, of how much mouse has traveled from the clicking point
		public ImGuiIO_MouseDragMaxDistanceAbsArray MouseDragMaxDistanceAbs;
		/// Squared maximum distance of how much mouse has traveled from the clicking point (used for moving thresholds)
		public ImGuiIO_MouseDragMaxDistanceSqrArray MouseDragMaxDistanceSqr;
		/// Touch/Pen pressure (0.0f to 1.0f, should be &gt;0.0f only when MouseDown[0] == true). Helper storage currently unused by Dear ImGui.
		public float PenPressure;
		/// Only modify via AddFocusEvent()
		public byte AppFocusLost;
		/// Only modify via SetAppAcceptingEvents()
		public byte AppAcceptingEvents;
		/// -1: unknown, 0: using AddKeyEvent(), 1: using legacy io.KeysDown[]
		public sbyte BackendUsingLegacyKeyArrays;
		/// 0: using AddKeyAnalogEvent(), 1: writing to legacy io.NavInputs[] directly
		public byte BackendUsingLegacyNavInputArray;
		/// For AddInputCharacterUTF16()
		public ushort InputQueueSurrogate;
		/// Queue of _characters_ input (obtained by platform backend). Fill using AddInputCharacter() helper.
		public ImVector<uint> InputQueueCharacters;
	}

	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImGuiIO_MouseDownArray
	{
		public fixed byte MouseDown[((int)(5))*(1)];
	}

	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImGuiIO_KeysDataArray
	{
		public fixed byte KeysData[((int)(ImGuiKeyKeysData.SIZE))*(16)];
	}

	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImGuiIO_MouseClickedPosArray
	{
		public fixed byte MouseClickedPos[((int)(5))*(8)];
	}

	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImGuiIO_MouseClickedTimeArray
	{
		public fixed byte MouseClickedTime[((int)(5))*(8)];
	}

	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImGuiIO_MouseClickedArray
	{
		public fixed byte MouseClicked[((int)(5))*(1)];
	}

	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImGuiIO_MouseDoubleClickedArray
	{
		public fixed byte MouseDoubleClicked[((int)(5))*(1)];
	}

	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImGuiIO_MouseClickedCountArray
	{
		public fixed byte MouseClickedCount[((int)(5))*(2)];
	}

	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImGuiIO_MouseClickedLastCountArray
	{
		public fixed byte MouseClickedLastCount[((int)(5))*(2)];
	}

	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImGuiIO_MouseReleasedArray
	{
		public fixed byte MouseReleased[((int)(5))*(1)];
	}

	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImGuiIO_MouseDownOwnedArray
	{
		public fixed byte MouseDownOwned[((int)(5))*(1)];
	}

	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImGuiIO_MouseDownOwnedUnlessPopupCloseArray
	{
		public fixed byte MouseDownOwnedUnlessPopupClose[((int)(5))*(1)];
	}

	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImGuiIO_MouseDownDurationArray
	{
		public fixed byte MouseDownDuration[((int)(5))*(4)];
	}

	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImGuiIO_MouseDownDurationPrevArray
	{
		public fixed byte MouseDownDurationPrev[((int)(5))*(4)];
	}

	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImGuiIO_MouseDragMaxDistanceAbsArray
	{
		public fixed byte MouseDragMaxDistanceAbs[((int)(5))*(8)];
	}

	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImGuiIO_MouseDragMaxDistanceSqrArray
	{
		public fixed byte MouseDragMaxDistanceSqr[((int)(5))*(4)];
	}

	/// <summary>
	/// Shared state of InputText(), passed as an argument to your callback when a ImGuiInputTextFlags_Callback* flag is used.
	/// The callback function should return 0 by default.
	/// Callbacks (follow a flag name and see comments in ImGuiInputTextFlags_ declarations for more details)
	/// - ImGuiInputTextFlags_CallbackEdit:        Callback on buffer edit (note that InputText() already returns true on edit, the callback is useful mainly to manipulate the underlying buffer while focus is active)
	/// - ImGuiInputTextFlags_CallbackAlways:      Callback on each iteration
	/// - ImGuiInputTextFlags_CallbackCompletion:  Callback on pressing TAB
	/// - ImGuiInputTextFlags_CallbackHistory:     Callback on pressing Up/Down arrows
	/// - ImGuiInputTextFlags_CallbackCharFilter:  Callback on character inputs to replace or discard them. Modify 'EventChar' to replace or discard, or return 1 in callback to discard.
	/// - ImGuiInputTextFlags_CallbackResize:      Callback on buffer capacity changes request (beyond 'buf_size' parameter value), allowing the string to grow.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImGuiInputTextCallbackData
	{
		/// Parent UI context
		public ImGuiContext* Ctx;
		/// One ImGuiInputTextFlags_Callback*    // Read-only
		public ImGuiInputTextFlags EventFlag;
		/// What user passed to InputText()      // Read-only
		public ImGuiInputTextFlags Flags;
		/// What user passed to InputText()      // Read-only
		public void* UserData;
		/// Character input                      // Read-write   // [CharFilter] Replace character with another one, or set to zero to drop. return 1 is equivalent to setting EventChar=0;
		public uint EventChar;
		/// Key pressed (Up/Down/TAB)            // Read-only    // [Completion,History]
		public ImGuiKey EventKey;
		/// Text buffer                          // Read-write   // [Resize] Can replace pointer / [Completion,History,Always] Only write to pointed data, don't replace the actual pointer!
		public byte* Buf;
		/// Text length (in bytes)               // Read-write   // [Resize,Completion,History,Always] Exclude zero-terminator storage. In C land: == strlen(some_text), in C++ land: string.length()
		public int BufTextLen;
		/// Buffer size (in bytes) = capacity+1  // Read-only    // [Resize,Completion,History,Always] Include zero-terminator storage. In C land == ARRAYSIZE(my_char_array), in C++ land: string.capacity()+1
		public int BufSize;
		/// Set if you modify Buf/BufTextLen!    // Write        // [Completion,History,Always]
		public byte BufDirty;
		///                                      // Read-write   // [Completion,History,Always]
		public int CursorPos;
		///                                      // Read-write   // [Completion,History,Always] == to SelectionEnd when no selection)
		public int SelectionStart;
		///                                      // Read-write   // [Completion,History,Always]
		public int SelectionEnd;
	}

	/// <summary>
	/// [Internal] Storage used by IsKeyDown(), IsKeyPressed() etc functions.
	/// If prior to 1.87 you used io.KeysDownDuration[] (which was marked as internal), you should use GetKeyData(key)-&gt;DownDuration and *NOT* io.KeysData[key]-&gt;DownDuration.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImGuiKeyData
	{
		/// True for if key is down
		public byte Down;
		/// Duration the key has been down (&lt;0.0f: not pressed, 0.0f: just pressed, &gt;0.0f: time held)
		public float DownDuration;
		/// Last frame duration the key has been down
		public float DownDurationPrev;
		/// 0.0f..1.0f for gamepad values
		public float AnalogValue;
	}

	/// <summary>
	/// Helper: Manually clip large list of items.
	/// If you have lots evenly spaced items and you have random access to the list, you can perform coarse
	/// clipping based on visibility to only submit items that are in view.
	/// The clipper calculates the range of visible items and advance the cursor to compensate for the non-visible items we have skipped.
	/// (Dear ImGui already clip items based on their bounds but: it needs to first layout the item to do so, and generally
	///  fetching/submitting your own data incurs additional cost. Coarse clipping using ImGuiListClipper allows you to easily
	///  scale using lists with tens of thousands of items without a problem)
	/// Usage:
	///   ImGuiListClipper clipper;
	///   clipper.Begin(1000);         	/// We have 1000 elements, evenly spaced.
	///   while (clipper.Step())
	///       for (int i = clipper.DisplayStart; i &lt; clipper.DisplayEnd; i++)
	///           ImGui::Text("line number %d", i);
	/// Generally what happens is:
	/// - Clipper lets you process the first element (DisplayStart = 0, DisplayEnd = 1) regardless of it being visible or not.
	/// - User code submit that one element.
	/// - Clipper can measure the height of the first element
	/// - Clipper calculate the actual range of elements to display based on the current clipping rectangle, position the cursor before the first visible element.
	/// - User code submit visible elements.
	/// - The clipper also handles various subtleties related to keyboard/gamepad navigation, wrapping etc.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImGuiListClipper
	{
		/// Parent UI context
		public ImGuiContext* Ctx;
		/// First item to display, updated by each call to Step()
		public int DisplayStart;
		/// End of items to display (exclusive)
		public int DisplayEnd;
		/// [Internal] Number of items
		public int ItemsCount;
		/// [Internal] Height of item after a first step and item submission can calculate it
		public float ItemsHeight;
		/// [Internal] Cursor position at the time of Begin() or after table frozen rows are all processed
		public float StartPosY;
		/// [Internal] Internal data
		public void* TempData;
	}

	/// <summary>
	/// Helper: Execute a block of code at maximum once a frame. Convenient if you want to quickly create a UI within deep-nested code that runs multiple times every frame.
	/// Usage: static ImGuiOnceUponAFrame oaf; if (oaf) ImGui::Text("This will be called only once per frame");
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImGuiOnceUponAFrame
	{
		public int RefFrame;
	}

	/// <summary>
	/// Data payload for Drag and Drop operations: AcceptDragDropPayload(), GetDragDropPayload()
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImGuiPayload
	{
		/// Data (copied and owned by dear imgui)
		public void* Data;
		/// Data size
		public int DataSize;
		/// Source item id
		public uint SourceId;
		/// Source parent id (if available)
		public uint SourceParentId;
		/// Data timestamp
		public int DataFrameCount;
		/// Data type tag (short user-supplied string, 32 characters max)
		public ImGuiPayload_DataTypeArray DataType;
		/// Set when AcceptDragDropPayload() was called and mouse has been hovering the target item (nb: handle overlapping drag targets)
		public byte Preview;
		/// Set when AcceptDragDropPayload() was called and mouse button is released over the target item.
		public byte Delivery;
	}

	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImGuiPayload_DataTypeArray
	{
		public fixed byte DataType[((int)(32+1))*(1)];
	}

	/// <summary>
	/// (Optional) Access via ImGui::GetPlatformIO()
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImGuiPlatformIO
	{
		/// . . U . .  // Create a new platform window for the given viewport
		public delegate* unmanaged[Cdecl]<ImGuiViewport*, void> Platform_CreateWindow;
		/// N . U . D  //
		public delegate* unmanaged[Cdecl]<ImGuiViewport*, void> Platform_DestroyWindow;
		/// . . U . .  // Newly created windows are initially hidden so SetWindowPos/Size/Title can be called on them before showing the window
		public delegate* unmanaged[Cdecl]<ImGuiViewport*, void> Platform_ShowWindow;
		/// . . U . .  // Set platform window position (given the upper-left corner of client area)
		public delegate* unmanaged[Cdecl]<ImGuiViewport*, Unity.Mathematics.float2, void> Platform_SetWindowPos;
		/// N . . . .  //
		public delegate* unmanaged[Cdecl]<ImGuiViewport*, Unity.Mathematics.float2> Platform_GetWindowPos;
		/// . . U . .  // Set platform window client area size (ignoring OS decorations such as OS title bar etc.)
		public delegate* unmanaged[Cdecl]<ImGuiViewport*, Unity.Mathematics.float2, void> Platform_SetWindowSize;
		/// N . . . .  // Get platform window client area size
		public delegate* unmanaged[Cdecl]<ImGuiViewport*, Unity.Mathematics.float2> Platform_GetWindowSize;
		/// N . . . .  // Move window to front and set input focus
		public delegate* unmanaged[Cdecl]<ImGuiViewport*, void> Platform_SetWindowFocus;
		/// . . U . .  //
		public delegate* unmanaged[Cdecl]<ImGuiViewport*, byte> Platform_GetWindowFocus;
		/// N . . . .  // Get platform window minimized state. When minimized, we generally won't attempt to get/set size and contents will be culled more easily
		public delegate* unmanaged[Cdecl]<ImGuiViewport*, byte> Platform_GetWindowMinimized;
		/// . . U . .  // Set platform window title (given an UTF-8 string)
		public delegate* unmanaged[Cdecl]<ImGuiViewport*, byte*, void> Platform_SetWindowTitle;
		/// . . U . .  // (Optional) Setup global transparency (not per-pixel transparency)
		public delegate* unmanaged[Cdecl]<ImGuiViewport*, float, void> Platform_SetWindowAlpha;
		/// . . U . .  // (Optional) Called by UpdatePlatformWindows(). Optional hook to allow the platform backend from doing general book-keeping every frame.
		public delegate* unmanaged[Cdecl]<ImGuiViewport*, void> Platform_UpdateWindow;
		/// . . . R .  // (Optional) Main rendering (platform side! This is often unused, or just setting a "current" context for OpenGL bindings). 'render_arg' is the value passed to RenderPlatformWindowsDefault().
		public delegate* unmanaged[Cdecl]<ImGuiViewport*, System.IntPtr, void> Platform_RenderWindow;
		/// . . . R .  // (Optional) Call Present/SwapBuffers (platform side! This is often unused!). 'render_arg' is the value passed to RenderPlatformWindowsDefault().
		public delegate* unmanaged[Cdecl]<ImGuiViewport*, System.IntPtr, void> Platform_SwapBuffers;
		/// N . . . .  // (Optional) [BETA] FIXME-DPI: DPI handling: Return DPI scale for this viewport. 1.0f = 96 DPI.
		public delegate* unmanaged[Cdecl]<ImGuiViewport*, float> Platform_GetWindowDpiScale;
		/// . F . . .  // (Optional) [BETA] FIXME-DPI: DPI handling: Called during Begin() every time the viewport we are outputting into changes, so backend has a chance to swap fonts to adjust style.
		public delegate* unmanaged[Cdecl]<ImGuiViewport*, void> Platform_OnChangedViewport;
		/// (Optional) For a Vulkan Renderer to call into Platform code (since the surface creation needs to tie them both).
		public delegate* unmanaged[Cdecl]<ImGuiViewport*, ulong, System.IntPtr, ulong*, int> Platform_CreateVkSurface;
		/// . . U . .  // Create swap chain, frame buffers etc. (called after Platform_CreateWindow)
		public delegate* unmanaged[Cdecl]<ImGuiViewport*, void> Renderer_CreateWindow;
		/// N . U . D  // Destroy swap chain, frame buffers etc. (called before Platform_DestroyWindow)
		public delegate* unmanaged[Cdecl]<ImGuiViewport*, void> Renderer_DestroyWindow;
		/// . . U . .  // Resize swap chain, frame buffers etc. (called after Platform_SetWindowSize)
		public delegate* unmanaged[Cdecl]<ImGuiViewport*, Unity.Mathematics.float2, void> Renderer_SetWindowSize;
		/// . . . R .  // (Optional) Clear framebuffer, setup render target, then render the viewport-&gt;DrawData. 'render_arg' is the value passed to RenderPlatformWindowsDefault().
		public delegate* unmanaged[Cdecl]<ImGuiViewport*, System.IntPtr, void> Renderer_RenderWindow;
		/// . . . R .  // (Optional) Call Present/SwapBuffers. 'render_arg' is the value passed to RenderPlatformWindowsDefault().
		public delegate* unmanaged[Cdecl]<ImGuiViewport*, System.IntPtr, void> Renderer_SwapBuffers;
		public ImVector<ImGuiPlatformMonitor> Monitors;
		/// Main viewports, followed by all secondary viewports.
		public ImVector<Ptr<ImGuiViewport>> Viewports;
	}

	/// <summary>
	/// (Optional) Support for IME (Input Method Editor) via the io.SetPlatformImeDataFn() function.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImGuiPlatformImeData
	{
		/// A widget wants the IME to be visible
		public byte WantVisible;
		/// Position of the input cursor
		public Unity.Mathematics.float2 InputPos;
		/// Line height
		public float InputLineHeight;
	}

	/// <summary>
	/// (Optional) This is required when enabling multi-viewport. Represent the bounds of each connected monitor/display and their DPI.
	/// We use this information for multiple DPI support + clamping the position of popups and tooltips so they don't straddle multiple monitors.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImGuiPlatformMonitor
	{
		/// Coordinates of the area displayed on this monitor (Min = upper left, Max = bottom right)
		public Unity.Mathematics.float2 MainPos;
		/// Coordinates of the area displayed on this monitor (Min = upper left, Max = bottom right)
		public Unity.Mathematics.float2 MainSize;
		/// Coordinates without task bars / side bars / menu bars. Used to avoid positioning popups/tooltips inside this region. If you don't have this info, please copy the value for MainPos/MainSize.
		public Unity.Mathematics.float2 WorkPos;
		/// Coordinates without task bars / side bars / menu bars. Used to avoid positioning popups/tooltips inside this region. If you don't have this info, please copy the value for MainPos/MainSize.
		public Unity.Mathematics.float2 WorkSize;
		/// 1.0f = 96 DPI
		public float DpiScale;
		/// Backend dependant data (e.g. HMONITOR, GLFWmonitor*, SDL Display Index, NSScreen*)
		public void* PlatformHandle;
	}

	/// <summary>
	/// Resizing callback data to apply custom constraint. As enabled by SetNextWindowSizeConstraints(). Callback is called during the next Begin().
	/// NB: For basic min/max size constraint on each axis you don't need to use the callback! The SetNextWindowSizeConstraints() parameters are enough.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImGuiSizeCallbackData
	{
		/// Read-only.   What user passed to SetNextWindowSizeConstraints(). Generally store an integer or float in here (need reinterpret_cast&lt;&gt;).
		public void* UserData;
		/// Read-only.   Window position, for reference.
		public Unity.Mathematics.float2 Pos;
		/// Read-only.   Current window size.
		public Unity.Mathematics.float2 CurrentSize;
		/// Read-write.  Desired size, based on user's mouse position. Write to this field to restrain resizing.
		public Unity.Mathematics.float2 DesiredSize;
	}

	/// <summary>
	/// Helper: Key-&gt;Value storage
	/// Typically you don't have to worry about this since a storage is held within each Window.
	/// We use it to e.g. store collapse state for a tree (Int 0/1)
	/// This is optimized for efficient lookup (dichotomy into a contiguous buffer) and rare insertion (typically tied to user interactions aka max once a frame)
	/// You can use it as custom user storage for temporary values. Declare your own storage if, for example:
	/// - You want to manipulate the open/close state of a particular sub-tree in your interface (tree node uses Int 0/1 to store their state).
	/// - You want to store custom debug data easily without adding or editing structures in your code (probably not efficient, but convenient)
	/// Types are NOT stored, so it is up to you to make sure your Key don't collide with different types.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImGuiStorage
	{
		public ImVector<ImGuiStoragePair> Data;
	}

	/// <summary>

    	/// [Internal]
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImGuiStoragePair
	{
		public uint key;
		public ImGuiStoragePairUnion union;
	}

	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImGuiStyle
	{
		/// Global alpha applies to everything in Dear ImGui.
		public float Alpha;
		/// Additional alpha multiplier applied by BeginDisabled(). Multiply over current value of Alpha.
		public float DisabledAlpha;
		/// Padding within a window.
		public Unity.Mathematics.float2 WindowPadding;
		/// Radius of window corners rounding. Set to 0.0f to have rectangular windows. Large values tend to lead to variety of artifacts and are not recommended.
		public float WindowRounding;
		/// Thickness of border around windows. Generally set to 0.0f or 1.0f. (Other values are not well tested and more CPU/GPU costly).
		public float WindowBorderSize;
		/// Minimum window size. This is a global setting. If you want to constrain individual windows, use SetNextWindowSizeConstraints().
		public Unity.Mathematics.float2 WindowMinSize;
		/// Alignment for title bar text. Defaults to (0.0f,0.5f) for left-aligned,vertically centered.
		public Unity.Mathematics.float2 WindowTitleAlign;
		/// Side of the collapsing/docking button in the title bar (None/Left/Right). Defaults to ImGuiDir_Left.
		public ImGuiDir WindowMenuButtonPosition;
		/// Radius of child window corners rounding. Set to 0.0f to have rectangular windows.
		public float ChildRounding;
		/// Thickness of border around child windows. Generally set to 0.0f or 1.0f. (Other values are not well tested and more CPU/GPU costly).
		public float ChildBorderSize;
		/// Radius of popup window corners rounding. (Note that tooltip windows use WindowRounding)
		public float PopupRounding;
		/// Thickness of border around popup/tooltip windows. Generally set to 0.0f or 1.0f. (Other values are not well tested and more CPU/GPU costly).
		public float PopupBorderSize;
		/// Padding within a framed rectangle (used by most widgets).
		public Unity.Mathematics.float2 FramePadding;
		/// Radius of frame corners rounding. Set to 0.0f to have rectangular frame (used by most widgets).
		public float FrameRounding;
		/// Thickness of border around frames. Generally set to 0.0f or 1.0f. (Other values are not well tested and more CPU/GPU costly).
		public float FrameBorderSize;
		/// Horizontal and vertical spacing between widgets/lines.
		public Unity.Mathematics.float2 ItemSpacing;
		/// Horizontal and vertical spacing between within elements of a composed widget (e.g. a slider and its label).
		public Unity.Mathematics.float2 ItemInnerSpacing;
		/// Padding within a table cell. CellPadding.y may be altered between different rows.
		public Unity.Mathematics.float2 CellPadding;
		/// Expand reactive bounding box for touch-based system where touch position is not accurate enough. Unfortunately we don't sort widgets so priority on overlap will always be given to the first widget. So don't grow this too much!
		public Unity.Mathematics.float2 TouchExtraPadding;
		/// Horizontal indentation when e.g. entering a tree node. Generally == (FontSize + FramePadding.x*2).
		public float IndentSpacing;
		/// Minimum horizontal spacing between two columns. Preferably &gt; (FramePadding.x + 1).
		public float ColumnsMinSpacing;
		/// Width of the vertical scrollbar, Height of the horizontal scrollbar.
		public float ScrollbarSize;
		/// Radius of grab corners for scrollbar.
		public float ScrollbarRounding;
		/// Minimum width/height of a grab box for slider/scrollbar.
		public float GrabMinSize;
		/// Radius of grabs corners rounding. Set to 0.0f to have rectangular slider grabs.
		public float GrabRounding;
		/// The size in pixels of the dead-zone around zero on logarithmic sliders that cross zero.
		public float LogSliderDeadzone;
		/// Radius of upper corners of a tab. Set to 0.0f to have rectangular tabs.
		public float TabRounding;
		/// Thickness of border around tabs.
		public float TabBorderSize;
		/// Minimum width for close button to appear on an unselected tab when hovered. Set to 0.0f to always show when hovering, set to FLT_MAX to never show close button unless selected.
		public float TabMinWidthForCloseButton;
		/// Thickness of tab-bar separator, which takes on the tab active color to denote focus.
		public float TabBarBorderSize;
		/// Angle of angled headers (supported values range from -50.0f degrees to +50.0f degrees).
		public float TableAngledHeadersAngle;
		/// Side of the color button in the ColorEdit4 widget (left/right). Defaults to ImGuiDir_Right.
		public ImGuiDir ColorButtonPosition;
		/// Alignment of button text when button is larger than text. Defaults to (0.5f, 0.5f) (centered).
		public Unity.Mathematics.float2 ButtonTextAlign;
		/// Alignment of selectable text. Defaults to (0.0f, 0.0f) (top-left aligned). It's generally important to keep this left-aligned if you want to lay multiple items on a same line.
		public Unity.Mathematics.float2 SelectableTextAlign;
		/// Thickkness of border in SeparatorText()
		public float SeparatorTextBorderSize;
		/// Alignment of text within the separator. Defaults to (0.0f, 0.5f) (left aligned, center).
		public Unity.Mathematics.float2 SeparatorTextAlign;
		/// Horizontal offset of text from each edge of the separator + spacing on other axis. Generally small values. .y is recommended to be == FramePadding.y.
		public Unity.Mathematics.float2 SeparatorTextPadding;
		/// Window position are clamped to be visible within the display area or monitors by at least this amount. Only applies to regular windows.
		public Unity.Mathematics.float2 DisplayWindowPadding;
		/// If you cannot see the edges of your screen (e.g. on a TV) increase the safe area padding. Apply to popups/tooltips as well regular windows. NB: Prefer configuring your TV sets correctly!
		public Unity.Mathematics.float2 DisplaySafeAreaPadding;
		/// Thickness of resizing border between docked windows
		public float DockingSeparatorSize;
		/// Scale software rendered mouse cursor (when io.MouseDrawCursor is enabled). We apply per-monitor DPI scaling over this scale. May be removed later.
		public float MouseCursorScale;
		/// Enable anti-aliased lines/borders. Disable if you are really tight on CPU/GPU. Latched at the beginning of the frame (copied to ImDrawList).
		public byte AntiAliasedLines;
		/// Enable anti-aliased lines/borders using textures where possible. Require backend to render with bilinear filtering (NOT point/nearest filtering). Latched at the beginning of the frame (copied to ImDrawList).
		public byte AntiAliasedLinesUseTex;
		/// Enable anti-aliased edges around filled shapes (rounded rectangles, circles, etc.). Disable if you are really tight on CPU/GPU. Latched at the beginning of the frame (copied to ImDrawList).
		public byte AntiAliasedFill;
		/// Tessellation tolerance when using PathBezierCurveTo() without a specific number of segments. Decrease for highly tessellated curves (higher quality, more polygons), increase to reduce quality.
		public float CurveTessellationTol;
		/// Maximum error (in pixels) allowed when using AddCircle()/AddCircleFilled() or drawing rounded corner rectangles with no explicit segment count specified. Decrease for higher quality but more geometry.
		public float CircleTessellationMaxError;
		public ImGuiStyle_ColorsArray Colors;
		/// Delay for IsItemHovered(ImGuiHoveredFlags_Stationary). Time required to consider mouse stationary.
		public float HoverStationaryDelay;
		/// Delay for IsItemHovered(ImGuiHoveredFlags_DelayShort). Usually used along with HoverStationaryDelay.
		public float HoverDelayShort;
		/// Delay for IsItemHovered(ImGuiHoveredFlags_DelayNormal). "
		public float HoverDelayNormal;
		/// Default flags when using IsItemHovered(ImGuiHoveredFlags_ForTooltip) or BeginItemTooltip()/SetItemTooltip() while using mouse.
		public ImGuiHoveredFlags HoverFlagsForTooltipMouse;
		/// Default flags when using IsItemHovered(ImGuiHoveredFlags_ForTooltip) or BeginItemTooltip()/SetItemTooltip() while using keyboard/gamepad.
		public ImGuiHoveredFlags HoverFlagsForTooltipNav;
	}

	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImGuiStyle_ColorsArray
	{
		public fixed byte Colors[((int)(ImGuiCol.COUNT))*(16)];
	}

	/// <summary>
	/// Sorting specification for one column of a table (sizeof == 12 bytes)
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImGuiTableColumnSortSpecs
	{
		/// User id of the column (if specified by a TableSetupColumn() call)
		public uint ColumnUserID;
		/// Index of the column
		public short ColumnIndex;
		/// Index within parent ImGuiTableSortSpecs (always stored in order starting from 0, tables sorted on a single criteria will always have a 0 here)
		public short SortOrder;
		/// ImGuiSortDirection_Ascending or ImGuiSortDirection_Descending
		public ImGuiSortDirection SortDirection;
	}

	/// <summary>
	/// Sorting specifications for a table (often handling sort specs for a single column, occasionally more)
	/// Obtained by calling TableGetSortSpecs().
	/// When 'SpecsDirty == true' you can sort your data. It will be true with sorting specs have changed since last call, or the first time.
	/// Make sure to set 'SpecsDirty = false' after sorting, else you may wastefully sort your data every frame!
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImGuiTableSortSpecs
	{
		/// Pointer to sort spec array.
		public ImGuiTableColumnSortSpecs* Specs;
		/// Sort spec count. Most often 1. May be &gt; 1 when ImGuiTableFlags_SortMulti is enabled. May be == 0 when ImGuiTableFlags_SortTristate is enabled.
		public int SpecsCount;
		/// Set to true when specs have changed since last time! Use this to sort again, then clear the flag.
		public byte SpecsDirty;
	}

	/// <summary>
	/// Helper: Growable text buffer for logging/accumulating text
	/// (this could be called 'ImGuiTextBuilder' / 'ImGuiStringBuilder')
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImGuiTextBuffer
	{
		public ImVector<byte> Buf;
	}

	/// <summary>
	/// Helper: Parse and apply text filters. In format "aaaaa[,bbbb][,ccccc]"
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImGuiTextFilter
	{
		public ImGuiTextFilter_InputBufArray InputBuf;
		public ImVector<ImGuiTextRange> Filters;
		public int CountGrep;
	}

	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImGuiTextFilter_InputBufArray
	{
		public fixed byte InputBuf[((int)(256))*(1)];
	}

	/// <summary>
    	/// [Internal]
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImGuiTextRange
	{
		public byte* b;
		public byte* e;
	}

	/// <summary>
	/// - Currently represents the Platform Window created by the application which is hosting our Dear ImGui windows.
	/// - With multi-viewport enabled, we extend this concept to have multiple active viewports.
	/// - In the future we will extend this concept further to also represent Platform Monitor and support a "no main platform window" operation mode.
	/// - About Main Area vs Work Area:
	///   - Main Area = entire viewport.
	///   - Work Area = entire viewport minus sections used by main menu bars (for platform windows), or by task bar (for platform monitor).
	///   - Windows are generally trying to stay within the Work Area of their host viewport.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImGuiViewport
	{
		/// Unique identifier for the viewport
		public uint ID;
		/// See ImGuiViewportFlags_
		public ImGuiViewportFlags Flags;
		/// Main Area: Position of the viewport (Dear ImGui coordinates are the same as OS desktop/native coordinates)
		public Unity.Mathematics.float2 Pos;
		/// Main Area: Size of the viewport.
		public Unity.Mathematics.float2 Size;
		/// Work Area: Position of the viewport minus task bars, menus bars, status bars (&gt;= Pos)
		public Unity.Mathematics.float2 WorkPos;
		/// Work Area: Size of the viewport minus task bars, menu bars, status bars (&lt;= Size)
		public Unity.Mathematics.float2 WorkSize;
		/// 1.0f = 96 DPI = No extra scale.
		public float DpiScale;
		/// (Advanced) 0: no parent. Instruct the platform backend to setup a parent/child relationship between platform windows.
		public uint ParentViewportId;
		/// The ImDrawData corresponding to this viewport. Valid after Render() and until the next call to NewFrame().
		public ImDrawData* DrawData;
		/// void* to hold custom data structure for the renderer (e.g. swap chain, framebuffers etc.). generally set by your Renderer_CreateWindow function.
		public void* RendererUserData;
		/// void* to hold custom data structure for the OS / platform (e.g. windowing info, render context). generally set by your Platform_CreateWindow function.
		public void* PlatformUserData;
		/// void* for FindViewportByPlatformHandle(). (e.g. suggested to use natural platform handle such as HWND, GLFWWindow*, SDL_Window*)
		public void* PlatformHandle;
		/// void* to hold lower-level, platform-native window handle (under Win32 this is expected to be a HWND, unused for other platforms), when using an abstraction layer like GLFW or SDL (where PlatformHandle would be a SDL_Window*)
		public void* PlatformHandleRaw;
		/// Platform window has been created (Platform_CreateWindow() has been called). This is false during the first frame where a viewport is being created.
		public byte PlatformWindowCreated;
		/// Platform window requested move (e.g. window was moved by the OS / host window manager, authoritative position will be OS window position)
		public byte PlatformRequestMove;
		/// Platform window requested resize (e.g. window was resized by the OS / host window manager, authoritative size will be OS window size)
		public byte PlatformRequestResize;
		/// Platform window requested closure (e.g. window was moved by the OS / host window manager, e.g. pressing ALT-F4)
		public byte PlatformRequestClose;
	}

	/// <summary>
	/// [ALPHA] Rarely used / very advanced uses only. Use with SetNextWindowClass() and DockSpace() functions.
	/// Important: the content of this class is still highly WIP and likely to change and be refactored
	/// before we stabilize Docking features. Please be mindful if using this.
	/// Provide hints:
	/// - To the platform backend via altered viewport flags (enable/disable OS decoration, OS task bar icons, etc.)
	/// - To the platform backend for OS level parent/child relationships of viewport.
	/// - To the docking system for various options and filtering.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ImGuiWindowClass
	{
		/// User data. 0 = Default class (unclassed). Windows of different classes cannot be docked with each others.
		public uint ClassId;
		/// Hint for the platform backend. -1: use default. 0: request platform backend to not parent the platform. != 0: request platform backend to create a parent&lt;&gt;child relationship between the platform windows. Not conforming backends are free to e.g. parent every viewport to the main viewport or not.
		public uint ParentViewportId;
		/// ID of parent window for shortcut focus route evaluation, e.g. Shortcut() call from Parent Window will succeed when this window is focused.
		public uint FocusRouteParentWindowId;
		/// Viewport flags to set when a window of this class owns a viewport. This allows you to enforce OS decoration or task bar icon, override the defaults on a per-window basis.
		public ImGuiViewportFlags ViewportFlagsOverrideSet;
		/// Viewport flags to clear when a window of this class owns a viewport. This allows you to enforce OS decoration or task bar icon, override the defaults on a per-window basis.
		public ImGuiViewportFlags ViewportFlagsOverrideClear;
		/// [EXPERIMENTAL] TabItem flags to set when a window of this class gets submitted into a dock node tab bar. May use with ImGuiTabItemFlags_Leading or ImGuiTabItemFlags_Trailing.
		public ImGuiTabItemFlags TabItemFlagsOverrideSet;
		/// [EXPERIMENTAL] Dock node flags to set when a window of this class is hosted by a dock node (it doesn't have to be selected!)
		public ImGuiDockNodeFlags DockNodeFlagsOverrideSet;
		/// Set to true to enforce single floating windows of this class always having their own docking node (equivalent of setting the global io.ConfigDockingAlwaysTabBar)
		public byte DockingAlwaysTabBar;
		/// Set to true to allow windows of this class to be docked/merged with an unclassed window. // FIXME-DOCK: Move to DockNodeFlags override?
		public byte DockingAllowUnclassed;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe partial struct ImVector<T> where T : unmanaged
	{
		public int Size;
		public int Capacity;
		public T* Data;
	}

}
