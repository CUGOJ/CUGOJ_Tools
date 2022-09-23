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

  public partial class SaveSubmissionInfoResponse : TBase
  {
    private global::CUGOJ.RPC.Gen.Base.BaseResp _BaseResp;

    public long SubmissionID { get; set; }

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

    public SaveSubmissionInfoResponse()
    {
    }

    public SaveSubmissionInfoResponse(long SubmissionID) : this()
    {
      this.SubmissionID = SubmissionID;
    }

    public SaveSubmissionInfoResponse DeepCopy()
    {
      var tmp145 = new SaveSubmissionInfoResponse();
      tmp145.SubmissionID = this.SubmissionID;
      if((BaseResp != null) && __isset.BaseResp)
      {
        tmp145.BaseResp = (global::CUGOJ.RPC.Gen.Base.BaseResp)this.BaseResp.DeepCopy();
      }
      tmp145.__isset.BaseResp = this.__isset.BaseResp;
      return tmp145;
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
        var tmp146 = new TStruct("SaveSubmissionInfoResponse");
        await oprot.WriteStructBeginAsync(tmp146, cancellationToken);
        var tmp147 = new TField();
        tmp147.Name = "SubmissionID";
        tmp147.Type = TType.I64;
        tmp147.ID = 1;
        await oprot.WriteFieldBeginAsync(tmp147, cancellationToken);
        await oprot.WriteI64Async(SubmissionID, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
        if((BaseResp != null) && __isset.BaseResp)
        {
          tmp147.Name = "BaseResp";
          tmp147.Type = TType.Struct;
          tmp147.ID = 255;
          await oprot.WriteFieldBeginAsync(tmp147, cancellationToken);
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
      if (!(that is SaveSubmissionInfoResponse other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return global::System.Object.Equals(SubmissionID, other.SubmissionID)
        && ((__isset.BaseResp == other.__isset.BaseResp) && ((!__isset.BaseResp) || (global::System.Object.Equals(BaseResp, other.BaseResp))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        hashcode = (hashcode * 397) + SubmissionID.GetHashCode();
        if((BaseResp != null) && __isset.BaseResp)
        {
          hashcode = (hashcode * 397) + BaseResp.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp148 = new StringBuilder("SaveSubmissionInfoResponse(");
      tmp148.Append(", SubmissionID: ");
      SubmissionID.ToString(tmp148);
      if((BaseResp != null) && __isset.BaseResp)
      {
        tmp148.Append(", BaseResp: ");
        BaseResp.ToString(tmp148);
      }
      tmp148.Append(')');
      return tmp148.ToString();
    }
  }

}
