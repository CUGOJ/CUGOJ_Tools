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

  public partial class GetSubmissionListResponse : TBase
  {
    private global::CUGOJ.RPC.Gen.Base.BaseResp _BaseResp;

    public List<global::CUGOJ.RPC.Gen.Common.SubmissionStruct> SubmissionList { get; set; }

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

    public GetSubmissionListResponse()
    {
    }

    public GetSubmissionListResponse(List<global::CUGOJ.RPC.Gen.Common.SubmissionStruct> SubmissionList) : this()
    {
      this.SubmissionList = SubmissionList;
    }

    public GetSubmissionListResponse DeepCopy()
    {
      var tmp121 = new GetSubmissionListResponse();
      if((SubmissionList != null))
      {
        tmp121.SubmissionList = this.SubmissionList.DeepCopy();
      }
      if((BaseResp != null) && __isset.BaseResp)
      {
        tmp121.BaseResp = (global::CUGOJ.RPC.Gen.Base.BaseResp)this.BaseResp.DeepCopy();
      }
      tmp121.__isset.BaseResp = this.__isset.BaseResp;
      return tmp121;
    }

    public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        bool isset_SubmissionList = false;
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
                  var _list122 = await iprot.ReadListBeginAsync(cancellationToken);
                  SubmissionList = new List<global::CUGOJ.RPC.Gen.Common.SubmissionStruct>(_list122.Count);
                  for(int _i123 = 0; _i123 < _list122.Count; ++_i123)
                  {
                    global::CUGOJ.RPC.Gen.Common.SubmissionStruct _elem124;
                    _elem124 = new global::CUGOJ.RPC.Gen.Common.SubmissionStruct();
                    await _elem124.ReadAsync(iprot, cancellationToken);
                    SubmissionList.Add(_elem124);
                  }
                  await iprot.ReadListEndAsync(cancellationToken);
                }
                isset_SubmissionList = true;
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
        if (!isset_SubmissionList)
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
        var tmp125 = new TStruct("GetSubmissionListResponse");
        await oprot.WriteStructBeginAsync(tmp125, cancellationToken);
        var tmp126 = new TField();
        if((SubmissionList != null))
        {
          tmp126.Name = "SubmissionList";
          tmp126.Type = TType.List;
          tmp126.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp126, cancellationToken);
          await oprot.WriteListBeginAsync(new TList(TType.Struct, SubmissionList.Count), cancellationToken);
          foreach (global::CUGOJ.RPC.Gen.Common.SubmissionStruct _iter127 in SubmissionList)
          {
            await _iter127.WriteAsync(oprot, cancellationToken);
          }
          await oprot.WriteListEndAsync(cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((BaseResp != null) && __isset.BaseResp)
        {
          tmp126.Name = "BaseResp";
          tmp126.Type = TType.Struct;
          tmp126.ID = 255;
          await oprot.WriteFieldBeginAsync(tmp126, cancellationToken);
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
      if (!(that is GetSubmissionListResponse other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return TCollections.Equals(SubmissionList, other.SubmissionList)
        && ((__isset.BaseResp == other.__isset.BaseResp) && ((!__isset.BaseResp) || (global::System.Object.Equals(BaseResp, other.BaseResp))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((SubmissionList != null))
        {
          hashcode = (hashcode * 397) + TCollections.GetHashCode(SubmissionList);
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
      var tmp128 = new StringBuilder("GetSubmissionListResponse(");
      if((SubmissionList != null))
      {
        tmp128.Append(", SubmissionList: ");
        SubmissionList.ToString(tmp128);
      }
      if((BaseResp != null) && __isset.BaseResp)
      {
        tmp128.Append(", BaseResp: ");
        BaseResp.ToString(tmp128);
      }
      tmp128.Append(')');
      return tmp128.ToString();
    }
  }

}
