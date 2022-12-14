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

  public partial class GetUserSubmissionStatusByProblemIDListRequest : TBase
  {
    private int _DesiredStatus;

    public long UserID { get; set; }

    public List<long> ProblemIDList { get; set; }

    public int DesiredStatus
    {
      get
      {
        return _DesiredStatus;
      }
      set
      {
        __isset.DesiredStatus = true;
        this._DesiredStatus = value;
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
      public bool DesiredStatus;
      public bool @Base;
    }

    public GetUserSubmissionStatusByProblemIDListRequest()
    {
    }

    public GetUserSubmissionStatusByProblemIDListRequest(long UserID, List<long> ProblemIDList) : this()
    {
      this.UserID = UserID;
      this.ProblemIDList = ProblemIDList;
    }

    public GetUserSubmissionStatusByProblemIDListRequest DeepCopy()
    {
      var tmp150 = new GetUserSubmissionStatusByProblemIDListRequest();
      tmp150.UserID = this.UserID;
      if((ProblemIDList != null))
      {
        tmp150.ProblemIDList = this.ProblemIDList.DeepCopy();
      }
      if(__isset.DesiredStatus)
      {
        tmp150.DesiredStatus = this.DesiredStatus;
      }
      tmp150.__isset.DesiredStatus = this.__isset.DesiredStatus;
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
        bool isset_UserID = false;
        bool isset_ProblemIDList = false;
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
            case 2:
              if (field.Type == TType.List)
              {
                {
                  var _list151 = await iprot.ReadListBeginAsync(cancellationToken);
                  ProblemIDList = new List<long>(_list151.Count);
                  for(int _i152 = 0; _i152 < _list151.Count; ++_i152)
                  {
                    long _elem153;
                    _elem153 = await iprot.ReadI64Async(cancellationToken);
                    ProblemIDList.Add(_elem153);
                  }
                  await iprot.ReadListEndAsync(cancellationToken);
                }
                isset_ProblemIDList = true;
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 3:
              if (field.Type == TType.I32)
              {
                DesiredStatus = await iprot.ReadI32Async(cancellationToken);
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
        if (!isset_UserID)
        {
          throw new TProtocolException(TProtocolException.INVALID_DATA);
        }
        if (!isset_ProblemIDList)
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
        var tmp154 = new TStruct("GetUserSubmissionStatusByProblemIDListRequest");
        await oprot.WriteStructBeginAsync(tmp154, cancellationToken);
        var tmp155 = new TField();
        tmp155.Name = "UserID";
        tmp155.Type = TType.I64;
        tmp155.ID = 1;
        await oprot.WriteFieldBeginAsync(tmp155, cancellationToken);
        await oprot.WriteI64Async(UserID, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
        if((ProblemIDList != null))
        {
          tmp155.Name = "ProblemIDList";
          tmp155.Type = TType.List;
          tmp155.ID = 2;
          await oprot.WriteFieldBeginAsync(tmp155, cancellationToken);
          await oprot.WriteListBeginAsync(new TList(TType.I64, ProblemIDList.Count), cancellationToken);
          foreach (long _iter156 in ProblemIDList)
          {
            await oprot.WriteI64Async(_iter156, cancellationToken);
          }
          await oprot.WriteListEndAsync(cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.DesiredStatus)
        {
          tmp155.Name = "DesiredStatus";
          tmp155.Type = TType.I32;
          tmp155.ID = 3;
          await oprot.WriteFieldBeginAsync(tmp155, cancellationToken);
          await oprot.WriteI32Async(DesiredStatus, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Base != null) && __isset.@Base)
        {
          tmp155.Name = "Base";
          tmp155.Type = TType.Struct;
          tmp155.ID = 255;
          await oprot.WriteFieldBeginAsync(tmp155, cancellationToken);
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
      if (!(that is GetUserSubmissionStatusByProblemIDListRequest other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return global::System.Object.Equals(UserID, other.UserID)
        && TCollections.Equals(ProblemIDList, other.ProblemIDList)
        && ((__isset.DesiredStatus == other.__isset.DesiredStatus) && ((!__isset.DesiredStatus) || (global::System.Object.Equals(DesiredStatus, other.DesiredStatus))))
        && ((__isset.@Base == other.__isset.@Base) && ((!__isset.@Base) || (global::System.Object.Equals(Base, other.Base))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        hashcode = (hashcode * 397) + UserID.GetHashCode();
        if((ProblemIDList != null))
        {
          hashcode = (hashcode * 397) + TCollections.GetHashCode(ProblemIDList);
        }
        if(__isset.DesiredStatus)
        {
          hashcode = (hashcode * 397) + DesiredStatus.GetHashCode();
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
      var tmp157 = new StringBuilder("GetUserSubmissionStatusByProblemIDListRequest(");
      tmp157.Append(", UserID: ");
      UserID.ToString(tmp157);
      if((ProblemIDList != null))
      {
        tmp157.Append(", ProblemIDList: ");
        ProblemIDList.ToString(tmp157);
      }
      if(__isset.DesiredStatus)
      {
        tmp157.Append(", DesiredStatus: ");
        DesiredStatus.ToString(tmp157);
      }
      if((Base != null) && __isset.@Base)
      {
        tmp157.Append(", Base: ");
        Base.ToString(tmp157);
      }
      tmp157.Append(')');
      return tmp157.ToString();
    }
  }

}