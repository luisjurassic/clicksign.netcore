// <copyright file="Node.cs" company="Rocket Robin">
// Copyright (c) Rocket Robin. All rights reserved.
// Licensed under the Apache v2 license. See LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;

namespace ClickSign.NetCoreUtils.Mimetype;

/// <summary>
/// node
/// </summary>
internal class Node
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Node" /> class.
    /// </summary>
    internal Node()
    {
    }

    /// <summary>
    /// Gets or sets children.
    /// </summary>
    internal SortedList<byte, Node> Children { get; set; }

    /// <summary>
    /// Gets or sets depth.
    /// </summary>
    internal int Depth { get; set; }

    /// <summary>
    /// Gets or sets extentions.
    /// </summary>
    internal List<string> Extentions { get; set; }

    /// <summary>
    /// Gets or sets parent node.
    /// </summary>
    internal Node Parent { get; set; }
}