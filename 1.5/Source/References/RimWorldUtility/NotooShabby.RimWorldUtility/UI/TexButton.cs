using System;
using UnityEngine;
using Verse;

namespace RimWorldUtility.UI
{
	// Token: 0x0200002B RID: 43
	[StaticConstructorOnStartup]
	public class TexButton
	{
		// Token: 0x04000069 RID: 105
		public static readonly Texture2D CloseXBig = ContentFinder<Texture2D>.Get("UI/Widgets/CloseX", true);

		// Token: 0x0400006A RID: 106
		public static readonly Texture2D CloseXSmall = ContentFinder<Texture2D>.Get("UI/Widgets/CloseXSmall", true);

		// Token: 0x0400006B RID: 107
		public static readonly Texture2D NextBig = ContentFinder<Texture2D>.Get("UI/Widgets/NextArrow", true);

		// Token: 0x0400006C RID: 108
		public static readonly Texture2D DeleteX = ContentFinder<Texture2D>.Get("UI/Buttons/Delete", true);

		// Token: 0x0400006D RID: 109
		public static readonly Texture2D ReorderUp = ContentFinder<Texture2D>.Get("UI/Buttons/ReorderUp", true);

		// Token: 0x0400006E RID: 110
		public static readonly Texture2D ReorderDown = ContentFinder<Texture2D>.Get("UI/Buttons/ReorderDown", true);

		// Token: 0x0400006F RID: 111
		public static readonly Texture2D Plus = ContentFinder<Texture2D>.Get("UI/Buttons/Plus", true);

		// Token: 0x04000070 RID: 112
		public static readonly Texture2D Minus = ContentFinder<Texture2D>.Get("UI/Buttons/Minus", true);

		// Token: 0x04000071 RID: 113
		public static readonly Texture2D Suspend = ContentFinder<Texture2D>.Get("UI/Buttons/Suspend", true);

		// Token: 0x04000072 RID: 114
		public static readonly Texture2D SelectOverlappingNext = ContentFinder<Texture2D>.Get("UI/Buttons/SelectNextOverlapping", true);

		// Token: 0x04000073 RID: 115
		public static readonly Texture2D Info = ContentFinder<Texture2D>.Get("UI/Buttons/InfoButton", true);

		// Token: 0x04000074 RID: 116
		public static readonly Texture2D Rename = ContentFinder<Texture2D>.Get("UI/Buttons/Rename", true);

		// Token: 0x04000075 RID: 117
		public static readonly Texture2D Banish = ContentFinder<Texture2D>.Get("UI/Buttons/Banish", true);

		// Token: 0x04000076 RID: 118
		public static readonly Texture2D OpenStatsReport = ContentFinder<Texture2D>.Get("UI/Buttons/OpenStatsReport", true);

		// Token: 0x04000077 RID: 119
		public static readonly Texture2D RenounceTitle = ContentFinder<Texture2D>.Get("UI/Buttons/Renounce", true);

		// Token: 0x04000078 RID: 120
		public static readonly Texture2D Copy = ContentFinder<Texture2D>.Get("UI/Buttons/Copy", true);

		// Token: 0x04000079 RID: 121
		public static readonly Texture2D Paste = ContentFinder<Texture2D>.Get("UI/Buttons/Paste", true);

		// Token: 0x0400007A RID: 122
		public static readonly Texture2D Drop = ContentFinder<Texture2D>.Get("UI/Buttons/Drop", true);

		// Token: 0x0400007B RID: 123
		public static readonly Texture2D Ingest = ContentFinder<Texture2D>.Get("UI/Buttons/Ingest", true);

		// Token: 0x0400007C RID: 124
		public static readonly Texture2D DragHash = ContentFinder<Texture2D>.Get("UI/Buttons/DragHash", true);

		// Token: 0x0400007D RID: 125
		public static readonly Texture2D ToggleLog = ContentFinder<Texture2D>.Get("UI/Buttons/DevRoot/ToggleLog", true);

		// Token: 0x0400007E RID: 126
		public static readonly Texture2D OpenDebugActionsMenu = ContentFinder<Texture2D>.Get("UI/Buttons/DevRoot/OpenDebugActionsMenu", true);

		// Token: 0x0400007F RID: 127
		public static readonly Texture2D OpenInspector = ContentFinder<Texture2D>.Get("UI/Buttons/DevRoot/OpenInspector", true);

