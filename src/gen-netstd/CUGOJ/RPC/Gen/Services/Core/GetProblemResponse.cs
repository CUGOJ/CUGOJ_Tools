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

  public partial class GetProblemResponse : TBase
  {
    private global::CUGOJ.RPC.Gen.Base.BaseResp _BaseResp;

    public global::CUGOJ.RPC.Gen.Common.ProblemStruct Problem { get; set; }

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

    public GetProblemResponse()
    {
    }

    public GetProblemResponse(global::CUGOJ.RPC.Gen.Common.ProblemStruct Problem) : this()
    {
      this.Problem = Problem;
    }

    public GetProblemResponse DeepCopy()
    {
      var tmp48 = new GetProblemResponse();
      if((Problem != null))
      {
        tmp48.Problem = (global::CUGOJ.RPC.Gen.Common.ProblemStruct)this.Problem.DeepCopy();
      }
      if((BaseResp != null) && __isset.BaseResp)
      {
        tmp48.BaseResp = (global::CUGOJ.RPC.Gen.Base.BaseResp)this.BaseResp.DeepCopy();
      }
      tmp48.__isset.BaseResp = this.__isset.BaseResp;
      return tmp48;
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
        var tmp49 = new TStruct("GetProblemResponse");
        await oprot.WriteStructBeginAsync(tmp49, cancellationToken);
        var tmp50 = new TField();
        if((Problem != null))
        {
          tmp50.Name = "Problem";
          tmp50.Type = TType.Struct;
          tmp50.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp50, cancellationToken);
          await Problem.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((BaseResp != null) && __isset.BaseResp)
        {
          tmp50.Name = "BaseResp";
          tmp50.Type = TType.Struct;
          tmp50.ID = 255;
          await oprot.WriteFieldBeginAsync(tmp50, cancellationToken);
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
      if (!(that is GetProblemResponse other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return global::System.Object.Equals(Problem, other.Problem)
        && ((__isset.BaseResp == other.__isset.BaseResp) && ((!__isset.BaseResp) || (global::System.Object.Equals(BaseResp, other.BaseResp))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((Problem != null))
        {
          hashcode = (hashcode * 397) + Problem.GetHashCode();
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
      var tmp51 = new StringBuilder("GetProblemResponse(");
      if((Problem != null))
      {
        tmp51.Append(", Problem: ");
        Problem.ToString(tmp51);
      }
      if((BaseResp != null) && __isset.BaseResp)
      {
        tmp51.Append(", BaseResp: ");
        BaseResp.ToString(tmp51);
      }
      tmp51.Append(')');
      return tmp51.ToString();
    }
  }

}