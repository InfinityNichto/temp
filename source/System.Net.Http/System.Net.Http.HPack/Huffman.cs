namespace System.Net.Http.HPack;

internal static class Huffman
{
	private static readonly uint[] s_encodingTableCodes = new uint[257]
	{
		4290772992u, 4294946816u, 4294966816u, 4294966832u, 4294966848u, 4294966864u, 4294966880u, 4294966896u, 4294966912u, 4294961664u,
		4294967280u, 4294966928u, 4294966944u, 4294967284u, 4294966960u, 4294966976u, 4294966992u, 4294967008u, 4294967024u, 4294967040u,
		4294967056u, 4294967072u, 4294967288u, 4294967088u, 4294967104u, 4294967120u, 4294967136u, 4294967152u, 4294967168u, 4294967184u,
		4294967200u, 4294967216u, 1342177280u, 4261412864u, 4265607168u, 4288675840u, 4291297280u, 1409286144u, 4160749568u, 4282384384u,
		4269801472u, 4273995776u, 4177526784u, 4284481536u, 4194304000u, 1476395008u, 1543503872u, 1610612736u, 0u, 134217728u,
		268435456u, 1677721600u, 1744830464u, 1811939328u, 1879048192u, 1946157056u, 2013265920u, 2080374784u, 3087007744u, 4211081216u,
		4294443008u, 2147483648u, 4289724416u, 4278190080u, 4291821568u, 2214592512u, 3120562176u, 3154116608u, 3187671040u, 3221225472u,
		3254779904u, 3288334336u, 3321888768u, 3355443200u, 3388997632u, 3422552064u, 3456106496u, 3489660928u, 3523215360u, 3556769792u,
		3590324224u, 3623878656u, 3657433088u, 3690987520u, 3724541952u, 3758096384u, 3791650816u, 3825205248u, 4227858432u, 3858759680u,
		4244635648u, 4292345856u, 4294836224u, 4292870144u, 4293918720u, 2281701376u, 4294574080u, 402653184u, 2348810240u, 536870912u,
		2415919104u, 671088640u, 2483027968u, 2550136832u, 2617245696u, 805306368u, 3892314112u, 3925868544u, 2684354560u, 2751463424u,
		2818572288u, 939524096u, 2885681152u, 3959422976u, 2952790016u, 1073741824u, 1207959552u, 3019898880u, 3992977408u, 4026531840u,
		4060086272u, 4093640704u, 4127195136u, 4294705152u, 4286578688u, 4294180864u, 4293394432u, 4294967232u, 4294860800u, 4294920192u,
		4294864896u, 4294868992u, 4294921216u, 4294922240u, 4294923264u, 4294947328u, 4294924288u, 4294947840u, 4294948352u, 4294948864u,
		4294949376u, 4294949888u, 4294961920u, 4294950400u, 4294962176u, 4294962432u, 4294925312u, 4294950912u, 4294962688u, 4294951424u,
		4294951936u, 4294952448u, 4294952960u, 4294893568u, 4294926336u, 4294953472u, 4294927360u, 4294953984u, 4294954496u, 4294962944u,
		4294928384u, 4294895616u, 4294873088u, 4294929408u, 4294930432u, 4294955008u, 4294955520u, 4294897664u, 4294956032u, 4294931456u,
		4294932480u, 4294963200u, 4294899712u, 4294933504u, 4294956544u, 4294957056u, 4294901760u, 4294903808u, 4294934528u, 4294905856u,
		4294957568u, 4294935552u, 4294958080u, 4294958592u, 4294877184u, 4294936576u, 4294937600u, 4294938624u, 4294959104u, 4294939648u,
		4294940672u, 4294959616u, 4294965248u, 4294965312u, 4294881280u, 4294844416u, 4294941696u, 4294960128u, 4294942720u, 4294964736u,
		4294965376u, 4294965440u, 4294965504u, 4294966208u, 4294966240u, 4294965568u, 4294963456u, 4294964864u, 4294852608u, 4294907904u,
		4294965632u, 4294966272u, 4294966304u, 4294965696u, 4294966336u, 4294963712u, 4294909952u, 4294912000u, 4294965760u, 4294965824u,
		4294967248u, 4294966368u, 4294966400u, 4294966432u, 4294885376u, 4294963968u, 4294889472u, 4294914048u, 4294943744u, 4294916096u,
		4294918144u, 4294960640u, 4294944768u, 4294945792u, 4294964992u, 4294965120u, 4294964224u, 4294964480u, 4294965888u, 4294961152u,
		4294965952u, 4294966464u, 4294966016u, 4294966080u, 4294966496u, 4294966528u, 4294966560u, 4294966592u, 4294966624u, 4294967264u,
		4294966656u, 4294966688u, 4294966720u, 4294966752u, 4294966784u, 4294966144u, 4294967292u
	};

	private static readonly ushort[] s_decodingTree = GenerateDecodingLookupTree();

