﻿// <copyright file="Metadata.cs" company="Rocket Robin">
// Copyright (c) Rocket Robin. All rights reserved.
// Licensed under the Apache v2 license. See LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Text;

namespace ClickSign.NetCoreUtils.Mimetype;

/// <summary>
/// metadata
/// </summary>
internal class Metadata
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Metadata" /> class.
    /// </summary>
    internal Metadata()
    {
        Offsets = new List<Offset>(4);
    }

    /// <summary>
    /// Gets or sets the extention list of this metadata.
    /// </summary>
    internal List<string> Extentions { get; set; }

    /// <summary>
    /// Gets or sets the offset list of one metadata.
    /// </summary>
    internal List<Offset> Offsets { get; set; }

    /// <summary>
    /// Start match.
    /// </summary>
    /// <param name="data">The hex head of one file.</param>
    /// <returns>match result: matched or not.</returns>
    internal bool Match(byte[] data)
    {
        foreach (var offset in Offsets)
        {
            if (data.Length < offset.Start + offset.Count)
                // the data's length less than the length of metadata required.
                return false;
            if (offset.Value == Encoding.ASCII.GetString(data, offset.Start, offset.Count)) continue;
            return false;
        }

        return true;
    }
}