/**
 * <auto-generated>
 * Autogenerated by Thrift Compiler (0.16.0)
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 * </auto-generated>
 */
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


#nullable disable                // suppress C# 8.0 nullable contexts (we still support earlier versions)
#pragma warning disable IDE0079  // remove unnecessary pragmas
#pragma warning disable IDE1006  // parts of the code use IDL spelling
#pragma warning disable IDE0083  // pattern matching "that is not SomeType" requires net5.0 but we still support earlier versions

namespace CUGOJ.RPC.Gen.Services.Authentication
{
  public partial class AuthenticationService
  {
    public interface IAsync
    {
      global::System.Threading.Tasks.Task<global::CUGOJ.RPC.Gen.Base.PingResponse> Ping(global::CUGOJ.RPC.Gen.Base.PingRequest req, CancellationToken cancellationToken = default);

    }


    public class Client : TBaseClient, IDisposable, IAsync
    {
      public Client(TProtocol protocol) : this(protocol, protocol)
      {
      }

      public Client(TProtocol inputProtocol, TProtocol outputProtocol) : base(inputProtocol, outputProtocol)
      {
      }

      public async global::System.Threading.Tasks.Task<global::CUGOJ.RPC.Gen.Base.PingResponse> Ping(global::CUGOJ.RPC.Gen.Base.PingRequest req, CancellationToken cancellationToken = default)
      {
        await send_Ping(req, cancellationToken);
        return await recv_Ping(cancellationToken);
      }

      public async global::System.Threading.Tasks.Task send_Ping(global::CUGOJ.RPC.Gen.Base.PingRequest req, CancellationToken cancellationToken = default)
      {
        await OutputProtocol.WriteMessageBeginAsync(new TMessage("Ping", TMessageType.Call, SeqId), cancellationToken);
        
        var tmp0 = new InternalStructs.Ping_args() {
          Req = req,
        };
        
        await tmp0.WriteAsync(OutputProtocol, cancellationToken);
        await OutputProtocol.WriteMessageEndAsync(cancellationToken);
        await OutputProtocol.Transport.FlushAsync(cancellationToken);
      }

      public async global::System.Threading.Tasks.Task<global::CUGOJ.RPC.Gen.Base.PingResponse> recv_Ping(CancellationToken cancellationToken = default)
      {
        
        var tmp1 = await InputProtocol.ReadMessageBeginAsync(cancellationToken);
        if (tmp1.Type == TMessageType.Exception)
        {
          var tmp2 = await TApplicationException.ReadAsync(InputProtocol, cancellationToken);
          await InputProtocol.ReadMessageEndAsync(cancellationToken);
          throw tmp2;
        }

        var tmp3 = new InternalStructs.Ping_result();
        await tmp3.ReadAsync(InputProtocol, cancellationToken);
        await InputProtocol.ReadMessageEndAsync(cancellationToken);
        if (tmp3.__isset.success)
        {
          return tmp3.Success;
        }
        throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "Ping failed: unknown result");
      }

    }

    public class AsyncProcessor : ITAsyncProcessor
    {
      private readonly IAsync _iAsync;
      private readonly ILogger<AsyncProcessor> _logger;

      public AsyncProcessor(IAsync iAsync, ILogger<AsyncProcessor> logger = default)
      {
        _iAsync = iAsync ?? throw new ArgumentNullException(nameof(iAsync));
        _logger = logger;
        processMap_["Ping"] = Ping_ProcessAsync;
      }

      protected delegate global::System.Threading.Tasks.Task ProcessFunction(int seqid, TProtocol iprot, TProtocol oprot, CancellationToken cancellationToken);
      protected Dictionary<string, ProcessFunction> processMap_ = new Dictionary<string, ProcessFunction>();

      public async Task<bool> ProcessAsync(TProtocol iprot, TProtocol oprot)
      {
        return await ProcessAsync(iprot, oprot, CancellationToken.None);
      }

      public async Task<bool> ProcessAsync(TProtocol iprot, TProtocol oprot, CancellationToken cancellationToken)
      {
        try
        {
          var msg = await iprot.ReadMessageBeginAsync(cancellationToken);

          processMap_.TryGetValue(msg.Name, out ProcessFunction fn);

          if (fn == null)
          {
            await TProtocolUtil.SkipAsync(iprot, TType.Struct, cancellationToken);
            await iprot.ReadMessageEndAsync(cancellationToken);
            var x = new TApplicationException (TApplicationException.ExceptionType.UnknownMethod, "Invalid method name: '" + msg.Name + "'");
            await oprot.WriteMessageBeginAsync(new TMessage(msg.Name, TMessageType.Exception, msg.SeqID), cancellationToken);
            await x.WriteAsync(oprot, cancellationToken);
            await oprot.WriteMessageEndAsync(cancellationToken);
            await oprot.Transport.FlushAsync(cancellationToken);
            return true;
          }

          await fn(msg.SeqID, iprot, oprot, cancellationToken);

        }
        catch (IOException)
        {
          return false;
        }

        return true;
      }

