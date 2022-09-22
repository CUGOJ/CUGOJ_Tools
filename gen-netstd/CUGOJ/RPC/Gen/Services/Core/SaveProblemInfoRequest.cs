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

  public partial class SaveProblemInfoRequest : TBase
  {
    private global::CUGOJ.RPC.Gen.Base.@Base _Base;

    public global::CUGOJ.RPC.Gen.Common.ProblemStruct Problem { get; set; }

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

    public SaveProblemInfoRequest()
    {
    }

    public SaveProblemInfoRequest(global::CUGOJ.RPC.Gen.Common.ProblemStruct Problem) : this()
    {
      this.Problem = Problem;
    }

    public SaveProblemInfoRequest DeepCopy()
    {
      var tmp77 = new SaveProblemInfoRequest();
      if((Problem != null))
      {
        tmp77.Problem = (global::CUGOJ.RPC.Gen.Common.ProblemStruct)this.Problem.DeepCopy();
      }
      if((Base != null) && __isset.@Base)
      {
        tmp77.Base = (global::CUGOJ.RPC.Gen.Base.@Base)this.Base.DeepCopy();
      }
      tmp77.__isset.@Base = this.__isset.@Base;
      return tmp77;
    }

    public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        bool isset_Problem = false;
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
                Problem = new global::CUGOJ.RPC.Gen.Common.ProblemStruct();
                await Problem.ReadAsync(iprot, cancellationToken);
                isset_Problem = true;
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
        if (!isset_Problem)
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
        var tmp78 = new TStruct("SaveProblemInfoRequest");
        await oprot.WriteStructBeginAsync(tmp78, cancellationToken);
        var tmp79 = new TField();
        if((Problem != null))
        {
          tmp79.Name = "Problem";
          tmp79.Type = TType.Struct;
          tmp79.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp79, cancellationToken);
          await Problem.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Base != null) && __isset.@Base)
        {
          tmp79.Name = "Base";
          tmp79.Type = TType.Struct;
          tmp79.ID = 255;
          await oprot.WriteFieldBeginAsync(tmp79, cancellationToken);
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
      if (!(that is SaveProblemInfoRequest other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return global::System.Object.Equals(Problem, other.Problem)
        && ((__isset.@Base == other.__isset.@Base) && ((!__isset.@Base) || (global::System.Object.Equals(Base, other.Base))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((Problem != null))
        {
          hashcode = (hashcode * 397) + Problem.GetHashCode();
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
      var tmp80 = new StringBuilder("SaveProblemInfoRequest(");
      if((Problem != null))
      {
        tmp80.Append(", Problem: ");
        Problem.ToString(tmp80);
      }
      if((Base != null) && __isset.@Base)
      {
        tmp80.Append(", Base: ");
        Base.ToString(tmp80);
      }
      tmp80.Append(')');
      return tmp80.ToString();
    }
  }

}
