// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Reflection;
using Microsoft.Extensions.DiagnosticAdapter.Infrastructure;
using Microsoft.Extensions.DiagnosticAdapter.Internal;

namespace Microsoft.Extensions.DiagnosticAdapter
{
    public class ProxyDiagnosticSourceMethodAdapter : IDiagnosticSourceMethodAdapter
    {
        private readonly IProxyFactory _factory = new ProxyFactory();

        public Func<object, object, bool> Adapt(MethodInfo method, Type inputType)
        {
            var proxyMethod = ProxyMethodEmitter.CreateProxyMethod(method, inputType);
            return (listener, data) => proxyMethod(listener, data, _factory);
        }
    }
}
