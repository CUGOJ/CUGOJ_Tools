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

  public partial class GetUserDetailResponse : TBase
  {
    private global::CUGOJ.RPC.Gen.Base.BaseResp _BaseResp;

    public global::CUGOJ.RPC.Gen.Common.UserStruct User { get; set; }

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

    public GetUserDetailResponse()
    {
    }

    public GetUserDetailResponse(global::CUGOJ.RPC.Gen.Common.UserStruct User) : this()
    {
      this.User = User;
    }

    public GetUserDetailResponse DeepCopy()
    {
      var tmp101 = new GetUserDetailResponse();
      if((User != null))
      {
        tmp101.User = (global::CUGOJ.RPC.Gen.Common.UserStruct)this.User.DeepCopy();
      }
      if((BaseResp != null) && __isset.BaseResp)
      {
        tmp101.BaseResp = (global::CUGOJ.RPC.Gen.Base.BaseResp)this.BaseResp.DeepCopy();
      }
      tmp101.__isset.BaseResp = this.__isset.BaseResp;
      return tmp101;
    }

    public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        bool isset_User = false;
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
                User = new global::CUGOJ.RPC.Gen.Common.UserStruct();
                await User.ReadAsync(iprot, cancellationToken);
                isset_User = true;
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
        if (!isset_User)
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
        var tmp102 = new TStruct("GetUserDetailResponse");
        await oprot.WriteStructBeginAsync(tmp102, cancellationToken);
        var tmp103 = new TField();
        if((User != null))
        {
          tmp103.Name = "User";
          tmp103.Type = TType.Struct;
          tmp103.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp103, cancellationToken);
          await User.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((BaseResp != null) && __isset.BaseResp)
        {
          tmp103.Name = "BaseResp";
          tmp103.Type = TType.Struct;
          tmp103.ID = 255;
          await oprot.WriteFieldBeginAsync(tmp103, cancellationToken);
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
      if (!(that is GetUserDetailResponse other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return global::System.Object.Equals(User, other.User)
        && ((__isset.BaseResp == other.__isset.BaseResp) && ((!__isset.BaseResp) || (global::System.Object.Equals(BaseResp, other.BaseResp))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((User != null))
        {
          hashcode = (hashcode * 397) + User.GetHashCode();
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
      var tmp104 = new StringBuilder("GetUserDetailResponse(");
      if((User != null))
      {
        tmp104.Append(", User: ");
        User.ToString(tmp104);
      }
      if((BaseResp != null) && __isset.BaseResp)
      {
        tmp104.Append(", BaseResp: ");
        BaseResp.ToString(tmp104);
      }
      tmp104.Append(')');
      return tmp104.ToString();
    }
  }

}
