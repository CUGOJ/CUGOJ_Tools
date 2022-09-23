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

namespace CUGOJ.RPC.Gen.Services.Core
{

  public partial class AddServiceRequest : TBase
  {

    /// <summary>
    /// 
    /// <seealso cref="global::CUGOJ.RPC.Gen.Base.ServiceTypeEnum"/>
    /// </summary>
    public global::CUGOJ.RPC.Gen.Base.ServiceTypeEnum ServiceType { get; set; }

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

    public AddServiceRequest()
    {
    }

    public AddServiceRequest(global::CUGOJ.RPC.Gen.Base.ServiceTypeEnum ServiceType) : this()
    {
      this.ServiceType = ServiceType;
    }

    public AddServiceRequest DeepCopy()
    {
      var tmp218 = new AddServiceRequest();
      tmp218.ServiceType = this.ServiceType;
      if((Base != null) && __isset.@Base)
      {
        tmp218.Base = (global::CUGOJ.RPC.Gen.Base.@Base)this.Base.DeepCopy();
      }
      tmp218.__isset.@Base = this.__isset.@Base;
      return tmp218;
    }

    public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        bool isset_ServiceType = false;
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
              if (field.Type == TType.I32)
              {
                ServiceType = (global::CUGOJ.RPC.Gen.Base.ServiceTypeEnum)await iprot.ReadI32Async(cancellationToken);
                isset_ServiceType = true;
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
        if (!isset_ServiceType)
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
        var tmp219 = new TStruct("AddServiceRequest");
        await oprot.WriteStructBeginAsync(tmp219, cancellationToken);
        var tmp220 = new TField();
        tmp220.Name = "ServiceType";
        tmp220.Type = TType.I32;
        tmp220.ID = 1;
        await oprot.WriteFieldBeginAsync(tmp220, cancellationToken);
        await oprot.WriteI32Async((int)ServiceType, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
        if((Base != null) && __isset.@Base)
        {
          tmp220.Name = "Base";
          tmp220.Type = TType.Struct;
          tmp220.ID = 255;
          await oprot.WriteFieldBeginAsync(tmp220, cancellationToken);
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
      if (!(that is AddServiceRequest other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return global::System.Object.Equals(ServiceType, other.ServiceType)
        && ((__isset.@Base == other.__isset.@Base) && ((!__isset.@Base) || (global::System.Object.Equals(Base, other.Base))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        hashcode = (hashcode * 397) + ServiceType.GetHashCode();
        if((Base != null) && __isset.@Base)
        {
          hashcode = (hashcode * 397) + Base.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp221 = new StringBuilder("AddServiceRequest(");
      tmp221.Append(", ServiceType: ");
      ServiceType.ToString(tmp221);
      if((Base != null) && __isset.@Base)
      {
        tmp221.Append(", Base: ");
        Base.ToString(tmp221);
      }
      tmp221.Append(')');
      return tmp221.ToString();
    }
  }

}