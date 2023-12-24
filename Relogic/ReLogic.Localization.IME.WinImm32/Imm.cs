namespace ReLogic.Localization.IME.WinImm32;

internal static class Imm
{
	public const int ISC_SHOWUICANDIDATEWINDOW = 1;

	public const int ISC_SHOWUICOMPOSITIONWINDOW = int.MinValue;

	public const int ISC_SHOWUIGUIDELINE = 1073741824;

	public const int ISC_SHOWUIALLCANDIDATEWINDOW = 15;

	public const int ISC_SHOWUIALL = -1073741809;

	public const uint GCS_COMPREADSTR = 1u;

	public const uint GCS_COMPREADATTR = 2u;

	public const uint GCS_COMPREADCLAUSE = 4u;

	public const uint GCS_COMPSTR = 8u;

	public const uint GCS_COMPATTR = 16u;

	public const uint GCS_COMPCLAUSE = 32u;

	public const uint GCS_CURSORPOS = 128u;

	public const uint GCS_DELTASTART = 256u;

	public const uint GCS_RESULTREADSTR = 512u;

	public const uint GCS_RESULTREADCLAUSE = 1024u;

	public const uint GCS_RESULTSTR = 2048u;

	public const uint GCS_RESULTCLAUSE = 4096u;

	public const uint SCS_SETSTR = 9u;

	public const uint SCS_CHANGEATTRIBUTES = 4u;

	public const uint CPS_CANCEL = 4u;

	public const uint NI_CLOSECANDIDATE = 16u;

	public const uint NI_COMPOSITIONSTR = 21u;

	public const int IMN_CLOSESTATUSWINDOW = 1;

	public const int IMN_OPENSTATUSWINDOW = 2;

	public const int IMN_CHANGECANDIDATE = 3;

	public const int IMN_CLOSECANDIDATE = 4;

	public const int IMN_OPENCANDIDATE = 5;

	public const int IMN_SETCONVERSIONMODE = 6;

	public const int IMN_SETSENTENCEMODE = 7;

	public const int IMN_SETOPENSTATUS = 8;

	public const int IMN_SETCANDIDATEPOS = 9;

	public const int IMN_SETCOMPOSITIONFONT = 10;

	public const int IMN_SETCOMPOSITIONWINDOW = 11;

	public const int IMN_SETSTATUSWINDOWPOS = 12;

	public const int IMN_GUIDELINE = 13;

	public const int IMN_PRIVATE = 14;

	public const int IMC_GETCANDIDATEPOS = 7;

	public const int IMC_SETCANDIDATEPOS = 8;

	public const int IMC_GETCOMPOSITIONFONT = 9;

	public const int IMC_SETCOMPOSITIONFONT = 10;

	public const int IMC_GETCOMPOSITIONWINDOW = 11;

	public const int IMC_SETCOMPOSITIONWINDOW = 12;

	public const int IMC_GETSTATUSWINDOWPOS = 15;

	public const int IMC_SETSTATUSWINDOWPOS = 16;

	public const int IMC_CLOSESTATUSWINDOW = 33;

	public const int IMC_OPENSTATUSWINDOW = 34;

	public const int WA_INACTIVE = 0;

	public const int WA_ACTIVE = 1;

	public const int WA_CLICKACTIVE = 2;

	public const ushort LANG_NEUTRAL = 0;

	public const ushort LANG_INVARIANT = 127;

	public const ushort LANG_AFRIKAANS = 54;

	public const ushort LANG_ALBANIAN = 28;

	public const ushort LANG_ALSATIAN = 132;

	public const ushort LANG_AMHARIC = 94;

	public const ushort LANG_ARABIC = 1;

	public const ushort LANG_ARMENIAN = 43;

	public const ushort LANG_ASSAMESE = 77;

	public const ushort LANG_AZERI = 44;

	public const ushort LANG_AZERBAIJANI = 44;

	public const ushort LANG_BANGLA = 69;

	public const ushort LANG_BASHKIR = 109;

	public const ushort LANG_BASQUE = 45;

	public const ushort LANG_BELARUSIAN = 35;

	public const ushort LANG_BENGALI = 69;

	public const ushort LANG_BRETON = 126;

	public const ushort LANG_BOSNIAN = 26;

	public const ushort LANG_BOSNIAN_NEUTRAL = 30746;

