// SPDX-FileCopyrightText: 2022 Demerzel Solutions Limited
// SPDX-License-Identifier: LGPL-3.0-only

using System.Collections.Generic;
using System.Linq;
using Nethermind.Core;
using Nethermind.TxPool;

namespace Nethermind.JsonRpc.Modules.TxPool
{
    public class TxPoolInspection
    {
        public TxPoolInspection(TxPoolInfo info)
        {
            Pending = info.Pending.ToDictionary(static k => k.Key, static k => k.Value.ToDictionary(static v => v.Key, static v => GetTransactionSummary(v.Value)));
            Queued = info.Queued.ToDictionary(static k => k.Key, static k => k.Value.ToDictionary(static v => v.Key, static v => GetTransactionSummary(v.Value)));
        }

        public Dictionary<AddressAsKey, Dictionary<ulong, string>> Pending { get; set; }
        public Dictionary<AddressAsKey, Dictionary<ulong, string>> Queued { get; set; }

        private static string GetTransactionSummary(Transaction tx)
            => $"{tx.SenderAddress}: {tx.Value} wei + {tx.GasLimit} × {tx.GasPrice} gas";
    }
}
