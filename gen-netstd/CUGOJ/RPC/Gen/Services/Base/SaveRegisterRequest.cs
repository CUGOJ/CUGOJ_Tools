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

  public partial class SaveRegisterRequest : TBase
  {
    private global::CUGOJ.RPC.Gen.Base.@Base _Base;

    public global::CUGOJ.RPC.Gen.Common.RegisterStruct RegisterInfo { get; set; }

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

    public SaveRegisterRequest()
    {
    }

    public SaveRegisterRequest(global::CUGOJ.RPC.Gen.Common.RegisterStruct RegisterInfo) : this()
    {
      this.RegisterInfo = RegisterInfo;
    }

    public SaveRegisterRequest DeepCopy()
    {
      var tmp154 = new SaveRegisterRequest();
      if((RegisterInfo != null))
      {
        tmp154.RegisterInfo = (global::CUGOJ.RPC.Gen.Common.RegisterStruct)this.RegisterInfo.DeepCopy();
      }
      if((Base != null) && __isset.@Base)
      {
        tmp154.Base = (global::CUGOJ.RPC.Gen.Base.@Base)this.Base.DeepCopy();
      }
      tmp154.__isset.@Base = this.__isset.@Base;
      return tmp154;
    }

    public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        bool isset_RegisterInfo = false;
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
              if (field.Type == TType.Struct)
              {
                RegisterInfo = new global::CUGOJ.RPC.Gen.Common.RegisterStruct();
                await RegisterInfo.ReadAsync(iprot, cancellationToken);
                isset_RegisterInfo = true;
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
        if (!isset_RegisterInfo)
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
        var tmp155 = new TStruct("SaveRegisterRequest");
        await oprot.WriteStructBeginAsync(tmp155, cancellationToken);
        var tmp156 = new TField();
        if((RegisterInfo != null))
        {
          tmp156.Name = "RegisterInfo";
          tmp156.Type = TType.Struct;
          tmp156.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp156, cancellationToken);
          await RegisterInfo.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Base != null) && __isset.@Base)
        {
          tmp156.Name = "Base";
          tmp156.Type = TType.Struct;
          tmp156.ID = 255;
          await oprot.WriteFieldBeginAsync(tmp156, cancellationToken);
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
      if (!(that is SaveRegisterRequest other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return global::System.Object.Equals(RegisterInfo, other.RegisterInfo)
        && ((__isset.@Base == other.__isset.@Base) && ((!__isset.@Base) || (global::System.Object.Equals(Base, other.Base))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((RegisterInfo != null))
        {
          hashcode = (hashcode * 397) + RegisterInfo.GetHashCode();
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
      var tmp157 = new StringBuilder("SaveRegisterRequest(");
      if((RegisterInfo != null))
      {
        tmp157.Append(", RegisterInfo: ");
        RegisterInfo.ToString(tmp157);
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