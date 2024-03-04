#define IMGUI_DISABLE_OBSOLETE_KEYIO
#define IMGUI_DISABLE_OBSOLETE_FUNCTIONS

using System;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;
using ImGuiID = System.UInt32;
using ImWchar = System.UInt32;
using ImDrawIdx = System.UInt16;

namespace com.daxode.imgui
{

#pragma warning disable CS0414 // Field is assigned but its value is never used

	static class ImGui
	{
		public static unsafe ImGuiContext* GetCurrentContext() => NativeImGuiMethods.igGetCurrentContext();
		public static unsafe void DestroyContext(ImGuiContext* context) => NativeImGuiMethods.igDestroyContext(context);
		public static unsafe ImDrawData* GetDrawData() => NativeImGuiMethods.igGetDrawData();
		public static void Render() => NativeImGuiMethods.igRender();
		
		public static void End() => NativeImGuiMethods.igEnd();
		
		public static unsafe void ShowDemoWindow(ref bool p_open)
			=> NativeImGuiMethods.igShowDemoWindow((byte*)UnsafeUtility.AddressOf(ref p_open));

		public static unsafe ImGuiID DockSpace(ImGuiID id, float2 size = default, ImGuiDockNodeFlags flags = 0, ImGuiWindowClass* windowClass = null)
			=> NativeImGuiMethods.igDockSpace(id, size, flags, windowClass);

		/// calculate unique ID (hash of whole ID stack + given parameter). e.g. if you want to query into ImGuiStorage yourself
		public static unsafe ImGuiID GetID(FixedString128Bytes strId)
			=> NativeImGuiMethods.igGetID_Str(strId.GetUnsafePtr());

		
		/// push width of items for common large "item+label" widgets. &gt;0.0f: width in pixels, &lt;0.0f align xx pixels to the right of window (so -FLT_MIN always align width to the right side).
		public static void PushItemWidth(float item_width) => NativeImGuiMethods.igPushItemWidth(item_width);
		public static void PopItemWidth() => NativeImGuiMethods.igPopItemWidth();

		public static unsafe void Begin(FixedString128Bytes anotherWindow, ImGuiWindowFlags flags = 0)
			=> NativeImGuiMethods.igBegin(anotherWindow.GetUnsafePtr(), null, flags);

		public static unsafe void Begin(FixedString128Bytes anotherWindow, ref bool b, ImGuiWindowFlags flags = 0)
			=> NativeImGuiMethods.igBegin(anotherWindow.GetUnsafePtr(), (byte*)UnsafeUtility.AddressOf(ref b), flags);

		public static unsafe void Begin(NativeText anotherWindow, ref bool b, ImGuiWindowFlags flags = 0)
			=> NativeImGuiMethods.igBegin((byte*)anotherWindow.GetUnsafePtr(), (byte*)UnsafeUtility.AddressOf(ref b), flags);
		

		public static void Image(UnityObjRef<Texture2D> user_texture_id, float2 image_size,
			float2 uv0 = default)
		{
			NativeImGuiMethods.igImage(UnsafeUtility.As<UnityObjRef<Texture2D>, UnityObjRef<Texture2D>>(ref user_texture_id), image_size,
				uv0, new float2(1, 1), new float4(1, 1, 1, 1), default);
		}

		public static void Image(UnityObjRef<Texture2D> user_texture_id, float2 image_size,
			float2 uv0, float2 uv1)
		{
			NativeImGuiMethods.igImage(UnsafeUtility.As<UnityObjRef<Texture2D>, UnityObjRef<Texture2D>>(ref user_texture_id), image_size,
				uv0, uv1, new float4(1, 1, 1, 1), default);
		}

		public static void Image(UnityObjRef<Texture2D> user_texture_id, float2 image_size,
			float2 uv0, float2 uv1, float4 tint_col, float4 border_col = default)
		{
			NativeImGuiMethods.igImage(UnsafeUtility.As<UnityObjRef<Texture2D>, UnityObjRef<Texture2D>>(ref user_texture_id), image_size,
				uv0, uv1, tint_col, border_col);
		}