	public const ushort LANG_BULGARIAN = 2;

	public const ushort LANG_CATALAN = 3;

	public const ushort LANG_CENTRAL_KURDISH = 146;

	public const ushort LANG_CHEROKEE = 92;

	public const ushort LANG_CHINESE = 4;

	public const ushort LANG_CHINESE_SIMPLIFIED = 4;

	public const ushort LANG_CHINESE_TRADITIONAL = 31748;

	public const ushort LANG_CORSICAN = 131;

	public const ushort LANG_CROATIAN = 26;

	public const ushort LANG_CZECH = 5;

	public const ushort LANG_DANISH = 6;

	public const ushort LANG_DARI = 140;

	public const ushort LANG_DIVEHI = 101;

	public const ushort LANG_DUTCH = 19;

	public const ushort LANG_ENGLISH = 9;

	public const ushort LANG_ESTONIAN = 37;

	public const ushort LANG_FAEROESE = 56;

	public const ushort LANG_FARSI = 41;

	public const ushort LANG_FILIPINO = 100;

	public const ushort LANG_FINNISH = 11;

	public const ushort LANG_FRENCH = 12;

	public const ushort LANG_FRISIAN = 98;

	public const ushort LANG_FULAH = 103;

	public const ushort LANG_GALICIAN = 86;

	public const ushort LANG_GEORGIAN = 55;

	public const ushort LANG_GERMAN = 7;

	public const ushort LANG_GREEK = 8;

	public const ushort LANG_GREENLANDIC = 111;

	public const ushort LANG_GUJARATI = 71;

	public const ushort LANG_HAUSA = 104;

	public const ushort LANG_HAWAIIAN = 117;

	public const ushort LANG_HEBREW = 13;

	public const ushort LANG_HINDI = 57;

	public const ushort LANG_HUNGARIAN = 14;

	public const ushort LANG_ICELANDIC = 15;

	public const ushort LANG_IGBO = 112;

	public const ushort LANG_INDONESIAN = 33;

	public const ushort LANG_INUKTITUT = 93;

	public const ushort LANG_IRISH = 60;

	public const ushort LANG_ITALIAN = 16;

	public const ushort LANG_JAPANESE = 17;

	public const ushort LANG_KANNADA = 75;

	public const ushort LANG_KASHMIRI = 96;

	public const ushort LANG_KAZAK = 63;

	public const ushort LANG_KHMER = 83;

	public const ushort LANG_KICHE = 134;

	public const ushort LANG_KINYARWANDA = 135;

	public const ushort LANG_KONKANI = 87;

	public const ushort LANG_KOREAN = 18;

	public const ushort LANG_KYRGYZ = 64;

	public const ushort LANG_LAO = 84;

	public const ushort LANG_LATVIAN = 38;

	public const ushort LANG_LITHUANIAN = 39;

	public const ushort LANG_LOWER_SORBIAN = 46;

	public const ushort LANG_LUXEMBOURGISH = 110;

	public const ushort LANG_MACEDONIAN = 47;

	public const ushort LANG_MALAY = 62;

	public const ushort LANG_MALAYALAM = 76;

	public const ushort LANG_MALTESE = 58;

	public const ushort LANG_MANIPURI = 88;

	public const ushort LANG_MAORI = 129;

	public const ushort LANG_MAPUDUNGUN = 122;

	public const ushort LANG_MARATHI = 78;

	public const ushort LANG_MOHAWK = 124;

	public const ushort LANG_MONGOLIAN = 80;

	public const ushort LANG_NEPALI = 97;

	public const ushort LANG_NORWEGIAN = 20;

	public const ushort LANG_OCCITAN = 130;

	public const ushort LANG_ODIA = 72;

	public const ushort LANG_ORIYA = 72;

	public const ushort LANG_PASHTO = 99;

	public const ushort LANG_PERSIAN = 41;

	public const ushort LANG_POLISH = 21;

	public const ushort LANG_PORTUGUESE = 22;

	public const ushort LANG_PULAR = 103;

	public const ushort LANG_PUNJABI = 70;

	public const ushort LANG_QUECHUA = 107;

	public const ushort LANG_ROMANIAN = 24;

	public const ushort LANG_ROMANSH = 23;

	public const ushort LANG_RUSSIAN = 25;

