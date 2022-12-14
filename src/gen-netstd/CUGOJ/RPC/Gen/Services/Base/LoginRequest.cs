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

  public partial class LoginRequest : TBase
  {

    public string UserName { get; set; }

    public string Password { get; set; }

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

    public LoginRequest()
    {
    }

    public LoginRequest(string UserName, string Password) : this()
    {
      this.UserName = UserName;
      this.Password = Password;
    }

    public LoginRequest DeepCopy()
    {
      var tmp28 = new LoginRequest();
      if((UserName != null))
      {
        tmp28.UserName = this.UserName;
      }
      if((Password != null))
      {
        tmp28.Password = this.Password;
      }
      if((Base != null) && __isset.@Base)
      {
        tmp28.Base = (global::CUGOJ.RPC.Gen.Base.@Base)this.Base.DeepCopy();
      }
      tmp28.__isset.@Base = this.__isset.@Base;
      return tmp28;
    }

    public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        bool isset_UserName = false;
        bool isset_Password = false;
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
              if (field.Type == TType.String)
              {
                UserName = await iprot.ReadStringAsync(cancellationToken);
                isset_UserName = true;
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.String)
              {
                Password = await iprot.ReadStringAsync(cancellationToken);
                isset_Password = true;
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
        if (!isset_UserName)
        {
          throw new TProtocolException(TProtocolException.INVALID_DATA);
        }
        if (!isset_Password)
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
        var tmp29 = new TStruct("LoginRequest");
        await oprot.WriteStructBeginAsync(tmp29, cancellationToken);
        var tmp30 = new TField();
        if((UserName != null))
        {
          tmp30.Name = "UserName";
          tmp30.Type = TType.String;
          tmp30.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp30, cancellationToken);
          await oprot.WriteStringAsync(UserName, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Password != null))
        {
          tmp30.Name = "Password";
          tmp30.Type = TType.String;
          tmp30.ID = 2;
          await oprot.WriteFieldBeginAsync(tmp30, cancellationToken);
          await oprot.WriteStringAsync(Password, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Base != null) && __isset.@Base)
        {
          tmp30.Name = "Base";
          tmp30.Type = TType.Struct;
          tmp30.ID = 255;
          await oprot.WriteFieldBeginAsync(tmp30, cancellationToken);
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
      return global::System.Object.Equals(UserName, other.UserName)
        && global::System.Object.Equals(Password, other.Password)
        && ((__isset.@Base == other.__isset.@Base) && ((!__isset.@Base) || (global::System.Object.Equals(Base, other.Base))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((UserName != null))
        {
          hashcode = (hashcode * 397) + UserName.GetHashCode();
        }
        if((Password != null))
        {
          hashcode = (hashcode * 397) + Password.GetHashCode();
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
      var tmp31 = new StringBuilder("LoginRequest(");
      if((UserName != null))
      {
        tmp31.Append(", UserName: ");
        UserName.ToString(tmp31);
      }
      if((Password != null))
      {
        tmp31.Append(", Password: ");
        Password.ToString(tmp31);
      }
      if((Base != null) && __isset.@Base)
      {
        tmp31.Append(", Base: ");
        Base.ToString(tmp31);
      }
      tmp31.Append(')');
      return tmp31.ToString();
    }
  }

}