		public static void SetNextWindowPos(float2 pos, ImGuiCond cond = 0, float2 pivot = default)
			=> NativeImGuiMethods.igSetNextWindowPos(pos, cond, pivot);

		public static unsafe void Text(FixedString128Bytes text) => NativeImGuiMethods.igText(text.GetUnsafePtr());
		public static unsafe void Text(NativeText text) => NativeImGuiMethods.igText(text.GetUnsafePtr());
		
		public static unsafe bool Checkbox(FixedString128Bytes demoWindow, ref bool p1)
			=> NativeImGuiMethods.igCheckbox(demoWindow.GetUnsafePtr(), (byte*) UnsafeUtility.AddressOf(ref p1)) > 0;

		/// adjust format to decorate the value with a prefix or a suffix for in-slider labels or unit display.
		public static unsafe bool SliderFloat(FixedString128Bytes f, ref float currentVal, float from, float to)
		{
			FixedString128Bytes defaultFormat = "%.3g";
			return NativeImGuiMethods.igSliderFloat(f.GetUnsafePtr(), (float*)UnsafeUtility.AddressOf(ref currentVal), from, to, defaultFormat.GetUnsafePtr(), 0) > 0;
		}


		
		public static unsafe bool InputText(FixedString128Bytes label, ref FixedString512Bytes buf, ImGuiInputTextFlags flags = 0, ImGuiInputTextCallback callback = default)
			=> NativeImGuiMethods.igInputText(label.GetUnsafePtr(), buf.GetUnsafePtr(), (UIntPtr)buf.Capacity, flags, callback.Value, null) > 0; // user_data is in overload to avoid unsafe parameter

		public static unsafe bool InputText(FixedString128Bytes label, ref FixedString512Bytes buf, ImGuiInputTextFlags flags, ImGuiInputTextCallback callback, void* userData)
			=> NativeImGuiMethods.igInputText(label.GetUnsafePtr(), buf.GetUnsafePtr(), (UIntPtr)buf.Capacity, flags, callback.Value, userData) > 0;


		public static unsafe bool InputTextMultiline(FixedString128Bytes label, ref FixedString512Bytes buf, float2 size = default, ImGuiInputTextFlags flags = 0, ImGuiInputTextCallback callback = default)
			=> NativeImGuiMethods.igInputTextMultiline(label.GetUnsafePtr(), buf.GetUnsafePtr(), (UIntPtr)buf.Capacity, size, flags, callback.Value, null) > 0; // user_data is in overload to avoid unsafe parameter

		public static unsafe bool InputTextMultiline(FixedString128Bytes label, ref FixedString512Bytes buf, float2 size, ImGuiInputTextFlags flags, ImGuiInputTextCallback callback, void* userData)
			=> NativeImGuiMethods.igInputTextMultiline(label.GetUnsafePtr(), buf.GetUnsafePtr(), (UIntPtr)buf.Capacity, size, flags, callback.Value, userData) > 0;

		public static unsafe bool InputTextMultiline(FixedString128Bytes label, ref NativeText buf, float2 size = default, ImGuiInputTextFlags flags = 0, ImGuiInputTextCallback callback = default)
			=> NativeImGuiMethods.igInputTextMultiline(label.GetUnsafePtr(), buf.GetUnsafePtr(), (UIntPtr)buf.Capacity, size, flags, callback.Value, null) > 0; // user_data is in overload to avoid unsafe parameter

		public static unsafe bool InputTextMultiline(FixedString128Bytes label, ref NativeText buf, float2 size, ImGuiInputTextFlags flags, ImGuiInputTextCallback callback, void* userData)
			=> NativeImGuiMethods.igInputTextMultiline(label.GetUnsafePtr(), buf.GetUnsafePtr(), (UIntPtr) buf.Capacity, size, flags, callback.Value, userData) > 0;
		public static unsafe bool InputTextWithHint(FixedString128Bytes label, FixedString128Bytes hint, ref FixedString512Bytes buf, ImGuiInputTextFlags flags = 0, ImGuiInputTextCallback callback = default)
			=> NativeImGuiMethods.igInputTextWithHint(label.GetUnsafePtr(), hint.GetUnsafePtr(), buf.GetUnsafePtr(), (UIntPtr)buf.Capacity, flags, callback.Value, null) > 0; // user_data is in overload to avoid unsafe parameter
		public static unsafe bool InputTextWithHint(FixedString128Bytes label, FixedString128Bytes hint, ref FixedString512Bytes buf, ImGuiInputTextFlags flags, ImGuiInputTextCallback callback, void* userData)
			=> NativeImGuiMethods.igInputTextWithHint(label.GetUnsafePtr(), hint.GetUnsafePtr(), buf.GetUnsafePtr(), (UIntPtr)buf.Capacity, flags, callback.Value, userData) > 0;
		