	public const ushort LANG_SAKHA = 133;

	public const ushort LANG_SAMI = 59;

	public const ushort LANG_SANSKRIT = 79;

	public const ushort LANG_SCOTTISH_GAELIC = 145;

	public const ushort LANG_SERBIAN = 26;

	public const ushort LANG_SERBIAN_NEUTRAL = 31770;

	public const ushort LANG_SINDHI = 89;

	public const ushort LANG_SINHALESE = 91;

	public const ushort LANG_SLOVAK = 27;

	public const ushort LANG_SLOVENIAN = 36;

	public const ushort LANG_SOTHO = 108;

	public const ushort LANG_SPANISH = 10;

	public const ushort LANG_SWAHILI = 65;

	public const ushort LANG_SWEDISH = 29;

	public const ushort LANG_SYRIAC = 90;

	public const ushort LANG_TAJIK = 40;

	public const ushort LANG_TAMAZIGHT = 95;

	public const ushort LANG_TAMIL = 73;

	public const ushort LANG_TATAR = 68;

	public const ushort LANG_TELUGU = 74;

	public const ushort LANG_THAI = 30;

	public const ushort LANG_TIBETAN = 81;

	public const ushort LANG_TIGRIGNA = 115;

	public const ushort LANG_TIGRINYA = 115;

	public const ushort LANG_TSWANA = 50;

	public const ushort LANG_TURKISH = 31;

	public const ushort LANG_TURKMEN = 66;

	public const ushort LANG_UIGHUR = 128;

	public const ushort LANG_UKRAINIAN = 34;

	public const ushort LANG_UPPER_SORBIAN = 46;

	public const ushort LANG_URDU = 32;

	public const ushort LANG_UZBEK = 67;

	public const ushort LANG_VALENCIAN = 3;

	public const ushort LANG_VIETNAMESE = 42;

	public const ushort LANG_WELSH = 82;

	public const ushort LANG_WOLOF = 136;

	public const ushort LANG_XHOSA = 52;

	public const ushort LANG_YAKUT = 133;

	public const ushort LANG_YI = 120;

	public const ushort LANG_YORUBA = 106;

	public const ushort LANG_ZULU = 53;

	public const ushort SUBLANG_NEUTRAL = 0;

	public const ushort SUBLANG_DEFAULT = 1;

	public const ushort SUBLANG_SYS_DEFAULT = 2;

	public const ushort SUBLANG_CUSTOM_DEFAULT = 3;

	public const ushort SUBLANG_CUSTOM_UNSPECIFIED = 4;

	public const ushort SUBLANG_UI_CUSTOM_DEFAULT = 5;

	public const ushort SUBLANG_AFRIKAANS_SOUTH_AFRICA = 1;

	public const ushort SUBLANG_ALBANIAN_ALBANIA = 1;

	public const ushort SUBLANG_ALSATIAN_FRANCE = 1;

	public const ushort SUBLANG_AMHARIC_ETHIOPIA = 1;

	public const ushort SUBLANG_ARABIC_SAUDI_ARABIA = 1;

	public const ushort SUBLANG_ARABIC_IRAQ = 2;

	public const ushort SUBLANG_ARABIC_EGYPT = 3;

	public const ushort SUBLANG_ARABIC_LIBYA = 4;

	public const ushort SUBLANG_ARABIC_ALGERIA = 5;

	public const ushort SUBLANG_ARABIC_MOROCCO = 6;

	public const ushort SUBLANG_ARABIC_TUNISIA = 7;

	public const ushort SUBLANG_ARABIC_OMAN = 8;

	public const ushort SUBLANG_ARABIC_YEMEN = 9;

	public const ushort SUBLANG_ARABIC_SYRIA = 10;

	public const ushort SUBLANG_ARABIC_JORDAN = 11;

	public const ushort SUBLANG_ARABIC_LEBANON = 12;

	public const ushort SUBLANG_ARABIC_KUWAIT = 13;

	public const ushort SUBLANG_ARABIC_UAE = 14;

	public const ushort SUBLANG_ARABIC_BAHRAIN = 15;

	public const ushort SUBLANG_ARABIC_QATAR = 16;

	public const ushort SUBLANG_ARMENIAN_ARMENIA = 1;

	public const ushort SUBLANG_ASSAMESE_INDIA = 1;