	private static ReadOnlySpan<byte> EncodingTableBitLengths => new byte[257]
	{
		13, 23, 28, 28, 28, 28, 28, 28, 28, 24,
		30, 28, 28, 30, 28, 28, 28, 28, 28, 28,
		28, 28, 30, 28, 28, 28, 28, 28, 28, 28,
		28, 28, 6, 10, 10, 12, 13, 6, 8, 11,
		10, 10, 8, 11, 8, 6, 6, 6, 5, 5,
		5, 6, 6, 6, 6, 6, 6, 6, 7, 8,
		15, 6, 12, 10, 13, 6, 7, 7, 7, 7,
		7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
		7, 7, 7, 7, 7, 7, 7, 7, 8, 7,
		8, 13, 19, 13, 14, 6, 15, 5, 6, 5,
		6, 5, 6, 6, 6, 5, 7, 7, 6, 6,
		6, 5, 6, 7, 6, 5, 5, 6, 7, 7,
		7, 7, 7, 15, 11, 14, 13, 28, 20, 22,
		20, 20, 22, 22, 22, 23, 22, 23, 23, 23,
		23, 23, 24, 23, 24, 24, 22, 23, 24, 23,
		23, 23, 23, 21, 22, 23, 22, 23, 23, 24,
		22, 21, 20, 22, 22, 23, 23, 21, 23, 22,
		22, 24, 21, 22, 23, 23, 21, 21, 22, 21,
		23, 22, 23, 23, 20, 22, 22, 22, 23, 22,
		22, 23, 26, 26, 20, 19, 22, 23, 22, 25,
		26, 26, 26, 27, 27, 26, 24, 25, 19, 21,
		26, 27, 27, 26, 27, 24, 21, 21, 26, 26,
		28, 27, 27, 27, 20, 24, 20, 21, 22, 21,
		21, 23, 22, 22, 25, 25, 24, 24, 26, 23,
		26, 27, 26, 26, 27, 27, 27, 27, 27, 28,
		27, 27, 27, 27, 27, 26, 30
	};

	private static ushort[] GenerateDecodingLookupTree()
	{
		ushort[] array = new ushort[3840];
		uint[] array2 = s_encodingTableCodes;
		ReadOnlySpan<byte> encodingTableBitLengths = EncodingTableBitLengths;
		int num = 0;
		for (int i = 0; i <= 256; i++)
		{
			uint num2 = array2[i];
			int num3 = encodingTableBitLengths[i];
			int num4 = 0;
			int num5 = num3;
			while (num5 > 0)
			{
				int num6 = (int)(num2 >> 24);
				if (num5 <= 8)
				{
					int num7 = 1 << 8 - num5;
					for (int j = 0; j < num7; j++)
					{
						if (i == 256)
						{
							array[(num4 << 8) + (num6 | j)] = 33023;
						}
						else
						{
							array[(num4 << 8) + (num6 | j)] = (ushort)((num5 << 8) | i);
						}
					}
				}
				else
				{
					ushort num8 = array[(num4 << 8) + num6];
					if (num8 == 0)
					{
						num++;
						array[(num4 << 8) + num6] = (ushort)((0x80 | num) << 8);
						num4 = num;
					}
					else
					{
						num4 = (num8 & 0x7F00) >> 8;
					}
				}
				num5 -= 8;
				num2 <<= 8;
			}
		}
		return array;
	}

	public static int Decode(ReadOnlySpan<byte> src, ref byte[] dstArray)
	{
		Span<byte> span = dstArray;
		ushort[] array = s_decodingTree;
		int num = 0;
		uint num2 = 0u;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		while (num4 < src.Length)
		{
			num2 <<= 8;
			num2 |= src[num4++];
			num3 += 8;
			do
			{
				int num6 = (byte)(num2 >> num3 - 8);
				int num7 = array[(num << 8) + num6];
				if (num7 < 32768)
				{
					if (num5 == span.Length)
					{
						Array.Resize(ref dstArray, span.Length * 2);
						span = dstArray;
					}
					span[num5++] = (byte)num7;
					num = 0;
					num3 -= num7 >> 8;
				}
				else
				{
					num = (num7 & 0x7F00) >> 8;
					if (num == 0)
					{
						throw new HuffmanDecodingException(System.SR.net_http_hpack_huffman_decode_failed);
					}
					num3 -= 8;
				}
			}
			while (num3 >= 8);
		}
		while (num3 > 0)
		{
			if (num == 0)
			{
				uint num8 = uint.MaxValue >> 32 - num3;
				if ((num2 & num8) == num8)
				{
					break;
				}
			}
			int num6 = (byte)(num2 << 8 - num3);
			int num9 = array[(num << 8) + num6];
			if (num9 < 32768)
			{
				num3 -= num9 >> 8;
				if (num3 < 0)
				{
					throw new HuffmanDecodingException(System.SR.net_http_hpack_huffman_decode_failed);
				}
				if (num5 == span.Length)
				{
					Array.Resize(ref dstArray, span.Length * 2);
					span = dstArray;
				}
				span[num5++] = (byte)num9;
				num = 0;
				continue;
			}
			throw new HuffmanDecodingException(System.SR.net_http_hpack_huffman_decode_failed);
		}
		if (num != 0)
		{
			throw new HuffmanDecodingException(System.SR.net_http_hpack_huffman_decode_failed);
		}
		return num5;
	}
}
