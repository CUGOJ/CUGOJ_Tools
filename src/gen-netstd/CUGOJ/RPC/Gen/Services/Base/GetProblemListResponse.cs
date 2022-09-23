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

  public partial class GetProblemListResponse : TBase
  {
    private global::CUGOJ.RPC.Gen.Base.BaseResp _BaseResp;

    public List<global::CUGOJ.RPC.Gen.Common.ProblemStruct> ProblemList { get; set; }

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

    public GetProblemListResponse()
    {
    }

    public GetProblemListResponse(List<global::CUGOJ.RPC.Gen.Common.ProblemStruct> ProblemList, long NextCursor) : this()
    {
      this.ProblemList = ProblemList;
      this.NextCursor = NextCursor;
    }

    public GetProblemListResponse DeepCopy()
    {
      var tmp71 = new GetProblemListResponse();
      if((ProblemList != null))
      {
        tmp71.ProblemList = this.ProblemList.DeepCopy();
      }
      tmp71.NextCursor = this.NextCursor;
      if((BaseResp != null) && __isset.BaseResp)
      {
        tmp71.BaseResp = (global::CUGOJ.RPC.Gen.Base.BaseResp)this.BaseResp.DeepCopy();
      }
      tmp71.__isset.BaseResp = this.__isset.BaseResp;
      return tmp71;
    }

    public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        bool isset_ProblemList = false;
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
                  TList _list72 = await iprot.ReadListBeginAsync(cancellationToken);
                  ProblemList = new List<global::CUGOJ.RPC.Gen.Common.ProblemStruct>(_list72.Count);
                  for(int _i73 = 0; _i73 < _list72.Count; ++_i73)
                  {
                    global::CUGOJ.RPC.Gen.Common.ProblemStruct _elem74;
                    _elem74 = new global::CUGOJ.RPC.Gen.Common.ProblemStruct();
                    await _elem74.ReadAsync(iprot, cancellationToken);
                    ProblemList.Add(_elem74);
                  }
                  await iprot.ReadListEndAsync(cancellationToken);
                }
                isset_ProblemList = true;
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
        if (!isset_ProblemList)
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
        var tmp75 = new TStruct("GetProblemListResponse");
        await oprot.WriteStructBeginAsync(tmp75, cancellationToken);
        var tmp76 = new TField();
        if((ProblemList != null))
        {
          tmp76.Name = "ProblemList";
          tmp76.Type = TType.List;
          tmp76.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp76, cancellationToken);
          {
            await oprot.WriteListBeginAsync(new TList(TType.Struct, ProblemList.Count), cancellationToken);
            foreach (global::CUGOJ.RPC.Gen.Common.ProblemStruct _iter77 in ProblemList)
            {
              await _iter77.WriteAsync(oprot, cancellationToken);
            }
            await oprot.WriteListEndAsync(cancellationToken);
          }
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        tmp76.Name = "NextCursor";
        tmp76.Type = TType.I64;
        tmp76.ID = 2;
        await oprot.WriteFieldBeginAsync(tmp76, cancellationToken);
        await oprot.WriteI64Async(NextCursor, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
        if((BaseResp != null) && __isset.BaseResp)
        {
          tmp76.Name = "BaseResp";
          tmp76.Type = TType.Struct;
          tmp76.ID = 255;
          await oprot.WriteFieldBeginAsync(tmp76, cancellationToken);
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
      if (!(that is GetProblemListResponse other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return TCollections.Equals(ProblemList, other.ProblemList)
        && global::System.Object.Equals(NextCursor, other.NextCursor)
        && ((__isset.BaseResp == other.__isset.BaseResp) && ((!__isset.BaseResp) || (global::System.Object.Equals(BaseResp, other.BaseResp))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((ProblemList != null))
        {
          hashcode = (hashcode * 397) + TCollections.GetHashCode(ProblemList);
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
      var tmp78 = new StringBuilder("GetProblemListResponse(");
      if((ProblemList != null))
      {
        tmp78.Append(", ProblemList: ");
        ProblemList.ToString(tmp78);
      }
      tmp78.Append(", NextCursor: ");
      NextCursor.ToString(tmp78);
      if((BaseResp != null) && __isset.BaseResp)
      {
        tmp78.Append(", BaseResp: ");
        BaseResp.ToString(tmp78);
      }
      tmp78.Append(')');
      return tmp78.ToString();
    }
  }

}