	public const ushort SUBLANG_AZERI_LATIN = 1;

	public const ushort SUBLANG_AZERI_CYRILLIC = 2;

	public const ushort SUBLANG_AZERBAIJANI_AZERBAIJAN_LATIN = 1;

	public const ushort SUBLANG_AZERBAIJANI_AZERBAIJAN_CYRILLIC = 2;

	public const ushort SUBLANG_BANGLA_INDIA = 1;

	public const ushort SUBLANG_BANGLA_BANGLADESH = 2;

	public const ushort SUBLANG_BASHKIR_RUSSIA = 1;

	public const ushort SUBLANG_BASQUE_BASQUE = 1;

	public const ushort SUBLANG_BELARUSIAN_BELARUS = 1;

	public const ushort SUBLANG_BENGALI_INDIA = 1;

	public const ushort SUBLANG_BENGALI_BANGLADESH = 2;

	public const ushort SUBLANG_BOSNIAN_BOSNIA_HERZEGOVINA_LATIN = 5;

	public const ushort SUBLANG_BOSNIAN_BOSNIA_HERZEGOVINA_CYRILLIC = 8;

	public const ushort SUBLANG_BRETON_FRANCE = 1;

	public const ushort SUBLANG_BULGARIAN_BULGARIA = 1;

	public const ushort SUBLANG_CATALAN_CATALAN = 1;

	public const ushort SUBLANG_CENTRAL_KURDISH_IRAQ = 1;

	public const ushort SUBLANG_CHEROKEE_CHEROKEE = 1;

	public const ushort SUBLANG_CHINESE_TRADITIONAL = 1;

	public const ushort SUBLANG_CHINESE_SIMPLIFIED = 2;

	public const ushort SUBLANG_CHINESE_HONGKONG = 3;

	public const ushort SUBLANG_CHINESE_SINGAPORE = 4;

	public const ushort SUBLANG_CHINESE_MACAU = 5;

	public const ushort SUBLANG_CORSICAN_FRANCE = 1;

	public const ushort SUBLANG_CZECH_CZECH_REPUBLIC = 1;

	public const ushort SUBLANG_CROATIAN_CROATIA = 1;

	public const ushort SUBLANG_CROATIAN_BOSNIA_HERZEGOVINA_LATIN = 4;

	public const ushort SUBLANG_DANISH_DENMARK = 1;

	public const ushort SUBLANG_DARI_AFGHANISTAN = 1;

	public const ushort SUBLANG_DIVEHI_MALDIVES = 1;

	public const ushort SUBLANG_DUTCH = 1;

	public const ushort SUBLANG_DUTCH_BELGIAN = 2;

	public const ushort SUBLANG_ENGLISH_US = 1;

	public const ushort SUBLANG_ENGLISH_UK = 2;

	public const ushort SUBLANG_ENGLISH_AUS = 3;

	public const ushort SUBLANG_ENGLISH_CAN = 4;

	public const ushort SUBLANG_ENGLISH_NZ = 5;

	public const ushort SUBLANG_ENGLISH_EIRE = 6;

	public const ushort SUBLANG_ENGLISH_SOUTH_AFRICA = 7;

	public const ushort SUBLANG_ENGLISH_JAMAICA = 8;

	public const ushort SUBLANG_ENGLISH_CARIBBEAN = 9;

	public const ushort SUBLANG_ENGLISH_BELIZE = 10;

	public const ushort SUBLANG_ENGLISH_TRINIDAD = 11;

	public const ushort SUBLANG_ENGLISH_ZIMBABWE = 12;

	public const ushort SUBLANG_ENGLISH_PHILIPPINES = 13;

	public const ushort SUBLANG_ENGLISH_INDIA = 16;

	public const ushort SUBLANG_ENGLISH_MALAYSIA = 17;

	public const ushort SUBLANG_ENGLISH_SINGAPORE = 18;

	public const ushort SUBLANG_ESTONIAN_ESTONIA = 1;

	public const ushort SUBLANG_FAEROESE_FAROE_ISLANDS = 1;

	public const ushort SUBLANG_FILIPINO_PHILIPPINES = 1;

	public const ushort SUBLANG_FINNISH_FINLAND = 1;

	public const ushort SUBLANG_FRENCH = 1;