		// Token: 0x04000080 RID: 128
		public static readonly Texture2D OpenInspectSettings = ContentFinder<Texture2D>.Get("UI/Buttons/DevRoot/OpenInspectSettings", true);

		// Token: 0x04000081 RID: 129
		public static readonly Texture2D ToggleGodMode = ContentFinder<Texture2D>.Get("UI/Buttons/DevRoot/ToggleGodMode", true);

		// Token: 0x04000083 RID: 131
		public static readonly Texture2D ToggleTweak = ContentFinder<Texture2D>.Get("UI/Buttons/DevRoot/ToggleTweak", true);

		// Token: 0x04000084 RID: 132
		public static readonly Texture2D Add = ContentFinder<Texture2D>.Get("UI/Buttons/Dev/Add", true);

		// Token: 0x04000085 RID: 133
		public static readonly Texture2D NewItem = ContentFinder<Texture2D>.Get("UI/Buttons/Dev/NewItem", true);

		// Token: 0x04000086 RID: 134
		public static readonly Texture2D Reveal = ContentFinder<Texture2D>.Get("UI/Buttons/Dev/Reveal", true);

		// Token: 0x04000087 RID: 135
		public static readonly Texture2D Collapse = ContentFinder<Texture2D>.Get("UI/Buttons/Dev/Collapse", true);

		// Token: 0x04000088 RID: 136
		public static readonly Texture2D Empty = ContentFinder<Texture2D>.Get("UI/Buttons/Dev/Empty", true);

		// Token: 0x04000089 RID: 137
		public static readonly Texture2D Save = ContentFinder<Texture2D>.Get("UI/Buttons/Dev/Save", true);

		// Token: 0x0400008A RID: 138
		public static readonly Texture2D NewFile = ContentFinder<Texture2D>.Get("UI/Buttons/Dev/NewFile", true);

		// Token: 0x0400008B RID: 139
		public static readonly Texture2D RenameDev = ContentFinder<Texture2D>.Get("UI/Buttons/Dev/Rename", true);

		// Token: 0x0400008C RID: 140
		public static readonly Texture2D Reload = ContentFinder<Texture2D>.Get("UI/Buttons/Dev/Reload", true);

		// Token: 0x0400008D RID: 141
		public static readonly Texture2D Play = ContentFinder<Texture2D>.Get("UI/Buttons/Dev/Play", true);

		// Token: 0x0400008E RID: 142
		public static readonly Texture2D Stop = ContentFinder<Texture2D>.Get("UI/Buttons/Dev/Stop", true);

		// Token: 0x0400008F RID: 143
		public static readonly Texture2D RangeMatch = ContentFinder<Texture2D>.Get("UI/Buttons/Dev/RangeMatch", true);

		// Token: 0x04000091 RID: 145
		public static readonly Texture2D CenterOnPointsTex = ContentFinder<Texture2D>.Get("UI/Buttons/Dev/CenterOnPoints", true);

		// Token: 0x04000092 RID: 146
		public static readonly Texture2D CurveResetTex = ContentFinder<Texture2D>.Get("UI/Buttons/Dev/CurveReset", true);

		// Token: 0x04000093 RID: 147
		public static readonly Texture2D QuickZoomHor1Tex = ContentFinder<Texture2D>.Get("UI/Buttons/Dev/QuickZoomHor1", true);

		// Token: 0x04000094 RID: 148
		public static readonly Texture2D QuickZoomHor100Tex = ContentFinder<Texture2D>.Get("UI/Buttons/Dev/QuickZoomHor100", true);

		// Token: 0x04000095 RID: 149
		public static readonly Texture2D QuickZoomHor20kTex = ContentFinder<Texture2D>.Get("UI/Buttons/Dev/QuickZoomHor20k", true);

		// Token: 0x04000096 RID: 150
		public static readonly Texture2D QuickZoomVer1Tex = ContentFinder<Texture2D>.Get("UI/Buttons/Dev/QuickZoomVer1", true);

		// Token: 0x04000097 RID: 151
		public static readonly Texture2D QuickZoomVer100Tex = ContentFinder<Texture2D>.Get("UI/Buttons/Dev/QuickZoomVer100", true);

		// Token: 0x04000098 RID: 152
		public static readonly Texture2D QuickZoomVer20kTex = ContentFinder<Texture2D>.Get("UI/Buttons/Dev/QuickZoomVer20k", true);

		// Token: 0x04000099 RID: 153
		public static readonly Texture2D IconBlog = ContentFinder<Texture2D>.Get("UI/HeroArt/WebIcons/Blog", true);

