/*
Original Code: 
https://github.com/dotnet/runtime/blob/main/src/libraries/Microsoft.Extensions.DependencyInjection.Abstractions/src/ServiceProviderServiceExtensions.cs

Licensed to the .NET Foundation under one or more agreements.
The .NET Foundation licenses this file to you under the MIT license.
*/

namespace Nemonuri.Common.Primitives;

public static class ServiceProviderServiceExtensions
{
    public static T? GetService<T>(this IServiceProvider provider)
    {
        Guard.IsNotNull(provider);

        return (T?)provider.GetService(typeof(T));
    }
}
