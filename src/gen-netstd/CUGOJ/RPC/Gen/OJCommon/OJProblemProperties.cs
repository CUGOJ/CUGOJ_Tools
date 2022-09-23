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

namespace CUGOJ.RPC.Gen.OJCommon
{

  public partial class OJProblemProperties : TBase
  {
    private int _timeLimit;
    private int _memoryLimit;
    private int _outputLimit;
    private int _stackLimit;
    private bool _specialJudge;
    private bool _interactive;
    private List<global::CUGOJ.RPC.Gen.OJCommon.CodeLanguage> _languages;

    public int TimeLimit
    {
      get
      {
        return _timeLimit;
      }
      set
      {
        __isset.timeLimit = true;
        this._timeLimit = value;
      }
    }

    public int MemoryLimit
    {
      get
      {
        return _memoryLimit;
      }
      set
      {
        __isset.memoryLimit = true;
        this._memoryLimit = value;
      }
    }

    public int OutputLimit
    {
      get
      {
        return _outputLimit;
      }
      set
      {
        __isset.outputLimit = true;
        this._outputLimit = value;
      }
    }

    public int StackLimit
    {
      get
      {
        return _stackLimit;
      }
      set
      {
        __isset.stackLimit = true;
        this._stackLimit = value;
      }
    }

    public bool SpecialJudge
    {
      get
      {
        return _specialJudge;
      }
      set
      {
        __isset.specialJudge = true;
        this._specialJudge = value;
      }
    }

    public bool Interactive
    {
      get
      {
        return _interactive;
      }
      set
      {
        __isset.interactive = true;
        this._interactive = value;
      }
    }

