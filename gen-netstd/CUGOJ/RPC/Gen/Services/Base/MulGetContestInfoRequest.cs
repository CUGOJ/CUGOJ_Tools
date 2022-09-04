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

  public partial class MulGetContestInfoRequest : TBase
  {
    private bool _IsGetContestContent;
    private global::CUGOJ.RPC.Gen.Base.@Base _Base;

    public List<long> ContestIDList { get; set; }

    public bool IsGetContestContent
    {
      get
      {
        return _IsGetContestContent;
      }
      set
      {
        __isset.IsGetContestContent = true;
        this._IsGetContestContent = value;
      }
    }

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
      public bool IsGetContestContent;
      public bool @Base;
    }

    public MulGetContestInfoRequest()
    {
    }

    public MulGetContestInfoRequest(List<long> ContestIDList) : this()
    {
      this.ContestIDList = ContestIDList;
    }

    public MulGetContestInfoRequest DeepCopy()
    {
      var tmp80 = new MulGetContestInfoRequest();
      if((ContestIDList != null))
      {
        tmp80.ContestIDList = this.ContestIDList.DeepCopy();
      }
      if(__isset.IsGetContestContent)
      {
        tmp80.IsGetContestContent = this.IsGetContestContent;
      }
      tmp80.__isset.IsGetContestContent = this.__isset.IsGetContestContent;
      if((Base != null) && __isset.@Base)
      {
        tmp80.Base = (global::CUGOJ.RPC.Gen.Base.@Base)this.Base.DeepCopy();
      }
      tmp80.__isset.@Base = this.__isset.@Base;
      return tmp80;
    }

    public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        bool isset_ContestIDList = false;
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
              if (field.Type == TType.List)
              {
                {
                  TList _list81 = await iprot.ReadListBeginAsync(cancellationToken);
                  ContestIDList = new List<long>(_list81.Count);
                  for(int _i82 = 0; _i82 < _list81.Count; ++_i82)
                  {
                    long _elem83;
                    _elem83 = await iprot.ReadI64Async(cancellationToken);
                    ContestIDList.Add(_elem83);
                  }
                  await iprot.ReadListEndAsync(cancellationToken);
                }
                isset_ContestIDList = true;
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.Bool)
              {
                IsGetContestContent = await iprot.ReadBoolAsync(cancellationToken);
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
        if (!isset_ContestIDList)
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
        var tmp84 = new TStruct("MulGetContestInfoRequest");
        await oprot.WriteStructBeginAsync(tmp84, cancellationToken);
        var tmp85 = new TField();
        if((ContestIDList != null))
        {
          tmp85.Name = "ContestIDList";
          tmp85.Type = TType.List;
          tmp85.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp85, cancellationToken);
          {
            await oprot.WriteListBeginAsync(new TList(TType.I64, ContestIDList.Count), cancellationToken);
            foreach (long _iter86 in ContestIDList)
            {
              await oprot.WriteI64Async(_iter86, cancellationToken);
            }
            await oprot.WriteListEndAsync(cancellationToken);
          }
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.IsGetContestContent)
        {
          tmp85.Name = "IsGetContestContent";
          tmp85.Type = TType.Bool;
          tmp85.ID = 2;
          await oprot.WriteFieldBeginAsync(tmp85, cancellationToken);
          await oprot.WriteBoolAsync(IsGetContestContent, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Base != null) && __isset.@Base)
        {
          tmp85.Name = "Base";
          tmp85.Type = TType.Struct;
          tmp85.ID = 255;
          await oprot.WriteFieldBeginAsync(tmp85, cancellationToken);
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
      if (!(that is MulGetContestInfoRequest other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return TCollections.Equals(ContestIDList, other.ContestIDList)
        && ((__isset.IsGetContestContent == other.__isset.IsGetContestContent) && ((!__isset.IsGetContestContent) || (global::System.Object.Equals(IsGetContestContent, other.IsGetContestContent))))
        && ((__isset.@Base == other.__isset.@Base) && ((!__isset.@Base) || (global::System.Object.Equals(Base, other.Base))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((ContestIDList != null))
        {
          hashcode = (hashcode * 397) + TCollections.GetHashCode(ContestIDList);
        }
        if(__isset.IsGetContestContent)
        {
          hashcode = (hashcode * 397) + IsGetContestContent.GetHashCode();
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
      var tmp87 = new StringBuilder("MulGetContestInfoRequest(");
      if((ContestIDList != null))
      {
        tmp87.Append(", ContestIDList: ");
        ContestIDList.ToString(tmp87);
      }
      if(__isset.IsGetContestContent)
      {
        tmp87.Append(", IsGetContestContent: ");
        IsGetContestContent.ToString(tmp87);
      }
      if((Base != null) && __isset.@Base)
      {
        tmp87.Append(", Base: ");
        Base.ToString(tmp87);
      }
      tmp87.Append(')');
      return tmp87.ToString();
    }
  }

}