      public async global::System.Threading.Tasks.Task Ping_ProcessAsync(int seqid, TProtocol iprot, TProtocol oprot, CancellationToken cancellationToken)
      {
        var tmp4 = new InternalStructs.Ping_args();
        await tmp4.ReadAsync(iprot, cancellationToken);
        await iprot.ReadMessageEndAsync(cancellationToken);
        var tmp5 = new InternalStructs.Ping_result();
        try
        {
          tmp5.Success = await _iAsync.Ping(tmp4.Req, cancellationToken);
          await oprot.WriteMessageBeginAsync(new TMessage("Ping", TMessageType.Reply, seqid), cancellationToken); 
          await tmp5.WriteAsync(oprot, cancellationToken);
        }
        catch (TTransportException)
        {
          throw;
        }
        catch (Exception tmp6)
        {
          var tmp7 = $"Error occurred in {GetType().FullName}: {tmp6.Message}";
          if(_logger != null)
            _logger.LogError("{Exception}, {Message}", tmp6, tmp7);
          else
            Console.Error.WriteLine(tmp7);
          var tmp8 = new TApplicationException(TApplicationException.ExceptionType.InternalError," Internal error.");
          await oprot.WriteMessageBeginAsync(new TMessage("Ping", TMessageType.Exception, seqid), cancellationToken);
          await tmp8.WriteAsync(oprot, cancellationToken);
        }
        await oprot.WriteMessageEndAsync(cancellationToken);
        await oprot.Transport.FlushAsync(cancellationToken);
      }

    }

    public class InternalStructs
    {

      public partial class Ping_args : TBase
      {
        private global::CUGOJ.RPC.Gen.Base.PingRequest _req;

        public global::CUGOJ.RPC.Gen.Base.PingRequest Req
        {
          get
          {
            return _req;
          }
          set
          {
            __isset.req = true;
            this._req = value;
          }
        }


        public Isset __isset;
        public struct Isset
        {
          public bool req;
        }

        public Ping_args()
        {
        }

        public Ping_args DeepCopy()
        {
          var tmp9 = new Ping_args();
          if((Req != null) && __isset.req)
          {
            tmp9.Req = (global::CUGOJ.RPC.Gen.Base.PingRequest)this.Req.DeepCopy();
          }
          tmp9.__isset.req = this.__isset.req;
          return tmp9;
        }

        public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
        {
          iprot.IncrementRecursionDepth();
          try
          {
            TField field;
            await iprot.ReadStructBeginAsync(cancellationToken);
            while (true)
            {
              field = await iprot.ReadFieldBeginAsync(cancellationToken);
              if (field.Type == TType.Stop)
              {
                break;
              }

              switch (field.ID)
              {
                case 1:
                  if (field.Type == TType.Struct)
                  {
                    Req = new global::CUGOJ.RPC.Gen.Base.PingRequest();
                    await Req.ReadAsync(iprot, cancellationToken);
                  }
                  else
                  {
                    await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
                  }
                  break;
                default: 
                  await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
                  break;
              }

              await iprot.ReadFieldEndAsync(cancellationToken);
            }

            await iprot.ReadStructEndAsync(cancellationToken);
          }
          finally
          {
            iprot.DecrementRecursionDepth();
          }
        }

        public async global::System.Threading.Tasks.Task WriteAsync(TProtocol oprot, CancellationToken cancellationToken)
        {
          oprot.IncrementRecursionDepth();
          try
          {
            var tmp10 = new TStruct("Ping_args");
            await oprot.WriteStructBeginAsync(tmp10, cancellationToken);
            var tmp11 = new TField();
            if((Req != null) && __isset.req)
            {
              tmp11.Name = "req";
              tmp11.Type = TType.Struct;
              tmp11.ID = 1;
              await oprot.WriteFieldBeginAsync(tmp11, cancellationToken);
              await Req.WriteAsync(oprot, cancellationToken);
              await oprot.WriteFieldEndAsync(cancellationToken);
            }
            await oprot.WriteFieldStopAsync(cancellationToken);
            await oprot.WriteStructEndAsync(cancellationToken);
          }
          finally
          {
            oprot.DecrementRecursionDepth();
          }
        }

