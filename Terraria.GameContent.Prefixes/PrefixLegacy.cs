using Terraria.ID;

namespace Terraria.GameContent.Prefixes;

public class PrefixLegacy
{
	public class Prefixes
	{
		public static int[] PrefixesForSwords = new int[40]
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15, 36, 37, 38, 53, 54,
			55, 39, 40, 56, 41, 57, 42, 43, 44, 45,
			46, 47, 48, 49, 50, 51, 59, 60, 61, 81
		};

		public static int[] PrefixesForSpears = new int[14]
		{
			36, 37, 38, 53, 54, 55, 39, 40, 56, 41,
			57, 59, 60, 61
		};

		public static int[] PrefixesForGunsBows = new int[35]
		{
			16, 17, 18, 19, 20, 21, 22, 23, 24, 25,
			58, 36, 37, 38, 53, 54, 55, 39, 40, 56,
			41, 57, 42, 44, 45, 46, 47, 48, 49, 50,
			51, 59, 60, 61, 82
		};

		public static int[] PrefixesForMagicAndSummons = new int[36]
		{
			26, 27, 28, 29, 30, 31, 32, 33, 34, 35,
			52, 36, 37, 38, 53, 54, 55, 39, 40, 56,
			41, 57, 42, 43, 44, 45, 46, 47, 48, 49,
			50, 51, 59, 60, 61, 83
		};

		public static int[] PrefixesForBoomeransAndChakrums = new int[14]
		{
			36, 37, 38, 53, 54, 55, 39, 40, 56, 41,
			57, 59, 60, 61
		};

		public static int[] PrefixesForBoomeransAndChakrums_TerrarianYoyo = new int[15]
		{
			36, 37, 38, 53, 54, 55, 39, 40, 56, 41,
			57, 59, 60, 61, 84
		};

		public static int[] PrefixesForAccessories = new int[19]
		{
			62, 63, 64, 65, 66, 67, 68, 69, 70, 71,
			72, 73, 74, 75, 76, 77, 78, 79, 80
		};
	}

	public class ItemSets
	{
		public static SetFactory Factory = new SetFactory(ItemID.Count);

		public static bool[] BoomerangsChakrams = Factory.CreateBoolSet(55, 119, 191, 284, 670, 1122, 1513, 1569, 1571, 1825, 1918, 3054, 3262, 3278, 3279, 3280, 3281, 3282, 3283, 3284, 3285, 3286, 3287, 3288, 3289, 3290, 3291, 3292, 3315, 3316, 3317, 5294, 3030, 3543, 4764, 4818, 4760, 561, 1324, 5298);

		public static bool[] ItemsThatCanHaveLegendary2 = Factory.CreateBoolSet(3389);

		public static bool[] MagicAndSummon = Factory.CreateBoolSet(64, 112, 113, 127, 157, 165, 218, 272, 494, 495, 496, 514, 517, 518, 519, 683, 726, 739, 740, 741, 742, 743, 744, 788, 1121, 1155, 1157, 1178, 1244, 1256, 1260, 1264, 1266, 1295, 1296, 1308, 1309, 1313, 1336, 1444, 1445, 1446, 1572, 1801, 1802, 1930, 1931, 2188, 2622, 2621, 2584, 2551, 2366, 2535, 2365, 2364, 2623, 2750, 2795, 3053, 3051, 3209, 3014, 3105, 2882, 3269, 3006, 3377, 3069, 2749, 3249, 3476, 3474, 3531, 3541, 3542, 3569, 3570, 3571, 3779, 3787, 3531, 3852, 3870, 4269, 4273, 4281, 4347, 4348, 4270, 4758, 4715, 4952, 4607, 5005, 5065, 5069, 5114, 5119, 5118, 5147, 3824, 3818, 3829, 3832, 3825, 3819, 3830, 3833, 3826, 3820, 3831, 3834, 4062);

		public static bool[] GunsBows = Factory.CreateBoolSet(39, 44, 95, 96, 98, 99, 120, 164, 197, 219, 266, 281, 434, 435, 436, 481, 506, 533, 534, 578, 655, 658, 661, 679, 682, 725, 758, 759, 760, 796, 800, 905, 923, 964, 986, 1156, 1187, 1194, 1201, 1229, 1254, 1255, 1258, 1265, 1319, 1553, 1782, 1784, 1835, 1870, 1910, 1929, 1946, 2223, 2269, 2270, 2624, 2515, 2747, 2796, 2797, 3052, 2888, 3019, 3029, 3007, 3008, 3210, 3107, 3475, 3540, 3854, 3859, 3821, 3930, 3480, 3486, 3492, 3498, 3504, 3510, 3516, 3350, 3546, 3788, 4058, 4060, 4381, 4703, 4953, 5117, 5282);

		public static bool[] SpearsMacesChainsawsDrillsPunchCannon = Factory.CreateBoolSet(162, 5011, 5012, 160, 163, 220, 274, 277, 280, 383, 384, 385, 386, 387, 388, 389, 390, 406, 537, 550, 579, 756, 801, 802, 1186, 1189, 1190, 1193, 1196, 1197, 1200, 1203, 1204, 1228, 1231, 1232, 1259, 1262, 1297, 1314, 1325, 1947, 2332, 2331, 2342, 2424, 2611, 2798, 3012, 3473, 3098, 3368, 3835, 3836, 3858, 4061, 4144, 4272, 2774, 2773, 2779, 2778, 2784, 2783, 3464, 3463, 4788, 4789, 4790);

		public static bool[] SwordsHammersAxesPicks = Factory.CreateBoolSet(1, 4, 6, 7, 10, 24, 45, 46, 65, 103, 104, 121, 122, 155, 190, 196, 198, 199, 200, 201, 202, 203, 4258, 204, 213, 217, 273, 367, 368, 426, 482, 483, 484, 653, 654, 656, 657, 659, 660, 671, 672, 674, 675, 676, 723, 724, 757, 776, 777, 778, 787, 795, 797, 798, 799, 881, 882, 921, 922, 989, 990, 991, 992, 993, 1123, 1166, 1185, 1188, 1192, 1195, 1199, 1202, 1222, 1223, 1224, 1226, 1227, 1230, 1233, 1234, 1294, 1304, 1305, 1306, 1320, 1327, 1506, 1507, 1786, 1826, 1827, 1909, 1917, 1928, 2176, 2273, 2608, 2341, 2330, 2320, 2516, 2517, 2746, 2745, 3063, 3018, 3211, 3013, 3258, 3106, 3065, 2880, 3481, 3482, 3483, 3484, 3485, 3487, 3488, 3489, 3490, 3491, 3493, 3494, 3495, 3496, 3497, 3499, 3500, 3501, 3502, 3503, 3505, 3506, 3507, 3508, 3509, 3511, 3512, 3513, 3514, 3515, 3517, 3518, 3519, 3520, 3521, 3522, 3523, 3524, 3525, 3462, 3465, 3466, 2772, 2775, 2776, 2777, 2780, 2781, 2782, 2785, 2786, 3349, 3352, 3351, 3764, 3765, 3766, 3767, 3768, 3769, 4259, 3772, 3823, 3827, 186, 946, 4059, 4317, 4463, 486, 4707, 4711, 4956, 4923, 4672, 4913, 4912, 4911, 4678, 4679, 4680, 4914, 5074, 5094, 5095, 5096, 5097, 5283, 5284, 5129, 5295, 5382);
	}
}
