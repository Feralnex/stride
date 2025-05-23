// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://stride3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using System.Runtime.CompilerServices;

namespace Stride.Core;

/// <summary>
/// A Comparator to use <see cref="object.ReferenceEquals"/> method.
/// </summary>
/// <typeparam name="T">Type of the comparer</typeparam>
public class ReferenceEqualityComparer<T> : EqualityComparer<T> where T : class
{
    private static IEqualityComparer<T>? defaultComparer;

    /// <summary>
    /// Gets the default.
    /// </summary>
    public static new IEqualityComparer<T> Default
    {
        get { return defaultComparer ??= new ReferenceEqualityComparer<T>(); }
    }

    #region IEqualityComparer<T> Members

    /// <inheritdoc/>
    public override bool Equals(T? x, T? y)
    {
        return ReferenceEquals(x, y);
    }

    /// <inheritdoc/>
    public override int GetHashCode(T obj)
    {
        return RuntimeHelpers.GetHashCode(obj);
    }

    #endregion
}
