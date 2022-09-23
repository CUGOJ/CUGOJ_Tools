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

  public partial class GetRegisterRequest : TBase
  {

    public long ContestID { get; set; }

    public long UserID { get; set; }

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

    public GetRegisterRequest()
    {
    }

    public GetRegisterRequest(long ContestID, long UserID) : this()
    {
      this.ContestID = ContestID;
      this.UserID = UserID;
    }

    public GetRegisterRequest DeepCopy()
    {
      var tmp174 = new GetRegisterRequest();
      tmp174.ContestID = this.ContestID;
      tmp174.UserID = this.UserID;
      if((Base != null) && __isset.@Base)
      {
        tmp174.Base = (global::CUGOJ.RPC.Gen.Base.@Base)this.Base.DeepCopy();
      }
      tmp174.__isset.@Base = this.__isset.@Base;
      return tmp174;
    }

    public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        bool isset_ContestID = false;
        bool isset_UserID = false;
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
              if (field.Type == TType.I64)
              {
                ContestID = await iprot.ReadI64Async(cancellationToken);
                isset_ContestID = true;
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.I64)
              {
                UserID = await iprot.ReadI64Async(cancellationToken);
                isset_UserID = true;
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
        if (!isset_ContestID)
        {
          throw new TProtocolException(TProtocolException.INVALID_DATA);
        }
        if (!isset_UserID)
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
        var tmp175 = new TStruct("GetRegisterRequest");
        await oprot.WriteStructBeginAsync(tmp175, cancellationToken);
        var tmp176 = new TField();
        tmp176.Name = "ContestID";
        tmp176.Type = TType.I64;
        tmp176.ID = 1;
        await oprot.WriteFieldBeginAsync(tmp176, cancellationToken);
        await oprot.WriteI64Async(ContestID, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
        tmp176.Name = "UserID";
        tmp176.Type = TType.I64;
        tmp176.ID = 2;
        await oprot.WriteFieldBeginAsync(tmp176, cancellationToken);
        await oprot.WriteI64Async(UserID, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
        if((Base != null) && __isset.@Base)
        {
          tmp176.Name = "Base";
          tmp176.Type = TType.Struct;
          tmp176.ID = 255;
          await oprot.WriteFieldBeginAsync(tmp176, cancellationToken);
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
      if (!(that is GetRegisterRequest other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return global::System.Object.Equals(ContestID, other.ContestID)
        && global::System.Object.Equals(UserID, other.UserID)
        && ((__isset.@Base == other.__isset.@Base) && ((!__isset.@Base) || (global::System.Object.Equals(Base, other.Base))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        hashcode = (hashcode * 397) + ContestID.GetHashCode();
        hashcode = (hashcode * 397) + UserID.GetHashCode();
        if((Base != null) && __isset.@Base)
        {
          hashcode = (hashcode * 397) + Base.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp177 = new StringBuilder("GetRegisterRequest(");
      tmp177.Append(", ContestID: ");
      ContestID.ToString(tmp177);
      tmp177.Append(", UserID: ");
      UserID.ToString(tmp177);
      if((Base != null) && __isset.@Base)
      {
        tmp177.Append(", Base: ");
        Base.ToString(tmp177);
      }
      tmp177.Append(')');
      return tmp177.ToString();
    }
  }

}