#if !NET7_0_OR_GREATER
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

// ReSharper disable once CheckNamespace
namespace System.Diagnostics.CodeAnalysis;

using JetBrains.Annotations;

/// <summary>Specifies that this constructor sets all required members for the current type, and callers
/// do not need to set any required members themselves.</summary>
[AttributeUsage(AttributeTargets.Constructor)]
[UsedImplicitly]
internal sealed class SetsRequiredMembersAttribute : Attribute;
#endif