        public override bool Equals(object that)
        {
          if (!(that is Ping_args other)) return false;
          if (ReferenceEquals(this, other)) return true;
          return ((__isset.req == other.__isset.req) && ((!__isset.req) || (global::System.Object.Equals(Req, other.Req))));
        }

        public override int GetHashCode() {
          int hashcode = 157;
          unchecked {
            if((Req != null) && __isset.req)
            {
              hashcode = (hashcode * 397) + Req.GetHashCode();
            }
          }
          return hashcode;
        }

        public override string ToString()
        {
          var tmp12 = new StringBuilder("Ping_args(");
          int tmp13 = 0;
          if((Req != null) && __isset.req)
          {
            if(0 < tmp13++) { tmp12.Append(", "); }
            tmp12.Append("Req: ");
            Req.ToString(tmp12);
          }
          tmp12.Append(')');
          return tmp12.ToString();
        }
      }


      public partial class Ping_result : TBase
      {
        private global::CUGOJ.RPC.Gen.Base.PingResponse _success;

        public global::CUGOJ.RPC.Gen.Base.PingResponse Success
        {
          get
          {
            return _success;
          }
          set
          {
            __isset.success = true;
            this._success = value;
          }
        }


        public Isset __isset;
        public struct Isset
        {
          public bool success;
        }

        public Ping_result()
        {
        }

        public Ping_result DeepCopy()
        {
          var tmp14 = new Ping_result();
          if((Success != null) && __isset.success)
          {
            tmp14.Success = (global::CUGOJ.RPC.Gen.Base.PingResponse)this.Success.DeepCopy();
          }
          tmp14.__isset.success = this.__isset.success;
          return tmp14;
        }

        public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
        {
          iprot.IncrementRecursionDepth();
          try
          {
            TField field;
            await iprot.ReadStructBeginAsync(cancellationToken);
            while (true)
            {
              field = await iprot.ReadFieldBeginAsync(cancellationToken);
              if (field.Type == TType.Stop)
              {
                break;
              }

              switch (field.ID)
              {
                case 0:
                  if (field.Type == TType.Struct)
                  {
                    Success = new global::CUGOJ.RPC.Gen.Base.PingResponse();
                    await Success.ReadAsync(iprot, cancellationToken);
                  }
                  else
                  {
                    await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
                  }
                  break;
                default: 
                  await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
                  break;
              }

              await iprot.ReadFieldEndAsync(cancellationToken);
            }

            await iprot.ReadStructEndAsync(cancellationToken);
          }
          finally
          {
            iprot.DecrementRecursionDepth();
          }
        }

        public async global::System.Threading.Tasks.Task WriteAsync(TProtocol oprot, CancellationToken cancellationToken)
        {
          oprot.IncrementRecursionDepth();
          try
          {
            var tmp15 = new TStruct("Ping_result");
            await oprot.WriteStructBeginAsync(tmp15, cancellationToken);
            var tmp16 = new TField();

            if(this.__isset.success)
            {
              if (Success != null)
              {
                tmp16.Name = "Success";
                tmp16.Type = TType.Struct;
                tmp16.ID = 0;
                await oprot.WriteFieldBeginAsync(tmp16, cancellationToken);
                await Success.WriteAsync(oprot, cancellationToken);
                await oprot.WriteFieldEndAsync(cancellationToken);
              }
            }
            await oprot.WriteFieldStopAsync(cancellationToken);
            await oprot.WriteStructEndAsync(cancellationToken);
          }
          finally
          {
            oprot.DecrementRecursionDepth();
          }
        }

        public override bool Equals(object that)
        {
          if (!(that is Ping_result other)) return false;
          if (ReferenceEquals(this, other)) return true;
          return ((__isset.success == other.__isset.success) && ((!__isset.success) || (global::System.Object.Equals(Success, other.Success))));
        }

        public override int GetHashCode() {
          int hashcode = 157;
          unchecked {
            if((Success != null) && __isset.success)
            {
              hashcode = (hashcode * 397) + Success.GetHashCode();
            }
          }
          return hashcode;
        }

        public override string ToString()
        {
          var tmp17 = new StringBuilder("Ping_result(");
          int tmp18 = 0;
          if((Success != null) && __isset.success)
          {
            if(0 < tmp18++) { tmp17.Append(", "); }
            tmp17.Append("Success: ");
            Success.ToString(tmp17);
          }
          tmp17.Append(')');
          return tmp17.ToString();
        }
      }

    }

  }
}