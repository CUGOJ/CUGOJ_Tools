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

namespace CUGOJ.RPC.Gen.Services.Base
{

  public partial class GetContestListRequest : TBase
  {

    public long Cursor { get; set; }

    public long Limit { get; set; }

    public global::CUGOJ.RPC.Gen.Base.@Base Base
    {
      get
      {
        return _Base;
      }
      set
      {
        __isset.@Base = true;
        this._Base = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool @Base;
    }

    public GetContestListRequest()
    {
    }

    public GetContestListRequest(long Cursor, long Limit) : this()
    {
      this.Cursor = Cursor;
      this.Limit = Limit;
    }

    public GetContestListRequest DeepCopy()
    {
      var tmp150 = new GetContestListRequest();
      tmp150.Cursor = this.Cursor;
      tmp150.Limit = this.Limit;
      if((Base != null) && __isset.@Base)
      {
        tmp150.Base = (global::CUGOJ.RPC.Gen.Base.@Base)this.Base.DeepCopy();
      }
      tmp150.__isset.@Base = this.__isset.@Base;
      return tmp150;
    }

    public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        bool isset_Cursor = false;
        bool isset_Limit = false;
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
                Cursor = await iprot.ReadI64Async(cancellationToken);
                isset_Cursor = true;
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.I64)
              {
                Limit = await iprot.ReadI64Async(cancellationToken);
                isset_Limit = true;
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 255:
              if (field.Type == TType.Struct)
              {
                Base = new global::CUGOJ.RPC.Gen.Base.@Base();
                await Base.ReadAsync(iprot, cancellationToken);
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
        if (!isset_Cursor)
        {
          throw new TProtocolException(TProtocolException.INVALID_DATA);
        }
        if (!isset_Limit)
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
        var tmp151 = new TStruct("GetContestListRequest");
        await oprot.WriteStructBeginAsync(tmp151, cancellationToken);
        var tmp152 = new TField();
        tmp152.Name = "Cursor";
        tmp152.Type = TType.I64;
        tmp152.ID = 1;
        await oprot.WriteFieldBeginAsync(tmp152, cancellationToken);
        await oprot.WriteI64Async(Cursor, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
        tmp152.Name = "Limit";
        tmp152.Type = TType.I64;
        tmp152.ID = 2;
        await oprot.WriteFieldBeginAsync(tmp152, cancellationToken);
        await oprot.WriteI64Async(Limit, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
        if((Base != null) && __isset.@Base)
        {
          tmp152.Name = "Base";
          tmp152.Type = TType.Struct;
          tmp152.ID = 255;
          await oprot.WriteFieldBeginAsync(tmp152, cancellationToken);
          await Base.WriteAsync(oprot, cancellationToken);
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
      if (!(that is GetContestListRequest other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return global::System.Object.Equals(Cursor, other.Cursor)
        && global::System.Object.Equals(Limit, other.Limit)
        && ((__isset.@Base == other.__isset.@Base) && ((!__isset.@Base) || (global::System.Object.Equals(Base, other.Base))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        hashcode = (hashcode * 397) + Cursor.GetHashCode();
        hashcode = (hashcode * 397) + Limit.GetHashCode();
        if((Base != null) && __isset.@Base)
        {
          hashcode = (hashcode * 397) + Base.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp153 = new StringBuilder("GetContestListRequest(");
      tmp153.Append(", Cursor: ");
      Cursor.ToString(tmp153);
      tmp153.Append(", Limit: ");
      Limit.ToString(tmp153);
      if((Base != null) && __isset.@Base)
      {
        tmp153.Append(", Base: ");
        Base.ToString(tmp153);
      }
      tmp153.Append(')');
      return tmp153.ToString();
    }
  }

}