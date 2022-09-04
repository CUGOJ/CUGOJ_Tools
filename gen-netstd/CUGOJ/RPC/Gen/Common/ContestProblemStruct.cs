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

namespace CUGOJ.RPC.Gen.Common
{

  public partial class ContestProblemStruct : TBase
  {
    private long _ID;
    private global::CUGOJ.RPC.Gen.Common.ContestStruct _Contest;
    private global::CUGOJ.RPC.Gen.Common.ProblemStruct _Problem;
    private long _SubmissionCount;
    private long _AcceptedCount;
    private long _Version;
    private string _Properties;

    public long ID
    {
      get
      {
        return _ID;
      }
      set
      {
        __isset.ID = true;
        this._ID = value;
      }
    }

    public global::CUGOJ.RPC.Gen.Common.ContestStruct Contest
    {
      get
      {
        return _Contest;
      }
      set
      {
        __isset.Contest = true;
        this._Contest = value;
      }
    }

    public global::CUGOJ.RPC.Gen.Common.ProblemStruct Problem
    {
      get
      {
        return _Problem;
      }
      set
      {
        __isset.Problem = true;
        this._Problem = value;
      }
    }

    public long SubmissionCount
    {
      get
      {
        return _SubmissionCount;
      }
      set
      {
        __isset.SubmissionCount = true;
        this._SubmissionCount = value;
      }
    }

    public long AcceptedCount
    {
      get
      {
        return _AcceptedCount;
      }
      set
      {
        __isset.AcceptedCount = true;
        this._AcceptedCount = value;
      }
    }

    public long Version
    {
      get
      {
        return _Version;
      }
      set
      {
        __isset.Version = true;
        this._Version = value;
      }
    }

