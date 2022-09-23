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

  public partial class GetSubmissionDetailRequest : TBase
  {

    public long SubmissionID { get; set; }

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

    public GetSubmissionDetailRequest()
    {
    }

    public GetSubmissionDetailRequest(long SubmissionID) : this()
    {
      this.SubmissionID = SubmissionID;
    }

    public GetSubmissionDetailRequest DeepCopy()
    {
      var tmp130 = new GetSubmissionDetailRequest();
      tmp130.SubmissionID = this.SubmissionID;
      if((Base != null) && __isset.@Base)
      {
        tmp130.Base = (global::CUGOJ.RPC.Gen.Base.@Base)this.Base.DeepCopy();
      }
      tmp130.__isset.@Base = this.__isset.@Base;
      return tmp130;
    }

    public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        bool isset_SubmissionID = false;
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
                SubmissionID = await iprot.ReadI64Async(cancellationToken);
                isset_SubmissionID = true;
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
        if (!isset_SubmissionID)
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
        var tmp131 = new TStruct("GetSubmissionDetailRequest");
        await oprot.WriteStructBeginAsync(tmp131, cancellationToken);
        var tmp132 = new TField();
        tmp132.Name = "SubmissionID";
        tmp132.Type = TType.I64;
        tmp132.ID = 1;
        await oprot.WriteFieldBeginAsync(tmp132, cancellationToken);
        await oprot.WriteI64Async(SubmissionID, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
        if((Base != null) && __isset.@Base)
        {
          tmp132.Name = "Base";
          tmp132.Type = TType.Struct;
          tmp132.ID = 255;
          await oprot.WriteFieldBeginAsync(tmp132, cancellationToken);
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
      if (!(that is GetSubmissionDetailRequest other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return global::System.Object.Equals(SubmissionID, other.SubmissionID)
        && ((__isset.@Base == other.__isset.@Base) && ((!__isset.@Base) || (global::System.Object.Equals(Base, other.Base))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        hashcode = (hashcode * 397) + SubmissionID.GetHashCode();
        if((Base != null) && __isset.@Base)
        {
          hashcode = (hashcode * 397) + Base.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp133 = new StringBuilder("GetSubmissionDetailRequest(");
      tmp133.Append(", SubmissionID: ");
      SubmissionID.ToString(tmp133);
      if((Base != null) && __isset.@Base)
      {
        tmp133.Append(", Base: ");
        Base.ToString(tmp133);
      }
      tmp133.Append(')');
      return tmp133.ToString();
    }
  }

}