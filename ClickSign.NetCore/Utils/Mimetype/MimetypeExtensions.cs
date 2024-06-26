﻿// <copyright file="MimetypeExtensions.cs" company="Rocket Robin">
// Copyright (c) Rocket Robin. All rights reserved.
// Licensed under the Apache v2 license. See LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ClickSign.NetCoreUtils.Mimetype;

/// <summary>
/// MyrmecExtentions
/// </summary>
internal static class MimetypeExtensions
{
    /// <summary>
    /// Add metadata into metadata list.
    /// </summary>
    /// <param name="list">The target list.</param>
    /// <param name="record">The metadata record need to add.</param>
    internal static void Add(this List<Metadata> list, Record record)
    {
        var metadata = new Metadata
        {
            Extentions = record.Extentions.Split(',', ' ').ToList()
        };
        var hex = record.Hex;
        if (record.Offset > 0) hex = Repeat("??", record.Offset, ',') + hex;
        var byteStringArray = hex.Split(',', ' ');

        var lastCharIsQuestionMark = true;

        var start = 0;
        var count = 0;

        for (var i = 0; i < byteStringArray.Length + 1; i++)
        {
            if (i == byteStringArray.Length)
            {
                if (!lastCharIsQuestionMark)
                {
                    count = i - start;
                    metadata.Offsets.Add(MakeOffset(byteStringArray, start, count));
                }

                break;
            }

            if (byteStringArray[i] == "??")
            {
                if (!lastCharIsQuestionMark)
                {
                    count = i - start;
                    metadata.Offsets.Add(MakeOffset(byteStringArray, start, count));
                }

                lastCharIsQuestionMark = true;
            }
            else
            {
                if (lastCharIsQuestionMark) start = i;
                lastCharIsQuestionMark = false;
            }
        }

        list.Add(metadata);
    }

    /// <summary>
    /// Get byte array from string.
    /// </summary>
    /// <param name="source">byte format string.</param>
    /// <returns>result byte array.</returns>
    internal static byte[] GetByte(this string source)
    {
        var array = source.Split(',', ' ');
        var byteArr = new byte[array.Length];
        for (var i = 0; i < array.Length; i++) byteArr[i] = Convert.ToByte(array[i], 16);

        return byteArr;
    }

    /// <summary>
    /// Match result from complex metadata.
    /// </summary>
    /// <param name="list">The complex metadata list.</param>
    /// <param name="data">Data to be match.</param>
    /// <param name="matchAll">Match all result or only first that sniffer matched.</param>
    /// <returns>Match result list.</returns>
    internal static List<string> Match(this List<Metadata> list, byte[] data, bool matchAll = false)
    {
        var extentionStore = new List<string>(4);
        foreach (var metatata in list)
            if (metatata.Match(data))
            {
                extentionStore.AddRange(metatata.Extentions);
                if (!matchAll) break;
            }

        return extentionStore;
    }

    /// <summary>
    /// Populate matadata tree use record list.
    /// </summary>
    /// <param name="sniffer"></param>
    /// <param name="records">Matadate record list.</param>
    internal static void Populate(this Sniffer sniffer, IList<Record> records)
    {
        foreach (var record in records) sniffer.Add(record);
    }

    internal static Offset MakeOffset(string[] byteStringArray, int start, int count)
    {
        return new Offset
        {
            Start = start,
            Count = count,
            Value = Encoding.ASCII.GetString(string.Join(",", byteStringArray, start, count).GetByte())
        };
    }

    [DebuggerStepThrough]
    internal static string Repeat(string source, int count, char seprator)
    {
        var sb = new StringBuilder(count);
        for (var i = 0; i < count; i++) sb.Append(source).Append(seprator);

        return sb.ToString();
    }
}