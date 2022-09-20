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

  public partial class GetContestListResponse : TBase
  {
    private global::CUGOJ.RPC.Gen.Base.BaseResp _BaseResp;

    public List<global::CUGOJ.RPC.Gen.Common.ContestStruct> ContestList { get; set; }

    public long NextCursor { get; set; }

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

    public GetContestListResponse()
    {
    }

    public GetContestListResponse(List<global::CUGOJ.RPC.Gen.Common.ContestStruct> ContestList, long NextCursor) : this()
    {
      this.ContestList = ContestList;
      this.NextCursor = NextCursor;
    }

    public GetContestListResponse DeepCopy()
    {
      var tmp155 = new GetContestListResponse();
      if((ContestList != null))
      {
        tmp155.ContestList = this.ContestList.DeepCopy();
      }
      tmp155.NextCursor = this.NextCursor;
      if((BaseResp != null) && __isset.BaseResp)
      {
        tmp155.BaseResp = (global::CUGOJ.RPC.Gen.Base.BaseResp)this.BaseResp.DeepCopy();
      }
      tmp155.__isset.BaseResp = this.__isset.BaseResp;
      return tmp155;
    }

    public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        bool isset_ContestList = false;
        bool isset_NextCursor = false;
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
              if (field.Type == TType.List)
              {
                {
                  TList _list156 = await iprot.ReadListBeginAsync(cancellationToken);
                  ContestList = new List<global::CUGOJ.RPC.Gen.Common.ContestStruct>(_list156.Count);
                  for(int _i157 = 0; _i157 < _list156.Count; ++_i157)
                  {
                    global::CUGOJ.RPC.Gen.Common.ContestStruct _elem158;
                    _elem158 = new global::CUGOJ.RPC.Gen.Common.ContestStruct();
                    await _elem158.ReadAsync(iprot, cancellationToken);
                    ContestList.Add(_elem158);
                  }
                  await iprot.ReadListEndAsync(cancellationToken);
                }
                isset_ContestList = true;
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.I64)
              {
                NextCursor = await iprot.ReadI64Async(cancellationToken);
                isset_NextCursor = true;
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
        if (!isset_ContestList)
        {
          throw new TProtocolException(TProtocolException.INVALID_DATA);
        }
        if (!isset_NextCursor)
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
        var tmp159 = new TStruct("GetContestListResponse");
        await oprot.WriteStructBeginAsync(tmp159, cancellationToken);
        var tmp160 = new TField();
        if((ContestList != null))
        {
          tmp160.Name = "ContestList";
          tmp160.Type = TType.List;
          tmp160.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp160, cancellationToken);
          {
            await oprot.WriteListBeginAsync(new TList(TType.Struct, ContestList.Count), cancellationToken);
            foreach (global::CUGOJ.RPC.Gen.Common.ContestStruct _iter161 in ContestList)
            {
              await _iter161.WriteAsync(oprot, cancellationToken);
            }
            await oprot.WriteListEndAsync(cancellationToken);
          }
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        tmp160.Name = "NextCursor";
        tmp160.Type = TType.I64;
        tmp160.ID = 2;
        await oprot.WriteFieldBeginAsync(tmp160, cancellationToken);
        await oprot.WriteI64Async(NextCursor, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
        if((BaseResp != null) && __isset.BaseResp)
        {
          tmp160.Name = "BaseResp";
          tmp160.Type = TType.Struct;
          tmp160.ID = 255;
          await oprot.WriteFieldBeginAsync(tmp160, cancellationToken);
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
      if (!(that is GetContestListResponse other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return TCollections.Equals(ContestList, other.ContestList)
        && global::System.Object.Equals(NextCursor, other.NextCursor)
        && ((__isset.BaseResp == other.__isset.BaseResp) && ((!__isset.BaseResp) || (global::System.Object.Equals(BaseResp, other.BaseResp))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((ContestList != null))
        {
          hashcode = (hashcode * 397) + TCollections.GetHashCode(ContestList);
        }
        hashcode = (hashcode * 397) + NextCursor.GetHashCode();
        if((BaseResp != null) && __isset.BaseResp)
        {
          hashcode = (hashcode * 397) + BaseResp.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp162 = new StringBuilder("GetContestListResponse(");
      if((ContestList != null))
      {
        tmp162.Append(", ContestList: ");
        ContestList.ToString(tmp162);
      }
      tmp162.Append(", NextCursor: ");
      NextCursor.ToString(tmp162);
      if((BaseResp != null) && __isset.BaseResp)
      {
        tmp162.Append(", BaseResp: ");
        BaseResp.ToString(tmp162);
      }
      tmp162.Append(')');
      return tmp162.ToString();
    }
  }

}
