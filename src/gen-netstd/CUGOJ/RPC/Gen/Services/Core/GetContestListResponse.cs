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

  public partial class GetContestListResponse : TBase
  {
    private global::CUGOJ.RPC.Gen.Base.BaseResp _BaseResp;

    public List<global::CUGOJ.RPC.Gen.Common.ContestStruct> ContestList { get; set; }

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

    public GetContestListResponse(List<global::CUGOJ.RPC.Gen.Common.ContestStruct> ContestList) : this()
    {
      this.ContestList = ContestList;
    }

    public GetContestListResponse DeepCopy()
    {
      var tmp58 = new GetContestListResponse();
      if((ContestList != null))
      {
        tmp58.ContestList = this.ContestList.DeepCopy();
      }
      if((BaseResp != null) && __isset.BaseResp)
      {
        tmp58.BaseResp = (global::CUGOJ.RPC.Gen.Base.BaseResp)this.BaseResp.DeepCopy();
      }
      tmp58.__isset.BaseResp = this.__isset.BaseResp;
      return tmp58;
    }

    public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        bool isset_ContestList = false;
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
                  var _list59 = await iprot.ReadListBeginAsync(cancellationToken);
                  ContestList = new List<global::CUGOJ.RPC.Gen.Common.ContestStruct>(_list59.Count);
                  for(int _i60 = 0; _i60 < _list59.Count; ++_i60)
                  {
                    global::CUGOJ.RPC.Gen.Common.ContestStruct _elem61;
                    _elem61 = new global::CUGOJ.RPC.Gen.Common.ContestStruct();
                    await _elem61.ReadAsync(iprot, cancellationToken);
                    ContestList.Add(_elem61);
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
        var tmp62 = new TStruct("GetContestListResponse");
        await oprot.WriteStructBeginAsync(tmp62, cancellationToken);
        var tmp63 = new TField();
        if((ContestList != null))
        {
          tmp63.Name = "ContestList";
          tmp63.Type = TType.List;
          tmp63.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp63, cancellationToken);
          await oprot.WriteListBeginAsync(new TList(TType.Struct, ContestList.Count), cancellationToken);
          foreach (global::CUGOJ.RPC.Gen.Common.ContestStruct _iter64 in ContestList)
          {
            await _iter64.WriteAsync(oprot, cancellationToken);
          }
          await oprot.WriteListEndAsync(cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((BaseResp != null) && __isset.BaseResp)
        {
          tmp63.Name = "BaseResp";
          tmp63.Type = TType.Struct;
          tmp63.ID = 255;
          await oprot.WriteFieldBeginAsync(tmp63, cancellationToken);
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
        && ((__isset.BaseResp == other.__isset.BaseResp) && ((!__isset.BaseResp) || (global::System.Object.Equals(BaseResp, other.BaseResp))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((ContestList != null))
        {
          hashcode = (hashcode * 397) + TCollections.GetHashCode(ContestList);
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
      var tmp65 = new StringBuilder("GetContestListResponse(");
      if((ContestList != null))
      {
        tmp65.Append(", ContestList: ");
        ContestList.ToString(tmp65);
      }
      if((BaseResp != null) && __isset.BaseResp)
      {
        tmp65.Append(", BaseResp: ");
        BaseResp.ToString(tmp65);
      }
      tmp65.Append(')');
      return tmp65.ToString();
    }
  }

}
