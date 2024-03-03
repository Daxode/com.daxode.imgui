using System;
using System.Runtime.InteropServices;
namespace com.daxode.imgui
{
	internal static class NativeImGuiMethods
	{
#region ImColor
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImColor_HSV(UnityEngine.Color* pOut, float h, float s, float v, float a);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImColor_SetHSV(UnityEngine.Color* self, float h, float s, float v, float a);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImColor_destroy(UnityEngine.Color* self);
#endregion
#region ImDrawCmd
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe UnityObjRef<UnityEngine.Texture2D> ImDrawCmd_GetTexID(ImDrawCmd* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawCmd_destroy(ImDrawCmd* self);
#endregion
#region ImDrawData
		/// <summary>
		/// Helper to add an external draw list into an existing ImDrawData.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawData_AddDrawList(ImDrawData* self, ImDrawList* draw_list);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawData_Clear(ImDrawData* self);
		/// <summary>
		/// Helper to convert all buffers from indexed to non-indexed, in case you cannot render indexed. Note: this is slow and most likely a waste of resources. Always prefer indexed rendering!
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawData_DeIndexAllBuffers(ImDrawData* self);
		/// <summary>
		/// Helper to scale the ClipRect field of each ImDrawCmd. Use if your final output buffer is at a different scale than Dear ImGui expects, or if there is a difference between your window resolution and framebuffer resolution.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawData_ScaleClipRects(ImDrawData* self, Unity.Mathematics.float2 fb_scale);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawData_destroy(ImDrawData* self);
#endregion
#region ImDrawListSplitter
		/// <summary>
		/// Do not clear Channels[] so our allocations are reused next frame
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawListSplitter_Clear(ImDrawListSplitter* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawListSplitter_ClearFreeMemory(ImDrawListSplitter* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawListSplitter_Merge(ImDrawListSplitter* self, ImDrawList* draw_list);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawListSplitter_SetCurrentChannel(ImDrawListSplitter* self, ImDrawList* draw_list, int channel_idx);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawListSplitter_Split(ImDrawListSplitter* self, ImDrawList* draw_list, int count);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawListSplitter_destroy(ImDrawListSplitter* self);
#endregion
#region ImDrawList
		/// <summary>
		/// Cubic Bezier (4 control points)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_AddBezierCubic(ImDrawList* self, Unity.Mathematics.float2 p1, Unity.Mathematics.float2 p2, Unity.Mathematics.float2 p3, Unity.Mathematics.float2 p4, uint col, float thickness, int num_segments);
		/// <summary>
		/// Quadratic Bezier (3 control points)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_AddBezierQuadratic(ImDrawList* self, Unity.Mathematics.float2 p1, Unity.Mathematics.float2 p2, Unity.Mathematics.float2 p3, uint col, float thickness, int num_segments);
		/// <summary>
		/// Your rendering function must check for 'UserCallback' in ImDrawCmd and call the function instead of rendering triangles.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_AddCallback(ImDrawList* self, delegate* unmanaged[Cdecl]<ImDrawList*, ImDrawCmd*, void> callback, void* callback_data);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_AddCircle(ImDrawList* self, Unity.Mathematics.float2 center, float radius, uint col, int num_segments, float thickness);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_AddCircleFilled(ImDrawList* self, Unity.Mathematics.float2 center, float radius, uint col, int num_segments);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_AddConvexPolyFilled(ImDrawList* self, Unity.Mathematics.float2* points, int num_points, uint col);
		/// <summary>
		/// This is useful if you need to forcefully create a new draw call (to allow for dependent rendering / blending). Otherwise primitives are merged into the same draw-call as much as possible
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_AddDrawCmd(ImDrawList* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_AddEllipse(ImDrawList* self, Unity.Mathematics.float2 center, float radius_x, float radius_y, uint col, float rot, int num_segments, float thickness);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_AddEllipseFilled(ImDrawList* self, Unity.Mathematics.float2 center, float radius_x, float radius_y, uint col, float rot, int num_segments);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_AddImage(ImDrawList* self, UnityObjRef<UnityEngine.Texture2D> user_texture_id, Unity.Mathematics.float2 p_min, Unity.Mathematics.float2 p_max, Unity.Mathematics.float2 uv_min, Unity.Mathematics.float2 uv_max, uint col);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_AddImageQuad(ImDrawList* self, UnityObjRef<UnityEngine.Texture2D> user_texture_id, Unity.Mathematics.float2 p1, Unity.Mathematics.float2 p2, Unity.Mathematics.float2 p3, Unity.Mathematics.float2 p4, Unity.Mathematics.float2 uv1, Unity.Mathematics.float2 uv2, Unity.Mathematics.float2 uv3, Unity.Mathematics.float2 uv4, uint col);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_AddImageRounded(ImDrawList* self, UnityObjRef<UnityEngine.Texture2D> user_texture_id, Unity.Mathematics.float2 p_min, Unity.Mathematics.float2 p_max, Unity.Mathematics.float2 uv_min, Unity.Mathematics.float2 uv_max, uint col, float rounding, ImDrawFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_AddLine(ImDrawList* self, Unity.Mathematics.float2 p1, Unity.Mathematics.float2 p2, uint col, float thickness);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_AddNgon(ImDrawList* self, Unity.Mathematics.float2 center, float radius, uint col, int num_segments, float thickness);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_AddNgonFilled(ImDrawList* self, Unity.Mathematics.float2 center, float radius, uint col, int num_segments);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_AddPolyline(ImDrawList* self, Unity.Mathematics.float2* points, int num_points, uint col, ImDrawFlags flags, float thickness);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_AddQuad(ImDrawList* self, Unity.Mathematics.float2 p1, Unity.Mathematics.float2 p2, Unity.Mathematics.float2 p3, Unity.Mathematics.float2 p4, uint col, float thickness);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_AddQuadFilled(ImDrawList* self, Unity.Mathematics.float2 p1, Unity.Mathematics.float2 p2, Unity.Mathematics.float2 p3, Unity.Mathematics.float2 p4, uint col);
		/// <summary>
		/// a: upper-left, b: lower-right (== upper-left + size)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_AddRect(ImDrawList* self, Unity.Mathematics.float2 p_min, Unity.Mathematics.float2 p_max, uint col, float rounding, ImDrawFlags flags, float thickness);
		/// <summary>
		/// a: upper-left, b: lower-right (== upper-left + size)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_AddRectFilled(ImDrawList* self, Unity.Mathematics.float2 p_min, Unity.Mathematics.float2 p_max, uint col, float rounding, ImDrawFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_AddRectFilledMultiColor(ImDrawList* self, Unity.Mathematics.float2 p_min, Unity.Mathematics.float2 p_max, uint col_upr_left, uint col_upr_right, uint col_bot_right, uint col_bot_left);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_AddText_Vec2(ImDrawList* self, Unity.Mathematics.float2 pos, uint col, byte* text_begin, byte* text_end);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_AddText_FontPtr(ImDrawList* self, ImFont* font, float font_size, Unity.Mathematics.float2 pos, uint col, byte* text_begin, byte* text_end, float wrap_width, Unity.Mathematics.float4* cpu_fine_clip_rect);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_AddTriangle(ImDrawList* self, Unity.Mathematics.float2 p1, Unity.Mathematics.float2 p2, Unity.Mathematics.float2 p3, uint col, float thickness);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_AddTriangleFilled(ImDrawList* self, Unity.Mathematics.float2 p1, Unity.Mathematics.float2 p2, Unity.Mathematics.float2 p3, uint col);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_ChannelsMerge(ImDrawList* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_ChannelsSetCurrent(ImDrawList* self, int n);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_ChannelsSplit(ImDrawList* self, int count);
		/// <summary>
		/// Create a clone of the CmdBuffer/IdxBuffer/VtxBuffer.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe ImDrawList* ImDrawList_CloneOutput(ImDrawList* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_GetClipRectMax(Unity.Mathematics.float2* pOut, ImDrawList* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_GetClipRectMin(Unity.Mathematics.float2* pOut, ImDrawList* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_PathArcTo(ImDrawList* self, Unity.Mathematics.float2 center, float radius, float a_min, float a_max, int num_segments);
		/// <summary>
		/// Use precomputed angles for a 12 steps circle
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_PathArcToFast(ImDrawList* self, Unity.Mathematics.float2 center, float radius, int a_min_of_12, int a_max_of_12);
		/// <summary>
		/// Cubic Bezier (4 control points)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_PathBezierCubicCurveTo(ImDrawList* self, Unity.Mathematics.float2 p2, Unity.Mathematics.float2 p3, Unity.Mathematics.float2 p4, int num_segments);
		/// <summary>
		/// Quadratic Bezier (3 control points)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_PathBezierQuadraticCurveTo(ImDrawList* self, Unity.Mathematics.float2 p2, Unity.Mathematics.float2 p3, int num_segments);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_PathClear(ImDrawList* self);
		/// <summary>
		/// Ellipse
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_PathEllipticalArcTo(ImDrawList* self, Unity.Mathematics.float2 center, float radius_x, float radius_y, float rot, float a_min, float a_max, int num_segments);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_PathFillConvex(ImDrawList* self, uint col);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_PathLineTo(ImDrawList* self, Unity.Mathematics.float2 pos);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_PathLineToMergeDuplicate(ImDrawList* self, Unity.Mathematics.float2 pos);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_PathRect(ImDrawList* self, Unity.Mathematics.float2 rect_min, Unity.Mathematics.float2 rect_max, float rounding, ImDrawFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_PathStroke(ImDrawList* self, uint col, ImDrawFlags flags, float thickness);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_PopClipRect(ImDrawList* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_PopTextureID(ImDrawList* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_PrimQuadUV(ImDrawList* self, Unity.Mathematics.float2 a, Unity.Mathematics.float2 b, Unity.Mathematics.float2 c, Unity.Mathematics.float2 d, Unity.Mathematics.float2 uv_a, Unity.Mathematics.float2 uv_b, Unity.Mathematics.float2 uv_c, Unity.Mathematics.float2 uv_d, uint col);
		/// <summary>
		/// Axis aligned rectangle (composed of two triangles)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_PrimRect(ImDrawList* self, Unity.Mathematics.float2 a, Unity.Mathematics.float2 b, uint col);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_PrimRectUV(ImDrawList* self, Unity.Mathematics.float2 a, Unity.Mathematics.float2 b, Unity.Mathematics.float2 uv_a, Unity.Mathematics.float2 uv_b, uint col);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_PrimReserve(ImDrawList* self, int idx_count, int vtx_count);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_PrimUnreserve(ImDrawList* self, int idx_count, int vtx_count);
		/// <summary>
		/// Write vertex with unique index
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_PrimVtx(ImDrawList* self, Unity.Mathematics.float2 pos, Unity.Mathematics.float2 uv, uint col);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_PrimWriteIdx(ImDrawList* self, ushort idx);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_PrimWriteVtx(ImDrawList* self, Unity.Mathematics.float2 pos, Unity.Mathematics.float2 uv, uint col);
		/// <summary>
		/// Render-level scissoring. This is passed down to your render function but not used for CPU-side coarse clipping. Prefer using higher-level ImGui::PushClipRect() to affect logic (hit-testing and widget culling)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_PushClipRect(ImDrawList* self, Unity.Mathematics.float2 clip_rect_min, Unity.Mathematics.float2 clip_rect_max, byte intersect_with_current_clip_rect);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_PushClipRectFullScreen(ImDrawList* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_PushTextureID(ImDrawList* self, UnityObjRef<UnityEngine.Texture2D> texture_id);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe int ImDrawList__CalcCircleAutoSegmentCount(ImDrawList* self, float radius);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList__ClearFreeMemory(ImDrawList* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList__OnChangedClipRect(ImDrawList* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList__OnChangedTextureID(ImDrawList* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList__OnChangedVtxOffset(ImDrawList* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList__PathArcToFastEx(ImDrawList* self, Unity.Mathematics.float2 center, float radius, int a_min_sample, int a_max_sample, int a_step);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList__PathArcToN(ImDrawList* self, Unity.Mathematics.float2 center, float radius, float a_min, float a_max, int num_segments);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList__PopUnusedDrawCmd(ImDrawList* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList__ResetForNewFrame(ImDrawList* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList__TryMergeDrawCmds(ImDrawList* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImDrawList_destroy(ImDrawList* self);
#endregion
#region ImFontAtlasCustomRect
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte ImFontAtlasCustomRect_IsPacked(ImFontAtlasCustomRect* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImFontAtlasCustomRect_destroy(ImFontAtlasCustomRect* self);
#endregion
#region ImFontAtlas
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe int ImFontAtlas_AddCustomRectFontGlyph(ImFontAtlas* self, ImFont* font, uint id, int width, int height, float advance_x, Unity.Mathematics.float2 offset);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe int ImFontAtlas_AddCustomRectRegular(ImFontAtlas* self, int width, int height);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe ImFont* ImFontAtlas_AddFont(ImFontAtlas* self, ImFontConfig* font_cfg);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe ImFont* ImFontAtlas_AddFontDefault(ImFontAtlas* self, ImFontConfig* font_cfg);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe ImFont* ImFontAtlas_AddFontFromFileTTF(ImFontAtlas* self, byte* filename, float size_pixels, ImFontConfig* font_cfg, uint* glyph_ranges);
		/// <summary>
		/// 'compressed_font_data_base85' still owned by caller. Compress with binary_to_compressed_c.cpp with -base85 parameter.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe ImFont* ImFontAtlas_AddFontFromMemoryCompressedBase85TTF(ImFontAtlas* self, byte* compressed_font_data_base85, float size_pixels, ImFontConfig* font_cfg, uint* glyph_ranges);
		/// <summary>
		/// 'compressed_font_data' still owned by caller. Compress with binary_to_compressed_c.cpp.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe ImFont* ImFontAtlas_AddFontFromMemoryCompressedTTF(ImFontAtlas* self, void* compressed_font_data, int compressed_font_data_size, float size_pixels, ImFontConfig* font_cfg, uint* glyph_ranges);
		/// <summary>
		/// Note: Transfer ownership of 'ttf_data' to ImFontAtlas! Will be deleted after destruction of the atlas. Set font_cfg-&gt;FontDataOwnedByAtlas=false to keep ownership of your data and it won't be freed.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe ImFont* ImFontAtlas_AddFontFromMemoryTTF(ImFontAtlas* self, void* font_data, int font_data_size, float size_pixels, ImFontConfig* font_cfg, uint* glyph_ranges);
		/// <summary>
		/// Build pixels data. This is called automatically for you by the GetTexData*** functions.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte ImFontAtlas_Build(ImFontAtlas* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImFontAtlas_CalcCustomRectUV(ImFontAtlas* self, ImFontAtlasCustomRect* rect, Unity.Mathematics.float2* out_uv_min, Unity.Mathematics.float2* out_uv_max);
		/// <summary>
		/// Clear all input and output.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImFontAtlas_Clear(ImFontAtlas* self);
		/// <summary>
		/// Clear output font data (glyphs storage, UV coordinates).
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImFontAtlas_ClearFonts(ImFontAtlas* self);
		/// <summary>
		/// Clear input data (all ImFontConfig structures including sizes, TTF data, glyph ranges, etc.) = all the data used to build the texture and fonts.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImFontAtlas_ClearInputData(ImFontAtlas* self);
		/// <summary>
		/// Clear output texture data (CPU side). Saves RAM once the texture has been copied to graphics memory.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImFontAtlas_ClearTexData(ImFontAtlas* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe ImFontAtlasCustomRect* ImFontAtlas_GetCustomRectByIndex(ImFontAtlas* self, int index);
		/// <summary>
		/// Default + Half-Width + Japanese Hiragana/Katakana + full set of about 21000 CJK Unified Ideographs
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe uint* ImFontAtlas_GetGlyphRangesChineseFull(ImFontAtlas* self);
		/// <summary>
		/// Default + Half-Width + Japanese Hiragana/Katakana + set of 2500 CJK Unified Ideographs for common simplified Chinese
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe uint* ImFontAtlas_GetGlyphRangesChineseSimplifiedCommon(ImFontAtlas* self);
		/// <summary>
		/// Default + about 400 Cyrillic characters
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe uint* ImFontAtlas_GetGlyphRangesCyrillic(ImFontAtlas* self);
		/// <summary>
		/// Basic Latin, Extended Latin
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe uint* ImFontAtlas_GetGlyphRangesDefault(ImFontAtlas* self);
		/// <summary>
		/// Default + Greek and Coptic
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe uint* ImFontAtlas_GetGlyphRangesGreek(ImFontAtlas* self);
		/// <summary>
		/// Default + Hiragana, Katakana, Half-Width, Selection of 2999 Ideographs
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe uint* ImFontAtlas_GetGlyphRangesJapanese(ImFontAtlas* self);
		/// <summary>
		/// Default + Korean characters
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe uint* ImFontAtlas_GetGlyphRangesKorean(ImFontAtlas* self);
		/// <summary>
		/// Default + Thai characters
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe uint* ImFontAtlas_GetGlyphRangesThai(ImFontAtlas* self);
		/// <summary>
		/// Default + Vietnamese characters
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe uint* ImFontAtlas_GetGlyphRangesVietnamese(ImFontAtlas* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte ImFontAtlas_GetMouseCursorTexData(ImFontAtlas* self, ImGuiMouseCursor cursor, Unity.Mathematics.float2* out_offset, Unity.Mathematics.float2* out_size, Unity.Mathematics.float2* out_uv_border, Unity.Mathematics.float2* out_uv_fill);
		/// <summary>
		/// 1 byte per-pixel
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImFontAtlas_GetTexDataAsAlpha8(ImFontAtlas* self, byte** out_pixels, int* out_width, int* out_height, int* out_bytes_per_pixel);
		/// <summary>
		/// 4 bytes-per-pixel
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImFontAtlas_GetTexDataAsRGBA32(ImFontAtlas* self, byte** out_pixels, int* out_width, int* out_height, int* out_bytes_per_pixel);
		/// <summary>
		/// Bit ambiguous: used to detect when user didn't build texture but effectively we should check TexID != 0 except that would be backend dependent...
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte ImFontAtlas_IsBuilt(ImFontAtlas* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImFontAtlas_SetTexID(ImFontAtlas* self, UnityObjRef<UnityEngine.Texture2D> id);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImFontAtlas_destroy(ImFontAtlas* self);
#endregion
#region ImFontConfig
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImFontConfig_destroy(ImFontConfig* self);
#endregion
#region ImFontGlyphRangesBuilder
		/// <summary>
		/// Add character
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImFontGlyphRangesBuilder_AddChar(ImFontGlyphRangesBuilder* self, uint c);
		/// <summary>
		/// Add ranges, e.g. builder.AddRanges(ImFontAtlas::GetGlyphRangesDefault()) to force add all of ASCII/Latin+Ext
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImFontGlyphRangesBuilder_AddRanges(ImFontGlyphRangesBuilder* self, uint* ranges);
		/// <summary>
		/// Add string (each character of the UTF-8 string are added)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImFontGlyphRangesBuilder_AddText(ImFontGlyphRangesBuilder* self, byte* text, byte* text_end);
		/// <summary>
		/// Output new ranges
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImFontGlyphRangesBuilder_BuildRanges(ImFontGlyphRangesBuilder* self, ImVector<uint>* out_ranges);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImFontGlyphRangesBuilder_Clear(ImFontGlyphRangesBuilder* self);
		/// <summary>
		/// Get bit n in the array
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte ImFontGlyphRangesBuilder_GetBit(ImFontGlyphRangesBuilder* self, System.UIntPtr n);
		/// <summary>
		/// Set bit n in the array
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImFontGlyphRangesBuilder_SetBit(ImFontGlyphRangesBuilder* self, System.UIntPtr n);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImFontGlyphRangesBuilder_destroy(ImFontGlyphRangesBuilder* self);
#endregion
#region ImFont
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImFont_AddGlyph(ImFont* self, ImFontConfig* src_cfg, uint c, float x0, float y0, float x1, float y1, float u0, float v0, float u1, float v1, float advance_x);
		/// <summary>
		/// Makes 'dst' character/glyph points to 'src' character/glyph. Currently needs to be called AFTER fonts have been built.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImFont_AddRemapChar(ImFont* self, uint dst, uint src, byte overwrite_dst);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImFont_BuildLookupTable(ImFont* self);
		/// <summary>
		/// utf8
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImFont_CalcTextSizeA(Unity.Mathematics.float2* pOut, ImFont* self, float size, float max_width, float wrap_width, byte* text_begin, byte* text_end, byte** remaining);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte* ImFont_CalcWordWrapPositionA(ImFont* self, float scale, byte* text, byte* text_end, float wrap_width);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImFont_ClearOutputData(ImFont* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe ImFontGlyph* ImFont_FindGlyph(ImFont* self, uint c);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe ImFontGlyph* ImFont_FindGlyphNoFallback(ImFont* self, uint c);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe float ImFont_GetCharAdvance(ImFont* self, uint c);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte* ImFont_GetDebugName(ImFont* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImFont_GrowIndex(ImFont* self, int new_size);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte ImFont_IsGlyphRangeUnused(ImFont* self, uint c_begin, uint c_last);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte ImFont_IsLoaded(ImFont* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImFont_RenderChar(ImFont* self, ImDrawList* draw_list, float size, Unity.Mathematics.float2 pos, uint col, uint c);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImFont_RenderText(ImFont* self, ImDrawList* draw_list, float size, Unity.Mathematics.float2 pos, uint col, Unity.Mathematics.float4 clip_rect, byte* text_begin, byte* text_end, float wrap_width, byte cpu_fine_clip);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImFont_SetGlyphVisible(ImFont* self, uint c, byte visible);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImFont_destroy(ImFont* self);
#endregion
#region ImGuiIO
		/// <summary>
		/// Queue a gain/loss of focus for the application (generally based on OS/platform focus of your window)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiIO_AddFocusEvent(ImGuiIO* self, byte focused);
		/// <summary>
		/// Queue a new character input
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiIO_AddInputCharacter(ImGuiIO* self, uint c);
		/// <summary>
		/// Queue a new character input from a UTF-16 character, it can be a surrogate
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiIO_AddInputCharacterUTF16(ImGuiIO* self, ushort c);
		/// <summary>
		/// Queue a new characters input from a UTF-8 string
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiIO_AddInputCharactersUTF8(ImGuiIO* self, byte* str);
		/// <summary>
		/// Queue a new key down/up event for analog values (e.g. ImGuiKey_Gamepad_ values). Dead-zones should be handled by the backend.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiIO_AddKeyAnalogEvent(ImGuiIO* self, ImGuiKey key, byte down, float v);
		/// <summary>
		/// Queue a new key down/up event. Key should be "translated" (as in, generally ImGuiKey_A matches the key end-user would use to emit an 'A' character)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiIO_AddKeyEvent(ImGuiIO* self, ImGuiKey key, byte down);
		/// <summary>
		/// Queue a mouse button change
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiIO_AddMouseButtonEvent(ImGuiIO* self, int button, byte down);
		/// <summary>
		/// Queue a mouse position update. Use -FLT_MAX,-FLT_MAX to signify no mouse (e.g. app not focused and not hovered)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiIO_AddMousePosEvent(ImGuiIO* self, float x, float y);
		/// <summary>
		/// Queue a mouse source change (Mouse/TouchScreen/Pen)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiIO_AddMouseSourceEvent(ImGuiIO* self, ImGuiMouseSource source);
		/// <summary>
		/// Queue a mouse hovered viewport. Requires backend to set ImGuiBackendFlags_HasMouseHoveredViewport to call this (for multi-viewport support).
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiIO_AddMouseViewportEvent(ImGuiIO* self, uint id);
		/// <summary>
		/// Queue a mouse wheel update. wheel_y&lt;0: scroll down, wheel_y&gt;0: scroll up, wheel_x&lt;0: scroll right, wheel_x&gt;0: scroll left.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiIO_AddMouseWheelEvent(ImGuiIO* self, float wheel_x, float wheel_y);
		/// <summary>
		/// Clear all incoming events.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiIO_ClearEventsQueue(ImGuiIO* self);
		/// <summary>
		/// Clear current keyboard/mouse/gamepad state + current frame text input buffer. Equivalent to releasing all keys/buttons.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiIO_ClearInputKeys(ImGuiIO* self);
		/// <summary>
		/// Set master flag for accepting key/mouse/text events (default to true). Useful if you have native dialog boxes that are interrupting your application loop/refresh, and you want to disable events being queued while your app is frozen.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiIO_SetAppAcceptingEvents(ImGuiIO* self, byte accepting_events);
		/// <summary>
		/// [Optional] Specify index for legacy &lt;1.87 IsKeyXXX() functions with native indices + specify native keycode, scancode.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiIO_SetKeyEventNativeData(ImGuiIO* self, ImGuiKey key, int native_keycode, int native_scancode, int native_legacy_index);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiIO_destroy(ImGuiIO* self);
#endregion
#region ImGuiInputTextCallbackData
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiInputTextCallbackData_ClearSelection(ImGuiInputTextCallbackData* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiInputTextCallbackData_DeleteChars(ImGuiInputTextCallbackData* self, int pos, int bytes_count);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte ImGuiInputTextCallbackData_HasSelection(ImGuiInputTextCallbackData* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiInputTextCallbackData_InsertChars(ImGuiInputTextCallbackData* self, int pos, byte* text, byte* text_end);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiInputTextCallbackData_SelectAll(ImGuiInputTextCallbackData* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiInputTextCallbackData_destroy(ImGuiInputTextCallbackData* self);
#endregion
#region ImGuiListClipper
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiListClipper_Begin(ImGuiListClipper* self, int items_count, float items_height);
		/// <summary>
		/// Automatically called on the last call of Step() that returns false.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiListClipper_End(ImGuiListClipper* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiListClipper_IncludeItemByIndex(ImGuiListClipper* self, int item_index);
		/// <summary>
		/// item_end is exclusive e.g. use (42, 42+1) to make item 42 never clipped.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiListClipper_IncludeItemsByIndex(ImGuiListClipper* self, int item_begin, int item_end);
		/// <summary>
		/// Call until it returns false. The DisplayStart/DisplayEnd fields will be set and you can process/draw those items.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte ImGuiListClipper_Step(ImGuiListClipper* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiListClipper_destroy(ImGuiListClipper* self);
#endregion
#region ImGuiOnceUponAFrame
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiOnceUponAFrame_destroy(ImGuiOnceUponAFrame* self);
#endregion
#region ImGuiPayload
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiPayload_Clear(ImGuiPayload* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte ImGuiPayload_IsDataType(ImGuiPayload* self, byte* type);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte ImGuiPayload_IsDelivery(ImGuiPayload* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte ImGuiPayload_IsPreview(ImGuiPayload* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiPayload_destroy(ImGuiPayload* self);
#endregion
#region ImGuiPlatformIO
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiPlatformIO_destroy(ImGuiPlatformIO* self);
#endregion
#region ImGuiPlatformImeData
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiPlatformImeData_destroy(ImGuiPlatformImeData* self);
#endregion
#region ImGuiPlatformMonitor
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiPlatformMonitor_destroy(ImGuiPlatformMonitor* self);
#endregion
#region ImGuiStoragePair
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiStoragePair_destroy(ImGuiStoragePair* self);
#endregion
#region ImGuiStorage
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiStorage_BuildSortByKey(ImGuiStorage* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiStorage_Clear(ImGuiStorage* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte ImGuiStorage_GetBool(ImGuiStorage* self, uint key, byte default_val);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte* ImGuiStorage_GetBoolRef(ImGuiStorage* self, uint key, byte default_val);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe float ImGuiStorage_GetFloat(ImGuiStorage* self, uint key, float default_val);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe float* ImGuiStorage_GetFloatRef(ImGuiStorage* self, uint key, float default_val);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe int ImGuiStorage_GetInt(ImGuiStorage* self, uint key, int default_val);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe int* ImGuiStorage_GetIntRef(ImGuiStorage* self, uint key, int default_val);
		/// <summary>
		/// default_val is NULL
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void* ImGuiStorage_GetVoidPtr(ImGuiStorage* self, uint key);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void** ImGuiStorage_GetVoidPtrRef(ImGuiStorage* self, uint key, void* default_val);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiStorage_SetAllInt(ImGuiStorage* self, int val);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiStorage_SetBool(ImGuiStorage* self, uint key, byte val);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiStorage_SetFloat(ImGuiStorage* self, uint key, float val);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiStorage_SetInt(ImGuiStorage* self, uint key, int val);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiStorage_SetVoidPtr(ImGuiStorage* self, uint key, void* val);
#endregion
#region ImGuiStyle
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiStyle_ScaleAllSizes(ImGuiStyle* self, float scale_factor);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiStyle_destroy(ImGuiStyle* self);
#endregion
#region ImGuiTableColumnSortSpecs
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiTableColumnSortSpecs_destroy(ImGuiTableColumnSortSpecs* self);
#endregion
#region ImGuiTableSortSpecs
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiTableSortSpecs_destroy(ImGuiTableSortSpecs* self);
#endregion
#region ImGuiTextBuffer
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiTextBuffer_append(ImGuiTextBuffer* self, byte* str, byte* str_end);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiTextBuffer_appendf(ImGuiTextBuffer* self, byte* fmt);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiTextBuffer_appendfv(ImGuiTextBuffer* self, byte* fmt, __arglist);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte* ImGuiTextBuffer_begin(ImGuiTextBuffer* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte* ImGuiTextBuffer_c_str(ImGuiTextBuffer* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiTextBuffer_clear(ImGuiTextBuffer* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiTextBuffer_destroy(ImGuiTextBuffer* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte ImGuiTextBuffer_empty(ImGuiTextBuffer* self);
		/// <summary>
		/// Buf is zero-terminated, so end() will point on the zero-terminator
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte* ImGuiTextBuffer_end(ImGuiTextBuffer* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiTextBuffer_reserve(ImGuiTextBuffer* self, int capacity);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe int ImGuiTextBuffer_size(ImGuiTextBuffer* self);
#endregion
#region ImGuiTextFilter
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiTextFilter_Build(ImGuiTextFilter* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiTextFilter_Clear(ImGuiTextFilter* self);
		/// <summary>
		/// Helper calling InputText+Build
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte ImGuiTextFilter_Draw(ImGuiTextFilter* self, byte* label, float width);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte ImGuiTextFilter_IsActive(ImGuiTextFilter* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte ImGuiTextFilter_PassFilter(ImGuiTextFilter* self, byte* text, byte* text_end);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiTextFilter_destroy(ImGuiTextFilter* self);
#endregion
#region ImGuiTextRange
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiTextRange_destroy(ImGuiTextRange* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte ImGuiTextRange_empty(ImGuiTextRange* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiTextRange_split(ImGuiTextRange* self, byte separator, ImVector<ImGuiTextRange>* @out);
#endregion
#region ImGuiViewport
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiViewport_GetCenter(Unity.Mathematics.float2* pOut, ImGuiViewport* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiViewport_GetWorkCenter(Unity.Mathematics.float2* pOut, ImGuiViewport* self);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiViewport_destroy(ImGuiViewport* self);
#endregion
#region ImGuiWindowClass
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImGuiWindowClass_destroy(ImGuiWindowClass* self);
#endregion
#region ImVec2
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImVec2_destroy(Unity.Mathematics.float2* self);
#endregion
#region ImVec4
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void ImVec4_destroy(Unity.Mathematics.float4* self);
#endregion
#region ImGUI
		/// <summary>
		/// accept contents of a given type. If ImGuiDragDropFlags_AcceptBeforeDelivery is set you can peek into the payload before the mouse button is released.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe ImGuiPayload* igAcceptDragDropPayload(byte* type, ImGuiDragDropFlags flags);
		/// <summary>
		/// vertically align upcoming text baseline to FramePadding.y so that it will align properly to regularly framed items (call if you have text on a line before a framed item)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igAlignTextToFramePadding();
		/// <summary>
		/// square button with an arrow shape
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igArrowButton(byte* str_id, ImGuiDir dir);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igBegin(byte* name, byte* p_open, ImGuiWindowFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igBeginChild_Str(byte* str_id, Unity.Mathematics.float2 size, ImGuiChildFlags child_flags, ImGuiWindowFlags window_flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igBeginChild_ID(uint id, Unity.Mathematics.float2 size, ImGuiChildFlags child_flags, ImGuiWindowFlags window_flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igBeginCombo(byte* label, byte* preview_value, ImGuiComboFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igBeginDisabled(byte disabled);
		/// <summary>
		/// call after submitting an item which may be dragged. when this return true, you can call SetDragDropPayload() + EndDragDropSource()
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igBeginDragDropSource(ImGuiDragDropFlags flags);
		/// <summary>
		/// call after submitting an item that may receive a payload. If this returns true, you can call AcceptDragDropPayload() + EndDragDropTarget()
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igBeginDragDropTarget();
		/// <summary>
		/// lock horizontal starting position
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igBeginGroup();
		/// <summary>
		/// begin/append a tooltip window if preceding item was hovered.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igBeginItemTooltip();
		/// <summary>
		/// open a framed scrolling region
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igBeginListBox(byte* label, Unity.Mathematics.float2 size);
		/// <summary>
		/// create and append to a full screen menu-bar.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igBeginMainMenuBar();
		/// <summary>
		/// create a sub-menu entry. only call EndMenu() if this returns true!
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igBeginMenu(byte* label, byte enabled);
		/// <summary>
		/// append to menu-bar of current window (requires ImGuiWindowFlags_MenuBar flag set on parent window).
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igBeginMenuBar();
		/// <summary>
		/// return true if the popup is open, and you can start outputting to it.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igBeginPopup(byte* str_id, ImGuiWindowFlags flags);
		/// <summary>
		/// open+begin popup when clicked on last item. Use str_id==NULL to associate the popup to previous item. If you want to use that on a non-interactive item such as Text() you need to pass in an explicit ID here. read comments in .cpp!
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igBeginPopupContextItem(byte* str_id, ImGuiPopupFlags popup_flags);
		/// <summary>
		/// open+begin popup when clicked in void (where there are no windows).
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igBeginPopupContextVoid(byte* str_id, ImGuiPopupFlags popup_flags);
		/// <summary>
		/// open+begin popup when clicked on current window.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igBeginPopupContextWindow(byte* str_id, ImGuiPopupFlags popup_flags);
		/// <summary>
		/// return true if the modal is open, and you can start outputting to it.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igBeginPopupModal(byte* name, byte* p_open, ImGuiWindowFlags flags);
		/// <summary>
		/// create and append into a TabBar
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igBeginTabBar(byte* str_id, ImGuiTabBarFlags flags);
		/// <summary>
		/// create a Tab. Returns true if the Tab is selected.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igBeginTabItem(byte* label, byte* p_open, ImGuiTabItemFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igBeginTable(byte* str_id, int column, ImGuiTableFlags flags, Unity.Mathematics.float2 outer_size, float inner_width);
		/// <summary>
		/// begin/append a tooltip window.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igBeginTooltip();
		/// <summary>
		/// draw a small circle + keep the cursor on the same line. advance cursor x position by GetTreeNodeToLabelSpacing(), same distance that TreeNode() uses
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igBullet();
		/// <summary>
		/// shortcut for Bullet()+Text()
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igBulletText(byte* fmt);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igBulletTextV(byte* fmt, __arglist);
		/// <summary>
		/// button
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igButton(byte* label, Unity.Mathematics.float2 size);
		/// <summary>
		/// width of item given pushed settings and current cursor position. NOT necessarily the width of last item unlike most 'Item' functions.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe float igCalcItemWidth();
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igCalcTextSize(Unity.Mathematics.float2* pOut, byte* text, byte* text_end, byte hide_text_after_double_hash, float wrap_width);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igCheckbox(byte* label, byte* v);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igCheckboxFlags_IntPtr(byte* label, int* flags, int flags_value);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igCheckboxFlags_UintPtr(byte* label, uint* flags, uint flags_value);
		/// <summary>
		/// manually close the popup we have begin-ed into.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igCloseCurrentPopup();
		/// <summary>
		/// if returning 'true' the header is open. doesn't indent nor push on ID stack. user doesn't have to call TreePop().
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igCollapsingHeader_TreeNodeFlags(byte* label, ImGuiTreeNodeFlags flags);
		/// <summary>
		/// when 'p_visible != NULL': if '*p_visible==true' display an additional small close button on upper right of the header which will set the bool to false when clicked, if '*p_visible==false' don't display the header.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igCollapsingHeader_BoolPtr(byte* label, byte* p_visible, ImGuiTreeNodeFlags flags);
		/// <summary>
		/// display a color square/button, hover for details, return true when pressed.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igColorButton(byte* desc_id, Unity.Mathematics.float4 col, ImGuiColorEditFlags flags, Unity.Mathematics.float2 size);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe uint igColorConvertFloat4ToU32(Unity.Mathematics.float4 @in);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igColorConvertHSVtoRGB(float h, float s, float v, float* out_r, float* out_g, float* out_b);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igColorConvertRGBtoHSV(float r, float g, float b, float* out_h, float* out_s, float* out_v);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igColorConvertU32ToFloat4(Unity.Mathematics.float4* pOut, uint @in);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igColorEdit3(byte* label, float* col, ImGuiColorEditFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igColorEdit4(byte* label, float* col, ImGuiColorEditFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igColorPicker3(byte* label, float* col, ImGuiColorEditFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igColorPicker4(byte* label, float* col, ImGuiColorEditFlags flags, float* ref_col);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igColumns(int count, byte* id, byte border);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igCombo_Str_arr(byte* label, int* current_item, byte** items, int items_count, int popup_max_height_in_items);
		/// <summary>
		/// Separate items with \0 within a string, end item-list with \0\0. e.g. "One\0Two\0Three\0"
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igCombo_Str(byte* label, int* current_item, byte* items_separated_by_zeros, int popup_max_height_in_items);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igCombo_FnStrPtr(byte* label, int* current_item, delegate* unmanaged[Cdecl]<System.IntPtr, int, char*> getter, void* user_data, int items_count, int popup_max_height_in_items);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe ImGuiContext* igCreateContext(ImFontAtlas* shared_font_atlas);
		/// <summary>
		/// This is called by IMGUI_CHECKVERSION() macro.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igDebugCheckVersionAndDataLayout(byte* version_str, System.UIntPtr sz_io, System.UIntPtr sz_style, System.UIntPtr sz_vec2, System.UIntPtr sz_vec4, System.UIntPtr sz_drawvert, System.UIntPtr sz_drawidx);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igDebugFlashStyleColor(ImGuiCol idx);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igDebugStartItemPicker();
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igDebugTextEncoding(byte* text);
		/// <summary>
		/// NULL = destroy current context
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igDestroyContext(ImGuiContext* ctx);
		/// <summary>
		/// call DestroyWindow platform functions for all viewports. call from backend Shutdown() if you need to close platform windows before imgui shutdown. otherwise will be called by DestroyContext().
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igDestroyPlatformWindows();
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe uint igDockSpace(uint id, Unity.Mathematics.float2 size, ImGuiDockNodeFlags flags, ImGuiWindowClass* window_class);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe uint igDockSpaceOverViewport(ImGuiViewport* viewport, ImGuiDockNodeFlags flags, ImGuiWindowClass* window_class);
		/// <summary>
		/// If v_min &gt;= v_max we have no bound
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igDragFloat(byte* label, float* v, float v_speed, float v_min, float v_max, byte* format, ImGuiSliderFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igDragFloat2(byte* label, float* v, float v_speed, float v_min, float v_max, byte* format, ImGuiSliderFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igDragFloat3(byte* label, float* v, float v_speed, float v_min, float v_max, byte* format, ImGuiSliderFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igDragFloat4(byte* label, float* v, float v_speed, float v_min, float v_max, byte* format, ImGuiSliderFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igDragFloatRange2(byte* label, float* v_current_min, float* v_current_max, float v_speed, float v_min, float v_max, byte* format, byte* format_max, ImGuiSliderFlags flags);
		/// <summary>
		/// If v_min &gt;= v_max we have no bound
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igDragInt(byte* label, int* v, float v_speed, int v_min, int v_max, byte* format, ImGuiSliderFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igDragInt2(byte* label, int* v, float v_speed, int v_min, int v_max, byte* format, ImGuiSliderFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igDragInt3(byte* label, int* v, float v_speed, int v_min, int v_max, byte* format, ImGuiSliderFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igDragInt4(byte* label, int* v, float v_speed, int v_min, int v_max, byte* format, ImGuiSliderFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igDragIntRange2(byte* label, int* v_current_min, int* v_current_max, float v_speed, int v_min, int v_max, byte* format, byte* format_max, ImGuiSliderFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igDragScalar(byte* label, ImGuiDataType data_type, void* p_data, float v_speed, void* p_min, void* p_max, byte* format, ImGuiSliderFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igDragScalarN(byte* label, ImGuiDataType data_type, void* p_data, int components, float v_speed, void* p_min, void* p_max, byte* format, ImGuiSliderFlags flags);
		/// <summary>
		/// add a dummy item of given size. unlike InvisibleButton(), Dummy() won't take the mouse click or be navigable into.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igDummy(Unity.Mathematics.float2 size);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igEnd();
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igEndChild();
		/// <summary>
		/// only call EndCombo() if BeginCombo() returns true!
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igEndCombo();
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igEndDisabled();
		/// <summary>
		/// only call EndDragDropSource() if BeginDragDropSource() returns true!
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igEndDragDropSource();
		/// <summary>
		/// only call EndDragDropTarget() if BeginDragDropTarget() returns true!
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igEndDragDropTarget();
		/// <summary>
		/// ends the Dear ImGui frame. automatically called by Render(). If you don't need to render data (skipping rendering) you may call EndFrame() without Render()... but you'll have wasted CPU already! If you don't need to render, better to not create any windows and not call NewFrame() at all!
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igEndFrame();
		/// <summary>
		/// unlock horizontal starting position + capture the whole group bounding box into one "item" (so you can use IsItemHovered() or layout primitives such as SameLine() on whole group, etc.)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igEndGroup();
		/// <summary>
		/// only call EndListBox() if BeginListBox() returned true!
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igEndListBox();
		/// <summary>
		/// only call EndMainMenuBar() if BeginMainMenuBar() returns true!
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igEndMainMenuBar();
		/// <summary>
		/// only call EndMenu() if BeginMenu() returns true!
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igEndMenu();
		/// <summary>
		/// only call EndMenuBar() if BeginMenuBar() returns true!
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igEndMenuBar();
		/// <summary>
		/// only call EndPopup() if BeginPopupXXX() returns true!
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igEndPopup();
		/// <summary>
		/// only call EndTabBar() if BeginTabBar() returns true!
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igEndTabBar();
		/// <summary>
		/// only call EndTabItem() if BeginTabItem() returns true!
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igEndTabItem();
		/// <summary>
		/// only call EndTable() if BeginTable() returns true!
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igEndTable();
		/// <summary>
		/// only call EndTooltip() if BeginTooltip()/BeginItemTooltip() returns true!
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igEndTooltip();
		/// <summary>
		/// this is a helper for backends.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe ImGuiViewport* igFindViewportByID(uint id);
		/// <summary>
		/// this is a helper for backends. the type platform_handle is decided by the backend (e.g. HWND, MyWindow*, GLFWwindow* etc.)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe ImGuiViewport* igFindViewportByPlatformHandle(void* platform_handle);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igGetAllocatorFunctions(delegate* unmanaged[Cdecl]<System.UIntPtr, System.IntPtr, System.IntPtr>* p_alloc_func, delegate* unmanaged[Cdecl]<System.IntPtr, System.IntPtr, void>* p_free_func, void** p_user_data);
		/// <summary>
		/// get background draw list for the viewport associated to the current window. this draw list will be the first rendering one. Useful to quickly draw shapes/text behind dear imgui contents.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe ImDrawList* igGetBackgroundDrawList_Nil();
		/// <summary>
		/// get background draw list for the given viewport. this draw list will be the first rendering one. Useful to quickly draw shapes/text behind dear imgui contents.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe ImDrawList* igGetBackgroundDrawList_ViewportPtr(ImGuiViewport* viewport);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte* igGetClipboardText();
		/// <summary>
		/// retrieve given style color with style alpha applied and optional extra alpha multiplier, packed as a 32-bit value suitable for ImDrawList
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe uint igGetColorU32_Col(ImGuiCol idx, float alpha_mul);
		/// <summary>
		/// retrieve given color with style alpha applied, packed as a 32-bit value suitable for ImDrawList
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe uint igGetColorU32_Vec4(Unity.Mathematics.float4 col);
		/// <summary>
		/// retrieve given color with style alpha applied, packed as a 32-bit value suitable for ImDrawList
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe uint igGetColorU32_U32(uint col, float alpha_mul);
		/// <summary>
		/// get current column index
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe int igGetColumnIndex();
		/// <summary>
		/// get position of column line (in pixels, from the left side of the contents region). pass -1 to use current column, otherwise 0..GetColumnsCount() inclusive. column 0 is typically 0.0f
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe float igGetColumnOffset(int column_index);
		/// <summary>
		/// get column width (in pixels). pass -1 to use current column
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe float igGetColumnWidth(int column_index);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe int igGetColumnsCount();
		/// <summary>
		/// == GetContentRegionMax() - GetCursorPos()
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igGetContentRegionAvail(Unity.Mathematics.float2* pOut);
		/// <summary>
		/// current content boundaries (typically window boundaries including scrolling, or current column boundaries), in windows coordinates
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igGetContentRegionMax(Unity.Mathematics.float2* pOut);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe ImGuiContext* igGetCurrentContext();
		/// <summary>
		/// [window-local] cursor position in window coordinates (relative to window position)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igGetCursorPos(Unity.Mathematics.float2* pOut);
		/// <summary>
		/// [window-local] "
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe float igGetCursorPosX();
		/// <summary>
		/// [window-local] "
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe float igGetCursorPosY();
		/// <summary>
		/// cursor position in absolute coordinates (prefer using this, also more useful to work with ImDrawList API).
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igGetCursorScreenPos(Unity.Mathematics.float2* pOut);
		/// <summary>
		/// [window-local] initial cursor position, in window coordinates
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igGetCursorStartPos(Unity.Mathematics.float2* pOut);
		/// <summary>
		/// peek directly into the current payload from anywhere. returns NULL when drag and drop is finished or inactive. use ImGuiPayload::IsDataType() to test for the payload type.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe ImGuiPayload* igGetDragDropPayload();
		/// <summary>
		/// valid after Render() and until the next call to NewFrame(). this is what you have to render.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe ImDrawData* igGetDrawData();
		/// <summary>
		/// you may use this when creating your own ImDrawList instances.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe ImDrawListSharedData* igGetDrawListSharedData();
		/// <summary>
		/// get current font
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe ImFont* igGetFont();
		/// <summary>
		/// get current font size (= height in pixels) of current font with current scale applied
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe float igGetFontSize();
		/// <summary>
		/// get UV coordinate for a while pixel, useful to draw custom shapes via the ImDrawList API
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igGetFontTexUvWhitePixel(Unity.Mathematics.float2* pOut);
		/// <summary>
		/// get foreground draw list for the viewport associated to the current window. this draw list will be the last rendered one. Useful to quickly draw shapes/text over dear imgui contents.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe ImDrawList* igGetForegroundDrawList_Nil();
		/// <summary>
		/// get foreground draw list for the given viewport. this draw list will be the last rendered one. Useful to quickly draw shapes/text over dear imgui contents.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe ImDrawList* igGetForegroundDrawList_ViewportPtr(ImGuiViewport* viewport);
		/// <summary>
		/// get global imgui frame count. incremented by 1 every frame.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe int igGetFrameCount();
		/// <summary>
		/// ~ FontSize + style.FramePadding.y * 2
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe float igGetFrameHeight();
		/// <summary>
		/// ~ FontSize + style.FramePadding.y * 2 + style.ItemSpacing.y (distance in pixels between 2 consecutive lines of framed widgets)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe float igGetFrameHeightWithSpacing();
		/// <summary>
		/// calculate unique ID (hash of whole ID stack + given parameter). e.g. if you want to query into ImGuiStorage yourself
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe uint igGetID_Str(byte* str_id);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe uint igGetID_StrStr(byte* str_id_begin, byte* str_id_end);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe uint igGetID_Ptr(void* ptr_id);
		/// <summary>
		/// access the IO structure (mouse/keyboard/gamepad inputs, time, various configuration options/flags)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe ImGuiIO* igGetIO();
		/// <summary>
		/// get ID of last item (~~ often same ImGui::GetID(label) beforehand)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe uint igGetItemID();
		/// <summary>
		/// get lower-right bounding rectangle of the last item (screen space)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igGetItemRectMax(Unity.Mathematics.float2* pOut);
		/// <summary>
		/// get upper-left bounding rectangle of the last item (screen space)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igGetItemRectMin(Unity.Mathematics.float2* pOut);
		/// <summary>
		/// get size of last item
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igGetItemRectSize(Unity.Mathematics.float2* pOut);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe ImGuiKey igGetKeyIndex(ImGuiKey key);
		/// <summary>
		/// [DEBUG] returns English name of the key. Those names a provided for debugging purpose and are not meant to be saved persistently not compared.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte* igGetKeyName(ImGuiKey key);
		/// <summary>
		/// uses provided repeat rate/delay. return a count, most often 0 or 1 but might be &gt;1 if RepeatRate is small enough that DeltaTime &gt; RepeatRate
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe int igGetKeyPressedAmount(ImGuiKey key, float repeat_delay, float rate);
		/// <summary>
		/// return primary/default viewport. This can never be NULL.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe ImGuiViewport* igGetMainViewport();
		/// <summary>
		/// return the number of successive mouse-clicks at the time where a click happen (otherwise 0).
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe int igGetMouseClickedCount(ImGuiMouseButton button);
		/// <summary>
		/// get desired mouse cursor shape. Important: reset in ImGui::NewFrame(), this is updated during the frame. valid before Render(). If you use software rendering by setting io.MouseDrawCursor ImGui will render those for you
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe ImGuiMouseCursor igGetMouseCursor();
		/// <summary>
		/// return the delta from the initial clicking position while the mouse button is pressed or was just released. This is locked and return 0.0f until the mouse moves past a distance threshold at least once (if lock_threshold &lt; -1.0f, uses io.MouseDraggingThreshold)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igGetMouseDragDelta(Unity.Mathematics.float2* pOut, ImGuiMouseButton button, float lock_threshold);
		/// <summary>
		/// shortcut to ImGui::GetIO().MousePos provided by user, to be consistent with other calls
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igGetMousePos(Unity.Mathematics.float2* pOut);
		/// <summary>
		/// retrieve mouse position at the time of opening popup we have BeginPopup() into (helper to avoid user backing that value themselves)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igGetMousePosOnOpeningCurrentPopup(Unity.Mathematics.float2* pOut);
		/// <summary>
		/// platform/renderer functions, for backend to setup + viewports list.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe ImGuiPlatformIO* igGetPlatformIO();
		/// <summary>
		/// get maximum scrolling amount ~~ ContentSize.x - WindowSize.x - DecorationsSize.x
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe float igGetScrollMaxX();
		/// <summary>
		/// get maximum scrolling amount ~~ ContentSize.y - WindowSize.y - DecorationsSize.y
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe float igGetScrollMaxY();
		/// <summary>
		/// get scrolling amount [0 .. GetScrollMaxX()]
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe float igGetScrollX();
		/// <summary>
		/// get scrolling amount [0 .. GetScrollMaxY()]
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe float igGetScrollY();
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe ImGuiStorage* igGetStateStorage();
		/// <summary>
		/// access the Style structure (colors, sizes). Always use PushStyleColor(), PushStyleVar() to modify style mid-frame!
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe ImGuiStyle* igGetStyle();
		/// <summary>
		/// get a string corresponding to the enum value (for display, saving, etc.).
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte* igGetStyleColorName(ImGuiCol idx);
		/// <summary>
		/// retrieve style color as stored in ImGuiStyle structure. use to feed back into PushStyleColor(), otherwise use GetColorU32() to get style color with style alpha baked in.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe Unity.Mathematics.float4* igGetStyleColorVec4(ImGuiCol idx);
		/// <summary>
		/// ~ FontSize
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe float igGetTextLineHeight();
		/// <summary>
		/// ~ FontSize + style.ItemSpacing.y (distance in pixels between 2 consecutive lines of text)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe float igGetTextLineHeightWithSpacing();
		/// <summary>
		/// get global imgui time. incremented by io.DeltaTime every frame.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe double igGetTime();
		/// <summary>
		/// horizontal distance preceding label when using TreeNode*() or Bullet() == (g.FontSize + style.FramePadding.x*2) for a regular unframed TreeNode
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe float igGetTreeNodeToLabelSpacing();
		/// <summary>
		/// get the compiled version string e.g. "1.80 WIP" (essentially the value for IMGUI_VERSION from the compiled version of imgui.cpp)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte* igGetVersion();
		/// <summary>
		/// content boundaries max for the full window (roughly (0,0)+Size-Scroll) where Size can be overridden with SetNextWindowContentSize(), in window coordinates
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igGetWindowContentRegionMax(Unity.Mathematics.float2* pOut);
		/// <summary>
		/// content boundaries min for the full window (roughly (0,0)-Scroll), in window coordinates
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igGetWindowContentRegionMin(Unity.Mathematics.float2* pOut);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe uint igGetWindowDockID();
		/// <summary>
		/// get DPI scale currently associated to the current window's viewport.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe float igGetWindowDpiScale();
		/// <summary>
		/// get draw list associated to the current window, to append your own drawing primitives
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe ImDrawList* igGetWindowDrawList();
		/// <summary>
		/// get current window height (shortcut for GetWindowSize().y)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe float igGetWindowHeight();
		/// <summary>
		/// get current window position in screen space (note: it is unlikely you need to use this. Consider using current layout pos instead, GetCursorScreenPos())
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igGetWindowPos(Unity.Mathematics.float2* pOut);
		/// <summary>
		/// get current window size (note: it is unlikely you need to use this. Consider using GetCursorScreenPos() and e.g. GetContentRegionAvail() instead)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igGetWindowSize(Unity.Mathematics.float2* pOut);
		/// <summary>
		/// get viewport currently associated to the current window.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe ImGuiViewport* igGetWindowViewport();
		/// <summary>
		/// get current window width (shortcut for GetWindowSize().x)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe float igGetWindowWidth();
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igImage(UnityObjRef<UnityEngine.Texture2D> user_texture_id, Unity.Mathematics.float2 image_size, Unity.Mathematics.float2 uv0, Unity.Mathematics.float2 uv1, Unity.Mathematics.float4 tint_col, Unity.Mathematics.float4 border_col);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igImageButton(byte* str_id, UnityObjRef<UnityEngine.Texture2D> user_texture_id, Unity.Mathematics.float2 image_size, Unity.Mathematics.float2 uv0, Unity.Mathematics.float2 uv1, Unity.Mathematics.float4 bg_col, Unity.Mathematics.float4 tint_col);
		/// <summary>
		/// move content position toward the right, by indent_w, or style.IndentSpacing if indent_w &lt;= 0
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igIndent(float indent_w);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igInputDouble(byte* label, double* v, double step, double step_fast, byte* format, ImGuiInputTextFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igInputFloat(byte* label, float* v, float step, float step_fast, byte* format, ImGuiInputTextFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igInputFloat2(byte* label, float* v, byte* format, ImGuiInputTextFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igInputFloat3(byte* label, float* v, byte* format, ImGuiInputTextFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igInputFloat4(byte* label, float* v, byte* format, ImGuiInputTextFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igInputInt(byte* label, int* v, int step, int step_fast, ImGuiInputTextFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igInputInt2(byte* label, int* v, ImGuiInputTextFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igInputInt3(byte* label, int* v, ImGuiInputTextFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igInputInt4(byte* label, int* v, ImGuiInputTextFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igInputScalar(byte* label, ImGuiDataType data_type, void* p_data, void* p_step, void* p_step_fast, byte* format, ImGuiInputTextFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igInputScalarN(byte* label, ImGuiDataType data_type, void* p_data, int components, void* p_step, void* p_step_fast, byte* format, ImGuiInputTextFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igInputText(byte* label, byte* buf, System.UIntPtr buf_size, ImGuiInputTextFlags flags, delegate* unmanaged[Cdecl]<ImGuiInputTextCallbackData*, int> callback, void* user_data);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igInputTextMultiline(byte* label, byte* buf, System.UIntPtr buf_size, Unity.Mathematics.float2 size, ImGuiInputTextFlags flags, delegate* unmanaged[Cdecl]<ImGuiInputTextCallbackData*, int> callback, void* user_data);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igInputTextWithHint(byte* label, byte* hint, byte* buf, System.UIntPtr buf_size, ImGuiInputTextFlags flags, delegate* unmanaged[Cdecl]<ImGuiInputTextCallbackData*, int> callback, void* user_data);
		/// <summary>
		/// flexible button behavior without the visuals, frequently useful to build custom behaviors using the public api (along with IsItemActive, IsItemHovered, etc.)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igInvisibleButton(byte* str_id, Unity.Mathematics.float2 size, ImGuiButtonFlags flags);
		/// <summary>
		/// is any item active?
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igIsAnyItemActive();
		/// <summary>
		/// is any item focused?
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igIsAnyItemFocused();
		/// <summary>
		/// is any item hovered?
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igIsAnyItemHovered();
		/// <summary>
		/// [WILL OBSOLETE] is any mouse button held? This was designed for backends, but prefer having backend maintain a mask of held mouse buttons, because upcoming input queue system will make this invalid.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igIsAnyMouseDown();
		/// <summary>
		/// was the last item just made active (item was previously inactive).
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igIsItemActivated();
		/// <summary>
		/// is the last item active? (e.g. button being held, text field being edited. This will continuously return true while holding mouse button on an item. Items that don't interact will always return false)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igIsItemActive();
		/// <summary>
		/// is the last item hovered and mouse clicked on? (**)  == IsMouseClicked(mouse_button) && IsItemHovered()Important. (**) this is NOT equivalent to the behavior of e.g. Button(). Read comments in function definition.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igIsItemClicked(ImGuiMouseButton mouse_button);
		/// <summary>
		/// was the last item just made inactive (item was previously active). Useful for Undo/Redo patterns with widgets that require continuous editing.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igIsItemDeactivated();
		/// <summary>
		/// was the last item just made inactive and made a value change when it was active? (e.g. Slider/Drag moved). Useful for Undo/Redo patterns with widgets that require continuous editing. Note that you may get false positives (some widgets such as Combo()/ListBox()/Selectable() will return true even when clicking an already selected item).
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igIsItemDeactivatedAfterEdit();
		/// <summary>
		/// did the last item modify its underlying value this frame? or was pressed? This is generally the same as the "bool" return value of many widgets.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igIsItemEdited();
		/// <summary>
		/// is the last item focused for keyboard/gamepad navigation?
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igIsItemFocused();
		/// <summary>
		/// is the last item hovered? (and usable, aka not blocked by a popup, etc.). See ImGuiHoveredFlags for more options.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igIsItemHovered(ImGuiHoveredFlags flags);
		/// <summary>
		/// was the last item open state toggled? set by TreeNode().
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igIsItemToggledOpen();
		/// <summary>
		/// is the last item visible? (items may be out of sight because of clipping/scrolling)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igIsItemVisible();
		/// <summary>
		/// was key chord (mods + key) pressed, e.g. you can pass 'ImGuiMod_Ctrl | ImGuiKey_S' as a key-chord. This doesn't do any routing or focus check, please consider using Shortcut() function instead.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igIsKeyChordPressed(int key_chord);
		/// <summary>
		/// is key being held.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igIsKeyDown(ImGuiKey key);
		/// <summary>
		/// was key pressed (went from !Down to Down)? if repeat=true, uses io.KeyRepeatDelay / KeyRepeatRate
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igIsKeyPressed(ImGuiKey key, byte repeat);
		/// <summary>
		/// was key released (went from Down to !Down)?
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igIsKeyReleased(ImGuiKey key);
		/// <summary>
		/// did mouse button clicked? (went from !Down to Down). Same as GetMouseClickedCount() == 1.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igIsMouseClicked(ImGuiMouseButton button, byte repeat);
		/// <summary>
		/// did mouse button double-clicked? Same as GetMouseClickedCount() == 2. (note that a double-click will also report IsMouseClicked() == true)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igIsMouseDoubleClicked(ImGuiMouseButton button);
		/// <summary>
		/// is mouse button held?
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igIsMouseDown(ImGuiMouseButton button);
		/// <summary>
		/// is mouse dragging? (if lock_threshold &lt; -1.0f, uses io.MouseDraggingThreshold)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igIsMouseDragging(ImGuiMouseButton button, float lock_threshold);
		/// <summary>
		/// is mouse hovering given bounding rect (in screen space). clipped by current clipping settings, but disregarding of other consideration of focus/window ordering/popup-block.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igIsMouseHoveringRect(Unity.Mathematics.float2 r_min, Unity.Mathematics.float2 r_max, byte clip);
		/// <summary>
		/// by convention we use (-FLT_MAX,-FLT_MAX) to denote that there is no mouse available
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igIsMousePosValid(Unity.Mathematics.float2* mouse_pos);
		/// <summary>
		/// did mouse button released? (went from Down to !Down)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igIsMouseReleased(ImGuiMouseButton button);
		/// <summary>
		/// return true if the popup is open.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igIsPopupOpen(byte* str_id, ImGuiPopupFlags flags);
		/// <summary>
		/// test if rectangle (of given size, starting from cursor position) is visible / not clipped.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igIsRectVisible_Nil(Unity.Mathematics.float2 size);
		/// <summary>
		/// test if rectangle (in screen space) is visible / not clipped. to perform coarse clipping on user's side.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igIsRectVisible_Vec2(Unity.Mathematics.float2 rect_min, Unity.Mathematics.float2 rect_max);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igIsWindowAppearing();
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igIsWindowCollapsed();
		/// <summary>
		/// is current window docked into another window?
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igIsWindowDocked();
		/// <summary>
		/// is current window focused? or its root/child, depending on flags. see flags for options.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igIsWindowFocused(ImGuiFocusedFlags flags);
		/// <summary>
		/// is current window hovered and hoverable (e.g. not blocked by a popup/modal)? See ImGuiHoveredFlags_ for options. IMPORTANT: If you are trying to check whether your mouse should be dispatched to Dear ImGui or to your underlying app, you should not use this function! Use the 'io.WantCaptureMouse' boolean for that! Refer to FAQ entry "How can I tell whether to dispatch mouse/keyboard to Dear ImGui or my application?" for details.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igIsWindowHovered(ImGuiHoveredFlags flags);
		/// <summary>
		/// display text+label aligned the same way as value+label widgets
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igLabelText(byte* label, byte* fmt);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igLabelTextV(byte* label, byte* fmt, __arglist);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igListBox_Str_arr(byte* label, int* current_item, byte** items, int items_count, int height_in_items);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igListBox_FnStrPtr(byte* label, int* current_item, delegate* unmanaged[Cdecl]<System.IntPtr, int, char*> getter, void* user_data, int items_count, int height_in_items);
		/// <summary>
		/// call after CreateContext() and before the first call to NewFrame(). NewFrame() automatically calls LoadIniSettingsFromDisk(io.IniFilename).
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igLoadIniSettingsFromDisk(byte* ini_filename);
		/// <summary>
		/// call after CreateContext() and before the first call to NewFrame() to provide .ini data from your own data source.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igLoadIniSettingsFromMemory(byte* ini_data, System.UIntPtr ini_size);
		/// <summary>
		/// helper to display buttons for logging to tty/file/clipboard
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igLogButtons();
		/// <summary>
		/// stop logging (close file, etc.)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igLogFinish();
		/// <summary>
		/// pass text data straight to log (without being displayed)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igLogText(byte* fmt);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igLogTextV(byte* fmt, __arglist);
		/// <summary>
		/// start logging to OS clipboard
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igLogToClipboard(int auto_open_depth);
		/// <summary>
		/// start logging to file
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igLogToFile(int auto_open_depth, byte* filename);
		/// <summary>
		/// start logging to tty (stdout)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igLogToTTY(int auto_open_depth);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void* igMemAlloc(System.UIntPtr size);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igMemFree(void* ptr);
		/// <summary>
		/// return true when activated.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igMenuItem_Bool(byte* label, byte* shortcut, byte selected, byte enabled);
		/// <summary>
		/// return true when activated + toggle (*p_selected) if p_selected != NULL
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igMenuItem_BoolPtr(byte* label, byte* shortcut, byte* p_selected, byte enabled);
		/// <summary>
		/// start a new Dear ImGui frame, you can submit any command from this point until Render()/EndFrame().
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igNewFrame();
		/// <summary>
		/// undo a SameLine() or force a new line when in a horizontal-layout context.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igNewLine();
		/// <summary>
		/// next column, defaults to current row or next row if the current row is finished
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igNextColumn();
		/// <summary>
		/// call to mark popup as open (don't call every frame!).
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igOpenPopup_Str(byte* str_id, ImGuiPopupFlags popup_flags);
		/// <summary>
		/// id overload to facilitate calling from nested stacks
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igOpenPopup_ID(uint id, ImGuiPopupFlags popup_flags);
		/// <summary>
		/// helper to open popup when clicked on last item. Default to ImGuiPopupFlags_MouseButtonRight == 1. (note: actually triggers on the mouse _released_ event to be consistent with popup behaviors)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igOpenPopupOnItemClick(byte* str_id, ImGuiPopupFlags popup_flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igPlotHistogram_FloatPtr(byte* label, float* values, int values_count, int values_offset, byte* overlay_text, float scale_min, float scale_max, Unity.Mathematics.float2 graph_size, int stride);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igPlotHistogram_FnFloatPtr(byte* label, delegate* unmanaged[Cdecl]<System.IntPtr, int, float> values_getter, void* data, int values_count, int values_offset, byte* overlay_text, float scale_min, float scale_max, Unity.Mathematics.float2 graph_size);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igPlotLines_FloatPtr(byte* label, float* values, int values_count, int values_offset, byte* overlay_text, float scale_min, float scale_max, Unity.Mathematics.float2 graph_size, int stride);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igPlotLines_FnFloatPtr(byte* label, delegate* unmanaged[Cdecl]<System.IntPtr, int, float> values_getter, void* data, int values_count, int values_offset, byte* overlay_text, float scale_min, float scale_max, Unity.Mathematics.float2 graph_size);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igPopButtonRepeat();
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igPopClipRect();
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igPopFont();
		/// <summary>
		/// pop from the ID stack.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igPopID();
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igPopItemWidth();
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igPopStyleColor(int count);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igPopStyleVar(int count);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igPopTabStop();
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igPopTextWrapPos();
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igProgressBar(float fraction, Unity.Mathematics.float2 size_arg, byte* overlay);
		/// <summary>
		/// in 'repeat' mode, Button*() functions return repeated true in a typematic manner (using io.KeyRepeatDelay/io.KeyRepeatRate setting). Note that you can call IsItemActive() after any Button() to tell if the button is held in the current frame.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igPushButtonRepeat(byte repeat);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igPushClipRect(Unity.Mathematics.float2 clip_rect_min, Unity.Mathematics.float2 clip_rect_max, byte intersect_with_current_clip_rect);
		/// <summary>
		/// use NULL as a shortcut to push default font
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igPushFont(ImFont* font);
		/// <summary>
		/// push string into the ID stack (will hash string).
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igPushID_Str(byte* str_id);
		/// <summary>
		/// push string into the ID stack (will hash string).
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igPushID_StrStr(byte* str_id_begin, byte* str_id_end);
		/// <summary>
		/// push pointer into the ID stack (will hash pointer).
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igPushID_Ptr(void* ptr_id);
		/// <summary>
		/// push integer into the ID stack (will hash integer).
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igPushID_Int(int int_id);
		/// <summary>
		/// push width of items for common large "item+label" widgets. &gt;0.0f: width in pixels, &lt;0.0f align xx pixels to the right of window (so -FLT_MIN always align width to the right side).
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igPushItemWidth(float item_width);
		/// <summary>
		/// modify a style color. always use this if you modify the style after NewFrame().
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igPushStyleColor_U32(ImGuiCol idx, uint col);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igPushStyleColor_Vec4(ImGuiCol idx, Unity.Mathematics.float4 col);
		/// <summary>
		/// modify a style float variable. always use this if you modify the style after NewFrame().
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igPushStyleVar_Float(ImGuiStyleVar idx, float val);
		/// <summary>
		/// modify a style ImVec2 variable. always use this if you modify the style after NewFrame().
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igPushStyleVar_Vec2(ImGuiStyleVar idx, Unity.Mathematics.float2 val);
		/// <summary>
		/// == tab stop enable. Allow focusing using TAB/Shift-TAB, enabled by default but you can disable it for certain widgets
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igPushTabStop(byte tab_stop);
		/// <summary>
		/// push word-wrapping position for Text*() commands. &lt; 0.0f: no wrapping; 0.0f: wrap to end of window (or column); &gt; 0.0f: wrap at 'wrap_pos_x' position in window local space
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igPushTextWrapPos(float wrap_local_pos_x);
		/// <summary>
		/// use with e.g. if (RadioButton("one", my_value==1))  my_value = 1; 
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igRadioButton_Bool(byte* label, byte active);
		/// <summary>
		/// shortcut to handle the above pattern when value is an integer
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igRadioButton_IntPtr(byte* label, int* v, int v_button);
		/// <summary>
		/// ends the Dear ImGui frame, finalize the draw data. You can then get call GetDrawData().
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igRender();
		/// <summary>
		/// call in main loop. will call RenderWindow/SwapBuffers platform functions for each secondary viewport which doesn't have the ImGuiViewportFlags_Minimized flag set. May be reimplemented by user for custom rendering needs.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igRenderPlatformWindowsDefault(void* platform_render_arg, void* renderer_render_arg);
		/// <summary>
		///
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igResetMouseDragDelta(ImGuiMouseButton button);
		/// <summary>
		/// call between widgets or groups to layout them horizontally. X position given in window coordinates.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSameLine(float offset_from_start_x, float spacing);
		/// <summary>
		/// this is automatically called (if io.IniFilename is not empty) a few seconds after any modification that should be reflected in the .ini file (and also by DestroyContext).
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSaveIniSettingsToDisk(byte* ini_filename);
		/// <summary>
		/// return a zero-terminated string with the .ini data which you can save by your own mean. call when io.WantSaveIniSettings is set, then save data by your own mean and clear io.WantSaveIniSettings.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte* igSaveIniSettingsToMemory(System.UIntPtr* out_ini_size);
		/// <summary>
		/// "bool selected" carry the selection state (read-only). Selectable() is clicked is returns true so you can modify your selection state. size.x==0.0: use remaining width, size.x&gt;0.0: specify width. size.y==0.0: use label height, size.y&gt;0.0: specify height
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igSelectable_Bool(byte* label, byte selected, ImGuiSelectableFlags flags, Unity.Mathematics.float2 size);
		/// <summary>
		/// "bool* p_selected" point to the selection state (read-write), as a convenient helper.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igSelectable_BoolPtr(byte* label, byte* p_selected, ImGuiSelectableFlags flags, Unity.Mathematics.float2 size);
		/// <summary>
		/// separator, generally horizontal. inside a menu bar or in horizontal layout mode, this becomes a vertical separator.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSeparator();
		/// <summary>
		/// currently: formatted text with an horizontal line
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSeparatorText(byte* label);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetAllocatorFunctions(delegate* unmanaged[Cdecl]<System.UIntPtr, System.IntPtr, System.IntPtr> alloc_func, delegate* unmanaged[Cdecl]<System.IntPtr, System.IntPtr, void> free_func, void* user_data);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetClipboardText(byte* text);
		/// <summary>
		/// initialize current options (generally on application startup) if you want to select a default format, picker type, etc. User will be able to change many settings, unless you pass the _NoOptions flag to your calls.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetColorEditOptions(ImGuiColorEditFlags flags);
		/// <summary>
		/// set position of column line (in pixels, from the left side of the contents region). pass -1 to use current column
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetColumnOffset(int column_index, float offset_x);
		/// <summary>
		/// set column width (in pixels). pass -1 to use current column
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetColumnWidth(int column_index, float width);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetCurrentContext(ImGuiContext* ctx);
		/// <summary>
		/// [window-local] "
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetCursorPos(Unity.Mathematics.float2 local_pos);
		/// <summary>
		/// [window-local] "
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetCursorPosX(float local_x);
		/// <summary>
		/// [window-local] "
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetCursorPosY(float local_y);
		/// <summary>
		/// cursor position in absolute coordinates
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetCursorScreenPos(Unity.Mathematics.float2 pos);
		/// <summary>
		/// type is a user defined string of maximum 32 characters. Strings starting with '_' are reserved for dear imgui internal types. Data is copied and held by imgui. Return true when payload has been accepted.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igSetDragDropPayload(byte* type, void* data, System.UIntPtr sz, ImGuiCond cond);
		/// <summary>
		/// make last item the default focused item of a window.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetItemDefaultFocus();
		/// <summary>
		/// set a text-only tooltip if preceeding item was hovered. override any previous call to SetTooltip().
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetItemTooltip(byte* fmt);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetItemTooltipV(byte* fmt, __arglist);
		/// <summary>
		/// focus keyboard on the next widget. Use positive 'offset' to access sub components of a multiple component widget. Use -1 to access previous widget.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetKeyboardFocusHere(int offset);
		/// <summary>
		/// set desired mouse cursor shape
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetMouseCursor(ImGuiMouseCursor cursor_type);
		/// <summary>
		/// Override io.WantCaptureKeyboard flag next frame (said flag is left for your application to handle, typically when true it instructs your app to ignore inputs). e.g. force capture keyboard when your widget is being hovered. This is equivalent to setting "io.WantCaptureKeyboard = want_capture_keyboard"; after the next NewFrame() call.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetNextFrameWantCaptureKeyboard(byte want_capture_keyboard);
		/// <summary>
		/// Override io.WantCaptureMouse flag next frame (said flag is left for your application to handle, typical when true it instucts your app to ignore inputs). This is equivalent to setting "io.WantCaptureMouse = want_capture_mouse;" after the next NewFrame() call.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetNextFrameWantCaptureMouse(byte want_capture_mouse);
		/// <summary>
		/// allow next item to be overlapped by a subsequent item. Useful with invisible buttons, selectable, treenode covering an area where subsequent items may need to be added. Note that both Selectable() and TreeNode() have dedicated flags doing this.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetNextItemAllowOverlap();
		/// <summary>
		/// set next TreeNode/CollapsingHeader open state.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetNextItemOpen(byte is_open, ImGuiCond cond);
		/// <summary>
		/// set width of the _next_ common large "item+label" widget. &gt;0.0f: width in pixels, &lt;0.0f align xx pixels to the right of window (so -FLT_MIN always align width to the right side)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetNextItemWidth(float item_width);
		/// <summary>
		/// set next window background color alpha. helper to easily override the Alpha component of ImGuiCol_WindowBg/ChildBg/PopupBg. you may also use ImGuiWindowFlags_NoBackground.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetNextWindowBgAlpha(float alpha);
		/// <summary>
		/// set next window class (control docking compatibility + provide hints to platform backend via custom viewport flags and platform parent/child relationship)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetNextWindowClass(ImGuiWindowClass* window_class);
		/// <summary>
		/// set next window collapsed state. call before Begin()
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetNextWindowCollapsed(byte collapsed, ImGuiCond cond);
		/// <summary>
		/// set next window content size (~ scrollable client area, which enforce the range of scrollbars). Not including window decorations (title bar, menu bar, etc.) nor WindowPadding. set an axis to 0.0f to leave it automatic. call before Begin()
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetNextWindowContentSize(Unity.Mathematics.float2 size);
		/// <summary>
		/// set next window dock id
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetNextWindowDockID(uint dock_id, ImGuiCond cond);
		/// <summary>
		/// set next window to be focused / top-most. call before Begin()
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetNextWindowFocus();
		/// <summary>
		/// set next window position. call before Begin(). use pivot=(0.5f,0.5f) to center on given point, etc.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetNextWindowPos(Unity.Mathematics.float2 pos, ImGuiCond cond, Unity.Mathematics.float2 pivot);
		/// <summary>
		/// set next window scrolling value (use &lt; 0.0f to not affect a given axis).
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetNextWindowScroll(Unity.Mathematics.float2 scroll);
		/// <summary>
		/// set next window size. set axis to 0.0f to force an auto-fit on this axis. call before Begin()
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetNextWindowSize(Unity.Mathematics.float2 size, ImGuiCond cond);
		/// <summary>
		/// set next window size limits. use 0.0f or FLT_MAX if you don't want limits. Use -1 for both min and max of same axis to preserve current size (which itself is a constraint). Use callback to apply non-trivial programmatic constraints.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetNextWindowSizeConstraints(Unity.Mathematics.float2 size_min, Unity.Mathematics.float2 size_max, delegate* unmanaged[Cdecl]<ImGuiSizeCallbackData*, void> custom_callback, void* custom_callback_data);
		/// <summary>
		/// set next window viewport
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetNextWindowViewport(uint viewport_id);
		/// <summary>
		/// adjust scrolling amount to make given position visible. Generally GetCursorStartPos() + offset to compute a valid position.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetScrollFromPosX(float local_x, float center_x_ratio);
		/// <summary>
		/// adjust scrolling amount to make given position visible. Generally GetCursorStartPos() + offset to compute a valid position.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetScrollFromPosY(float local_y, float center_y_ratio);
		/// <summary>
		/// adjust scrolling amount to make current cursor position visible. center_x_ratio=0.0: left, 0.5: center, 1.0: right. When using to make a "default/current item" visible, consider using SetItemDefaultFocus() instead.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetScrollHereX(float center_x_ratio);
		/// <summary>
		/// adjust scrolling amount to make current cursor position visible. center_y_ratio=0.0: top, 0.5: center, 1.0: bottom. When using to make a "default/current item" visible, consider using SetItemDefaultFocus() instead.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetScrollHereY(float center_y_ratio);
		/// <summary>
		/// set scrolling amount [0 .. GetScrollMaxX()]
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetScrollX(float scroll_x);
		/// <summary>
		/// set scrolling amount [0 .. GetScrollMaxY()]
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetScrollY(float scroll_y);
		/// <summary>
		/// replace current window storage with our own (if you want to manipulate it yourself, typically clear subsection of it)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetStateStorage(ImGuiStorage* storage);
		/// <summary>
		/// notify TabBar or Docking system of a closed tab/window ahead (useful to reduce visual flicker on reorderable tab bars). For tab-bar: call after BeginTabBar() and before Tab submissions. Otherwise call with a window name.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetTabItemClosed(byte* tab_or_docked_window_label);
		/// <summary>
		/// set a text-only tooltip. Often used after a ImGui::IsItemHovered() check. Override any previous call to SetTooltip().
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetTooltip(byte* fmt);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetTooltipV(byte* fmt, __arglist);
		/// <summary>
		/// (not recommended) set current window collapsed state. prefer using SetNextWindowCollapsed().
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetWindowCollapsed_Bool(byte collapsed, ImGuiCond cond);
		/// <summary>
		/// set named window collapsed state
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetWindowCollapsed_Str(byte* name, byte collapsed, ImGuiCond cond);
		/// <summary>
		/// (not recommended) set current window to be focused / top-most. prefer using SetNextWindowFocus().
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetWindowFocus_Nil();
		/// <summary>
		/// set named window to be focused / top-most. use NULL to remove focus.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetWindowFocus_Str(byte* name);
		/// <summary>
		/// [OBSOLETE] set font scale. Adjust IO.FontGlobalScale if you want to scale all windows. This is an old API! For correct scaling, prefer to reload font + rebuild ImFontAtlas + call style.ScaleAllSizes().
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetWindowFontScale(float scale);
		/// <summary>
		/// (not recommended) set current window position - call within Begin()/End(). prefer using SetNextWindowPos(), as this may incur tearing and side-effects.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetWindowPos_Vec2(Unity.Mathematics.float2 pos, ImGuiCond cond);
		/// <summary>
		/// set named window position.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetWindowPos_Str(byte* name, Unity.Mathematics.float2 pos, ImGuiCond cond);
		/// <summary>
		/// (not recommended) set current window size - call within Begin()/End(). set to ImVec2(0, 0) to force an auto-fit. prefer using SetNextWindowSize(), as this may incur tearing and minor side-effects.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetWindowSize_Vec2(Unity.Mathematics.float2 size, ImGuiCond cond);
		/// <summary>
		/// set named window size. set axis to 0.0f to force an auto-fit on this axis.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSetWindowSize_Str(byte* name, Unity.Mathematics.float2 size, ImGuiCond cond);
		/// <summary>
		/// create About window. display Dear ImGui version, credits and build/system information.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igShowAboutWindow(byte* p_open);
		/// <summary>
		/// create Debug Log window. display a simplified log of important dear imgui events.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igShowDebugLogWindow(byte* p_open);
		/// <summary>
		/// create Demo window. demonstrate most ImGui features. call this to learn about the library! try to make it always available in your application!
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igShowDemoWindow(byte* p_open);
		/// <summary>
		/// add font selector block (not a window), essentially a combo listing the loaded fonts.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igShowFontSelector(byte* label);
		/// <summary>
		/// create Stack Tool window. hover items with mouse to query information about the source of their unique ID.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igShowIDStackToolWindow(byte* p_open);
		/// <summary>
		/// create Metrics/Debugger window. display Dear ImGui internals: windows, draw commands, various internal state, etc.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igShowMetricsWindow(byte* p_open);
		/// <summary>
		/// add style editor block (not a window). you can pass in a reference ImGuiStyle structure to compare to, revert to and save to (else it uses the default style)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igShowStyleEditor(ImGuiStyle* @ref);
		/// <summary>
		/// add style selector block (not a window), essentially a combo listing the default styles.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igShowStyleSelector(byte* label);
		/// <summary>
		/// add basic help/info block (not a window): how to manipulate ImGui as an end-user (mouse/keyboard controls).
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igShowUserGuide();
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igSliderAngle(byte* label, float* v_rad, float v_degrees_min, float v_degrees_max, byte* format, ImGuiSliderFlags flags);
		/// <summary>
		/// adjust format to decorate the value with a prefix or a suffix for in-slider labels or unit display.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igSliderFloat(byte* label, float* v, float v_min, float v_max, byte* format, ImGuiSliderFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igSliderFloat2(byte* label, float* v, float v_min, float v_max, byte* format, ImGuiSliderFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igSliderFloat3(byte* label, float* v, float v_min, float v_max, byte* format, ImGuiSliderFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igSliderFloat4(byte* label, float* v, float v_min, float v_max, byte* format, ImGuiSliderFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igSliderInt(byte* label, int* v, int v_min, int v_max, byte* format, ImGuiSliderFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igSliderInt2(byte* label, int* v, int v_min, int v_max, byte* format, ImGuiSliderFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igSliderInt3(byte* label, int* v, int v_min, int v_max, byte* format, ImGuiSliderFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igSliderInt4(byte* label, int* v, int v_min, int v_max, byte* format, ImGuiSliderFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igSliderScalar(byte* label, ImGuiDataType data_type, void* p_data, void* p_min, void* p_max, byte* format, ImGuiSliderFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igSliderScalarN(byte* label, ImGuiDataType data_type, void* p_data, int components, void* p_min, void* p_max, byte* format, ImGuiSliderFlags flags);
		/// <summary>
		/// button with (FramePadding.y == 0) to easily embed within text
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igSmallButton(byte* label);
		/// <summary>
		/// add vertical spacing.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igSpacing();
		/// <summary>
		/// classic imgui style
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igStyleColorsClassic(ImGuiStyle* dst);
		/// <summary>
		/// new, recommended style (default)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igStyleColorsDark(ImGuiStyle* dst);
		/// <summary>
		/// best used with borders and a custom, thicker font
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igStyleColorsLight(ImGuiStyle* dst);
		/// <summary>
		/// create a Tab behaving like a button. return true when clicked. cannot be selected in the tab bar.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igTabItemButton(byte* label, ImGuiTabItemFlags flags);
		/// <summary>
		/// submit a row with angled headers for every column with the ImGuiTableColumnFlags_AngledHeader flag. MUST BE FIRST ROW.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igTableAngledHeadersRow();
		/// <summary>
		/// return number of columns (value passed to BeginTable)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe int igTableGetColumnCount();
		/// <summary>
		/// return column flags so you can query their Enabled/Visible/Sorted/Hovered status flags. Pass -1 to use current column.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe ImGuiTableColumnFlags igTableGetColumnFlags(int column_n);
		/// <summary>
		/// return current column index.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe int igTableGetColumnIndex();
		/// <summary>
		/// return "" if column didn't have a name declared by TableSetupColumn(). Pass -1 to use current column.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte* igTableGetColumnName(int column_n);
		/// <summary>
		/// return current row index.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe int igTableGetRowIndex();
		/// <summary>
		/// get latest sort specs for the table (NULL if not sorting).  Lifetime: don't hold on this pointer over multiple frames or past any subsequent call to BeginTable().
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe ImGuiTableSortSpecs* igTableGetSortSpecs();
		/// <summary>
		/// submit one header cell manually (rarely used)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igTableHeader(byte* label);
		/// <summary>
		/// submit a row with headers cells based on data provided to TableSetupColumn() + submit context menu
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igTableHeadersRow();
		/// <summary>
		/// append into the next column (or first column of next row if currently in last column). Return true when column is visible.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igTableNextColumn();
		/// <summary>
		/// append into the first cell of a new row.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igTableNextRow(ImGuiTableRowFlags row_flags, float min_row_height);
		/// <summary>
		/// change the color of a cell, row, or column. See ImGuiTableBgTarget_ flags for details.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igTableSetBgColor(ImGuiTableBgTarget target, uint color, int column_n);
		/// <summary>
		/// change user accessible enabled/disabled state of a column. Set to false to hide the column. User can use the context menu to change this themselves (right-click in headers, or right-click in columns body with ImGuiTableFlags_ContextMenuInBody)
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igTableSetColumnEnabled(int column_n, byte v);
		/// <summary>
		/// append into the specified column. Return true when column is visible.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igTableSetColumnIndex(int column_n);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igTableSetupColumn(byte* label, ImGuiTableColumnFlags flags, float init_width_or_weight, uint user_id);
		/// <summary>
		/// lock columns/rows so they stay visible when scrolled.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igTableSetupScrollFreeze(int cols, int rows);
		/// <summary>
		/// formatted text
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igText(byte* fmt);
		/// <summary>
		/// shortcut for PushStyleColor(ImGuiCol_Text, col); Text(fmt, ...); PopStyleColor();
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igTextColored(Unity.Mathematics.float4 col, byte* fmt);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igTextColoredV(Unity.Mathematics.float4 col, byte* fmt, __arglist);
		/// <summary>
		/// shortcut for PushStyleColor(ImGuiCol_Text, style.Colors[ImGuiCol_TextDisabled]); Text(fmt, ...); PopStyleColor();
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igTextDisabled(byte* fmt);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igTextDisabledV(byte* fmt, __arglist);
		/// <summary>
		/// raw text without formatting. Roughly equivalent to Text("%s", text) but: A) doesn't require null terminated string if 'text_end' is specified, B) it's faster, no memory copy is done, no buffer size limits, recommended for long chunks of text.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igTextUnformatted(byte* text, byte* text_end);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igTextV(byte* fmt, __arglist);
		/// <summary>
		/// shortcut for PushTextWrapPos(0.0f); Text(fmt, ...); PopTextWrapPos();. Note that this won't work on an auto-resizing window if there's no other widgets to extend the window width, yoy may need to set a size using SetNextWindowSize().
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igTextWrapped(byte* fmt);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igTextWrappedV(byte* fmt, __arglist);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igTreeNode_Str(byte* label);
		/// <summary>
		/// helper variation to easily decorelate the id from the displayed string. Read the FAQ about why and how to use ID. to align arbitrary text at the same level as a TreeNode() you can use Bullet().
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igTreeNode_StrStr(byte* str_id, byte* fmt);
		/// <summary>
		/// "
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igTreeNode_Ptr(void* ptr_id, byte* fmt);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igTreeNodeEx_Str(byte* label, ImGuiTreeNodeFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igTreeNodeEx_StrStr(byte* str_id, ImGuiTreeNodeFlags flags, byte* fmt);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igTreeNodeEx_Ptr(void* ptr_id, ImGuiTreeNodeFlags flags, byte* fmt);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igTreeNodeExV_Str(byte* str_id, ImGuiTreeNodeFlags flags, byte* fmt, __arglist);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igTreeNodeExV_Ptr(void* ptr_id, ImGuiTreeNodeFlags flags, byte* fmt, __arglist);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igTreeNodeV_Str(byte* str_id, byte* fmt, __arglist);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igTreeNodeV_Ptr(void* ptr_id, byte* fmt, __arglist);
		/// <summary>
		/// ~ Unindent()+PopID()
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igTreePop();
		/// <summary>
		/// ~ Indent()+PushID(). Already called by TreeNode() when returning true, but you can call TreePush/TreePop yourself if desired.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igTreePush_Str(byte* str_id);
		/// <summary>
		/// "
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igTreePush_Ptr(void* ptr_id);
		/// <summary>
		/// move content position back to the left, by indent_w, or style.IndentSpacing if indent_w &lt;= 0
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igUnindent(float indent_w);
		/// <summary>
		/// call in main loop. will call CreateWindow/ResizeWindow/etc. platform functions for each secondary viewport, and DestroyWindow for each inactive viewport.
		/// </summary>
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igUpdatePlatformWindows();
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igVSliderFloat(byte* label, Unity.Mathematics.float2 size, float* v, float v_min, float v_max, byte* format, ImGuiSliderFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igVSliderInt(byte* label, Unity.Mathematics.float2 size, int* v, int v_min, int v_max, byte* format, ImGuiSliderFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe byte igVSliderScalar(byte* label, Unity.Mathematics.float2 size, ImGuiDataType data_type, void* p_data, void* p_min, void* p_max, byte* format, ImGuiSliderFlags flags);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igValue_Bool(byte* prefix, byte b);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igValue_Int(byte* prefix, int v);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igValue_Uint(byte* prefix, uint v);
		[DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe void igValue_Float(byte* prefix, float v, byte* float_format);
#endregion
	}
}