		public static bool IsItemDeactivatedAfterEdit() => NativeImGuiMethods.igIsItemDeactivatedAfterEdit() > 0;
		public static unsafe bool ColorEdit3(FixedString128Bytes clearColor, ref float4 f, ImGuiColorEditFlags flags = 0)
			=> NativeImGuiMethods.igColorEdit3(clearColor.GetUnsafePtr(), (float*)UnsafeUtility.AddressOf(ref f), flags) > 0;
		public static unsafe bool ColorEdit3(FixedString128Bytes clearColor, ref Color f, ImGuiColorEditFlags flags = 0)
			=> NativeImGuiMethods.igColorEdit3(clearColor.GetUnsafePtr(), (float*)UnsafeUtility.AddressOf(ref f), flags) > 0;
		public static unsafe bool ColorEdit3(FixedString128Bytes clearColor, ref float3 f, ImGuiColorEditFlags flags = 0)
			=> NativeImGuiMethods.igColorEdit3(clearColor.GetUnsafePtr(), (float*)UnsafeUtility.AddressOf(ref f), flags) > 0;
		public static unsafe bool ColorEdit4(FixedString128Bytes clearColor, ref float4 f, ImGuiColorEditFlags flags = 0)
			=> NativeImGuiMethods.igColorEdit4(clearColor.GetUnsafePtr(), (float*)UnsafeUtility.AddressOf(ref f), flags) > 0;
		public static unsafe bool ColorEdit4(FixedString128Bytes clearColor, ref Color f, ImGuiColorEditFlags flags = 0)
			=> NativeImGuiMethods.igColorEdit4(clearColor.GetUnsafePtr(), (float*)UnsafeUtility.AddressOf(ref f), flags) > 0;
		public static unsafe bool Button(FixedString128Bytes button, float2 size = default)
			=> NativeImGuiMethods.igButton(button.GetUnsafePtr(), size) > 0;
		public static void SameLine(float offset_from_start_x = 0.0f, float spacing = -1.0f)
			=> NativeImGuiMethods.igSameLine(offset_from_start_x, spacing);
		public static unsafe ImGuiIO* GetIO() => NativeImGuiMethods.igGetIO();
		public static unsafe void StyleColorsDark(out ImGuiStyle dst) 
			=> NativeImGuiMethods.igStyleColorsDark(out dst);
		public static void NewFrame() => NativeImGuiMethods.igNewFrame();
		public static unsafe ImGuiContext* CreateContext(ImFontAtlas* shared_font_atlas = null)
			=> NativeImGuiMethods.igCreateContext(shared_font_atlas); 
		public static void SetNextWindowBgAlpha(float alpha) 
			=> NativeImGuiMethods.igSetNextWindowBgAlpha(alpha);
		
		/// modify a style color. always use this if you modify the style after NewFrame().
		public static void PushStyleColor(ImGuiCol idx, Color32 col) 
			=> NativeImGuiMethods.igPushStyleColor_U32(idx, UnsafeUtility.As<Color32, uint>(ref col));
		public static void PushStyleColor(ImGuiCol idx, float4 col) => 
			NativeImGuiMethods.igPushStyleColor_Vec4(idx, col);
		public static void PushStyleColor(ImGuiCol idx, Color col) => 
			NativeImGuiMethods.igPushStyleColor_Vec4(idx, UnsafeUtility.As<Color, float4>(ref col));
		
		public static void PopStyleColor(int count = 1) 
			=> NativeImGuiMethods.igPopStyleColor(count);

