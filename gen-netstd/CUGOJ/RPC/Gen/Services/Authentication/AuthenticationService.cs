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

      global::System.Threading.Tasks.Task<global::CUGOJ.RPC.Gen.Services.Authentication.LoginResponse> Login(global::CUGOJ.RPC.Gen.Services.Authentication.LoginRequest req, CancellationToken cancellationToken = default);

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
        
        var tmp10 = new InternalStructs.Ping_args() {
          Req = req,
        };
        
        await tmp10.WriteAsync(OutputProtocol, cancellationToken);
        await OutputProtocol.WriteMessageEndAsync(cancellationToken);
        await OutputProtocol.Transport.FlushAsync(cancellationToken);
      }

      public async global::System.Threading.Tasks.Task<global::CUGOJ.RPC.Gen.Base.PingResponse> recv_Ping(CancellationToken cancellationToken = default)
      {
        
        var tmp11 = await InputProtocol.ReadMessageBeginAsync(cancellationToken);
        if (tmp11.Type == TMessageType.Exception)
        {
          var tmp12 = await TApplicationException.ReadAsync(InputProtocol, cancellationToken);
          await InputProtocol.ReadMessageEndAsync(cancellationToken);
          throw tmp12;
        }

        var tmp13 = new InternalStructs.Ping_result();
        await tmp13.ReadAsync(InputProtocol, cancellationToken);
        await InputProtocol.ReadMessageEndAsync(cancellationToken);
        if (tmp13.__isset.success)
        {
          return tmp13.Success;
        }
        throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "Ping failed: unknown result");
      }

      public async global::System.Threading.Tasks.Task<global::CUGOJ.RPC.Gen.Services.Authentication.LoginResponse> Login(global::CUGOJ.RPC.Gen.Services.Authentication.LoginRequest req, CancellationToken cancellationToken = default)
      {
        await send_Login(req, cancellationToken);
        return await recv_Login(cancellationToken);
      }

      public async global::System.Threading.Tasks.Task send_Login(global::CUGOJ.RPC.Gen.Services.Authentication.LoginRequest req, CancellationToken cancellationToken = default)
      {
        await OutputProtocol.WriteMessageBeginAsync(new TMessage("Login", TMessageType.Call, SeqId), cancellationToken);
        
        var tmp14 = new InternalStructs.Login_args() {
          Req = req,
        };
        
        await tmp14.WriteAsync(OutputProtocol, cancellationToken);
        await OutputProtocol.WriteMessageEndAsync(cancellationToken);
        await OutputProtocol.Transport.FlushAsync(cancellationToken);
      }

      public async global::System.Threading.Tasks.Task<global::CUGOJ.RPC.Gen.Services.Authentication.LoginResponse> recv_Login(CancellationToken cancellationToken = default)
      {
        
        var tmp15 = await InputProtocol.ReadMessageBeginAsync(cancellationToken);
        if (tmp15.Type == TMessageType.Exception)
        {
          var tmp16 = await TApplicationException.ReadAsync(InputProtocol, cancellationToken);
          await InputProtocol.ReadMessageEndAsync(cancellationToken);
          throw tmp16;
        }

        var tmp17 = new InternalStructs.Login_result();
        await tmp17.ReadAsync(InputProtocol, cancellationToken);
        await InputProtocol.ReadMessageEndAsync(cancellationToken);
        if (tmp17.__isset.success)
        {
          return tmp17.Success;
        }
        throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "Login failed: unknown result");
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
        processMap_["Login"] = Login_ProcessAsync;
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
        var tmp18 = new InternalStructs.Ping_args();
        await tmp18.ReadAsync(iprot, cancellationToken);
        await iprot.ReadMessageEndAsync(cancellationToken);
        var tmp19 = new InternalStructs.Ping_result();
        try
        {
          tmp19.Success = await _iAsync.Ping(tmp18.Req, cancellationToken);
          await oprot.WriteMessageBeginAsync(new TMessage("Ping", TMessageType.Reply, seqid), cancellationToken); 
          await tmp19.WriteAsync(oprot, cancellationToken);
        }
        catch (TTransportException)
        {
          throw;
        }
        catch (Exception tmp20)
        {
          var tmp21 = $"Error occurred in {GetType().FullName}: {tmp20.Message}";
          if(_logger != null)
            _logger.LogError("{Exception}, {Message}", tmp20, tmp21);
          else
            Console.Error.WriteLine(tmp21);
          var tmp22 = new TApplicationException(TApplicationException.ExceptionType.InternalError," Internal error.");
          await oprot.WriteMessageBeginAsync(new TMessage("Ping", TMessageType.Exception, seqid), cancellationToken);
          await tmp22.WriteAsync(oprot, cancellationToken);
        }
        await oprot.WriteMessageEndAsync(cancellationToken);
        await oprot.Transport.FlushAsync(cancellationToken);
      }

      public async global::System.Threading.Tasks.Task Login_ProcessAsync(int seqid, TProtocol iprot, TProtocol oprot, CancellationToken cancellationToken)
      {
        var tmp23 = new InternalStructs.Login_args();
        await tmp23.ReadAsync(iprot, cancellationToken);
        await iprot.ReadMessageEndAsync(cancellationToken);
        var tmp24 = new InternalStructs.Login_result();
        try
        {
          tmp24.Success = await _iAsync.Login(tmp23.Req, cancellationToken);
          await oprot.WriteMessageBeginAsync(new TMessage("Login", TMessageType.Reply, seqid), cancellationToken); 
          await tmp24.WriteAsync(oprot, cancellationToken);
        }
        catch (TTransportException)
        {
          throw;
        }
        catch (Exception tmp25)
        {
          var tmp26 = $"Error occurred in {GetType().FullName}: {tmp25.Message}";
          if(_logger != null)
            _logger.LogError("{Exception}, {Message}", tmp25, tmp26);
          else
            Console.Error.WriteLine(tmp26);
          var tmp27 = new TApplicationException(TApplicationException.ExceptionType.InternalError," Internal error.");
          await oprot.WriteMessageBeginAsync(new TMessage("Login", TMessageType.Exception, seqid), cancellationToken);
          await tmp27.WriteAsync(oprot, cancellationToken);
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
          var tmp28 = new Ping_args();
          if((Req != null) && __isset.req)
          {
            tmp28.Req = (global::CUGOJ.RPC.Gen.Base.PingRequest)this.Req.DeepCopy();
          }
          tmp28.__isset.req = this.__isset.req;
          return tmp28;
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
            var tmp29 = new TStruct("Ping_args");
            await oprot.WriteStructBeginAsync(tmp29, cancellationToken);
            var tmp30 = new TField();
            if((Req != null) && __isset.req)
            {
              tmp30.Name = "req";
              tmp30.Type = TType.Struct;
              tmp30.ID = 1;
              await oprot.WriteFieldBeginAsync(tmp30, cancellationToken);
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
          var tmp31 = new StringBuilder("Ping_args(");
          int tmp32 = 0;
          if((Req != null) && __isset.req)
          {
            if(0 < tmp32++) { tmp31.Append(", "); }
            tmp31.Append("Req: ");
            Req.ToString(tmp31);
          }
          tmp31.Append(')');
          return tmp31.ToString();
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
          var tmp33 = new Ping_result();
          if((Success != null) && __isset.success)
          {
            tmp33.Success = (global::CUGOJ.RPC.Gen.Base.PingResponse)this.Success.DeepCopy();
          }
          tmp33.__isset.success = this.__isset.success;
          return tmp33;
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
            var tmp34 = new TStruct("Ping_result");
            await oprot.WriteStructBeginAsync(tmp34, cancellationToken);
            var tmp35 = new TField();

            if(this.__isset.success)
            {
              if (Success != null)
              {
                tmp35.Name = "Success";
                tmp35.Type = TType.Struct;
                tmp35.ID = 0;
                await oprot.WriteFieldBeginAsync(tmp35, cancellationToken);
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
          var tmp36 = new StringBuilder("Ping_result(");
          int tmp37 = 0;
          if((Success != null) && __isset.success)
          {
            if(0 < tmp37++) { tmp36.Append(", "); }
            tmp36.Append("Success: ");
            Success.ToString(tmp36);
          }
          tmp36.Append(')');
          return tmp36.ToString();
        }
      }


      public partial class Login_args : TBase
      {
        private global::CUGOJ.RPC.Gen.Services.Authentication.LoginRequest _req;

        public global::CUGOJ.RPC.Gen.Services.Authentication.LoginRequest Req
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

        public Login_args()
        {
        }

        public Login_args DeepCopy()
        {
          var tmp38 = new Login_args();
          if((Req != null) && __isset.req)
          {
            tmp38.Req = (global::CUGOJ.RPC.Gen.Services.Authentication.LoginRequest)this.Req.DeepCopy();
          }
          tmp38.__isset.req = this.__isset.req;
          return tmp38;
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
                    Req = new global::CUGOJ.RPC.Gen.Services.Authentication.LoginRequest();
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
            var tmp39 = new TStruct("Login_args");
            await oprot.WriteStructBeginAsync(tmp39, cancellationToken);
            var tmp40 = new TField();
            if((Req != null) && __isset.req)
            {
              tmp40.Name = "req";
              tmp40.Type = TType.Struct;
              tmp40.ID = 1;
              await oprot.WriteFieldBeginAsync(tmp40, cancellationToken);
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
          if (!(that is Login_args other)) return false;
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
          var tmp41 = new StringBuilder("Login_args(");
          int tmp42 = 0;
          if((Req != null) && __isset.req)
          {
            if(0 < tmp42++) { tmp41.Append(", "); }
            tmp41.Append("Req: ");
            Req.ToString(tmp41);
          }
          tmp41.Append(')');
          return tmp41.ToString();
        }
      }


      public partial class Login_result : TBase
      {
        private global::CUGOJ.RPC.Gen.Services.Authentication.LoginResponse _success;

        public global::CUGOJ.RPC.Gen.Services.Authentication.LoginResponse Success
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

        public Login_result()
        {
        }

        public Login_result DeepCopy()
        {
          var tmp43 = new Login_result();
          if((Success != null) && __isset.success)
          {
            tmp43.Success = (global::CUGOJ.RPC.Gen.Services.Authentication.LoginResponse)this.Success.DeepCopy();
          }
          tmp43.__isset.success = this.__isset.success;
          return tmp43;
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
                    Success = new global::CUGOJ.RPC.Gen.Services.Authentication.LoginResponse();
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
            var tmp44 = new TStruct("Login_result");
            await oprot.WriteStructBeginAsync(tmp44, cancellationToken);
            var tmp45 = new TField();

            if(this.__isset.success)
            {
              if (Success != null)
              {
                tmp45.Name = "Success";
                tmp45.Type = TType.Struct;
                tmp45.ID = 0;
                await oprot.WriteFieldBeginAsync(tmp45, cancellationToken);
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
          if (!(that is Login_result other)) return false;
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
          var tmp46 = new StringBuilder("Login_result(");
          int tmp47 = 0;
          if((Success != null) && __isset.success)
          {
            if(0 < tmp47++) { tmp46.Append(", "); }
            tmp46.Append("Success: ");
            Success.ToString(tmp46);
          }
          tmp46.Append(')');
          return tmp46.ToString();
        }
      }

    }

  }
}