    public List<global::CUGOJ.RPC.Gen.OJCommon.CodeLanguage> Languages
    {
      get
      {
        return _languages;
      }
      set
      {
        __isset.languages = true;
        this._languages = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool timeLimit;
      public bool memoryLimit;
      public bool outputLimit;
      public bool stackLimit;
      public bool specialJudge;
      public bool interactive;
      public bool languages;
    }

    public OJProblemProperties()
    {
    }

    public OJProblemProperties DeepCopy()
    {
      var tmp0 = new OJProblemProperties();
      if(__isset.timeLimit)
      {
        tmp0.TimeLimit = this.TimeLimit;
      }
      tmp0.__isset.timeLimit = this.__isset.timeLimit;
      if(__isset.memoryLimit)
      {
        tmp0.MemoryLimit = this.MemoryLimit;
      }
      tmp0.__isset.memoryLimit = this.__isset.memoryLimit;
      if(__isset.outputLimit)
      {
        tmp0.OutputLimit = this.OutputLimit;
      }
      tmp0.__isset.outputLimit = this.__isset.outputLimit;
      if(__isset.stackLimit)
      {
        tmp0.StackLimit = this.StackLimit;
      }
      tmp0.__isset.stackLimit = this.__isset.stackLimit;
      if(__isset.specialJudge)
      {
        tmp0.SpecialJudge = this.SpecialJudge;
      }
      tmp0.__isset.specialJudge = this.__isset.specialJudge;
      if(__isset.interactive)
      {
        tmp0.Interactive = this.Interactive;
      }
      tmp0.__isset.interactive = this.__isset.interactive;
      if((Languages != null) && __isset.languages)
      {
        tmp0.Languages = this.Languages.DeepCopy();
      }
      tmp0.__isset.languages = this.__isset.languages;
      return tmp0;
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
              if (field.Type == TType.I32)
              {
                TimeLimit = await iprot.ReadI32Async(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.I32)
              {
                MemoryLimit = await iprot.ReadI32Async(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 3:
              if (field.Type == TType.I32)
              {
                OutputLimit = await iprot.ReadI32Async(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 4:
              if (field.Type == TType.I32)
              {
                StackLimit = await iprot.ReadI32Async(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 5:
              if (field.Type == TType.Bool)
              {
                SpecialJudge = await iprot.ReadBoolAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 6:
              if (field.Type == TType.Bool)
              {
                Interactive = await iprot.ReadBoolAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 7:
              if (field.Type == TType.List)
              {
                {
                  var _list1 = await iprot.ReadListBeginAsync(cancellationToken);
                  Languages = new List<global::CUGOJ.RPC.Gen.OJCommon.CodeLanguage>(_list1.Count);
                  for(int _i2 = 0; _i2 < _list1.Count; ++_i2)
                  {
                    global::CUGOJ.RPC.Gen.OJCommon.CodeLanguage _elem3;
                    _elem3 = (global::CUGOJ.RPC.Gen.OJCommon.CodeLanguage)await iprot.ReadI32Async(cancellationToken);
                    Languages.Add(_elem3);
                  }
                  await iprot.ReadListEndAsync(cancellationToken);
                }
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
        var tmp4 = new TStruct("OJProblemProperties");
        await oprot.WriteStructBeginAsync(tmp4, cancellationToken);
        var tmp5 = new TField();
        if(__isset.timeLimit)
        {
          tmp5.Name = "timeLimit";
          tmp5.Type = TType.I32;
          tmp5.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp5, cancellationToken);
          await oprot.WriteI32Async(TimeLimit, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.memoryLimit)
        {
          tmp5.Name = "memoryLimit";
          tmp5.Type = TType.I32;
          tmp5.ID = 2;
          await oprot.WriteFieldBeginAsync(tmp5, cancellationToken);
          await oprot.WriteI32Async(MemoryLimit, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.outputLimit)
        {
          tmp5.Name = "outputLimit";
          tmp5.Type = TType.I32;
          tmp5.ID = 3;
          await oprot.WriteFieldBeginAsync(tmp5, cancellationToken);
          await oprot.WriteI32Async(OutputLimit, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.stackLimit)
        {
          tmp5.Name = "stackLimit";
          tmp5.Type = TType.I32;
          tmp5.ID = 4;
          await oprot.WriteFieldBeginAsync(tmp5, cancellationToken);
          await oprot.WriteI32Async(StackLimit, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.specialJudge)
        {
          tmp5.Name = "specialJudge";
          tmp5.Type = TType.Bool;
          tmp5.ID = 5;
          await oprot.WriteFieldBeginAsync(tmp5, cancellationToken);
          await oprot.WriteBoolAsync(SpecialJudge, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.interactive)
        {
          tmp5.Name = "interactive";
          tmp5.Type = TType.Bool;
          tmp5.ID = 6;
          await oprot.WriteFieldBeginAsync(tmp5, cancellationToken);
          await oprot.WriteBoolAsync(Interactive, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Languages != null) && __isset.languages)
        {
          tmp5.Name = "languages";
          tmp5.Type = TType.List;
          tmp5.ID = 7;
          await oprot.WriteFieldBeginAsync(tmp5, cancellationToken);
          await oprot.WriteListBeginAsync(new TList(TType.I32, Languages.Count), cancellationToken);
          foreach (global::CUGOJ.RPC.Gen.OJCommon.CodeLanguage _iter6 in Languages)
          {
            await oprot.WriteI32Async((int)_iter6, cancellationToken);
          }
          await oprot.WriteListEndAsync(cancellationToken);
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
      if (!(that is OJProblemProperties other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.timeLimit == other.__isset.timeLimit) && ((!__isset.timeLimit) || (global::System.Object.Equals(TimeLimit, other.TimeLimit))))
        && ((__isset.memoryLimit == other.__isset.memoryLimit) && ((!__isset.memoryLimit) || (global::System.Object.Equals(MemoryLimit, other.MemoryLimit))))
        && ((__isset.outputLimit == other.__isset.outputLimit) && ((!__isset.outputLimit) || (global::System.Object.Equals(OutputLimit, other.OutputLimit))))
        && ((__isset.stackLimit == other.__isset.stackLimit) && ((!__isset.stackLimit) || (global::System.Object.Equals(StackLimit, other.StackLimit))))
        && ((__isset.specialJudge == other.__isset.specialJudge) && ((!__isset.specialJudge) || (global::System.Object.Equals(SpecialJudge, other.SpecialJudge))))
        && ((__isset.interactive == other.__isset.interactive) && ((!__isset.interactive) || (global::System.Object.Equals(Interactive, other.Interactive))))
        && ((__isset.languages == other.__isset.languages) && ((!__isset.languages) || (TCollections.Equals(Languages, other.Languages))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if(__isset.timeLimit)
        {
          hashcode = (hashcode * 397) + TimeLimit.GetHashCode();
        }
        if(__isset.memoryLimit)
        {
          hashcode = (hashcode * 397) + MemoryLimit.GetHashCode();
        }
        if(__isset.outputLimit)
        {
          hashcode = (hashcode * 397) + OutputLimit.GetHashCode();
        }
        if(__isset.stackLimit)
        {
          hashcode = (hashcode * 397) + StackLimit.GetHashCode();
        }
        if(__isset.specialJudge)
        {
          hashcode = (hashcode * 397) + SpecialJudge.GetHashCode();
        }
        if(__isset.interactive)
        {
          hashcode = (hashcode * 397) + Interactive.GetHashCode();
        }
        if((Languages != null) && __isset.languages)
        {
          hashcode = (hashcode * 397) + TCollections.GetHashCode(Languages);
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp7 = new StringBuilder("OJProblemProperties(");
      int tmp8 = 0;
      if(__isset.timeLimit)
      {
        if(0 < tmp8++) { tmp7.Append(", "); }
        tmp7.Append("TimeLimit: ");
        TimeLimit.ToString(tmp7);
      }
      if(__isset.memoryLimit)
      {
        if(0 < tmp8++) { tmp7.Append(", "); }
        tmp7.Append("MemoryLimit: ");
        MemoryLimit.ToString(tmp7);
      }
      if(__isset.outputLimit)
      {
        if(0 < tmp8++) { tmp7.Append(", "); }
        tmp7.Append("OutputLimit: ");
        OutputLimit.ToString(tmp7);
      }
      if(__isset.stackLimit)
      {
        if(0 < tmp8++) { tmp7.Append(", "); }
        tmp7.Append("StackLimit: ");
        StackLimit.ToString(tmp7);
      }
      if(__isset.specialJudge)
      {
        if(0 < tmp8++) { tmp7.Append(", "); }
        tmp7.Append("SpecialJudge: ");
        SpecialJudge.ToString(tmp7);
      }
      if(__isset.interactive)
      {
        if(0 < tmp8++) { tmp7.Append(", "); }
        tmp7.Append("Interactive: ");
        Interactive.ToString(tmp7);
      }
      if((Languages != null) && __isset.languages)
      {
        if(0 < tmp8++) { tmp7.Append(", "); }
        tmp7.Append("Languages: ");
        Languages.ToString(tmp7);
      }
      tmp7.Append(')');
      return tmp7.ToString();
    }
  }

}