		/// modify a style float variable. always use this if you modify the style after NewFrame().
		public static void PushStyleVar(ImGuiStyleVar idx, float val) 
			=> NativeImGuiMethods.igPushStyleVar_Float(idx, val);

		/// modify a style ImVec2 variable. always use this if you modify the style after NewFrame().
		public static void PushStyleVar(ImGuiStyleVar idx, float2 val) 
			=> NativeImGuiMethods.igPushStyleVar_Vec2(idx, val);

		/// Pop `count` style variable changes.
		public static void PopStyleVar(int count = 1) => NativeImGuiMethods.igPopStyleVar(count);

		/// set next window size. set axis to 0.0f to force an auto-fit on this axis. call before Begin()
		public static void SetNextWindowSize(float2 size, ImGuiCond cond = 0) 
			=> NativeImGuiMethods.igSetNextWindowSize(size, cond);
		public static unsafe void CheckVersion()
			=> DebugCheckVersionAndDataLayout("1.90.5 WIP",
				sizeof(ImGuiIO), sizeof(ImGuiStyle), sizeof(float2),
				sizeof(float4), sizeof(ImDrawVert), sizeof(ImDrawIdx));
		static unsafe bool DebugCheckVersionAndDataLayout(FixedString128Bytes version_str, int sz_io, int sz_style, int sz_vec2, int sz_vec4, int sz_drawvert, int sz_drawidx)
			=> NativeImGuiMethods.igDebugCheckVersionAndDataLayout(version_str.GetUnsafePtr(), (UIntPtr)sz_io, (UIntPtr)sz_style, (UIntPtr)sz_vec2, (UIntPtr)sz_vec4, (UIntPtr)sz_drawvert, (UIntPtr)sz_drawidx) > 0;
	}

	public static class ImGuiHelper
	{
		public static unsafe bool NewFrameSafe()
		{
			// Start the Dear ImGui frame
			if (ImGui.GetCurrentContext() == null || RenderHooks.GetBackendData() == null)
				return false;

			if (RenderHooks.IsNewFrame)
			{
				RenderHooks.NewFrame();
				InputAndWindowHooks.NewFrame();
				ImGui.NewFrame();
			}

			return true;
		}
	}

	/// Callback function for ImGui::InputText()
	unsafe struct ImGuiInputTextCallback
	{
		public delegate* unmanaged[Cdecl] <ImGuiInputTextCallbackData*, int> Value;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct Ptr<T> where T : unmanaged
	{
		public T* Value;
	}
	
	unsafe partial struct ImVector<T> where T : unmanaged
	{
		public ref T this[int index] => ref UnsafeUtility.ArrayElementAsRef<T>(Data, index);
	}

	unsafe struct ImDrawCallback
	{
		public static delegate* unmanaged[Cdecl]<ImDrawList*, ImDrawCmd*, void> ResetRenderState 
			=> (delegate* unmanaged[Cdecl]<ImDrawList*, ImDrawCmd*, void>)k_ResetRenderState;
		const nint k_ResetRenderState = -8;
	}

	unsafe partial struct ImDrawCmd
	{
		public UnityObjRef<Texture2D> GetTexID() => TextureId;
	};
	
	public struct ImFontBuilderIO{}
	public struct ImDrawListSharedData{}
	public struct ImGuiContext{}

	unsafe partial struct ImGuiIO
	{
		/// Queue a new key down/up event. Key should be "translated" (as in, generally ImGuiKey_A matches the key end-user would use to emit an 'A' character)
		public void AddKeyEvent(ImGuiKey key, bool down) 
			=> NativeImGuiMethods.ImGuiIO_AddKeyEvent((ImGuiIO*)UnsafeUtility.AddressOf(ref this), key, down ? (byte)1 : (byte)0);
		/// Queue a new key down/up event for analog values (e.g. ImGuiKey_Gamepad_ values). Dead-zones should be handled by the backend.
		public void AddKeyAnalogEvent(ImGuiKey key, byte down, float v) 
			=> NativeImGuiMethods.ImGuiIO_AddKeyAnalogEvent((ImGuiIO*)UnsafeUtility.AddressOf(ref this), key, down, v);
		public unsafe void AddMousePosEvent(float x, float y) 
			 => NativeImGuiMethods.ImGuiIO_AddMousePosEvent((ImGuiIO*)UnsafeUtility.AddressOf(ref this), x, y);
		public void AddMouseButtonEvent(int button, byte down) 
			=> NativeImGuiMethods.ImGuiIO_AddMouseButtonEvent((ImGuiIO*)UnsafeUtility.AddressOf(ref this), button, down);
		public void AddMouseWheelEvent(float wheel_x, float wheel_y) 
			=> NativeImGuiMethods.ImGuiIO_AddMouseWheelEvent((ImGuiIO*)UnsafeUtility.AddressOf(ref this), wheel_x, wheel_y);


