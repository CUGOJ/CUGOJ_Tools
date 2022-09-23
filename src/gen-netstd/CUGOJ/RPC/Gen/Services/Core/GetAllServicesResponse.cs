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

  public partial class GetAllServicesResponse : TBase
  {
    private global::CUGOJ.RPC.Gen.Base.BaseResp _BaseResp;

    public List<global::CUGOJ.RPC.Gen.Base.ServiceBaseInfo> Services { get; set; }

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

    public GetAllServicesResponse()
    {
    }

    public GetAllServicesResponse(List<global::CUGOJ.RPC.Gen.Base.ServiceBaseInfo> Services) : this()
    {
      this.Services = Services;
    }

    public GetAllServicesResponse DeepCopy()
    {
      var tmp189 = new GetAllServicesResponse();
      if((Services != null))
      {
        tmp189.Services = this.Services.DeepCopy();
      }
      if((BaseResp != null) && __isset.BaseResp)
      {
        tmp189.BaseResp = (global::CUGOJ.RPC.Gen.Base.BaseResp)this.BaseResp.DeepCopy();
      }
      tmp189.__isset.BaseResp = this.__isset.BaseResp;
      return tmp189;
    }

    public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        bool isset_Services = false;
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
                  var _list190 = await iprot.ReadListBeginAsync(cancellationToken);
                  Services = new List<global::CUGOJ.RPC.Gen.Base.ServiceBaseInfo>(_list190.Count);
                  for(int _i191 = 0; _i191 < _list190.Count; ++_i191)
                  {
                    global::CUGOJ.RPC.Gen.Base.ServiceBaseInfo _elem192;
                    _elem192 = new global::CUGOJ.RPC.Gen.Base.ServiceBaseInfo();
                    await _elem192.ReadAsync(iprot, cancellationToken);
                    Services.Add(_elem192);
                  }
                  await iprot.ReadListEndAsync(cancellationToken);
                }
                isset_Services = true;
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
        if (!isset_Services)
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
        var tmp193 = new TStruct("GetAllServicesResponse");
        await oprot.WriteStructBeginAsync(tmp193, cancellationToken);
        var tmp194 = new TField();
        if((Services != null))
        {
          tmp194.Name = "Services";
          tmp194.Type = TType.List;
          tmp194.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp194, cancellationToken);
          await oprot.WriteListBeginAsync(new TList(TType.Struct, Services.Count), cancellationToken);
          foreach (global::CUGOJ.RPC.Gen.Base.ServiceBaseInfo _iter195 in Services)
          {
            await _iter195.WriteAsync(oprot, cancellationToken);
          }
          await oprot.WriteListEndAsync(cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((BaseResp != null) && __isset.BaseResp)
        {
          tmp194.Name = "BaseResp";
          tmp194.Type = TType.Struct;
          tmp194.ID = 255;
          await oprot.WriteFieldBeginAsync(tmp194, cancellationToken);
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
      if (!(that is GetAllServicesResponse other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return TCollections.Equals(Services, other.Services)
        && ((__isset.BaseResp == other.__isset.BaseResp) && ((!__isset.BaseResp) || (global::System.Object.Equals(BaseResp, other.BaseResp))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((Services != null))
        {
          hashcode = (hashcode * 397) + TCollections.GetHashCode(Services);
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
      var tmp196 = new StringBuilder("GetAllServicesResponse(");
      if((Services != null))
      {
        tmp196.Append(", Services: ");
        Services.ToString(tmp196);
      }
      if((BaseResp != null) && __isset.BaseResp)
      {
        tmp196.Append(", BaseResp: ");
        BaseResp.ToString(tmp196);
      }
      tmp196.Append(')');
      return tmp196.ToString();
    }
  }

}
