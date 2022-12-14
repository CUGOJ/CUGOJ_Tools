/**
 * <auto-generated>
 * Autogenerated by Thrift Compiler (0.17.0)
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


#pragma warning disable IDE0079  // remove unnecessary pragmas
#pragma warning disable IDE0017  // object init can be simplified
#pragma warning disable IDE0028  // collection init can be simplified
#pragma warning disable IDE1006  // parts of the code use IDL spelling
#pragma warning disable CA1822   // empty DeepCopy() methods still non-static
#pragma warning disable IDE0083  // pattern matching "that is not SomeType" requires net5.0 but we still support earlier versions

namespace CUGOJ.RPC.Gen.Services.Core
{

  public partial class OJGetProblemListRequest : TBase
  {

    public long Cursor { get; set; }

    public int Limit { get; set; }

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

    public OJGetProblemListRequest()
    {
    }

    public OJGetProblemListRequest(long Cursor, int Limit) : this()
    {
      this.Cursor = Cursor;
      this.Limit = Limit;
    }

    public OJGetProblemListRequest DeepCopy()
    {
      var tmp0 = new OJGetProblemListRequest();
      tmp0.Cursor = this.Cursor;
      tmp0.Limit = this.Limit;
      if((Base != null) && __isset.@Base)
      {
        tmp0.Base = (global::CUGOJ.RPC.Gen.Base.@Base)this.Base.DeepCopy();
      }
      tmp0.__isset.@Base = this.__isset.@Base;
      return tmp0;
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
              if (field.Type == TType.I32)
              {
                Limit = await iprot.ReadI32Async(cancellationToken);
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
        var tmp1 = new TStruct("OJGetProblemListRequest");
        await oprot.WriteStructBeginAsync(tmp1, cancellationToken);
        var tmp2 = new TField();
        tmp2.Name = "Cursor";
        tmp2.Type = TType.I64;
        tmp2.ID = 1;
        await oprot.WriteFieldBeginAsync(tmp2, cancellationToken);
        await oprot.WriteI64Async(Cursor, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
        tmp2.Name = "Limit";
        tmp2.Type = TType.I32;
        tmp2.ID = 2;
        await oprot.WriteFieldBeginAsync(tmp2, cancellationToken);
        await oprot.WriteI32Async(Limit, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
        if((Base != null) && __isset.@Base)
        {
          tmp2.Name = "Base";
          tmp2.Type = TType.Struct;
          tmp2.ID = 255;
          await oprot.WriteFieldBeginAsync(tmp2, cancellationToken);
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
      if (!(that is OJGetProblemListRequest other)) return false;
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
      var tmp3 = new StringBuilder("OJGetProblemListRequest(");
      tmp3.Append(", Cursor: ");
      Cursor.ToString(tmp3);
      tmp3.Append(", Limit: ");
      Limit.ToString(tmp3);
      if((Base != null) && __isset.@Base)
      {
        tmp3.Append(", Base: ");
        Base.ToString(tmp3);
      }
      tmp3.Append(')');
      return tmp3.ToString();
    }
  }

}