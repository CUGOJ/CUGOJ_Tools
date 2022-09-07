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

  public partial class SubmitProblemRequest : TBase
  {
    private global::CUGOJ.RPC.Gen.Base.@Base _Base;

    public global::CUGOJ.RPC.Gen.Common.SubmissionStruct Submission { get; set; }

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

    public SubmitProblemRequest()
    {
    }

    public SubmitProblemRequest(global::CUGOJ.RPC.Gen.Common.SubmissionStruct Submission) : this()
    {
      this.Submission = Submission;
    }

    public SubmitProblemRequest DeepCopy()
    {
      var tmp131 = new SubmitProblemRequest();
      if((Submission != null))
      {
        tmp131.Submission = (global::CUGOJ.RPC.Gen.Common.SubmissionStruct)this.Submission.DeepCopy();
      }
      if((Base != null) && __isset.@Base)
      {
        tmp131.Base = (global::CUGOJ.RPC.Gen.Base.@Base)this.Base.DeepCopy();
      }
      tmp131.__isset.@Base = this.__isset.@Base;
      return tmp131;
    }

    public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        bool isset_Submission = false;
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
                Submission = new global::CUGOJ.RPC.Gen.Common.SubmissionStruct();
                await Submission.ReadAsync(iprot, cancellationToken);
                isset_Submission = true;
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
        if (!isset_Submission)
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
        var tmp132 = new TStruct("SubmitProblemRequest");
        await oprot.WriteStructBeginAsync(tmp132, cancellationToken);
        var tmp133 = new TField();
        if((Submission != null))
        {
          tmp133.Name = "Submission";
          tmp133.Type = TType.Struct;
          tmp133.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp133, cancellationToken);
          await Submission.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Base != null) && __isset.@Base)
        {
          tmp133.Name = "Base";
          tmp133.Type = TType.Struct;
          tmp133.ID = 255;
          await oprot.WriteFieldBeginAsync(tmp133, cancellationToken);
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
      if (!(that is SubmitProblemRequest other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return global::System.Object.Equals(Submission, other.Submission)
        && ((__isset.@Base == other.__isset.@Base) && ((!__isset.@Base) || (global::System.Object.Equals(Base, other.Base))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((Submission != null))
        {
          hashcode = (hashcode * 397) + Submission.GetHashCode();
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
      var tmp134 = new StringBuilder("SubmitProblemRequest(");
      if((Submission != null))
      {
        tmp134.Append(", Submission: ");
        Submission.ToString(tmp134);
      }
      if((Base != null) && __isset.@Base)
      {
        tmp134.Append(", Base: ");
        Base.ToString(tmp134);
      }
      tmp134.Append(')');
      return tmp134.ToString();
    }
  }

}
