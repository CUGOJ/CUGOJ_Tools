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

  public partial class GetRegisterListResponse : TBase
  {
    private global::CUGOJ.RPC.Gen.Base.BaseResp _BaseResp;

    public List<global::CUGOJ.RPC.Gen.Common.RegisterStruct> RegisterList { get; set; }

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

    public GetRegisterListResponse()
    {
    }

    public GetRegisterListResponse(List<global::CUGOJ.RPC.Gen.Common.RegisterStruct> RegisterList, long NextCursor) : this()
    {
      this.RegisterList = RegisterList;
      this.NextCursor = NextCursor;
    }

    public GetRegisterListResponse DeepCopy()
    {
      var tmp208 = new GetRegisterListResponse();
      if((RegisterList != null))
      {
        tmp208.RegisterList = this.RegisterList.DeepCopy();
      }
      tmp208.NextCursor = this.NextCursor;
      if((BaseResp != null) && __isset.BaseResp)
      {
        tmp208.BaseResp = (global::CUGOJ.RPC.Gen.Base.BaseResp)this.BaseResp.DeepCopy();
      }
      tmp208.__isset.BaseResp = this.__isset.BaseResp;
      return tmp208;
    }

    public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        bool isset_RegisterList = false;
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
                  var _list209 = await iprot.ReadListBeginAsync(cancellationToken);
                  RegisterList = new List<global::CUGOJ.RPC.Gen.Common.RegisterStruct>(_list209.Count);
                  for(int _i210 = 0; _i210 < _list209.Count; ++_i210)
                  {
                    global::CUGOJ.RPC.Gen.Common.RegisterStruct _elem211;
                    _elem211 = new global::CUGOJ.RPC.Gen.Common.RegisterStruct();
                    await _elem211.ReadAsync(iprot, cancellationToken);
                    RegisterList.Add(_elem211);
                  }
                  await iprot.ReadListEndAsync(cancellationToken);
                }
                isset_RegisterList = true;
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
        if (!isset_RegisterList)
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
        var tmp212 = new TStruct("GetRegisterListResponse");
        await oprot.WriteStructBeginAsync(tmp212, cancellationToken);
        var tmp213 = new TField();
        if((RegisterList != null))
        {
          tmp213.Name = "RegisterList";
          tmp213.Type = TType.List;
          tmp213.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp213, cancellationToken);
          await oprot.WriteListBeginAsync(new TList(TType.Struct, RegisterList.Count), cancellationToken);
          foreach (global::CUGOJ.RPC.Gen.Common.RegisterStruct _iter214 in RegisterList)
          {
            await _iter214.WriteAsync(oprot, cancellationToken);
          }
          await oprot.WriteListEndAsync(cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        tmp213.Name = "NextCursor";
        tmp213.Type = TType.I64;
        tmp213.ID = 2;
        await oprot.WriteFieldBeginAsync(tmp213, cancellationToken);
        await oprot.WriteI64Async(NextCursor, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
        if((BaseResp != null) && __isset.BaseResp)
        {
          tmp213.Name = "BaseResp";
          tmp213.Type = TType.Struct;
          tmp213.ID = 255;
          await oprot.WriteFieldBeginAsync(tmp213, cancellationToken);
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
      if (!(that is GetRegisterListResponse other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return TCollections.Equals(RegisterList, other.RegisterList)
        && global::System.Object.Equals(NextCursor, other.NextCursor)
        && ((__isset.BaseResp == other.__isset.BaseResp) && ((!__isset.BaseResp) || (global::System.Object.Equals(BaseResp, other.BaseResp))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((RegisterList != null))
        {
          hashcode = (hashcode * 397) + TCollections.GetHashCode(RegisterList);
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
      var tmp215 = new StringBuilder("GetRegisterListResponse(");
      if((RegisterList != null))
      {
        tmp215.Append(", RegisterList: ");
        RegisterList.ToString(tmp215);
      }
      tmp215.Append(", NextCursor: ");
      NextCursor.ToString(tmp215);
      if((BaseResp != null) && __isset.BaseResp)
      {
        tmp215.Append(", BaseResp: ");
        BaseResp.ToString(tmp215);
      }
      tmp215.Append(')');
      return tmp215.ToString();
    }
  }

}
