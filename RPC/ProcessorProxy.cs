using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Thrift;
using Thrift.Collections;

using Thrift.Protocol;
using Thrift.Protocol.Entities;
using Thrift.Protocol.Utilities;
using Thrift.Transport;
using Thrift.Transport.Client;
using Thrift.Transport.Server;
using Thrift.Processor;

namespace CUGOJ.CUGOJ_Tools.RPC;

public class ProcessorProxy : ITAsyncProcessor
{
    private string? GetIp(TProtocol iprot)
    {
        var transport = iprot.Transport is TSocketTransport ? ((TSocketTransport)iprot.Transport) : null;
        if (transport != null)
        {
            var remoteEndPoint = transport.TcpClient.Client.RemoteEndPoint;
            if (remoteEndPoint != null)
            {
                return remoteEndPoint is System.Net.IPEndPoint ? ((System.Net.IPEndPoint)remoteEndPoint).Address.ToString() : null;
            }
        }

        return null;
    }
    ITAsyncProcessor _processor;
    public ProcessorProxy(ITAsyncProcessor processor)
    {
        _processor = processor;
    }
    public Task<bool> ProcessAsync(TProtocol iprot, TProtocol oprot, CancellationToken cancellationToken = default)
    {
        var IP = GetIp(iprot);
        if (IP == null)
        {
            return Task.FromResult(false);
        }
        Context.Context.ClientIP = IP;
        return _processor.ProcessAsync(iprot, oprot, cancellationToken);
    }
}