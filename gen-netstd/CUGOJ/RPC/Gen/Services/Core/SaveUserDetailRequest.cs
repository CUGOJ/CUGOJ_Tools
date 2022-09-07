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

  public partial class SaveUserDetailRequest : TBase
  {
    private global::CUGOJ.RPC.Gen.Base.@Base _Base;

    public global::CUGOJ.RPC.Gen.Common.UserStruct User { get; set; }

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

    public SaveUserDetailRequest()
    {
    }

    public SaveUserDetailRequest(global::CUGOJ.RPC.Gen.Common.UserStruct User) : this()
    {
      this.User = User;
    }

    public SaveUserDetailRequest DeepCopy()
    {
      var tmp106 = new SaveUserDetailRequest();
      if((User != null))
      {
        tmp106.User = (global::CUGOJ.RPC.Gen.Common.UserStruct)this.User.DeepCopy();
      }
      if((Base != null) && __isset.@Base)
      {
        tmp106.Base = (global::CUGOJ.RPC.Gen.Base.@Base)this.Base.DeepCopy();
      }
      tmp106.__isset.@Base = this.__isset.@Base;
      return tmp106;
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
        var tmp107 = new TStruct("SaveUserDetailRequest");
        await oprot.WriteStructBeginAsync(tmp107, cancellationToken);
        var tmp108 = new TField();
        if((User != null))
        {
          tmp108.Name = "User";
          tmp108.Type = TType.Struct;
          tmp108.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp108, cancellationToken);
          await User.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Base != null) && __isset.@Base)
        {
          tmp108.Name = "Base";
          tmp108.Type = TType.Struct;
          tmp108.ID = 255;
          await oprot.WriteFieldBeginAsync(tmp108, cancellationToken);
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
      if (!(that is SaveUserDetailRequest other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return global::System.Object.Equals(User, other.User)
        && ((__isset.@Base == other.__isset.@Base) && ((!__isset.@Base) || (global::System.Object.Equals(Base, other.Base))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((User != null))
        {
          hashcode = (hashcode * 397) + User.GetHashCode();
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
      var tmp109 = new StringBuilder("SaveUserDetailRequest(");
      if((User != null))
      {
        tmp109.Append(", User: ");
        User.ToString(tmp109);
      }
      if((Base != null) && __isset.@Base)
      {
        tmp109.Append(", Base: ");
        Base.ToString(tmp109);
      }
      tmp109.Append(')');
      return tmp109.ToString();
    }
  }

}