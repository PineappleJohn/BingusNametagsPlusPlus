using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

namespace BingusNametagsPlusPlus.Utilities;

public static class Config
{
	public static bool ShowingNametags = true;

	public static bool ShowingName = true;
	public static bool ShowingPlatform = true;

	public static bool ShowInFirstPerson = true;
	public static bool ShowInThirdPerson = true;
	public static bool UserCustomIcons = true;
	public static bool GlobalIconsEnabled = true;

	public static TMP_FontAsset? CustomFont;

	public static float NametagScale = 5f;
	public static float NametagYOffset = 1f;

	public static bool CustomNametags = true;
	public static string NametagColor = "ffffff";

	public static bool NetworkBold = false;
	public static bool NetworkUnderline = false;
	public static bool NetworkItalic = false;

	public static void SavePrefs()
	{
		PlayerPrefs.SetInt("aquabytz_nametags_FPE", ShowInFirstPerson ? 1 : 0);
		PlayerPrefs.SetInt("aquabytz_nametags_TPE", ShowInThirdPerson ? 1 : 0);

		PlayerPrefs.SetInt("aquabytz_nametags_NameEnabled", ShowingName ? 1 : 0);

		PlayerPrefs.SetInt("aquabytz_nametags_AllIcons", GlobalIconsEnabled ? 1 : 0);
		PlayerPrefs.SetInt("aquabytz_nametags_PlatformEnabled", ShowingPlatform ? 1 : 0);
		PlayerPrefs.SetInt("aquabytz_nametags_ShowPlayerIcons", UserCustomIcons ? 1 : 0);

		PlayerPrefs.SetInt("aquabytz_nametags_DoNetworking", CustomNametags ? 1 : 0);
		PlayerPrefs.SetString("aquabytz_nametags_NetworkNametagColor", NametagColor);

		PlayerPrefs.SetFloat("aquabytz_nametags_NametagScale", NametagScale);
		PlayerPrefs.SetFloat("aquabytz_nametags_NametagY", NametagYOffset);
	}

	public static void LoadPrefs()
	{
		ShowInFirstPerson = PlayerPrefs.GetInt("aquabytz_nametags_FPE", 1) == 1;
		ShowInThirdPerson = PlayerPrefs.GetInt("aquabytz_nametags_TPE", 1) == 1;

		ShowingName = PlayerPrefs.GetInt("aquabytz_nametags_NameEnabled", 1) == 1;

		GlobalIconsEnabled = PlayerPrefs.GetInt("aquabytz_nametags_AllIcons", 1) == 1;
		ShowingPlatform = PlayerPrefs.GetInt("aquabytz_nametags_PlatformEnabled", 1) == 1;
		UserCustomIcons = PlayerPrefs.GetInt("aquabytz_nametags_ShowPlayerIcons", 1) == 1;

		CustomNametags = PlayerPrefs.GetInt("aquabytz_nametags_DoNetworking", 1) == 1;
		NametagColor = PlayerPrefs.GetString("aquabytz_nametags_NetworkNametagColor", NametagColor);

		NametagScale = PlayerPrefs.GetFloat("aquabytz_nametags_NametagScale", NametagScale);
		NametagYOffset = PlayerPrefs.GetFloat("aquabytz_nametags_NametagY", NametagYOffset);

		var fontFile =
			Directory.EnumerateFiles(Constants.AssemblyDirectory, "*.ttf", SearchOption.TopDirectoryOnly)
				.FirstOrDefault()
			?? Directory.EnumerateFiles(Constants.AssemblyDirectory, "*.otf", SearchOption.TopDirectoryOnly)
				.FirstOrDefault();

		if (!fontFile.IsNullOrWhiteSpace())
			CustomFont = TMP_FontAsset.CreateFontAsset(new Font(fontFile));
	}

	public static bool ValidHexCode(string hexCode)
	{
		return !hexCode.IsNullOrWhiteSpace() && Regex.IsMatch(hexCode, @"^#?([0-9a-fA-F]{6}|[0-9a-fA-F]{3})$");
	}
}