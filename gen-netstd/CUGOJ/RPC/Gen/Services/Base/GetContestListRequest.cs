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
    private long _UserID;
    private global::CUGOJ.RPC.Gen.Base.@Base _Base;

    public long Cursor { get; set; }

    public long Limit { get; set; }

    public long UserID
    {
      get
      {
        return _UserID;
      }
      set
      {
        __isset.UserID = true;
        this._UserID = value;
      }
    }

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
      public bool UserID;
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
      var tmp108 = new GetContestListRequest();
      tmp108.Cursor = this.Cursor;
      tmp108.Limit = this.Limit;
      if(__isset.UserID)
      {
        tmp108.UserID = this.UserID;
      }
      tmp108.__isset.UserID = this.__isset.UserID;
      if((Base != null) && __isset.@Base)
      {
        tmp108.Base = (global::CUGOJ.RPC.Gen.Base.@Base)this.Base.DeepCopy();
      }
      tmp108.__isset.@Base = this.__isset.@Base;
      return tmp108;
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
            case 3:
              if (field.Type == TType.I64)
              {
                UserID = await iprot.ReadI64Async(cancellationToken);
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
        var tmp109 = new TStruct("GetContestListRequest");
        await oprot.WriteStructBeginAsync(tmp109, cancellationToken);
        var tmp110 = new TField();
        tmp110.Name = "Cursor";
        tmp110.Type = TType.I64;
        tmp110.ID = 1;
        await oprot.WriteFieldBeginAsync(tmp110, cancellationToken);
        await oprot.WriteI64Async(Cursor, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
        tmp110.Name = "Limit";
        tmp110.Type = TType.I64;
        tmp110.ID = 2;
        await oprot.WriteFieldBeginAsync(tmp110, cancellationToken);
        await oprot.WriteI64Async(Limit, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
        if(__isset.UserID)
        {
          tmp110.Name = "UserID";
          tmp110.Type = TType.I64;
          tmp110.ID = 3;
          await oprot.WriteFieldBeginAsync(tmp110, cancellationToken);
          await oprot.WriteI64Async(UserID, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Base != null) && __isset.@Base)
        {
          tmp110.Name = "Base";
          tmp110.Type = TType.Struct;
          tmp110.ID = 255;
          await oprot.WriteFieldBeginAsync(tmp110, cancellationToken);
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
        && ((__isset.UserID == other.__isset.UserID) && ((!__isset.UserID) || (global::System.Object.Equals(UserID, other.UserID))))
        && ((__isset.@Base == other.__isset.@Base) && ((!__isset.@Base) || (global::System.Object.Equals(Base, other.Base))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        hashcode = (hashcode * 397) + Cursor.GetHashCode();
        hashcode = (hashcode * 397) + Limit.GetHashCode();
        if(__isset.UserID)
        {
          hashcode = (hashcode * 397) + UserID.GetHashCode();
        }
        if((Base != null) && __isset.@Base)
        {
          hashcode = (hashcode * 397) + Base.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp111 = new StringBuilder("GetContestListRequest(");
      tmp111.Append(", Cursor: ");
      Cursor.ToString(tmp111);
      tmp111.Append(", Limit: ");
      Limit.ToString(tmp111);
      if(__isset.UserID)
      {
        tmp111.Append(", UserID: ");
        UserID.ToString(tmp111);
      }
      if((Base != null) && __isset.@Base)
      {
        tmp111.Append(", Base: ");
        Base.ToString(tmp111);
      }
      tmp111.Append(')');
      return tmp111.ToString();
    }
  }

}