// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http
{
    public abstract class HttpMessageHandler : IDisposable
    {
        protected HttpMessageHandler()
        {
            if (NetEventSource.Log.IsEnabled()) NetEventSource.Enter(NetEventSource.ComponentType.Http, this, ".ctor", null);
            if (NetEventSource.Log.IsEnabled()) NetEventSource.Exit(NetEventSource.ComponentType.Http, this, ".ctor", null);
        }

        protected internal abstract Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken);

        #region IDisposable Members

        protected virtual void Dispose(bool disposing)
        {
            // Nothing to do in base class.
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