    public string Properties
    {
      get
      {
        return _Properties;
      }
      set
      {
        __isset.Properties = true;
        this._Properties = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool ID;
      public bool Contest;
      public bool Problem;
      public bool SubmissionCount;
      public bool AcceptedCount;
      public bool Version;
      public bool Properties;
    }

    public ContestProblemStruct()
    {
    }

    public ContestProblemStruct DeepCopy()
    {
      var tmp64 = new ContestProblemStruct();
      if(__isset.ID)
      {
        tmp64.ID = this.ID;
      }
      tmp64.__isset.ID = this.__isset.ID;
      if((Contest != null) && __isset.Contest)
      {
        tmp64.Contest = (global::CUGOJ.RPC.Gen.Common.ContestStruct)this.Contest.DeepCopy();
      }
      tmp64.__isset.Contest = this.__isset.Contest;
      if((Problem != null) && __isset.Problem)
      {
        tmp64.Problem = (global::CUGOJ.RPC.Gen.Common.ProblemStruct)this.Problem.DeepCopy();
      }
      tmp64.__isset.Problem = this.__isset.Problem;
      if(__isset.SubmissionCount)
      {
        tmp64.SubmissionCount = this.SubmissionCount;
      }
      tmp64.__isset.SubmissionCount = this.__isset.SubmissionCount;
      if(__isset.AcceptedCount)
      {
        tmp64.AcceptedCount = this.AcceptedCount;
      }
      tmp64.__isset.AcceptedCount = this.__isset.AcceptedCount;
      if(__isset.Version)
      {
        tmp64.Version = this.Version;
      }
      tmp64.__isset.Version = this.__isset.Version;
      if((Properties != null) && __isset.Properties)
      {
        tmp64.Properties = this.Properties;
      }
      tmp64.__isset.Properties = this.__isset.Properties;
      return tmp64;
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
              if (field.Type == TType.I64)
              {
                ID = await iprot.ReadI64Async(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.Struct)
              {
                Contest = new global::CUGOJ.RPC.Gen.Common.ContestStruct();
                await Contest.ReadAsync(iprot, cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 3:
              if (field.Type == TType.Struct)
              {
                Problem = new global::CUGOJ.RPC.Gen.Common.ProblemStruct();
                await Problem.ReadAsync(iprot, cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 4:
              if (field.Type == TType.I64)
              {
                SubmissionCount = await iprot.ReadI64Async(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 5:
              if (field.Type == TType.I64)
              {
                AcceptedCount = await iprot.ReadI64Async(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 6:
              if (field.Type == TType.I64)
              {
                Version = await iprot.ReadI64Async(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 7:
              if (field.Type == TType.String)
              {
                Properties = await iprot.ReadStringAsync(cancellationToken);
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
        var tmp65 = new TStruct("ContestProblemStruct");
        await oprot.WriteStructBeginAsync(tmp65, cancellationToken);
        var tmp66 = new TField();
        if(__isset.ID)
        {
          tmp66.Name = "ID";
          tmp66.Type = TType.I64;
          tmp66.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp66, cancellationToken);
          await oprot.WriteI64Async(ID, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Contest != null) && __isset.Contest)
        {
          tmp66.Name = "Contest";
          tmp66.Type = TType.Struct;
          tmp66.ID = 2;
          await oprot.WriteFieldBeginAsync(tmp66, cancellationToken);
          await Contest.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Problem != null) && __isset.Problem)
        {
          tmp66.Name = "Problem";
          tmp66.Type = TType.Struct;
          tmp66.ID = 3;
          await oprot.WriteFieldBeginAsync(tmp66, cancellationToken);
          await Problem.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.SubmissionCount)
        {
          tmp66.Name = "SubmissionCount";
          tmp66.Type = TType.I64;
          tmp66.ID = 4;
          await oprot.WriteFieldBeginAsync(tmp66, cancellationToken);
          await oprot.WriteI64Async(SubmissionCount, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.AcceptedCount)
        {
          tmp66.Name = "AcceptedCount";
          tmp66.Type = TType.I64;
          tmp66.ID = 5;
          await oprot.WriteFieldBeginAsync(tmp66, cancellationToken);
          await oprot.WriteI64Async(AcceptedCount, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.Version)
        {
          tmp66.Name = "Version";
          tmp66.Type = TType.I64;
          tmp66.ID = 6;
          await oprot.WriteFieldBeginAsync(tmp66, cancellationToken);
          await oprot.WriteI64Async(Version, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Properties != null) && __isset.Properties)
        {
          tmp66.Name = "Properties";
          tmp66.Type = TType.String;
          tmp66.ID = 7;
          await oprot.WriteFieldBeginAsync(tmp66, cancellationToken);
          await oprot.WriteStringAsync(Properties, cancellationToken);
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
      if (!(that is ContestProblemStruct other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.ID == other.__isset.ID) && ((!__isset.ID) || (global::System.Object.Equals(ID, other.ID))))
        && ((__isset.Contest == other.__isset.Contest) && ((!__isset.Contest) || (global::System.Object.Equals(Contest, other.Contest))))
        && ((__isset.Problem == other.__isset.Problem) && ((!__isset.Problem) || (global::System.Object.Equals(Problem, other.Problem))))
        && ((__isset.SubmissionCount == other.__isset.SubmissionCount) && ((!__isset.SubmissionCount) || (global::System.Object.Equals(SubmissionCount, other.SubmissionCount))))
        && ((__isset.AcceptedCount == other.__isset.AcceptedCount) && ((!__isset.AcceptedCount) || (global::System.Object.Equals(AcceptedCount, other.AcceptedCount))))
        && ((__isset.Version == other.__isset.Version) && ((!__isset.Version) || (global::System.Object.Equals(Version, other.Version))))
        && ((__isset.Properties == other.__isset.Properties) && ((!__isset.Properties) || (global::System.Object.Equals(Properties, other.Properties))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if(__isset.ID)
        {
          hashcode = (hashcode * 397) + ID.GetHashCode();
        }
        if((Contest != null) && __isset.Contest)
        {
          hashcode = (hashcode * 397) + Contest.GetHashCode();
        }
        if((Problem != null) && __isset.Problem)
        {
          hashcode = (hashcode * 397) + Problem.GetHashCode();
        }
        if(__isset.SubmissionCount)
        {
          hashcode = (hashcode * 397) + SubmissionCount.GetHashCode();
        }
        if(__isset.AcceptedCount)
        {
          hashcode = (hashcode * 397) + AcceptedCount.GetHashCode();
        }
        if(__isset.Version)
        {
          hashcode = (hashcode * 397) + Version.GetHashCode();
        }
        if((Properties != null) && __isset.Properties)
        {
          hashcode = (hashcode * 397) + Properties.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp67 = new StringBuilder("ContestProblemStruct(");
      int tmp68 = 0;
      if(__isset.ID)
      {
        if(0 < tmp68++) { tmp67.Append(", "); }
        tmp67.Append("ID: ");
        ID.ToString(tmp67);
      }
      if((Contest != null) && __isset.Contest)
      {
        if(0 < tmp68++) { tmp67.Append(", "); }
        tmp67.Append("Contest: ");
        Contest.ToString(tmp67);
      }
      if((Problem != null) && __isset.Problem)
      {
        if(0 < tmp68++) { tmp67.Append(", "); }
        tmp67.Append("Problem: ");
        Problem.ToString(tmp67);
      }
      if(__isset.SubmissionCount)
      {
        if(0 < tmp68++) { tmp67.Append(", "); }
        tmp67.Append("SubmissionCount: ");
        SubmissionCount.ToString(tmp67);
      }
      if(__isset.AcceptedCount)
      {
        if(0 < tmp68++) { tmp67.Append(", "); }
        tmp67.Append("AcceptedCount: ");
        AcceptedCount.ToString(tmp67);
      }
      if(__isset.Version)
      {
        if(0 < tmp68++) { tmp67.Append(", "); }
        tmp67.Append("Version: ");
        Version.ToString(tmp67);
      }
      if((Properties != null) && __isset.Properties)
      {
        if(0 < tmp68++) { tmp67.Append(", "); }
        tmp67.Append("Properties: ");
        Properties.ToString(tmp67);
      }
      tmp67.Append(')');
      return tmp67.ToString();
    }
  }

}