		// Token: 0x0400009A RID: 154
		public static readonly Texture2D IconForums = ContentFinder<Texture2D>.Get("UI/HeroArt/WebIcons/Forums", true);

		// Token: 0x0400009B RID: 155
		public static readonly Texture2D IconTwitter = ContentFinder<Texture2D>.Get("UI/HeroArt/WebIcons/Twitter", true);

		// Token: 0x0400009C RID: 156
		public static readonly Texture2D IconBook = ContentFinder<Texture2D>.Get("UI/HeroArt/WebIcons/Book", true);

		// Token: 0x0400009D RID: 157
		public static readonly Texture2D IconSoundtrack = ContentFinder<Texture2D>.Get("UI/HeroArt/WebIcons/Soundtrack", true);

		// Token: 0x0400009E RID: 158
		public static readonly Texture2D ShowLearningHelper = ContentFinder<Texture2D>.Get("UI/Buttons/ShowLearningHelper", true);

		// Token: 0x0400009F RID: 159
		public static readonly Texture2D ShowZones = ContentFinder<Texture2D>.Get("UI/Buttons/ShowZones", true);

		// Token: 0x040000A0 RID: 160
		public static readonly Texture2D ShowFertilityOverlay = ContentFinder<Texture2D>.Get("UI/Buttons/ShowFertilityOverlay", true);

		// Token: 0x040000A1 RID: 161
		public static readonly Texture2D ShowTerrainAffordanceOverlay = ContentFinder<Texture2D>.Get("UI/Buttons/ShowTerrainAffordanceOverlay", true);

		// Token: 0x040000A2 RID: 162
		public static readonly Texture2D ShowBeauty = ContentFinder<Texture2D>.Get("UI/Buttons/ShowBeauty", true);

		// Token: 0x040000A3 RID: 163
		public static readonly Texture2D ShowRoomStats = ContentFinder<Texture2D>.Get("UI/Buttons/ShowRoomStats", true);

		// Token: 0x040000A4 RID: 164
		public static readonly Texture2D ShowColonistBar = ContentFinder<Texture2D>.Get("UI/Buttons/ShowColonistBar", true);

		// Token: 0x040000A5 RID: 165
		public static readonly Texture2D ShowRoofOverlay = ContentFinder<Texture2D>.Get("UI/Buttons/ShowRoofOverlay", true);

		// Token: 0x040000A6 RID: 166
		public static readonly Texture2D AutoHomeArea = ContentFinder<Texture2D>.Get("UI/Buttons/AutoHomeArea", true);

		// Token: 0x040000A7 RID: 167
		public static readonly Texture2D AutoRebuild = ContentFinder<Texture2D>.Get("UI/Buttons/AutoRebuild", true);

		// Token: 0x040000A8 RID: 168
		public static readonly Texture2D CategorizedResourceReadout = ContentFinder<Texture2D>.Get("UI/Buttons/ResourceReadoutCategorized", true);

		// Token: 0x040000A9 RID: 169
		public static readonly Texture2D LockNorthUp = ContentFinder<Texture2D>.Get("UI/Buttons/LockNorthUp", true);

		// Token: 0x040000AA RID: 170
		public static readonly Texture2D UsePlanetDayNightSystem = ContentFinder<Texture2D>.Get("UI/Buttons/UsePlanetDayNightSystem", true);

		// Token: 0x040000AB RID: 171
		public static readonly Texture2D ShowExpandingIcons = ContentFinder<Texture2D>.Get("UI/Buttons/ShowExpandingIcons", true);

		// Token: 0x040000AC RID: 172
		public static readonly Texture2D ShowWorldFeatures = ContentFinder<Texture2D>.Get("UI/Buttons/ShowWorldFeatures", true);

		// Token: 0x040000AD RID: 173
		public static readonly Texture2D[] SpeedButtonTextures = new Texture2D[]
		{
			ContentFinder<Texture2D>.Get("UI/TimeControls/TimeSpeedButton_Pause", true),
			ContentFinder<Texture2D>.Get("UI/TimeControls/TimeSpeedButton_Normal", true),
			ContentFinder<Texture2D>.Get("UI/TimeControls/TimeSpeedButton_Fast", true),
			ContentFinder<Texture2D>.Get("UI/TimeControls/TimeSpeedButton_Superfast", true),
			ContentFinder<Texture2D>.Get("UI/TimeControls/TimeSpeedButton_Superfast", true)
		};
	}
}