	public const ushort SUBLANG_FRENCH_BELGIAN = 2;

	public const ushort SUBLANG_FRENCH_CANADIAN = 3;

	public const ushort SUBLANG_FRENCH_SWISS = 4;

	public const ushort SUBLANG_FRENCH_LUXEMBOURG = 5;

	public const ushort SUBLANG_FRENCH_MONACO = 6;

	public const ushort SUBLANG_FRISIAN_NETHERLANDS = 1;

	public const ushort SUBLANG_FULAH_SENEGAL = 2;

	public const ushort SUBLANG_GALICIAN_GALICIAN = 1;

	public const ushort SUBLANG_GEORGIAN_GEORGIA = 1;

	public const ushort SUBLANG_GERMAN = 1;

	public const ushort SUBLANG_GERMAN_SWISS = 2;

	public const ushort SUBLANG_GERMAN_AUSTRIAN = 3;

	public const ushort SUBLANG_GERMAN_LUXEMBOURG = 4;

	public const ushort SUBLANG_GERMAN_LIECHTENSTEIN = 5;

	public const ushort SUBLANG_GREEK_GREECE = 1;

	public const ushort SUBLANG_GREENLANDIC_GREENLAND = 1;

	public const ushort SUBLANG_GUJARATI_INDIA = 1;

	public const ushort SUBLANG_HAUSA_NIGERIA_LATIN = 1;

	public const ushort SUBLANG_HAWAIIAN_US = 1;

	public const ushort SUBLANG_HEBREW_ISRAEL = 1;

	public const ushort SUBLANG_HINDI_INDIA = 1;

	public const ushort SUBLANG_HUNGARIAN_HUNGARY = 1;

	public const ushort SUBLANG_ICELANDIC_ICELAND = 1;

	public const ushort SUBLANG_IGBO_NIGERIA = 1;

	public const ushort SUBLANG_INDONESIAN_INDONESIA = 1;

	public const ushort SUBLANG_INUKTITUT_CANADA = 1;

	public const ushort SUBLANG_INUKTITUT_CANADA_LATIN = 2;

	public const ushort SUBLANG_IRISH_IRELAND = 2;

	public const ushort SUBLANG_ITALIAN = 1;

	public const ushort SUBLANG_ITALIAN_SWISS = 2;

	public const ushort SUBLANG_JAPANESE_JAPAN = 1;

	public const ushort SUBLANG_KANNADA_INDIA = 1;

	public const ushort SUBLANG_KASHMIRI_SASIA = 2;

	public const ushort SUBLANG_KASHMIRI_INDIA = 2;

	public const ushort SUBLANG_KAZAK_KAZAKHSTAN = 1;

	public const ushort SUBLANG_KHMER_CAMBODIA = 1;

	public const ushort SUBLANG_KICHE_GUATEMALA = 1;

	public const ushort SUBLANG_KINYARWANDA_RWANDA = 1;

	public const ushort SUBLANG_KONKANI_INDIA = 1;

	public const ushort SUBLANG_KOREAN = 1;

	public const ushort SUBLANG_KYRGYZ_KYRGYZSTAN = 1;

	public const ushort SUBLANG_LAO_LAO = 1;

	public const ushort SUBLANG_LATVIAN_LATVIA = 1;

	public const ushort SUBLANG_LITHUANIAN = 1;

	public const ushort SUBLANG_LOWER_SORBIAN_GERMANY = 2;

	public const ushort SUBLANG_LUXEMBOURGISH_LUXEMBOURG = 1;

	public const ushort SUBLANG_MACEDONIAN_MACEDONIA = 1;

	public const ushort SUBLANG_MALAY_MALAYSIA = 1;

	public const ushort SUBLANG_MALAY_BRUNEI_DARUSSALAM = 2;

	public const ushort SUBLANG_MALAYALAM_INDIA = 1;

	public const ushort SUBLANG_MALTESE_MALTA = 1;

	public const ushort SUBLANG_MAORI_NEW_ZEALAND = 1;

	public const ushort SUBLANG_MAPUDUNGUN_CHILE = 1;

	public const ushort SUBLANG_MARATHI_INDIA = 1;

	public const ushort SUBLANG_MOHAWK_MOHAWK = 1;

	public const ushort SUBLANG_MONGOLIAN_CYRILLIC_MONGOLIA = 1;

