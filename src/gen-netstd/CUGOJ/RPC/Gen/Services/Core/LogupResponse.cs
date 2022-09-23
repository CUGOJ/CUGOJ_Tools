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

namespace CUGOJ.RPC.Gen.Services.Core
{

  public partial class LogupResponse : TBase
  {
    private global::CUGOJ.RPC.Gen.Base.BaseResp _BaseResp;

    public long UserID { get; set; }

    public global::CUGOJ.RPC.Gen.Base.BaseResp BaseResp
    {
      get
      {
        return _BaseResp;
      }
      set
      {
        __isset.BaseResp = true;
        this._BaseResp = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool BaseResp;
    }

    public LogupResponse()
    {
    }

    public LogupResponse(long UserID) : this()
    {
      this.UserID = UserID;
    }

    public LogupResponse DeepCopy()
    {
      var tmp131 = new LogupResponse();
      tmp131.UserID = this.UserID;
      if((BaseResp != null) && __isset.BaseResp)
      {
        tmp131.BaseResp = (global::CUGOJ.RPC.Gen.Base.BaseResp)this.BaseResp.DeepCopy();
      }
      tmp131.__isset.BaseResp = this.__isset.BaseResp;
      return tmp131;
    }

    public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        bool isset_UserID = false;
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
              if (field.Type == TType.I64)
              {
                UserID = await iprot.ReadI64Async(cancellationToken);
                isset_UserID = true;
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 255:
              if (field.Type == TType.Struct)
              {
                BaseResp = new global::CUGOJ.RPC.Gen.Base.BaseResp();
                await BaseResp.ReadAsync(iprot, cancellationToken);
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
        if (!isset_UserID)
        {
          throw new TProtocolException(TProtocolException.INVALID_DATA);
        }
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
        var tmp132 = new TStruct("LogupResponse");
        await oprot.WriteStructBeginAsync(tmp132, cancellationToken);
        var tmp133 = new TField();
        tmp133.Name = "UserID";
        tmp133.Type = TType.I64;
        tmp133.ID = 1;
        await oprot.WriteFieldBeginAsync(tmp133, cancellationToken);
        await oprot.WriteI64Async(UserID, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
        if((BaseResp != null) && __isset.BaseResp)
        {
          tmp133.Name = "BaseResp";
          tmp133.Type = TType.Struct;
          tmp133.ID = 255;
          await oprot.WriteFieldBeginAsync(tmp133, cancellationToken);
          await BaseResp.WriteAsync(oprot, cancellationToken);
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
      if (!(that is LogupResponse other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return global::System.Object.Equals(UserID, other.UserID)
        && ((__isset.BaseResp == other.__isset.BaseResp) && ((!__isset.BaseResp) || (global::System.Object.Equals(BaseResp, other.BaseResp))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        hashcode = (hashcode * 397) + UserID.GetHashCode();
        if((BaseResp != null) && __isset.BaseResp)
        {
          hashcode = (hashcode * 397) + BaseResp.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp134 = new StringBuilder("LogupResponse(");
      tmp134.Append(", UserID: ");
      UserID.ToString(tmp134);
      if((BaseResp != null) && __isset.BaseResp)
      {
        tmp134.Append(", BaseResp: ");
        BaseResp.ToString(tmp134);
      }
      tmp134.Append(')');
      return tmp134.ToString();
    }
  }

}