		/// Queue a mouse source change (Mouse/TouchScreen/Pen)
		public void AddMouseSourceEvent(ImGuiMouseSource source) 
			=> NativeImGuiMethods.ImGuiIO_AddMouseSourceEvent((ImGuiIO*)UnsafeUtility.AddressOf(ref this), source);

		/// Queue a gain/loss of focus for the application (generally based on OS/platform focus of your window)
		public void AddFocusEvent(bool focused) 
			=> NativeImGuiMethods.ImGuiIO_AddFocusEvent((ImGuiIO*)UnsafeUtility.AddressOf(ref this), focused ? (byte)1 : (byte)0);
		
		/// Queue a new characters input from a UTF-8 string
		public void AddInputCharactersUTF8(FixedString128Bytes str) 
			=> NativeImGuiMethods.ImGuiIO_AddInputCharactersUTF8((ImGuiIO*)UnsafeUtility.AddressOf(ref this), str.GetUnsafePtr());
		
		/// Clear all incoming events.
		public void ClearEventsQueue() 
			=> NativeImGuiMethods.ImGuiIO_ClearEventsQueue((ImGuiIO*)UnsafeUtility.AddressOf(ref this));

		/// Clear current keyboard/mouse/gamepad state + current frame text input buffer. Equivalent to releasing all keys/buttons.
		public void ClearInputKeys() 
			=> NativeImGuiMethods.ImGuiIO_ClearInputKeys((ImGuiIO*)UnsafeUtility.AddressOf(ref this));
	}

// Load and rasterize multiple TTF/OTF fonts into a same texture. The font atlas will build a single texture holding:
//  - One or more fonts.
//  - Custom graphics data needed to render the shapes needed by Dear ImGui.
//  - Mouse cursor shapes for software cursor rendering (unless setting 'Flags |= NoMouseCursors' in the font atlas).
// It is the user-code responsibility to setup/build the atlas, then upload the pixel data into a texture accessible by your graphics api.
//  - Optionally, call any of the AddFont*** functions. If you don't call any, the default font embedded in the code will be loaded for you.
//  - Call GetTexDataAsAlpha8() or GetTexDataAsRGBA32() to build and retrieve pixels data.
//  - Upload the pixels data into a texture within your graphics system (see imgui_impl_xxxx.cpp examples)
//  - Call SetTexID(my_tex_id); and pass the pointer/identifier to your texture in a format natural to your graphics API.
//    This value will be passed back to you during rendering to identify the texture. Read FAQ entry about UnityObjRef<Texture2D> for more details.
// Common pitfalls:
// - If you pass a 'glyph_ranges' array to AddFont*** functions, you need to make sure that your array persist up until the
//   atlas is build (when calling GetTexData*** or Build()). We only copy the pointer, not the data.
// - Important: By default, AddFontFromMemoryTTF() takes ownership of the data. Even though we are not writing to it, we will free the pointer on destruction.
//   You can set font_cfg->FontDataOwnedByAtlas=false to keep ownership of your data and it won't be freed,
// - Even though many functions are suffixed with "TTF", OTF data is supported just as well.
// - This is an old API and it is currently awkward for those and various other reasons! We will address them in the future!
	unsafe partial struct ImFontAtlas
	{
		public ImFont* AddFontDefault(ImFontConfig* font_cfg = null) => NativeImGuiMethods.ImFontAtlas_AddFontDefault((ImFontAtlas*)UnsafeUtility.AddressOf(ref this), font_cfg);
		