	public const ushort SUBLANG_MONGOLIAN_PRC = 2;

	public const ushort SUBLANG_NEPALI_INDIA = 2;

	public const ushort SUBLANG_NEPALI_NEPAL = 1;

	public const ushort SUBLANG_NORWEGIAN_BOKMAL = 1;

	public const ushort SUBLANG_NORWEGIAN_NYNORSK = 2;

	public const ushort SUBLANG_OCCITAN_FRANCE = 1;

	public const ushort SUBLANG_ODIA_INDIA = 1;

	public const ushort SUBLANG_ORIYA_INDIA = 1;

	public const ushort SUBLANG_PASHTO_AFGHANISTAN = 1;

	public const ushort SUBLANG_PERSIAN_IRAN = 1;

	public const ushort SUBLANG_POLISH_POLAND = 1;

	public const ushort SUBLANG_PORTUGUESE = 2;

	public const ushort SUBLANG_PORTUGUESE_BRAZILIAN = 1;

	public const ushort SUBLANG_PULAR_SENEGAL = 2;

	public const ushort SUBLANG_PUNJABI_INDIA = 1;

	public const ushort SUBLANG_PUNJABI_PAKISTAN = 2;

	public const ushort SUBLANG_QUECHUA_BOLIVIA = 1;

	public const ushort SUBLANG_QUECHUA_ECUADOR = 2;

	public const ushort SUBLANG_QUECHUA_PERU = 3;

	public const ushort SUBLANG_ROMANIAN_ROMANIA = 1;

	public const ushort SUBLANG_ROMANSH_SWITZERLAND = 1;

	public const ushort SUBLANG_RUSSIAN_RUSSIA = 1;

	public const ushort SUBLANG_SAKHA_RUSSIA = 1;

	public const ushort SUBLANG_SAMI_NORTHERN_NORWAY = 1;

	public const ushort SUBLANG_SAMI_NORTHERN_SWEDEN = 2;

	public const ushort SUBLANG_SAMI_NORTHERN_FINLAND = 3;

	public const ushort SUBLANG_SAMI_LULE_NORWAY = 4;

	public const ushort SUBLANG_SAMI_LULE_SWEDEN = 5;

	public const ushort SUBLANG_SAMI_SOUTHERN_NORWAY = 6;

	public const ushort SUBLANG_SAMI_SOUTHERN_SWEDEN = 7;

	public const ushort SUBLANG_SAMI_SKOLT_FINLAND = 8;

	public const ushort SUBLANG_SAMI_INARI_FINLAND = 9;

	public const ushort SUBLANG_SANSKRIT_INDIA = 1;

	public const ushort SUBLANG_SCOTTISH_GAELIC = 1;

	public const ushort SUBLANG_SERBIAN_BOSNIA_HERZEGOVINA_LATIN = 6;

	public const ushort SUBLANG_SERBIAN_BOSNIA_HERZEGOVINA_CYRILLIC = 7;

	public const ushort SUBLANG_SERBIAN_MONTENEGRO_LATIN = 11;

	public const ushort SUBLANG_SERBIAN_MONTENEGRO_CYRILLIC = 12;

	public const ushort SUBLANG_SERBIAN_SERBIA_LATIN = 9;

	public const ushort SUBLANG_SERBIAN_SERBIA_CYRILLIC = 10;

	public const ushort SUBLANG_SERBIAN_CROATIA = 1;

	public const ushort SUBLANG_SERBIAN_LATIN = 2;

	public const ushort SUBLANG_SERBIAN_CYRILLIC = 3;

	public const ushort SUBLANG_SINDHI_INDIA = 1;

	public const ushort SUBLANG_SINDHI_PAKISTAN = 2;

	public const ushort SUBLANG_SINDHI_AFGHANISTAN = 2;

	public const ushort SUBLANG_SINHALESE_SRI_LANKA = 1;

	public const ushort SUBLANG_SOTHO_NORTHERN_SOUTH_AFRICA = 1;

	public const ushort SUBLANG_SLOVAK_SLOVAKIA = 1;

	public const ushort SUBLANG_SLOVENIAN_SLOVENIA = 1;

	public const ushort SUBLANG_SPANISH = 1;

	public const ushort SUBLANG_SPANISH_MEXICAN = 2;

