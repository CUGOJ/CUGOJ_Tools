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

namespace CUGOJ.RPC.Gen.Services.Authentication
{

  public partial class LoginRequest : TBase
  {
    private global::CUGOJ.RPC.Gen.Common.UserLoginInfoStruct _UserLoginInfo;

    public global::CUGOJ.RPC.Gen.Common.UserLoginInfoStruct UserLoginInfo
    {
      get
      {
        return _UserLoginInfo;
      }
      set
      {
        __isset.UserLoginInfo = true;
        this._UserLoginInfo = value;
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
      public bool UserLoginInfo;
      public bool @Base;
    }

    public LoginRequest()
    {
    }

    public LoginRequest DeepCopy()
    {
      var tmp0 = new LoginRequest();
      if((UserLoginInfo != null) && __isset.UserLoginInfo)
      {
        tmp0.UserLoginInfo = (global::CUGOJ.RPC.Gen.Common.UserLoginInfoStruct)this.UserLoginInfo.DeepCopy();
      }
      tmp0.__isset.UserLoginInfo = this.__isset.UserLoginInfo;
      if((Base != null) && __isset.@Base)
      {
        tmp0.Base = (global::CUGOJ.RPC.Gen.Base.@Base)this.Base.DeepCopy();
      }
      tmp0.__isset.@Base = this.__isset.@Base;
      return tmp0;
    }

    public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
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
                UserLoginInfo = new global::CUGOJ.RPC.Gen.Common.UserLoginInfoStruct();
                await UserLoginInfo.ReadAsync(iprot, cancellationToken);
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
        var tmp1 = new TStruct("LoginRequest");
        await oprot.WriteStructBeginAsync(tmp1, cancellationToken);
        var tmp2 = new TField();
        if((UserLoginInfo != null) && __isset.UserLoginInfo)
        {
          tmp2.Name = "UserLoginInfo";
          tmp2.Type = TType.Struct;
          tmp2.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp2, cancellationToken);
          await UserLoginInfo.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Base != null) && __isset.@Base)
        {
          tmp2.Name = "Base";
          tmp2.Type = TType.Struct;
          tmp2.ID = 255;
          await oprot.WriteFieldBeginAsync(tmp2, cancellationToken);
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
      if (!(that is LoginRequest other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.UserLoginInfo == other.__isset.UserLoginInfo) && ((!__isset.UserLoginInfo) || (global::System.Object.Equals(UserLoginInfo, other.UserLoginInfo))))
        && ((__isset.@Base == other.__isset.@Base) && ((!__isset.@Base) || (global::System.Object.Equals(Base, other.Base))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((UserLoginInfo != null) && __isset.UserLoginInfo)
        {
          hashcode = (hashcode * 397) + UserLoginInfo.GetHashCode();
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
      var tmp3 = new StringBuilder("LoginRequest(");
      int tmp4 = 0;
      if((UserLoginInfo != null) && __isset.UserLoginInfo)
      {
        if(0 < tmp4++) { tmp3.Append(", "); }
        tmp3.Append("UserLoginInfo: ");
        UserLoginInfo.ToString(tmp3);
      }
      if((Base != null) && __isset.@Base)
      {
        if(0 < tmp4++) { tmp3.Append(", "); }
        tmp3.Append("Base: ");
        Base.ToString(tmp3);
      }
      tmp3.Append(')');
      return tmp3.ToString();
    }
  }

}