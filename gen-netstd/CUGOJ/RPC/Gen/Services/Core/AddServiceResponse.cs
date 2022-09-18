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

  public partial class AddServiceResponse : TBase
  {
    private global::CUGOJ.RPC.Gen.Base.BaseResp _BaseResp;

    public string ConnectionString { get; set; }

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

    public AddServiceResponse()
    {
    }

    public AddServiceResponse(string ConnectionString) : this()
    {
      this.ConnectionString = ConnectionString;
    }

    public AddServiceResponse DeepCopy()
    {
      var tmp218 = new AddServiceResponse();
      if((ConnectionString != null))
      {
        tmp218.ConnectionString = this.ConnectionString;
      }
      if((BaseResp != null) && __isset.BaseResp)
      {
        tmp218.BaseResp = (global::CUGOJ.RPC.Gen.Base.BaseResp)this.BaseResp.DeepCopy();
      }
      tmp218.__isset.BaseResp = this.__isset.BaseResp;
      return tmp218;
    }

    public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        bool isset_ConnectionString = false;
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
              if (field.Type == TType.String)
              {
                ConnectionString = await iprot.ReadStringAsync(cancellationToken);
                isset_ConnectionString = true;
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
        if (!isset_ConnectionString)
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
        var tmp219 = new TStruct("AddServiceResponse");
        await oprot.WriteStructBeginAsync(tmp219, cancellationToken);
        var tmp220 = new TField();
        if((ConnectionString != null))
        {
          tmp220.Name = "ConnectionString";
          tmp220.Type = TType.String;
          tmp220.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp220, cancellationToken);
          await oprot.WriteStringAsync(ConnectionString, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((BaseResp != null) && __isset.BaseResp)
        {
          tmp220.Name = "BaseResp";
          tmp220.Type = TType.Struct;
          tmp220.ID = 255;
          await oprot.WriteFieldBeginAsync(tmp220, cancellationToken);
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
      if (!(that is AddServiceResponse other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return global::System.Object.Equals(ConnectionString, other.ConnectionString)
        && ((__isset.BaseResp == other.__isset.BaseResp) && ((!__isset.BaseResp) || (global::System.Object.Equals(BaseResp, other.BaseResp))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((ConnectionString != null))
        {
          hashcode = (hashcode * 397) + ConnectionString.GetHashCode();
        }
        if((BaseResp != null) && __isset.BaseResp)
        {
          hashcode = (hashcode * 397) + BaseResp.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp221 = new StringBuilder("AddServiceResponse(");
      if((ConnectionString != null))
      {
        tmp221.Append(", ConnectionString: ");
        ConnectionString.ToString(tmp221);
      }
      if((BaseResp != null) && __isset.BaseResp)
      {
        tmp221.Append(", BaseResp: ");
        BaseResp.ToString(tmp221);
      }
      tmp221.Append(')');
      return tmp221.ToString();
    }
  }

}
