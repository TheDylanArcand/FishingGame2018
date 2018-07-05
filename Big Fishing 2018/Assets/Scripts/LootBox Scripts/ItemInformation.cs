﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemInformation
{
	public static string[] ItemPrefix =
	{
		"Fast",
		"Strong",
		"Beefy",
		"Searing",
		"Crystal",
		"Limestone",
		"Spooky",
		"Scary",
		"Skeleton"
	};

	public static string[] ItemSuffix =
	{
		"Insanity",
		"Flame",
		"Health",
		"Resistance",
		"Life",
		"Destiny",
		"Pain",
		"Nature"
	};

	public static KeyValuePair<string, int[]>[] ItemSingleValueStat =
	{
		//new KeyValuePair<string, int[]>(Name of stat with "{0}" for where value is placed , new int[2] Array for lower and upper values of stat),

		new KeyValuePair<string, int[]>("+ {0} Physical Damage", new int[2]{50, 100}),
		new KeyValuePair<string, int[]>("Attack Speed {0}% Increaase", new int[2]{15, 20}),
	};

	public static KeyValuePair<string, int[]>[] ItemTwoValueStat =
	{
		//new KeyValuePair<string, int[]>(Name of stat with "{0}" and "{1} for where value is placed , new int[4] Array for lower and upper values of the minimum and maximum values to the stat),

		new KeyValuePair<string, int[]>("+ {0} - {1} Physical Damage", new int[4]{1, 10, 30, 40}),
		new KeyValuePair<string, int[]>("{0}% change to apply level {1} Weakness on enemy", new int[4]{5, 10, 10, 25}),
	};
}
