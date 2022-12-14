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

namespace CUGOJ.RPC.Gen.Services.Base
{

  public partial class GetSubmissionListRequest : TBase
  {
    private bool _NewSubmissionFirst;
    private long _ContestID;
    private long _ProblemID;

    public long Cursor { get; set; }

    public long Limit { get; set; }

    public long MaxStoredTimestamp { get; set; }

    public bool NewSubmissionFirst
    {
      get
      {
        return _NewSubmissionFirst;
      }
      set
      {
        __isset.NewSubmissionFirst = true;
        this._NewSubmissionFirst = value;
      }
    }

    public long ContestID
    {
      get
      {
        return _ContestID;
      }
      set
      {
        __isset.ContestID = true;
        this._ContestID = value;
      }
    }

    public long ProblemID
    {
      get
      {
        return _ProblemID;
      }
      set
      {
        __isset.ProblemID = true;
        this._ProblemID = value;
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
      public bool NewSubmissionFirst;
      public bool ContestID;
      public bool ProblemID;
      public bool @Base;
    }

    public GetSubmissionListRequest()
    {
    }

    public GetSubmissionListRequest(long Cursor, long Limit, long MaxStoredTimestamp) : this()
    {
      this.Cursor = Cursor;
      this.Limit = Limit;
      this.MaxStoredTimestamp = MaxStoredTimestamp;
    }

    public GetSubmissionListRequest DeepCopy()
    {
      var tmp116 = new GetSubmissionListRequest();
      tmp116.Cursor = this.Cursor;
      tmp116.Limit = this.Limit;
      tmp116.MaxStoredTimestamp = this.MaxStoredTimestamp;
      if(__isset.NewSubmissionFirst)
      {
        tmp116.NewSubmissionFirst = this.NewSubmissionFirst;
      }
      tmp116.__isset.NewSubmissionFirst = this.__isset.NewSubmissionFirst;
      if(__isset.ContestID)
      {
        tmp116.ContestID = this.ContestID;
      }
      tmp116.__isset.ContestID = this.__isset.ContestID;
      if(__isset.ProblemID)
      {
        tmp116.ProblemID = this.ProblemID;
      }
      tmp116.__isset.ProblemID = this.__isset.ProblemID;
      if((Base != null) && __isset.@Base)
      {
        tmp116.Base = (global::CUGOJ.RPC.Gen.Base.@Base)this.Base.DeepCopy();
      }
      tmp116.__isset.@Base = this.__isset.@Base;
      return tmp116;
    }

    public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        bool isset_Cursor = false;
        bool isset_Limit = false;
        bool isset_MaxStoredTimestamp = false;
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
                MaxStoredTimestamp = await iprot.ReadI64Async(cancellationToken);
                isset_MaxStoredTimestamp = true;
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 4:
              if (field.Type == TType.Bool)
              {
                NewSubmissionFirst = await iprot.ReadBoolAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 5:
              if (field.Type == TType.I64)
              {
                ContestID = await iprot.ReadI64Async(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 6:
              if (field.Type == TType.I64)
              {
                ProblemID = await iprot.ReadI64Async(cancellationToken);
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
        if (!isset_MaxStoredTimestamp)
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
        var tmp117 = new TStruct("GetSubmissionListRequest");
        await oprot.WriteStructBeginAsync(tmp117, cancellationToken);
        var tmp118 = new TField();
        tmp118.Name = "Cursor";
        tmp118.Type = TType.I64;
        tmp118.ID = 1;
        await oprot.WriteFieldBeginAsync(tmp118, cancellationToken);
        await oprot.WriteI64Async(Cursor, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
        tmp118.Name = "Limit";
        tmp118.Type = TType.I64;
        tmp118.ID = 2;
        await oprot.WriteFieldBeginAsync(tmp118, cancellationToken);
        await oprot.WriteI64Async(Limit, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
        tmp118.Name = "MaxStoredTimestamp";
        tmp118.Type = TType.I64;
        tmp118.ID = 3;
        await oprot.WriteFieldBeginAsync(tmp118, cancellationToken);
        await oprot.WriteI64Async(MaxStoredTimestamp, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
        if(__isset.NewSubmissionFirst)
        {
          tmp118.Name = "NewSubmissionFirst";
          tmp118.Type = TType.Bool;
          tmp118.ID = 4;
          await oprot.WriteFieldBeginAsync(tmp118, cancellationToken);
          await oprot.WriteBoolAsync(NewSubmissionFirst, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.ContestID)
        {
          tmp118.Name = "ContestID";
          tmp118.Type = TType.I64;
          tmp118.ID = 5;
          await oprot.WriteFieldBeginAsync(tmp118, cancellationToken);
          await oprot.WriteI64Async(ContestID, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.ProblemID)
        {
          tmp118.Name = "ProblemID";
          tmp118.Type = TType.I64;
          tmp118.ID = 6;
          await oprot.WriteFieldBeginAsync(tmp118, cancellationToken);
          await oprot.WriteI64Async(ProblemID, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Base != null) && __isset.@Base)
        {
          tmp118.Name = "Base";
          tmp118.Type = TType.Struct;
          tmp118.ID = 255;
          await oprot.WriteFieldBeginAsync(tmp118, cancellationToken);
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
      if (!(that is GetSubmissionListRequest other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return global::System.Object.Equals(Cursor, other.Cursor)
        && global::System.Object.Equals(Limit, other.Limit)
        && global::System.Object.Equals(MaxStoredTimestamp, other.MaxStoredTimestamp)
        && ((__isset.NewSubmissionFirst == other.__isset.NewSubmissionFirst) && ((!__isset.NewSubmissionFirst) || (global::System.Object.Equals(NewSubmissionFirst, other.NewSubmissionFirst))))
        && ((__isset.ContestID == other.__isset.ContestID) && ((!__isset.ContestID) || (global::System.Object.Equals(ContestID, other.ContestID))))
        && ((__isset.ProblemID == other.__isset.ProblemID) && ((!__isset.ProblemID) || (global::System.Object.Equals(ProblemID, other.ProblemID))))
        && ((__isset.@Base == other.__isset.@Base) && ((!__isset.@Base) || (global::System.Object.Equals(Base, other.Base))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        hashcode = (hashcode * 397) + Cursor.GetHashCode();
        hashcode = (hashcode * 397) + Limit.GetHashCode();
        hashcode = (hashcode * 397) + MaxStoredTimestamp.GetHashCode();
        if(__isset.NewSubmissionFirst)
        {
          hashcode = (hashcode * 397) + NewSubmissionFirst.GetHashCode();
        }
        if(__isset.ContestID)
        {
          hashcode = (hashcode * 397) + ContestID.GetHashCode();
        }
        if(__isset.ProblemID)
        {
          hashcode = (hashcode * 397) + ProblemID.GetHashCode();
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
      var tmp119 = new StringBuilder("GetSubmissionListRequest(");
      tmp119.Append(", Cursor: ");
      Cursor.ToString(tmp119);
      tmp119.Append(", Limit: ");
      Limit.ToString(tmp119);
      tmp119.Append(", MaxStoredTimestamp: ");
      MaxStoredTimestamp.ToString(tmp119);
      if(__isset.NewSubmissionFirst)
      {
        tmp119.Append(", NewSubmissionFirst: ");
        NewSubmissionFirst.ToString(tmp119);
      }
      if(__isset.ContestID)
      {
        tmp119.Append(", ContestID: ");
        ContestID.ToString(tmp119);
      }
      if(__isset.ProblemID)
      {
        tmp119.Append(", ProblemID: ");
        ProblemID.ToString(tmp119);
      }
      if((Base != null) && __isset.@Base)
      {
        tmp119.Append(", Base: ");
        Base.ToString(tmp119);
      }
      tmp119.Append(')');
      return tmp119.ToString();
    }
  }

}