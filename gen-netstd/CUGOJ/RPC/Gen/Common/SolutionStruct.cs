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

  public partial class SolutionStruct : TBase
  {
    private long _ID;
    private global::CUGOJ.RPC.Gen.Common.UserStruct _Writer;
    private global::CUGOJ.RPC.Gen.Common.ContestStruct _Contest;
    private global::CUGOJ.RPC.Gen.Common.ProblemStruct _Problem;
    private string _Content;
    private long _CreateTime;
    private long _UpdateTime;

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

    public global::CUGOJ.RPC.Gen.Common.UserStruct Writer
    {
      get
      {
        return _Writer;
      }
      set
      {
        __isset.Writer = true;
        this._Writer = value;
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

    public string Content
    {
      get
      {
        return _Content;
      }
      set
      {
        __isset.Content = true;
        this._Content = value;
      }
    }

    public long CreateTime
    {
      get
      {
        return _CreateTime;
      }
      set
      {
        __isset.CreateTime = true;
        this._CreateTime = value;
      }
    }

    public long UpdateTime
    {
      get
      {
        return _UpdateTime;
      }
      set
      {
        __isset.UpdateTime = true;
        this._UpdateTime = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool ID;
      public bool Writer;
      public bool Contest;
      public bool Problem;
      public bool Content;
      public bool CreateTime;
      public bool UpdateTime;
    }

    public SolutionStruct()
    {
    }

    public SolutionStruct DeepCopy()
    {
      var tmp74 = new SolutionStruct();
      if(__isset.ID)
      {
        tmp74.ID = this.ID;
      }
      tmp74.__isset.ID = this.__isset.ID;
      if((Writer != null) && __isset.Writer)
      {
        tmp74.Writer = (global::CUGOJ.RPC.Gen.Common.UserStruct)this.Writer.DeepCopy();
      }
      tmp74.__isset.Writer = this.__isset.Writer;
      if((Contest != null) && __isset.Contest)
      {
        tmp74.Contest = (global::CUGOJ.RPC.Gen.Common.ContestStruct)this.Contest.DeepCopy();
      }
      tmp74.__isset.Contest = this.__isset.Contest;
      if((Problem != null) && __isset.Problem)
      {
        tmp74.Problem = (global::CUGOJ.RPC.Gen.Common.ProblemStruct)this.Problem.DeepCopy();
      }
      tmp74.__isset.Problem = this.__isset.Problem;
      if((Content != null) && __isset.Content)
      {
        tmp74.Content = this.Content;
      }
      tmp74.__isset.Content = this.__isset.Content;
      if(__isset.CreateTime)
      {
        tmp74.CreateTime = this.CreateTime;
      }
      tmp74.__isset.CreateTime = this.__isset.CreateTime;
      if(__isset.UpdateTime)
      {
        tmp74.UpdateTime = this.UpdateTime;
      }
      tmp74.__isset.UpdateTime = this.__isset.UpdateTime;
      return tmp74;
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
                Writer = new global::CUGOJ.RPC.Gen.Common.UserStruct();
                await Writer.ReadAsync(iprot, cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 3:
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
            case 4:
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
            case 5:
              if (field.Type == TType.String)
              {
                Content = await iprot.ReadStringAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 6:
              if (field.Type == TType.I64)
              {
                CreateTime = await iprot.ReadI64Async(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 7:
              if (field.Type == TType.I64)
              {
                UpdateTime = await iprot.ReadI64Async(cancellationToken);
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
        var tmp75 = new TStruct("SolutionStruct");
        await oprot.WriteStructBeginAsync(tmp75, cancellationToken);
        var tmp76 = new TField();
        if(__isset.ID)
        {
          tmp76.Name = "ID";
          tmp76.Type = TType.I64;
          tmp76.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp76, cancellationToken);
          await oprot.WriteI64Async(ID, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Writer != null) && __isset.Writer)
        {
          tmp76.Name = "Writer";
          tmp76.Type = TType.Struct;
          tmp76.ID = 2;
          await oprot.WriteFieldBeginAsync(tmp76, cancellationToken);
          await Writer.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Contest != null) && __isset.Contest)
        {
          tmp76.Name = "Contest";
          tmp76.Type = TType.Struct;
          tmp76.ID = 3;
          await oprot.WriteFieldBeginAsync(tmp76, cancellationToken);
          await Contest.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Problem != null) && __isset.Problem)
        {
          tmp76.Name = "Problem";
          tmp76.Type = TType.Struct;
          tmp76.ID = 4;
          await oprot.WriteFieldBeginAsync(tmp76, cancellationToken);
          await Problem.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Content != null) && __isset.Content)
        {
          tmp76.Name = "Content";
          tmp76.Type = TType.String;
          tmp76.ID = 5;
          await oprot.WriteFieldBeginAsync(tmp76, cancellationToken);
          await oprot.WriteStringAsync(Content, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.CreateTime)
        {
          tmp76.Name = "CreateTime";
          tmp76.Type = TType.I64;
          tmp76.ID = 6;
          await oprot.WriteFieldBeginAsync(tmp76, cancellationToken);
          await oprot.WriteI64Async(CreateTime, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.UpdateTime)
        {
          tmp76.Name = "UpdateTime";
          tmp76.Type = TType.I64;
          tmp76.ID = 7;
          await oprot.WriteFieldBeginAsync(tmp76, cancellationToken);
          await oprot.WriteI64Async(UpdateTime, cancellationToken);
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
      if (!(that is SolutionStruct other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.ID == other.__isset.ID) && ((!__isset.ID) || (global::System.Object.Equals(ID, other.ID))))
        && ((__isset.Writer == other.__isset.Writer) && ((!__isset.Writer) || (global::System.Object.Equals(Writer, other.Writer))))
        && ((__isset.Contest == other.__isset.Contest) && ((!__isset.Contest) || (global::System.Object.Equals(Contest, other.Contest))))
        && ((__isset.Problem == other.__isset.Problem) && ((!__isset.Problem) || (global::System.Object.Equals(Problem, other.Problem))))
        && ((__isset.Content == other.__isset.Content) && ((!__isset.Content) || (global::System.Object.Equals(Content, other.Content))))
        && ((__isset.CreateTime == other.__isset.CreateTime) && ((!__isset.CreateTime) || (global::System.Object.Equals(CreateTime, other.CreateTime))))
        && ((__isset.UpdateTime == other.__isset.UpdateTime) && ((!__isset.UpdateTime) || (global::System.Object.Equals(UpdateTime, other.UpdateTime))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if(__isset.ID)
        {
          hashcode = (hashcode * 397) + ID.GetHashCode();
        }
        if((Writer != null) && __isset.Writer)
        {
          hashcode = (hashcode * 397) + Writer.GetHashCode();
        }
        if((Contest != null) && __isset.Contest)
        {
          hashcode = (hashcode * 397) + Contest.GetHashCode();
        }
        if((Problem != null) && __isset.Problem)
        {
          hashcode = (hashcode * 397) + Problem.GetHashCode();
        }
        if((Content != null) && __isset.Content)
        {
          hashcode = (hashcode * 397) + Content.GetHashCode();
        }
        if(__isset.CreateTime)
        {
          hashcode = (hashcode * 397) + CreateTime.GetHashCode();
        }
        if(__isset.UpdateTime)
        {
          hashcode = (hashcode * 397) + UpdateTime.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp77 = new StringBuilder("SolutionStruct(");
      int tmp78 = 0;
      if(__isset.ID)
      {
        if(0 < tmp78++) { tmp77.Append(", "); }
        tmp77.Append("ID: ");
        ID.ToString(tmp77);
      }
      if((Writer != null) && __isset.Writer)
      {
        if(0 < tmp78++) { tmp77.Append(", "); }
        tmp77.Append("Writer: ");
        Writer.ToString(tmp77);
      }
      if((Contest != null) && __isset.Contest)
      {
        if(0 < tmp78++) { tmp77.Append(", "); }
        tmp77.Append("Contest: ");
        Contest.ToString(tmp77);
      }
      if((Problem != null) && __isset.Problem)
      {
        if(0 < tmp78++) { tmp77.Append(", "); }
        tmp77.Append("Problem: ");
        Problem.ToString(tmp77);
      }
      if((Content != null) && __isset.Content)
      {
        if(0 < tmp78++) { tmp77.Append(", "); }
        tmp77.Append("Content: ");
        Content.ToString(tmp77);
      }
      if(__isset.CreateTime)
      {
        if(0 < tmp78++) { tmp77.Append(", "); }
        tmp77.Append("CreateTime: ");
        CreateTime.ToString(tmp77);
      }
      if(__isset.UpdateTime)
      {
        if(0 < tmp78++) { tmp77.Append(", "); }
        tmp77.Append("UpdateTime: ");
        UpdateTime.ToString(tmp77);
      }
      tmp77.Append(')');
      return tmp77.ToString();
    }
  }

}
