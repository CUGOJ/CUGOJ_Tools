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

  public partial class SaveContestInfoRequest : TBase
  {

    public global::CUGOJ.RPC.Gen.Common.ContestStruct Contest { get; set; }

    public List<global::CUGOJ.RPC.Gen.Common.ProblemStruct> Problems { get; set; }

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

    public SaveContestInfoRequest()
    {
    }

    public SaveContestInfoRequest(global::CUGOJ.RPC.Gen.Common.ContestStruct Contest, List<global::CUGOJ.RPC.Gen.Common.ProblemStruct> Problems) : this()
    {
      this.Contest = Contest;
      this.Problems = Problems;
    }

    public SaveContestInfoRequest DeepCopy()
    {
      var tmp87 = new SaveContestInfoRequest();
      if((Contest != null))
      {
        tmp87.Contest = (global::CUGOJ.RPC.Gen.Common.ContestStruct)this.Contest.DeepCopy();
      }
      if((Problems != null))
      {
        tmp87.Problems = this.Problems.DeepCopy();
      }
      if((Base != null) && __isset.@Base)
      {
        tmp87.Base = (global::CUGOJ.RPC.Gen.Base.@Base)this.Base.DeepCopy();
      }
      tmp87.__isset.@Base = this.__isset.@Base;
      return tmp87;
    }

    public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        bool isset_Contest = false;
        bool isset_Problems = false;
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
                Contest = new global::CUGOJ.RPC.Gen.Common.ContestStruct();
                await Contest.ReadAsync(iprot, cancellationToken);
                isset_Contest = true;
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.List)
              {
                {
                  TList _list88 = await iprot.ReadListBeginAsync(cancellationToken);
                  Problems = new List<global::CUGOJ.RPC.Gen.Common.ProblemStruct>(_list88.Count);
                  for(int _i89 = 0; _i89 < _list88.Count; ++_i89)
                  {
                    global::CUGOJ.RPC.Gen.Common.ProblemStruct _elem90;
                    _elem90 = new global::CUGOJ.RPC.Gen.Common.ProblemStruct();
                    await _elem90.ReadAsync(iprot, cancellationToken);
                    Problems.Add(_elem90);
                  }
                  await iprot.ReadListEndAsync(cancellationToken);
                }
                isset_Problems = true;
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
        if (!isset_Contest)
        {
          throw new TProtocolException(TProtocolException.INVALID_DATA);
        }
        if (!isset_Problems)
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
        var tmp91 = new TStruct("SaveContestInfoRequest");
        await oprot.WriteStructBeginAsync(tmp91, cancellationToken);
        var tmp92 = new TField();
        if((Contest != null))
        {
          tmp92.Name = "Contest";
          tmp92.Type = TType.Struct;
          tmp92.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp92, cancellationToken);
          await Contest.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Problems != null))
        {
          tmp92.Name = "Problems";
          tmp92.Type = TType.List;
          tmp92.ID = 2;
          await oprot.WriteFieldBeginAsync(tmp92, cancellationToken);
          {
            await oprot.WriteListBeginAsync(new TList(TType.Struct, Problems.Count), cancellationToken);
            foreach (global::CUGOJ.RPC.Gen.Common.ProblemStruct _iter93 in Problems)
            {
              await _iter93.WriteAsync(oprot, cancellationToken);
            }
            await oprot.WriteListEndAsync(cancellationToken);
          }
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Base != null) && __isset.@Base)
        {
          tmp92.Name = "Base";
          tmp92.Type = TType.Struct;
          tmp92.ID = 255;
          await oprot.WriteFieldBeginAsync(tmp92, cancellationToken);
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
      if (!(that is SaveContestInfoRequest other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return global::System.Object.Equals(Contest, other.Contest)
        && TCollections.Equals(Problems, other.Problems)
        && ((__isset.@Base == other.__isset.@Base) && ((!__isset.@Base) || (global::System.Object.Equals(Base, other.Base))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((Contest != null))
        {
          hashcode = (hashcode * 397) + Contest.GetHashCode();
        }
        if((Problems != null))
        {
          hashcode = (hashcode * 397) + TCollections.GetHashCode(Problems);
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
      var tmp94 = new StringBuilder("SaveContestInfoRequest(");
      if((Contest != null))
      {
        tmp94.Append(", Contest: ");
        Contest.ToString(tmp94);
      }
      if((Problems != null))
      {
        tmp94.Append(", Problems: ");
        Problems.ToString(tmp94);
      }
      if((Base != null) && __isset.@Base)
      {
        tmp94.Append(", Base: ");
        Base.ToString(tmp94);
      }
      tmp94.Append(')');
      return tmp94.ToString();
    }
  }

}