	public const ushort SUBLANG_SPANISH_MODERN = 3;

	public const ushort SUBLANG_SPANISH_GUATEMALA = 4;

	public const ushort SUBLANG_SPANISH_COSTA_RICA = 5;

	public const ushort SUBLANG_SPANISH_PANAMA = 6;

	public const ushort SUBLANG_SPANISH_DOMINICAN_REPUBLIC = 7;

	public const ushort SUBLANG_SPANISH_VENEZUELA = 8;

	public const ushort SUBLANG_SPANISH_COLOMBIA = 9;

	public const ushort SUBLANG_SPANISH_PERU = 10;

	public const ushort SUBLANG_SPANISH_ARGENTINA = 11;

	public const ushort SUBLANG_SPANISH_ECUADOR = 12;

	public const ushort SUBLANG_SPANISH_CHILE = 13;

	public const ushort SUBLANG_SPANISH_URUGUAY = 14;

	public const ushort SUBLANG_SPANISH_PARAGUAY = 15;

	public const ushort SUBLANG_SPANISH_BOLIVIA = 16;

	public const ushort SUBLANG_SPANISH_EL_SALVADOR = 17;

	public const ushort SUBLANG_SPANISH_HONDURAS = 18;

	public const ushort SUBLANG_SPANISH_NICARAGUA = 19;

	public const ushort SUBLANG_SPANISH_PUERTO_RICO = 20;

	public const ushort SUBLANG_SPANISH_US = 21;

	public const ushort SUBLANG_SWAHILI_KENYA = 1;

	public const ushort SUBLANG_SWEDISH = 1;

	public const ushort SUBLANG_SWEDISH_FINLAND = 2;

	public const ushort SUBLANG_SYRIAC_SYRIA = 1;

	public const ushort SUBLANG_TAJIK_TAJIKISTAN = 1;

	public const ushort SUBLANG_TAMAZIGHT_ALGERIA_LATIN = 2;

	public const ushort SUBLANG_TAMAZIGHT_MOROCCO_TIFINAGH = 4;

	public const ushort SUBLANG_TAMIL_INDIA = 1;

	public const ushort SUBLANG_TAMIL_SRI_LANKA = 2;

	public const ushort SUBLANG_TATAR_RUSSIA = 1;

	public const ushort SUBLANG_TELUGU_INDIA = 1;

	public const ushort SUBLANG_THAI_THAILAND = 1;

	public const ushort SUBLANG_TIBETAN_PRC = 1;

	public const ushort SUBLANG_TIGRIGNA_ERITREA = 2;

	public const ushort SUBLANG_TIGRINYA_ERITREA = 2;

	public const ushort SUBLANG_TIGRINYA_ETHIOPIA = 1;

	public const ushort SUBLANG_TSWANA_BOTSWANA = 2;

	public const ushort SUBLANG_TSWANA_SOUTH_AFRICA = 1;

	public const ushort SUBLANG_TURKISH_TURKEY = 1;

	public const ushort SUBLANG_TURKMEN_TURKMENISTAN = 1;

	public const ushort SUBLANG_UIGHUR_PRC = 1;

	public const ushort SUBLANG_UKRAINIAN_UKRAINE = 1;

	public const ushort SUBLANG_UPPER_SORBIAN_GERMANY = 1;

	public const ushort SUBLANG_URDU_PAKISTAN = 1;

	public const ushort SUBLANG_URDU_INDIA = 2;

	public const ushort SUBLANG_UZBEK_LATIN = 1;

	public const ushort SUBLANG_UZBEK_CYRILLIC = 2;

	public const ushort SUBLANG_VALENCIAN_VALENCIA = 2;

	public const ushort SUBLANG_VIETNAMESE_VIETNAM = 1;

	public const ushort SUBLANG_WELSH_UNITED_KINGDOM = 1;

	public const ushort SUBLANG_WOLOF_SENEGAL = 1;

	public const ushort SUBLANG_XHOSA_SOUTH_AFRICA = 1;

	public const ushort SUBLANG_YAKUT_RUSSIA = 1;

	public const ushort SUBLANG_YI_PRC = 1;

	public const ushort SUBLANG_YORUBA_NIGERIA = 1;

	public const ushort SUBLANG_ZULU_SOUTH_AFRICA = 1;
}
