// SPDX-FileCopyrightText: 2022 Demerzel Solutions Limited
// SPDX-License-Identifier: LGPL-3.0-only

using System;
using System.Threading.Tasks;

namespace Nethermind.Synchronization
{
    public interface ISynchronizer : IAsyncDisposable
    {
        event EventHandler<SyncEventArgs> SyncEvent;

        void Start();
    }
}