		public ImFont* AddFontFromFileTTF(FixedString512Bytes filename, float size_pixels, ImFontConfig* font_cfg = null, ImWchar* glyph_ranges = null)
			=> NativeImGuiMethods.ImFontAtlas_AddFontFromFileTTF((ImFontAtlas*)UnsafeUtility.AddressOf(ref this), filename.GetUnsafePtr(), size_pixels, font_cfg, glyph_ranges);

		public void Clear() => NativeImGuiMethods.ImFontAtlas_Clear((ImFontAtlas*)UnsafeUtility.AddressOf(ref this));

		public void GetTexDataAsAlpha8(out byte* out_pixels, out int out_width, out int out_height, out int out_bytes_per_pixel)
			=> NativeImGuiMethods.ImFontAtlas_GetTexDataAsAlpha8((ImFontAtlas*)UnsafeUtility.AddressOf(ref this), out out_pixels, out out_width, out out_height, out out_bytes_per_pixel);
		
		public void GetTexDataAsRGBA32(out byte* out_pixels, out int out_width, out int out_height, out int out_bytes_per_pixel)
			=> NativeImGuiMethods.ImFontAtlas_GetTexDataAsRGBA32((ImFontAtlas*)UnsafeUtility.AddressOf(ref this), out out_pixels, out out_width, out out_height, out out_bytes_per_pixel);

		internal bool IsBuilt() => Fonts.Size > 0 && TexReady>0; // Bit ambiguous: used to detect when user didn't build texture but effectively we should check TexID != 0 except that would be backend dependent...

		public void SetTexID(UnityObjRef<Texture2D> id)
		{
			TexID = id;
		}
	}

	enum ImGuiKeyNamedKey
	{
		BEGIN = 512,
		END = (int)ImGuiKey.COUNT,
		COUNT = END - BEGIN,
	}

	enum ImGuiKeyKeysData
	{
		SIZE = ImGuiKeyNamedKey.COUNT,
		OFFSET = ImGuiKeyNamedKey.BEGIN,
	}
	
	/// Keyboard Modifiers (explicitly submitted by backend via AddKeyEvent() calls)
	/// - This is mirroring the data also written to io.KeyCtrl, io.KeyShift, io.KeyAlt, io.KeySuper, in a format allowing
	///   them to be accessed via standard key API, allowing calls such as IsKeyPressed(), IsKeyReleased(), querying duration etc.
	/// - Code polling every key (e.g. an interface to detect a key press for input mapping) might want to ignore those
	///   and prefer using the real keys (e.g. LeftCtrl, RightCtrl instead of ImGuiMod_Ctrl).
	/// - In theory the value of keyboard modifiers should be roughly equivalent to a logical or of the equivalent left/right keys.
	///   In practice: it's complicated; mods are often provided from different sources. Keyboard layout, IME, sticky keys and
	///   backends tend to interfere and break that equivalence. The safer decision is to relay that ambiguity down to the end-user...
	[Flags]
	enum ImGuiModFlags
	{
		None                   = 0,
        /// Ctrl
		Ctrl                   = 1 << 12, 
        /// Shift
		Shift                  = 1 << 13, 
        /// Option/Menu
		Alt                    = 1 << 14, 
        /// Cmd/Super/Windows
		Super                  = 1 << 15, 
		/// Alias for Ctrl (non-macOS) _or_ Super (macOS).
		Shortcut               = 1 << 11, 
		/// 5-bits
		Mask_                  = 0xF800,  
	}
	
	[StructLayout(LayoutKind.Explicit)]
	unsafe struct ImGuiStoragePairUnion {
		[FieldOffset(0)]
		public int val_i; 
		[FieldOffset(0)]
		public float val_f; 
		[FieldOffset(0)]
		public void* val_p;
	}
	
	[StructLayout(LayoutKind.Explicit)]
	unsafe struct ImGuiStyleModUnion {
		[FieldOffset(0)]
		public fixed int BackupInt[2]; 
		[FieldOffset(0)]
		public fixed float BackupFloat[2];
	}
}